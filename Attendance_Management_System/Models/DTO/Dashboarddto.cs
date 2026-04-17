namespace Attendance_Management_System.Models.dto
{
    public class Dashboarddto
    {
        public int TotalStudents { get; set; }
        public int TotalTeachers { get; set; }
        public int TotalCourses { get; set; }

        public double AttendanceRate { get; set; }
        public double AttendanceChange { get; set; } 

        public int CoursesEnded { get; set; } 
    }
}
