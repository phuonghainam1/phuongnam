using System;
using BT_L0_PhuongHaiNam.Services;

namespace BT_L0_PhuongHaiNam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StudentService.LoadFromFile(); 
            while (true)
            {
                Console.WriteLine("\nStudent Management System");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Read Student by ID");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Display All Students");
                Console.WriteLine("6. Display Students by Academic Performance");
                Console.WriteLine("7. Display Academic Performance Percentages");
                Console.WriteLine("8. Display GPA Percentages");
                Console.WriteLine("9. Save to File");
                Console.WriteLine("10. Exit");
                Console.Write("Choose an option: ");

                string input = Console.ReadLine();
                if (!int.TryParse(input, out int option))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        StudentService.CreateStudent(new Model.Student());
                        break;
                    case 2:
                        Console.Write("Enter Student ID: ");
                        if (int.TryParse(Console.ReadLine(), out int readId))
                            StudentService.ReadStudent(readId);
                        else
                            Console.WriteLine("Invalid ID format.");
                        break;
                    case 3:
                        Console.Write("Enter Student ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int updateId))
                            StudentService.UpdateStudent(updateId);
                        else
                            Console.WriteLine("Invalid ID format.");
                        break;
                    case 4:
                        Console.Write("Enter Student ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                            StudentService.DeleteStudent(deleteId);
                        else
                            Console.WriteLine("Invalid ID format.");
                        break;
                    case 5:
                        StudentService.DisplayAllStudents();
                        break;
                    case 6:
                        StudentService.DisplayStudentByAcademicPerformance();
                        break;
                    case 7:
                        StudentService.DisplayAcademicPerformancePercentages();
                        break;
                    case 8:
                        StudentService.DisplayGPAPercentage();
                        break;
                    case 9:
                        StudentService.SaveToFile();
                        break;
                    case 10:
                        StudentService.SaveToFile();
                        Console.WriteLine("Exiting program.");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}