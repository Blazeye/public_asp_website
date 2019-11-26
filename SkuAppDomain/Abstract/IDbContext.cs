using SkuAppDomain.Entities;
using System.Data.Entity;
using System.Linq;

namespace SkuAppDomain.Abstract
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        IDbSet<Category> Categories { get; set; }
        IDbSet<Color> Colors { get; set; }
        IDbSet<Comment> Comments { get; set; }
        IDbSet<Message> Messages { get; set; }
        IDbSet<Role> Roles { get; set; }
        IDbSet<Subject> Subjects { get; set; }
        IDbSet<User> Users { get; set; }
        void ExecuteCommand(string command, params object[] parameters);
        int SaveChanges();
    }
}
