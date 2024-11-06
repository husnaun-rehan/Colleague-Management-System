
namespace CMS.Core.Models
{
    public class TeacherDto
    {
        public TeacherDto(int id,string name,string description, string type)
        {
            Id = id;
            Name = name;
            Description = description;
            Type = type;
            
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

    }
}
