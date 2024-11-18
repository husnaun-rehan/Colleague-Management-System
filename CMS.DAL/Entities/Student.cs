namespace CMS.Repositories.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EnrollmentNumber { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; } // Navigation property
        public ICollection<Course> Courses { get; set; } // Navigation property
    }
}
