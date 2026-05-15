namespace Attendance_Management_System.Models
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        public string CourseCode { get; set; } = string.Empty;

        public string CourseName { get; set; } = string.Empty;

        public int TeacherId { get; set; }

        public string TeacherName { get; set; } = string.Empty;

        public int TotalStudents { get; set; }

        public int TotalAttendanceRecords { get; set; }
    }
}