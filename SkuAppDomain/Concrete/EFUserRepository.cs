using SkuAppDomain.Abstract;
using SkuAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SkuAppDomain.Entities
{
    public class EFUserRepository : IUserRepository
    {
        private readonly EFDbContext context = new EFDbContext();
        public virtual IEnumerable<User> Users
        {
            get { return context.Users.ToList(); }
            set { value = context.Users.ToList(); }
        }
        public virtual IEnumerable<Role> Roles
        {
            get { return context.Roles.ToList(); }
            set { value = context.Roles.ToList(); }
        }
    }
}
