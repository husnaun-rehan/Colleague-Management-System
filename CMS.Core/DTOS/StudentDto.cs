namespace CMS.Core.Models
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EnrollmentNumber { get; set; }
        public int DepartmentId { get; set; }
        public List<int> CourseIds { get; set; }

        public StudentDto(int id, string name, string enrollmentNumber, int departmentId, List<int> courseIds)
        {
            Id = id;
            Name = name;
            EnrollmentNumber = enrollmentNumber;
            DepartmentId = departmentId;
            CourseIds = courseIds;
        }
    }
}
