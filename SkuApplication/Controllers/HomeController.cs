using SkuAppDomain.Abstract;
using System.Linq;
using System.Web.Mvc;
using SkuApplication.Models;
using System;
using System.Diagnostics;
using System.Data.Entity.Validation;
using SkuAppDomain.Entities;
using System.Collections.Generic;

namespace SkuApplication.Controllers
{
    public class HomeController : Controller
    {
        private ICommentRepository<Comment> comments;
        private IGenericRepository<Message> messages;
        public int PageSize = 3;


        public HomeController(  IGenericRepository<Message> Messages,
                                ICommentRepository<Comment> commentRepository   )
        {
            this.comments = commentRepository;
            this.messages = Messages;
        }


        public List<LogComment> Comments()
        {
            int role = 1;
            if(Session != null && Session["clearance"] != null) 
            { 
                role = Convert.ToInt32(Session["clearance"]); 
            }
            return comments.FilterComments(role);
        }


        public ViewResult Index(string category, string subject, string date, bool? marked, bool? followup, int page = 1, string followupDescr = null)
        {
            DateTime filterAfter = CalculateStartTime(date);
            var comments = this.Comments();
            if(followupDescr == "") { followupDescr = null; }

            var commentList = comments.Where(p => category == null || p.Category == category)
                .Where(p => subject == null || p.Subject == subject || p.Category == subject || subject == "Alle categorieën en onderwerpen")
                .Where(p => p.UpdatedDate > filterAfter)
                .Where(p => marked == null || marked == false || p.IsMarked == (bool)marked || (p.IsComment == false && p.HasMarkedComment))
                .Where(p => followup == null || followup == false || p.IsFollowUp == (bool)followup)
                .Where(p => followupDescr == null || followupDescr == p.FollowUpRole || (followupDescr == "Medewerker" && p.FollowUpRole.Contains("Medewerker")) || (followupDescr == "MijnOpvolgingen" && p.FollowUpName == Convert.ToString(Session["username"])))
                .ToList();

            var startPage = commentList.Where(i => i.IsComment == false).ElementAtOrDefault((page - 1) * PageSize);
            var endPage = commentList.Where(i => i.IsComment == false).ElementAtOrDefault((page) * PageSize);

            int startPageIndx = 0;
            int totalTaken = commentList.Count();
       
            if (startPage != null) { startPageIndx = commentList.IndexOf(startPage);
                if (endPage != null) { totalTaken = (commentList.IndexOf(endPage) - startPageIndx); }
            }

            int nrMessages = commentList.Where(i => i.IsComment == false).Count();
            double totalPages = Convert.ToDouble(nrMessages) / Convert.ToDouble(PageSize);

            CommentListViewModel model = new CommentListViewModel()
            {
                CommentList = commentList
                .Skip(startPageIndx)
                .Take(totalTaken)
                .ToList(), 
                SearchData = new SearchInfo 
                { 
                    CurrentCategory = category, 
                    CurrentSubject = subject, 
                    CurrentDate = date, 
                    CurrentFollowup = followup, 
                    CurrentMarked = marked 
                },
                PagingData = new PagingInfo
                {
                    CurrentPage = page,
                    TotalPages = (int)Math.Ceiling(totalPages)
                }
            };

            return View(model);
        }

        private DateTime CalculateStartTime(string date)
        {
            DateTime now = DateTime.Now;
            switch (date)
            {
                default:
                case "Alle berichten":
                    return new DateTime(0);

                case "Sinds laatste logout":
                    if(Session["last_logout"] == null) {
                        return new DateTime(0);
                    }
                    return Convert.ToDateTime(Session["last_logout"]);

                case "Afgelopen 24 uur":
                    return now.AddHours(-24);

                case "Afgelopen week":
                    return now.Date.AddDays(-7); // seven days since midnight today

                case "Afgelopen maand":
                    return now.Date.AddMonths(-1); // a month prior to midnight today
            }
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        // Get: Home/Update
        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(int ArgUserId, int ArgMessageId, string ArgComment)
        {
            try
            {
                if (Session["user"] != null)
                {
                    DateTime ArgCreatedAt = DateTime.Now;
                    DateTime ArgUpdatedAt = DateTime.Now;
                    Byte ArgMarked = 0;
                    comments.UpdateAndSubmit(new Comment
                    {
                        user_id = ArgUserId,
                        message_id = ArgMessageId,
                        comment = ArgComment,
                        marked = ArgMarked,
                        created_at = ArgCreatedAt,
                        updated_at = ArgUpdatedAt
                    });

                    return RedirectToAction("Index", "Home");
                }
                return View(ArgComment);
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

        
        [HttpPost]
        public ActionResult SetFollowupDate(int actualId)
        {
            try
            {

                var messageToUpdate = messages.GetById(actualId);
                var active = messageToUpdate.followup_date = DateTime.Now;
                messages.UpdateAndSubmit(messageToUpdate);
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


        [HttpPost]
        public ActionResult SetFollowupUser(int actualId)
        {
            try
            {

                var messageToUpdate = messages.GetById(actualId);
                var active = messageToUpdate.followup_user_id = Convert.ToInt32(Session["id"]);
                messages.UpdateAndSubmit(messageToUpdate);
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




        [HttpPost]
        public ActionResult SetMessageMarked(int actualId)
        {
            try
            {

                var messageToUpdate = messages.GetById(actualId);
                var active = messageToUpdate.marked;
                switch (active)
                {
                    case 0:
                        messageToUpdate.marked = 1;
                        break;
                    case 1:
                        messageToUpdate.marked = 0;
                        break;
                    default:
                        break;
                }
                messages.UpdateAndSubmit(messageToUpdate);
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


        [HttpPost]
        public ActionResult SetCommentMarked(int actualId)
        {
            try
            {

                var commentToUpdate = comments.GetById(actualId);
                var active = commentToUpdate.marked;
                switch (active)
                {
                    case 0:
                        commentToUpdate.marked = 1;
                        break;
                    case 1:
                        commentToUpdate.marked = 0;
                        break;
                    default:
                        break;
                }
                comments.UpdateAndSubmit(commentToUpdate);
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
                //return View();
            }
        }


        //Get: Home/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(int ArgUserId, int ArgMessageId, string ArgComment)
        {
            try
            {
                // TODO: Add insert logic here
                if (Session["user"] != null)
                {
                    DateTime ArgCreatedAt = DateTime.Now;
                    DateTime ArgUpdatedAt = DateTime.Now;
                    Byte ArgMarked = 0;
                    comments.InsertAndSubmit(new Comment {  user_id = ArgUserId,
                                                            message_id = ArgMessageId,
                                                            comment = ArgComment,
                                                            marked = ArgMarked,
                                                            created_at = ArgCreatedAt,
                                                            updated_at = ArgUpdatedAt  });

                    return RedirectToAction("Index", "Home");
                }
                return View();
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
