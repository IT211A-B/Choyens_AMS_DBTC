namespace Attendance_Management_System.DTO
{
    public class Enrollmentdto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }

    public class EnrollmentReadDTO
    {
        public int Id { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
    }
}