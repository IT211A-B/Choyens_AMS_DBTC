namespace Attendance_Management_System.Models.dto
{
    public class Attendancedto
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string Status { get; set; }
    }

    public class AttendanceReadDTO
    {   
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string CourseName { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
