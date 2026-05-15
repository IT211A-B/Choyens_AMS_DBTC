using Attendance_Management_System.Data;
using Attendance_Management_System.dto;
using Attendance_Management_System.Models;
using Microsoft.AspNetCore.Mvc;


namespace Attendance_Management_System.Controllers
{
    [Route("api/dashboard")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetStats()
        {
            var totalStudents = _context.Students.Count();
            var totalTeachers = _context.Teachers.Count();
            var totalCourses = _context.Courses.Count();

            var presentToday = _context.Attendances
                .Where(a => a.Date.Date == DateTime.Today && a.Status == "Present")
                .Count();

            var totalToday = _context.Attendances
                .Where(a => a.Date.Date == DateTime.Today)
                .Count();

            double attendanceRate = totalToday == 0 ? 0 :
                (double)presentToday / totalToday * 100;

            
            var dashboard = new Dashboarddto
            {
                TotalStudents = totalStudents,
                TotalTeachers = totalTeachers,
                TotalCourses = totalCourses,
                AttendanceRate = Math.Round(attendanceRate, 2)
            };

            return Ok(dashboard);
        }
    }
}
