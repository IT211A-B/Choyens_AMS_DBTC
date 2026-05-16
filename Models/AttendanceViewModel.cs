namespace AMS_DBTC_Frontend.Models
{
    public class AttendanceDto
    {
        // PRIMARY KEY
        public int Id { get; set; }

        // STUDENT ID FROM BACKEND
        public int StudentId { get; set; }

        // COURSE ID FROM BACKEND
        public int CourseId { get; set; }

        // DATE OF ATTENDANCE
        public DateTime Date { get; set; }

        // PRESENT / ABSENT / LATE
        public string Status { get; set; } = string.Empty;

        // TRUE OR FALSE
        public bool IsPresent { get; set; }
    }
}