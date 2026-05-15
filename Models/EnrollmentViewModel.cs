using Microsoft.AspNetCore.Mvc;

namespace AMS_DBTC_Frontend.Models
{
    public class EnrollmentViewModel
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public string StudentName { get; set; } = string.Empty;

        public int CourseId { get; set; }

        public string CourseCode { get; set; } = string.Empty;

        public string CourseName { get; set; } = string.Empty;
    }
}