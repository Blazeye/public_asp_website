using MySql.Data.EntityFramework;
using SkuAppDomain.Abstract;
using System;
using System.Data.Entity;

namespace SkuAppDomain.Entities
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class EFDbContext : DbContext, IDbContext
    {
        public EFDbContext() : base("super_awesome_child_farm") // look in Web.config for name
        {
            Database.SetInitializer<EFDbContext>(null); // disables "code-first" database
            Database.Log = delegate (string message) {
                Console.Write(message);
            };
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Color> Colors { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<Message> Messages { get; set; }
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<Subject> Subjects { get; set; }
        public IDbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }

        public void ExecuteCommand(string command, params object[] parameters)
        {
            base.Database.ExecuteSqlCommand(command, parameters);
        }
    }
}
