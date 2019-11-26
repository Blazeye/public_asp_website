using System;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;
using CryptSharp;
using SkuAppDomain.Abstract;
using SkuAppDomain.Entities;
using SkuApplication.Abstract;
using SkuApplication.Models;

namespace SkuApplication.Controllers
{
    public class UserController : Controller, IUserController
    {

        public IGenericRepository<User> users;

        public UserController(IGenericRepository<User> Users)
        {
            this.users = Users;
        }

        // GET: User
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            try
            {
                if (login.Password != null)
                {
                    // code below encrypts passwords
                    // string cryptedPassword = Crypter.Blowfish.Crypt(login.Password, new CrypterOptions() { { CrypterOption.Variant, BlowfishCrypterVariant.Corrected }, { CrypterOption.Rounds, 10 } });



                    var user = users.GetById(users.GetIdByUsername(login.UserName));
                    if (user != null)
                    {
                        bool cool = Crypter.CheckPassword(login.Password, user.encrypted_password);
                        Session.Timeout = 20;
                        Session["user"] = user;
                        Session["id"] = user.id;
                        Session["username"] = user.username;
                        Session["clearance"] = user.role;
                        Session["last_logout"] = user.last_logout;
                        return RedirectToAction("Index", new RouteValueDictionary(
                            new { controller = "Home", action = "Index" }));
                    }
                    return View(login);
                }
                return View(login);
            }
            catch(DbEntityValidationException e)
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

        public ActionResult Logout()
        {
            if(HttpContext.Session["username"] != null)
            {
                Session.Abandon();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    //User user = userRepository.Add(collection);
                    return RedirectToAction("Login", new LoginViewModel { });
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult EditLastLogout(int userid, DateTime last_logout )
        {

            try
            {
                var userToUpdate = users.GetById(userid);
                userToUpdate.last_logout = last_logout;
                users.UpdateAndSubmit(userToUpdate);
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

        

        public string GetErrorMessage()
        {
            return $"Heb de gebruiker niet kunnen vinden; Check aub of uw ingevulde gegevens wel kloppen";
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        //[AcceptVerbs("Get", "Post")]
        //public ActionResult VerifyUser(string username)
        //{

        //    if (users.GetIdByUsername(username) != 0)
        //    {
        //        return Json($"Username {username} is already in use.");
        //    }

        //    return Json(true);
        //}
    }
}
