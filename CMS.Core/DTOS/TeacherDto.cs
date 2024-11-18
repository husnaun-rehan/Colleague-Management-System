﻿namespace CMS.Core.Models
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int DepartmentId { get; set; }

        public TeacherDto(int id, string name, string description, string type, int departmentId)
        {
            Id = id;
            Name = name;
            Description = description;
            Type = type;
            DepartmentId = departmentId;
        }
    }
}
