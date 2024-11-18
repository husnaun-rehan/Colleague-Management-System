using System;
using System.Threading.Tasks;
using CMS.Core.Interfaces;
using CMS.Core.Models;
using CMS.Services;
using System.Text;

class Program
{
    static async Task Main(string[] args)
    {
        ITeacherService teacherService = new TeacherService();

        StringBuilder headerdesign = new StringBuilder();
        headerdesign
            .Append('-', 120)
            .AppendLine()
            .Append(' ', 45)
            .Append("College Management System")
            .Append(' ', 45)
            .AppendLine()
            .Append('-', 120);
        Console.WriteLine(headerdesign);

        while (true)
        {
            Console.Write("\t\tMAIN MENU\n" +
                          "SELECT OPTION FROM GIVEN BELOW:\n" +
                          "1: Add Teacher\n" +
                          "2: View Teacher\n" +
                          "3: View All Teachers\n" +
                          "4: Update Teacher\n" +
                          "5: Delete Teacher\n" +
                          "ENTER OPTION: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Name: ");
                    var name = Console.ReadLine();
                    Console.Write("Enter Description: ");
                    var description = Console.ReadLine();
                    Console.Write("Enter Type: ");
                    var type = Console.ReadLine();
                    var newTeacher = new TeacherDto(0, name, description, type); // Id set to 0, but ignored in AddTeacherAsync
                    await teacherService.AddTeacherAsync(newTeacher);
                    Console.WriteLine("Teacher added.");
                    break;

                case "2":
                    Console.Write("Enter ID: ");
                    var id = int.Parse(Console.ReadLine());
                    var teacher = await teacherService.GetTeacherByIdAsync(id);
                    if (teacher != null)
                    {
                        Console.WriteLine($"ID: {teacher.Id}, Name: {teacher.Name}, Description: {teacher.Description}, Type: {teacher.Type}");
                    }
                    else
                    {
                        Console.WriteLine("Teacher not found.");
                    }
                    break;

                case "3":
                    var teachers = await teacherService.GetTeachersAsync();
                    foreach (var t in teachers)
                    {
                        Console.WriteLine($"ID: {t.Id}, Name: {t.Name}, Description: {t.Description}, Type: {t.Type}");
                    }
                    break;

                case "4":
                    Console.Write("Enter ID: ");
                    var updateId = int.Parse(Console.ReadLine());
                    var updateTeacher = await teacherService.GetTeacherByIdAsync(updateId);
                    if (updateTeacher != null)
                    {
                        Console.Write("Enter New Name: ");
                        updateTeacher.Name = Console.ReadLine();
                        Console.Write("Enter New Description: ");
                        updateTeacher.Description = Console.ReadLine();
                        Console.Write("Enter New Type: ");
                        updateTeacher.Type = Console.ReadLine();
                        await teacherService.UpdateTeacherAsync(updateTeacher);
                        Console.WriteLine("Teacher updated.");
                    }
                    else
                    {
                        Console.WriteLine("Teacher not found.");
                    }
                    break;

                case "5":
                    Console.Write("Enter ID: ");
                    var deleteId = int.Parse(Console.ReadLine());
                    await teacherService.DeleteTeacherAsync(deleteId);
                    Console.WriteLine("Teacher deleted.");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
