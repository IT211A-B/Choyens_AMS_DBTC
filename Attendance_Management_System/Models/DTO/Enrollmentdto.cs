namespace Attendance_Management_System.Models.dto
{
    public class Enrollmentdto
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }

    public class EnrollmentReadDTO
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string CourseName { get; set; }
    }
}
