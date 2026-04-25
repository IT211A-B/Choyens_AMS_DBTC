using System.ComponentModel.DataAnnotations;

namespace Attendance_Management_System.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string StudentNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Email { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}