// See https://aka.ms/new-console-template for more information
using CMS.Core.Interfaces;
using CMS.Core.Models;
using CMS.Services;

Console.WriteLine("College Manaagement System");

TeacherDto teacher = new TeacherDto(1,"Hasnain","teacher","Computer Teacher");
TeacherDto teacher1 = new TeacherDto(2,"Ali","teacher","Math Teacher");

ITeacherService teacherService = new TeacherService();

await teacherService.AddTeacherAsync(teacher);
