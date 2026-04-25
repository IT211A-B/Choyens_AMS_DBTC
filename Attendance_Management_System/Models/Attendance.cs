using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attendance_Management_System.Models
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }

        public int StudentId { get; set; }
        public int CourseId { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; } = null!;

        [ForeignKey("CourseId")]
        public Course Course { get; set; } = null!;

        public DateTime Date { get; set; } = DateTime.Now;
        public string Status { get; set; } = string.Empty;
        public int IsPresent { get; set; }
    }
}