using System;
using BT_L0_PhuongHaiNam.Services;

namespace BT_L0_PhuongHaiNam.Validation;

static class Validation
{
    public static bool IsValidName(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > Constants.Constant.MAX_LENGTH_NAME)
        {
            System.Console.WriteLine($"Name is invalid. It should not be empty or exceed {Constants.Constant.MAX_LENGTH_NAME} characters.");
            return false;
        }
        return true;
    }

    public static bool IsValidBirthDate(DateTime birthDate)
    {
        if (birthDate.Year < Constants.Constant.MIN_BIRTH_YEAR)
        {
            System.Console.WriteLine("Birth date cannot be in the future.");
            return false;
        }
        return true;
    }

    public static bool IsValidAddress(string address)
    {
        if (string.IsNullOrWhiteSpace(address) || address.Length > Constants.Constant.MAX_LENGTH_ADDRESS)
        {
            System.Console.WriteLine($"Address is invalid. It should not exceed {Constants.Constant.MAX_LENGTH_ADDRESS} characters.");
            return false;
        }
        return true;
    }
    public static bool IsValidHeight(double height)
    {
        if (height < Constants.Constant.MIN_HEIGHT || height > Constants.Constant.MAX_HEIGHT)
        {
            System.Console.WriteLine($"Height is invalid. It should be between {Constants.Constant.MIN_HEIGHT} and {Constants.Constant.MAX_HEIGHT}.");
            return false;
        }
        return true;
    }
    public static bool IsValidWeight(double weight)
    {
        if (weight < Constants.Constant.MIN_WEIGHT || weight > Constants.Constant.MAX_WEIGHT)
        {
            System.Console.WriteLine($"Weight is invalid. It should be between {Constants.Constant.MIN_WEIGHT} and {Constants.Constant.MAX_WEIGHT}.");
            return false;
        }
        return true;
    }
    public static bool IsValidStudentId(string studentId)
    {
        if (string.IsNullOrWhiteSpace(studentId) || StudentService.FindStudentByStudentId(studentId) != null || studentId.Length > Constants.Constant.MAX_LENGTH_STUDENT_ID)
        {
            System.Console.WriteLine($"Student ID is invalid. It should not be empty or exceed {Constants.Constant.MAX_LENGTH_STUDENT_ID} characters.");
            return false;
        }
        return true;
    }

    public static bool IsValidSchool(string school)
    {
        if (string.IsNullOrWhiteSpace(school) || school.Length > Constants.Constant.MAX_LENGTH_SCHOOL)
        {
            System.Console.WriteLine($"School is invalid. It should not be empty or exceed {Constants.Constant.MAX_LENGTH_SCHOOL} characters.");
            return false;
        }
        return true;
    }
    public static bool IsValidEnrollmentYear(int enrollmentYear)
    {
        if (enrollmentYear < Constants.Constant.MIN_ENROLLMENT_YEAR)
        {
            System.Console.WriteLine($"Enrollment year is invalid. It should be greater than {Constants.Constant.MIN_ENROLLMENT_YEAR}.");
            return false;
        }
        return true;
    }
    public static bool IsValidGPA(double gpa)
    {
        if (gpa < Constants.Constant.MIN_GPA || gpa > Constants.Constant.MAX_GPA)
        {
            System.Console.WriteLine($"GPA is invalid. It should be between {Constants.Constant.MIN_GPA} and {Constants.Constant.MAX_GPA}.");
            return false;
        }
        return true;
    }
    public static bool ParseDateTime(string dateString, string format, out DateTime result)
    {
        if (string.IsNullOrWhiteSpace(dateString))
        {
            Console.WriteLine("Date string cannot be empty.");
            result = default;
            return false;
        }

        if (!DateTime.TryParseExact(dateString, format, null, System.Globalization.DateTimeStyles.None, out result))
        {
            Console.WriteLine($"Invalid date format. Expected format: {format}.");
            return false;
        }

        if (!IsValidBirthDate(result))
        {
            return false;
        }

        return true;
    }
}
