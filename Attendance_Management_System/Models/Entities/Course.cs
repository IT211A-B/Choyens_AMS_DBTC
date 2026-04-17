using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attendance_Management_System.Models.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public string CourseCode { get; set; }
        public string CourseName { get; set; }

        public int TeacherId { get; set; }

        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }
    }
}
