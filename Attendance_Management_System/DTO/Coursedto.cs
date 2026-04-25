namespace Attendance_Management_System.DTO
{
    public class Coursedto
    {
        public string CourseCode { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public int TeacherId { get; set; }
    }

    public class CourseReadDTO
    {
        public int Id { get; set; }
        public string CourseCode { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public string TeacherName { get; set; } = string.Empty;
    }
}