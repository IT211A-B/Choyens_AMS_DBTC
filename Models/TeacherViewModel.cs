using Microsoft.AspNetCore.Mvc;

namespace AMS_DBTC_Frontend.Models
{
    public class TeacherViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Email { get; set; }

        public int TotalCourses { get; set; }
    }
}