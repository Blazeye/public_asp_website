using SkuAppDomain.Abstract;
using SkuAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SkuAppDomain.Entities
{
    //public class EFMssgRepository : IMssgRepository
    //{
    //    private EFDbContext context = new EFDbContext();

    //    public virtual IEnumerable<Category> Categories
    //    {
    //        get { return context.Categories.ToList(); }
    //    }
    //    public virtual IEnumerable<Color> Colors
    //    {
    //        get { return context.Colors.ToList(); }
    //    }
    //    public virtual IEnumerable<Comment> Comments
    //    {
    //        get { return context.Comments; }
    //        set {
    //            value = context.Comments.ToList();

    //            //var dingus = context.Comments.Find(id);
    //            //dingus.comment = value;
    //            //context.SaveChanges();

    //            /*if (!string.IsNullOrEmpty(value)) { context.Comments.Where(m => m.id == id).SelectMany(m => m.comment).First(p => p.ToString = value)} */
    //        }
    //    }
    //    public virtual IEnumerable<Message> Messages
    //    {
    //        get { return context.Messages.ToList(); }
    //    }
    //    public virtual IEnumerable<Subject> Subjects
    //    {
    //        get { return context.Subjects.ToList(); }
    //    }
    //    public virtual IEnumerable<User> Users
    //    {
    //        get { return context.Users.ToList(); }
    //    }
    //}
}
