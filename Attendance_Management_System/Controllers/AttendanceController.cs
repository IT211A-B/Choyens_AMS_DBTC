using Attendance_Management_System.Data;
using Attendance_Management_System.Models.dto;
using Attendance_Management_System.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Attendance_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AttendanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Mark(Attendancedto dto)
        {
            var attendance = new Attendance
            {
                StudentId = dto.StudentId,
                CourseId = dto.CourseId,
                Status = dto.Status
            };

            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();

            return Ok(attendance);
        }

        [HttpGet]
        public async Task<IActionResult> GetAttendance()
        {
            var data = await _context.Attendances
                .Include(a => a.Student)
                .Include(a => a.Course)
                .Select(a => new AttendanceReadDTO
                {
                    Id = a.Id,
                    StudentName = a.Student.FirstName + " " + a.Student.LastName,
                    CourseName = a.Course.CourseName,
                    Date = a.Date,
                    Status = a.Status
                })
                .ToListAsync();

            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttendance(int id, Attendancedto dto)
        {
            var attendance = await _context.Attendances.FindAsync(id);

            if (attendance == null)
                return NotFound();

            attendance.StudentId = dto.StudentId;
            attendance.CourseId = dto.CourseId;
            attendance.Status = dto.Status;

            await _context.SaveChangesAsync();

            return Ok(attendance);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance(int id)
        {
            var attendance = await _context.Attendances.FindAsync(id);

            if (attendance == null)
                return NotFound();

            _context.Attendances.Remove(attendance);
            await _context.SaveChangesAsync();

            return Ok("Deleted successfully");
        }
    }
}