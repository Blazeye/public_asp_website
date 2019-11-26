using SkuAppDomain.Abstract;
using System.Collections.Generic;
using System.Linq;
using SkuAppDomain.Entities;
using System.Web.Mvc;
using SkuApplication.Models;
using System;

namespace SkuApplication.Controllers
{
    public class NavController : Controller
    {
        private INavRepository<Category> repository;

        public NavController(INavRepository<Category> Repository)
        {
            repository = Repository;
        }

        public PartialViewResult Menu(string category = null, string subject = null, string date = null, bool marked = false, bool followup = false, string followupDescr = null)
        {
            ViewBag.SelectedCategory = category;
            ViewBag.SelectedSubject = subject;
            ViewBag.SelectedDate = date;

            NavMenuViewModel menuList = new NavMenuViewModel();

            menuList.MenuCatItems = repository.GetMenuItems(null);
            menuList.MenuDateItems = new List<string> { "Alle berichten", "Sinds laatste logout", "Afgelopen 24 uur", "Afgelopen week", "Afgelopen maand" };
            menuList.MenuIsMarked = marked;
            menuList.MenuHasFollowup = followup;
            menuList.MenuFollowupRoleItems = followupDescr;
            return PartialView(menuList);
        }
    }
}