using System.ComponentModel.DataAnnotations;

namespace Attendance_Management_System.Models.Entities
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
