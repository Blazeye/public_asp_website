using SkuAppDomain.Abstract;
using SkuAppDomain.Entities;
using SkuApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace SkuApplication.Controllers
{
    public class MessageController : Controller
    {
        INavRepository<Category> categories;
        IMessageRepository<Message> messages;
        IMessageRepository<Comment> comments;
        IGenericRepository<Role> roles;
        IGenericRepository<User> users;

        public MessageController(INavRepository<Category> Categories,
                                 IMessageRepository<Message> Messages,
                                 IMessageRepository<Comment> Comments,
                                 IGenericRepository<Role> Roles,
                                 IGenericRepository<User> Users)
        {
            this.categories = Categories;
            this.messages = Messages;
            this.comments = Comments;
            this.roles = Roles;
            this.users = Users;
        }

        // GET: Message/Message
        public ViewResult Message(string category, string message, string role, bool marked = false, bool followup = false, int followupUser = 0)
        {
            ViewBag.SelectedMessage = message;
            ViewBag.SelectedRole = role;

            List<User> followupUsernames = users.GetAll().Where(i => i.role >= 3).ToList();

            var itemList = categories.GetMenuItems(null);
            var roleList = roles.GetAll().ToList();
            MessageViewModel model = new MessageViewModel { CategoryList = itemList, RoleList = roleList, ArgItem = category, IsMarked = marked, HasFollowup = followup, FollowupUser = followupUser, FollowupUsernames = followupUsernames };

            return View(model);
        }

        // GET: Message/EditMessage
        public ActionResult EditMessage(int messageId, bool IsComment )
        {
            Message message = null;
            Comment comment = null;
            bool isMarked = false;
            bool hasFollowup = false;
            int followupUser = 0; 

            try
            {
                if (IsComment) { comment = comments.GetById(messageId); isMarked = Convert.ToBoolean(comment.marked); }
                else { message = messages.GetById(messageId); isMarked = Convert.ToBoolean(message.marked); hasFollowup = Convert.ToBoolean(message.followup); 
                    followupUser = Convert.ToInt32(message.visible_for_role_id); }
                var itemList = categories.GetMenuItems(null);
                var roleList = roles.GetAll().ToList();

                MessageViewModel model = new MessageViewModel
                {
                    CategoryList = itemList,
                    RoleList = roleList,
                    Message = message,
                    Comment = comment,
                    IsComment = IsComment,
                    ArgItem = null,
                    HasFollowup = hasFollowup,
                    IsMarked = isMarked,
                    FollowupUser = followupUser,
                };
                return View(model);
            }

            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }

        //GET: Message/Create
        [HttpGet]
        public ActionResult Create(string ArgItem, string message)
        {
            ViewBag.SelectedSubject = ArgItem;

            return View(message);
        }

        // POST: Message/Create
        [HttpPost]
        public ActionResult Create(string ArgItem, string message, int visibleToRoleId, bool marked, bool followup, int followupUser = 0)
        {
            try
            {
                int? userid = Convert.ToInt32(Session["id"]);
                byte bytemarked = Convert.ToByte(marked);
                byte bytefollowup = Convert.ToByte(followup);
                Message messageToAdd = messages.SaveNewMessage(ArgItem, message, userid, visibleToRoleId, bytemarked, bytefollowup, followupUser);
                messages.InsertAndSubmit(messageToAdd);

                return RedirectToAction("Index", "Home");
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Value: \"{1}\" Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        [HttpGet]
        public ActionResult UpdateMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateMessage(int messageId, string message, int visibleToRoleId, bool? marked)
        {
            try
            {
                var messageToChange = messages.GetById(messageId);
                messageToChange.marked = Convert.ToByte(marked);
                messageToChange.message = message;
                messageToChange.visible_for_role_id = visibleToRoleId;
                messageToChange.updated_at = DateTime.Now;
                
                messages.UpdateAndSubmit(messageToChange);

                return RedirectToAction("Index", "Home");
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Value: \"{1}\" Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
        [HttpGet]
        public ActionResult UpdateComment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateComment(int commentId, string comment, bool? marked)
        {
            try
            {
                var commentToChange = comments.GetById(commentId);
                commentToChange.marked = Convert.ToByte(marked);
                commentToChange.comment = comment;
                commentToChange.updated_at = DateTime.Now;

                comments.UpdateAndSubmit(commentToChange);

                return RedirectToAction("Index", "Home");
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Value: \"{1}\" Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}