namespace Attendance_Management_System.Models.dto
{
    public class Coursedto
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int TeacherId { get; set; }
    }

    public class CourseReadDTO
    {
        public int Id { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string TeacherName { get; set; }
    }
}
