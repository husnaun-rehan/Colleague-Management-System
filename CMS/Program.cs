using System;
using System.Threading.Tasks;
using CMS.Core.Interfaces;
using CMS.Core.Models;
using CMS.Services;
using CMS.Repositories;
using CMS.Repositories.DataBase;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using CMS.Core.Repositories;

class Program
{
    static async Task Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var teacherService = serviceProvider.GetRequiredService<ITeacherService>();
        var studentService = serviceProvider.GetRequiredService<IStudentService>();
        var courseService = serviceProvider.GetRequiredService<ICourseService>();
        var departmentService = serviceProvider.GetRequiredService<IDepartmentService>();

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
                          "1: Manage Teachers\n" +
                          "2: Manage Students\n" +
                          "3: Manage Courses\n" +
                          "4: Manage Departments\n" +
                          "5: Exit\n" + // Added exit option
                          "ENTER OPTION: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await ManageTeachers(teacherService);
                    break;

                case "2":
                    await ManageStudents(studentService);
                    break;

                case "3":
                    await ManageCourses(courseService);
                    break;

                case "4":
                    await ManageDepartments(departmentService);
                    break;

                case "5":
                    Environment.Exit(0); // Exit application
                    break;

                default:
                    Console.WriteLine("Invalid choice. Press any key to try again...");
                    Console.ReadKey();
                    break;
            }
        }

    }

    private static async Task ManageTeachers(ITeacherService teacherService)
    {
        while (true)
        {
            Console.WriteLine("Manage Teachers\n" +
                              "1: Add Teacher\n" +
                              "2: View Teacher\n" +
                              "3: View All Teachers\n" +
                              "4: Update Teacher\n" +
                              "5: Delete Teacher\n" +
                              "6: Back to Main Menu\n" +
                              "7: Exit\n" +
                              "ENTER OPTION: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Name: ");
                    var teacherName = Console.ReadLine();
                    Console.Write("Enter Description: ");
                    var teacherDescription = Console.ReadLine();
                    Console.Write("Enter Type: ");
                    var teacherType = Console.ReadLine();
                    Console.Write("Enter Department ID: ");
                    var teacherDepartmentId = int.Parse(Console.ReadLine());
                    var newTeacher = new TeacherDto(0, teacherName, teacherDescription, teacherType, teacherDepartmentId); // Added departmentId
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

                case "6":
                    return; // Back to Main Menu

                case "7":
                    Environment.Exit(0); // Exit application
                    break;

                default:
                    Console.WriteLine("Invalid choice. Press any key to try again...");
                    Console.ReadKey();
                    break;
            }
        }
    }


    private static async Task ManageStudents(IStudentService studentService)
    {
        while (true)
        {
            Console.WriteLine("Manage Students\n" +
                              "1: Add Student\n" +
                              "2: View Student\n" +
                              "3: View All Students\n" +
                              "4: Update Student\n" +
                              "5: Delete Student\n" +
                              "6: Back to Main Menu\n" +
                              "7: Exit\n" +
                              "ENTER OPTION: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Name: ");
                    var studentName = Console.ReadLine();
                    Console.Write("Enter Enrollment Number: ");
                    var enrollmentNumber = Console.ReadLine();
                    Console.Write("Enter Department ID: ");
                    var studentDepartmentId = int.Parse(Console.ReadLine());
                    var newStudent = new StudentDto(0, studentName, enrollmentNumber, studentDepartmentId, new List<int>()); // Added courseIds
                    await studentService.AddStudentAsync(newStudent);
                    Console.WriteLine("Student added.");
                    break;

                case "2":
                    Console.Write("Enter ID: ");
                    var id = int.Parse(Console.ReadLine());
                    var student = await studentService.GetStudentByIdAsync(id);
                    if (student != null)
                    {
                        Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Enrollment Number: {student.EnrollmentNumber}, Department ID: {student.DepartmentId}");
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                    break;

                case "3":
                    var students = await studentService.GetStudentsAsync();
                    foreach (var s in students)
                    {
                        Console.WriteLine($"ID: {s.Id}, Name: {s.Name}, Enrollment Number: {s.EnrollmentNumber}, Department ID: {s.DepartmentId}");
                    }
                    break;

                case "4":
                    Console.Write("Enter ID: ");
                    var updateId = int.Parse(Console.ReadLine());
                    var updateStudent = await studentService.GetStudentByIdAsync(updateId);
                    if (updateStudent != null)
                    {
                        Console.Write("Enter New Name: ");
                        updateStudent.Name = Console.ReadLine();
                        Console.Write("Enter New Enrollment Number: ");
                        updateStudent.EnrollmentNumber = Console.ReadLine();
                        Console.Write("Enter New Department ID: ");
                        updateStudent.DepartmentId = int.Parse(Console.ReadLine());
                        await studentService.UpdateStudentAsync(updateStudent);
                        Console.WriteLine("Student updated.");
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                    break;

                case "5":
                    Console.Write("Enter ID: ");
                    var deleteId = int.Parse(Console.ReadLine());
                    await studentService.DeleteStudentAsync(deleteId);
                    Console.WriteLine("Student deleted.");
                    break;

                case "6":
                    return; // Back to Main Menu

                case "7":
                    Environment.Exit(0); // Exit application
                    break;

                default:
                    Console.WriteLine("Invalid choice. Press any key to try again...");
                    Console.ReadKey();
                    break;
            }
        }
    }


    private static async Task ManageCourses(ICourseService courseService)
    {
        while (true)
        {
            Console.WriteLine("Manage Courses\n" +
                              "1: Add Course\n" +
                              "2: View Course\n" +
                              "3: View All Courses\n" +
                              "4: Update Course\n" +
                              "5: Delete Course\n" +
                              "6: Back to Main Menu\n" +
                              "7: Exit\n" +
                              "ENTER OPTION: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Name: ");
                    var courseName = Console.ReadLine();
                    Console.Write("Enter Description: ");
                    var courseDescription = Console.ReadLine();
                    Console.Write("Enter Department ID: ");
                    var courseDepartmentId = int.Parse(Console.ReadLine());
                    var newCourse = new CourseDto(0, courseName, courseDescription, courseDepartmentId, new List<int>()); // Added studentIds
                    await courseService.AddCourseAsync(newCourse);
                    Console.WriteLine("Course added.");
                    break;

                case "2":
                    Console.Write("Enter ID: ");
                    var id = int.Parse(Console.ReadLine());
                    var course = await courseService.GetCourseByIdAsync(id);
                    if (course != null)
                    {
                        Console.WriteLine($"ID: {course.Id}, Name: {course.Name}, Description: {course.Description}, Department ID: {course.DepartmentId}");
                    }
                    else
                    {
                        Console.WriteLine("Course not found.");
                    }
                    break;

                case "3":
                    var courses = await courseService.GetCoursesAsync();
                    foreach (var c in courses)
                    {
                        Console.WriteLine($"ID: {c.Id}, Name: {c.Name}, Description: {c.Description}, Department ID: {c.DepartmentId}");
                    }
                    break;

                case "4":
                    Console.Write("Enter ID: ");
                    var updateId = int.Parse(Console.ReadLine());
                    var updateCourse = await courseService.GetCourseByIdAsync(updateId);
                    if (updateCourse != null)
                    {
                        Console.Write("Enter New Name: ");
                        updateCourse.Name = Console.ReadLine();
                        Console.Write("Enter New Description: ");
                        updateCourse.Description = Console.ReadLine();
                        Console.Write("Enter New Department ID: ");
                        updateCourse.DepartmentId = int.Parse(Console.ReadLine());
                        await courseService.UpdateCourseAsync(updateCourse);
                        Console.WriteLine("Course updated.");
                    }
                    else
                    {
                        Console.WriteLine("Course not found.");
                    }
                    break;

                case "5":
                    Console.Write("Enter ID: ");
                    var deleteId = int.Parse(Console.ReadLine());
                    await courseService.DeleteCourseAsync(deleteId);
                    Console.WriteLine("Course deleted.");
                    break;

                case "6":
                    return; // Back to Main Menu

                case "7":
                    Environment.Exit(0); // Exit application
                    break;

                default:
                    Console.WriteLine("Invalid choice. Press any key to try again...");
                    Console.ReadKey();
                    break;
            }
        }
    }


    private static async Task ManageDepartments(IDepartmentService departmentService)
    {
        while (true)
        {
            Console.WriteLine("Manage Departments\n" +
                              "1: Add Department\n" +
                              "2: View Department\n" +
                              "3: View All Departments\n" +
                              "4: Update Department\n" +
                              "5: Delete Department\n" +
                              "6: Back to Main Menu\n" +
                              "7: Exit\n" +
                              "ENTER OPTION: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Name: ");
                    var name = Console.ReadLine();
                    Console.Write("Enter Description: ");
                    var description = Console.ReadLine();
                    var newDepartment = new DepartmentDto(0, name, description);
                    await departmentService.AddDepartmentAsync(newDepartment);
                    Console.WriteLine("Department added.");
                    break;

                case "2":
                    Console.Write("Enter ID: ");
                    var id = int.Parse(Console.ReadLine());
                    var department = await departmentService.GetDepartmentByIdAsync(id);
                    if (department != null)
                    {
                        Console.WriteLine($"ID: {department.Id}, Name: {department.Name}, Description: {department.Description}");
                    }
                    else
                    {
                        Console.WriteLine("Department not found.");
                    }
                    break;

                case "3":
                    var departments = await departmentService.GetDepartmentsAsync();
                    foreach (var d in departments)
                    {
                        Console.WriteLine($"ID: {d.Id}, Name: {d.Name}, Description: {d.Description}");
                    }
                    break;

                case "4":
                    Console.Write("Enter ID: ");
                    var updateId = int.Parse(Console.ReadLine());
                    var updateDepartment = await departmentService.GetDepartmentByIdAsync(updateId);
                    if (updateDepartment != null)
                    {
                        Console.Write("Enter New Name: ");
                        updateDepartment.Name = Console.ReadLine();
                        Console.Write("Enter New Description: ");
                        updateDepartment.Description = Console.ReadLine();
                        await departmentService.UpdateDepartmentAsync(updateDepartment);
                        Console.WriteLine("Department updated.");
                    }
                    else
                    {
                        Console.WriteLine("Department not found.");
                    }
                    break;

                case "5":
                    Console.Write("Enter ID: ");
                    var deleteId = int.Parse(Console.ReadLine());
                    await departmentService.DeleteDepartmentAsync(deleteId);
                    Console.WriteLine("Department deleted.");
                    break;

                case "6":
                    return; // Back to Main Menu

                case "7":
                    Environment.Exit(0); // Exit application
                    break;

                default:
                    Console.WriteLine("Invalid choice. Press any key to try again...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Register services and repositories
        services.AddScoped<ITeacherService, TeacherService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<IDepartmentService, DepartmentService>();

        services.AddScoped<ITeacherRepository, TeacherRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();

        services.AddScoped<CMSDbContext>();
    }
}
