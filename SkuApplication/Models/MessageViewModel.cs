using SkuAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkuApplication.Models
{
    public class MessageViewModel
    {
        public List<MenuItem> CategoryList { get; set; }

        public List<Role> RoleList { get; set; }

        public Message Message { get; set; }

        public Comment Comment { get; set; }

        public bool IsComment { get; set; }

        public string ArgItem { get; set; }

        public bool IsMarked { get; set; }

        public bool HasFollowup { get; set; }

        public int FollowupUser { get; set; }

        public List<User> FollowupUsernames { get; set; }
    }
}