using System;
using System.Runtime.CompilerServices;
using BT_L0_PhuongHaiNam.Model;
using Microsoft.VisualBasic;

namespace BT_L0_PhuongHaiNam.Services;

public class StudentService
{
    private static List<Student> students = new List<Student>();
    private const string FilePath = "students.txt";

    public static void AddStudent(Student student)
    {
        students.Add(student);
        System.Console.WriteLine("Student added successfully.");
    }
    public static Student FindStudentByStudentId(string studentId)
    {
        return students.FirstOrDefault(s => s.StudentId == studentId)!;

    }
    public static Student FindStudentById(int id)
    {
        return students.FirstOrDefault(s => s.Id == id)!;
    }
    public static void CreateStudent(Student student)
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Enter student name:");
                string name = Console.ReadLine()!;
                if (!Validation.Validation.IsValidName(name))
                {
                    continue;
                }

                Console.WriteLine("Enter Date of Birth (dd-MM-yyyy): ");
                string dobInput = Console.ReadLine()!;
                if (!Validation.Validation.ParseDateTime(dobInput, "dd-MM-yyyy", out DateTime dob))
                {
                    continue;
                }
                if (!Validation.Validation.IsValidBirthDate(dob))
                {
                    continue;
                }

                Console.WriteLine("Enter address:");
                string address = Console.ReadLine()!;
                if (!Validation.Validation.IsValidAddress(address))
                {
                    continue;
                }

                Console.WriteLine("Enter height:");
                if (!double.TryParse(Console.ReadLine(), out double height) || !Validation.Validation.IsValidHeight(height))
                {
                    continue;
                }

                Console.WriteLine("Enter weight:");
                if (!double.TryParse(Console.ReadLine(), out double weight) || !Validation.Validation.IsValidWeight(weight))
                {
                    continue;
                }

                Console.WriteLine("Enter student ID:");
                string studentId = Console.ReadLine()!;
                if (!Validation.Validation.IsValidStudentId(studentId))
                {
                    continue;
                }
                if (FindStudentByStudentId(studentId) != null)
                {
                    System.Console.WriteLine($"Student ID {studentId} already exists.");
                    continue;
                }

                Console.WriteLine("Enter school:");
                string school = Console.ReadLine()!;
                if (!Validation.Validation.IsValidSchool(school))
                {
                    continue;
                }

                Console.WriteLine("Enter enrollment year:");
                if (!int.TryParse(Console.ReadLine(), out int enrollmentYear) || !Validation.Validation.IsValidEnrollmentYear(enrollmentYear))
                {
                    continue;
                }

                Console.WriteLine("Enter GPA:");
                if (!double.TryParse(Console.ReadLine(), out double gpa) || !Validation.Validation.IsValidGPA(gpa))
                {
                    continue;
                }

                Student student1 = new Student(name, dob, address, height, weight, studentId, school, enrollmentYear, gpa);
                student1.AssignId();
                AddStudent(student1);
                Console.WriteLine(student1.ToString());
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
    public static void ReadStudent(int id)
    {
        Student student = FindStudentById(id);
        if (student != null)
        {
            Console.WriteLine(student.ToString());
        }
        else
        {
            Console.WriteLine($"Student with id {id} not found.");
        }
    }

