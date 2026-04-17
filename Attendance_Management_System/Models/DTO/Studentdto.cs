namespace Attendance_Management_System.Models.dto
{
    public class Studentdto
    {
        public string StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class StudentReadDTO
    {
        public int Id { get; set; }
        public string StudentNumber { get; set; }
        public string FullName { get; set; }
    }
}
