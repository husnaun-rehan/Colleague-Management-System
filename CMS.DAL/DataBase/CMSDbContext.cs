using CMS.Repositories.Entities;
using System.Data.Entity;

namespace CMS.Repositories.DataBase
{
    public class CMSDbContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }

        public CMSDbContext() : base("data source=RANA-AMEER-HAMZ; initial Catalog=CMS_DB; integrated security=SSPI")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Teacher>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Teacher>()
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Teacher>()
                .Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<Teacher>()
                .Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
