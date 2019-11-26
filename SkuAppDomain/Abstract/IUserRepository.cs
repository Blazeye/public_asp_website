using SkuAppDomain.Entities;
using System;
using System.Collections.Generic;

namespace SkuAppDomain.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }
        IEnumerable<Role> Roles { get; }
    }
}
