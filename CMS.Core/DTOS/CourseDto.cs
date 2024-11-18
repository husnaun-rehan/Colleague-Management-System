namespace CMS.Core.Models
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public List<int> StudentIds { get; set; }

        public CourseDto(int id, string name, string description, int departmentId, List<int> studentIds)
        {
            Id = id;
            Name = name;
            Description = description;
            DepartmentId = departmentId;
            StudentIds = studentIds;
        }
    }
}
