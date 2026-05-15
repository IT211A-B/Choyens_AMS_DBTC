using Microsoft.AspNetCore.Mvc;

namespace AMS_DBTC_Frontend.Models
{
    public class AttendanceViewModel
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public string StudentName { get; set; } = string.Empty;

        public int CourseId { get; set; }

        public string CourseName { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public string Status { get; set; } = string.Empty;

        public bool IsPresent { get; set; }
    }
}