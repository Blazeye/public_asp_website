using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SkuAppDomain.Entities;

namespace SkuAppDomain.EntityFrameworkTest.LogData
{
    public partial class EFFarmContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Category>(entity =>
            //{
            //    entity.HasKey(e => e.id)
            //        .HasName("PK_Category");

            //    entity.Property(e => e.active)
            //        .HasColumnType("tinyint(1)")
            //        .IsRequired();

            //    entity.Property(e => e.is_dier)
            //        .HasColumnType("tinyint(1)")
            //        .IsRequired();

            //    entity.Property(e => e.name)
            //        .HasColumnType("varchar(100)")
            //        .IsRequired();



            //});

            //modelBuilder.Entity<Color>(entity =>
            //{

            //});
        }
    }
}