    public static void UpdateStudent(int id)
    {
        Student updatedStudent = FindStudentById(id);
        if (updatedStudent == null)
        {
            Console.WriteLine($"Student with id {id} not found.");
            return;
        }

        while (true)
        {
            try
            {
                Console.WriteLine("Enter new name (or press Enter to keep current):");
                string name = Console.ReadLine()!;
                if (!string.IsNullOrEmpty(name)) // Chỉ kiểm tra nếu người dùng nhập giá trị
                {
                    if (!Validation.Validation.IsValidName(name))
                    {
                        continue;
                    }
                    updatedStudent.Name = name;
                }

                Console.WriteLine("Enter new Date of Birth (dd-MM-yyyy) (or press Enter to keep current): ");
                string dobInput = Console.ReadLine()!;

                if (!string.IsNullOrEmpty(dobInput))
                {
                    if (!Validation.Validation.ParseDateTime(dobInput, "dd-MM-yyyy", out DateTime dob) || !Validation.Validation.IsValidBirthDate(dob))
                    {
                        continue;
                    }
                    updatedStudent.Dob = dob;
                }

                Console.WriteLine("Enter new address(or press Enter to keep current): ");
                string address = Console.ReadLine()!;
                if (address != null)
                {
                    if (!Validation.Validation.IsValidAddress(address))
                    {
                        continue;
                    }
                    updatedStudent.Address = address;
                }
                Console.WriteLine("Enter new Height(or press enter to keep current): ");
                string height = Console.ReadLine()!;
                if (!string.IsNullOrEmpty(height))
                {
                    if (!double.TryParse(height, out double parsedHeight) || !Validation.Validation.IsValidHeight(parsedHeight))
                    {
                        continue;
                    }
                    updatedStudent.Height = parsedHeight;
                }

                Console.WriteLine("Enter new Weight(or press enter to keep current): ");
                string weight = Console.ReadLine()!;
                if (!string.IsNullOrEmpty(weight))
                {
                    if (!double.TryParse(weight, out double parsedWeight) || !Validation.Validation.IsValidWeight(parsedWeight))
                    {
                        continue;
                    }
                    updatedStudent.Weight = parsedWeight;
                }
                Console.WriteLine("Enter new student ID (or press Enter to keep current):");
                string studentId = Console.ReadLine()!;
                if (!string.IsNullOrEmpty(studentId))
                {
                    if (!Validation.Validation.IsValidStudentId(studentId))
                    {
                        continue;
                    }
                    if (FindStudentByStudentId(studentId) != null && FindStudentByStudentId(studentId).Id != id)
                    {
                        System.Console.WriteLine($"Student ID {studentId} already exists.");
                        continue;
                    }
                    updatedStudent.StudentId = studentId;
                }
                Console.WriteLine("Enter new school (or press Enter to keep current):");
                string school = Console.ReadLine()!;
                if (!string.IsNullOrEmpty(school))
                {
                    if (!Validation.Validation.IsValidSchool(school))
                    {
                        continue;
                    }
                    updatedStudent.School = school;
                }
                Console.WriteLine("Enter new enrollment year (or press Enter to keep current):");
                string enrollmentYearInput = Console.ReadLine()!;
                if (!string.IsNullOrEmpty(enrollmentYearInput))
                {
                    if (!int.TryParse(enrollmentYearInput, out int enrollmentYear) || !Validation.Validation.IsValidEnrollmentYear(enrollmentYear))
                    {
                        continue;
                    }
                    updatedStudent.EnrollmentYear = enrollmentYear;
                }
                Console.WriteLine("Enter new GPA (or press Enter to keep current):");
                string gpaInput = Console.ReadLine()!;
                if (!string.IsNullOrEmpty(gpaInput))
                {
                    if (!double.TryParse(gpaInput, out double gpa) || !Validation.Validation.IsValidGPA(gpa))
                    {
                        continue;
                    }
                    updatedStudent.GPA = gpa;
                }
                Console.WriteLine("Student updated successfully.");
                Console.WriteLine(updatedStudent.ToString());
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }
    }

    public static void DeleteStudent(int id)
    {
        Student student = FindStudentById(id);
        if (student != null)
        {
            students.Remove(student);
            Console.WriteLine($"Student with id {id} deleted successfully.");
        }
        else
        {
            Console.WriteLine($"Student with id {id} not found.");
        }
    }

    public static void DisplayAllStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students available.");
            return;
        }
        foreach (var student in students)
        {
            Console.WriteLine(student.ToString());
        }
    }

    public static void DisplayStudentByAcademicPerformance()
    {
        Console.WriteLine("Enter Academic Performance (Poor, Weak, Average, Good, VeryGood, Excellent): ");
        string input = Console.ReadLine()!;
        if (!Enum.TryParse<Student.AcademicPerformance>(input, true, out var performance))
        {
            Console.WriteLine("Invalid Academic Performance input.");
            return;
        }
        var filteredStudents = students.Where(s => s.UpdatedAcademicPerformance == performance).ToList();
        if (filteredStudents.Count == 0)
        {
            Console.WriteLine($"No students found with {performance} performance.");
            return;
        }
        foreach (var student in filteredStudents)
        {
            Console.WriteLine(student.ToString());
        }
    }

    public static void DisplayAcademicPerformancePercentages()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students available.");
            return;
        }

        var performanceCounts = students.GroupBy(s => s.UpdatedAcademicPerformance)
            .ToDictionary(g => g.Key, g => g.Count());

        Console.WriteLine("Academic Performance Percentages (sorted from high to low): ");
        var sortedPerformances = Enum.GetValues(typeof(Student.AcademicPerformance))
            .Cast<Student.AcademicPerformance>()
            .OrderByDescending(p => (int)p);
        foreach (var performance in sortedPerformances)
        {
            int count = performanceCounts.ContainsKey(performance) ? performanceCounts[performance] : 0;
            double percentage = (double)count / students.Count * 100;
            System.Console.WriteLine($"{performance} : {percentage:F2}%");
        }
    }

    public static void DisplayGPAPercentage()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students available.");
            return;
        }
        var gpaCounts = students.GroupBy(s => s.GPA)
            .ToDictionary(g => g.Key, g => g.Count());

        Console.WriteLine("GPA percentages: ");
        foreach (var gpa in gpaCounts.Keys.OrderBy(g => g))
        {
            double percentage = (double)gpaCounts[gpa] / students.Count * 100;
            System.Console.WriteLine($"{gpa} : {percentage:F2}%");
        }
    }

    public static void SaveToFile()
    {
        using (StreamWriter writer = new StreamWriter(FilePath))
        {
            foreach (var student in students)
            {
                writer.WriteLine($"{student.Id}|{student.Name}|{student.Dob:dd-MM-yyyy}|{student.Address}|{student.Height}|{student.Weight}|" +
                                     $"{student.StudentId}|{student.School}|{student.EnrollmentYear}|{student.GPA}");
            }
            System.Console.WriteLine("Students save to file successfully.");
        }
    }

    public static void LoadFromFile()
    {
        if (!File.Exists(FilePath))
        {
            return;
        }
        students.Clear();
        using (StreamReader reader = new StreamReader(FilePath))
        {
            string line;
            while ((line = reader.ReadLine()!) != null)
            {
                var parts = line.Split('|');
                if (parts.Length == 10)
                {
                    try
                    {
                        int id = int.Parse(parts[0]);
                        string name = parts[1];
                        if (!Validation.Validation.ParseDateTime(parts[2], "dd-MM-yyyy", out DateTime dob))
                            continue;
                        string address = parts[3];
                        double height = double.Parse(parts[4]);
                        double weight = double.Parse(parts[5]);
                        string studentId = parts[6];
                        string school = parts[7];
                        int enrollmentYear = int.Parse(parts[8]);
                        double gpa = double.Parse(parts[9]);

                        Student student = new Student(name, dob, address, height, weight, studentId, school, enrollmentYear, gpa);
                        student.Id = id;
                        students.Add(student);
                    }
                    catch
                    {

                    }
                }
            }
            Person.SetNextId(students.Any() ? students.Max(s => s.Id) : 0);
        }
    }

}
