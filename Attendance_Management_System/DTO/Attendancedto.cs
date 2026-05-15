namespace Attendance_Management_System.DTO
{
    public class Attendancedto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string Status { get; set; } = string.Empty;
        public int IsPresent { get; set; }
        public DateTime Date { get; set; }
    }

    public class AttendanceReadDTO
    {
        public int Id { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}