using Microsoft.AspNetCore.Mvc;

namespace AMS_DBTC_Frontend.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        public string StudentNumber { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public string? Email { get; set; }

        public int TotalEnrollments { get; set; }

        public int TotalAttendanceRecords { get; set; }
    }
}