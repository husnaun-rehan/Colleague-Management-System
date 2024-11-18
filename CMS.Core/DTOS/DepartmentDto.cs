namespace CMS.Core.Models
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DepartmentDto(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
