using System.ComponentModel.DataAnnotations;

namespace Attendance_Management_System.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
