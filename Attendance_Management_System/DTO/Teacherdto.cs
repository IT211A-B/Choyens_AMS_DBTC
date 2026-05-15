namespace Attendance_Management_System.DTO
{
    public class Teacherdto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
    }

    public class TeacherReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}