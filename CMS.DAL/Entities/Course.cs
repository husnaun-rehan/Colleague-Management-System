namespace CMS.Repositories.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; } // Navigation property
        public ICollection<Student> Students { get; set; } // Navigation property
    }
}
