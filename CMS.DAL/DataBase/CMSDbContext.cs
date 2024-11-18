using System.Data.Entity;
using CMS.Repositories.Entities;

namespace CMS.Repositories.DataBase
{
    public class CMSDbContext : DbContext
    {
        public CMSDbContext() : base("name=CMSDbContext") 
        { 
        }


        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }

        // Configuration for relationships
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Teacher and Department relationship
            modelBuilder.Entity<Teacher>()
                .HasRequired(t => t.Department)
                .WithMany()
                .HasForeignKey(t => t.DepartmentId)
                .WillCascadeOnDelete(false);

            // Student and Department relationship
            modelBuilder.Entity<Student>()
                .HasRequired(s => s.Department)
                .WithMany()
                .HasForeignKey(s => s.DepartmentId)
                .WillCascadeOnDelete(false);

            // Course and Department relationship
            modelBuilder.Entity<Course>()
                .HasRequired(c => c.Department)
                .WithMany()
                .HasForeignKey(c => c.DepartmentId)
                .WillCascadeOnDelete(false);

            // Student and Course many-to-many relationship
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students)
                .Map(cs =>
                {
                    cs.MapLeftKey("StudentId");
                    cs.MapRightKey("CourseId");
                    cs.ToTable("StudentCourses");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
