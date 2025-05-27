namespace BT_L0_PhuongHaiNam.Model;

public class Student : Person
{
    public string StudentId { get; set; }
    public string School { get; set; }
    public int EnrollmentYear { get; set; }
    public double GPA { get; set; }

    public Student()
    {
    }
    public Student(string name, DateTime dob, string address, double height, double weight, string studentId,
        string school, int enrollmentYear, double gpa) : base(name, dob, address, height, weight)
    {
        StudentId = studentId;
        School = school;
        EnrollmentYear = enrollmentYear;
        GPA = gpa;
    }
    public override string ToString()
    {
        return base.ToString() + $", Student ID: {StudentId}, School: {School}, Enrollment Year: {EnrollmentYear}, GPA: {GPA}";
    }
    
    public enum AcademicPerformance
    {
        Poor,       // < 3.0
        Weak,       // 3.0 - 4.99
        Average,    // 5.0 - 6.49
        Good,       // 6.5 - 7.49
        VeryGood,   // 7.5 - 8.99
        Excellent   // >= 9.0
    }

    
    public AcademicPerformance UpdatedAcademicPerformance
    {
        get
        {
            if (GPA < 3.0)
                return AcademicPerformance.Poor;
            else if (GPA < 5.0)
                return AcademicPerformance.Weak;
            else if (GPA < 6.5)
                return AcademicPerformance.Average;
            else if (GPA < 7.5)
                return AcademicPerformance.Good;
            else if (GPA < 9.0)
                return AcademicPerformance.VeryGood;
            else
                return AcademicPerformance.Excellent;
        }
    }
    
}