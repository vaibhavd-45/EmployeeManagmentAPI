using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Management_System_API.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Employee), nameof(ValidateAge))]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Position is required.")]
        [StringLength(100, ErrorMessage = "Position cannot be longer than 100 characters.")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        [Range(1000, double.MaxValue, ErrorMessage = "Salary must be at least 1000.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Custom validation for Date of Birth (Ensures employee is at least 18 years old)
        public static ValidationResult ValidateAge(DateTime dateOfBirth, ValidationContext context)
        {
            int age = DateTime.Today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > DateTime.Today.AddYears(-age)) age--; // Adjust if birthday hasn't occurred yet

            if (age < 18)
                return new ValidationResult("Employee must be at least 18 years old.");

            return ValidationResult.Success;
        }
    }
}
