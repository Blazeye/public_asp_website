using SkuAppDomain.Entities;
using System.Collections.Generic;



namespace SkuApplication.Models
{
    public class NavMenuViewModel
    {
        public List<MenuItem> MenuCatItems { get; set; }
        public List<string> MenuDateItems { get; set; }
        public bool MenuIsMarked { get; set; }
        public bool MenuHasFollowup { get; set; }
        public string MenuFollowupRoleItems { get; set; }

        public NavMenuViewModel()
        {
            this.MenuCatItems = new List<MenuItem>();
        }
    }
}