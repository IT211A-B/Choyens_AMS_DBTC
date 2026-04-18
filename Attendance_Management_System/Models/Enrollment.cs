using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attendance_Management_System.Models
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }

        public int StudentId { get; set; }
        public int CourseId { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }
    }
}
