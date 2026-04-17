using Attendance_Management_System.Data;
using Attendance_Management_System.Models.dto;
using Attendance_Management_System.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace Attendance_Management_System.Controllers
{
    [Route("api/enrollments")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Enroll(Enrollmentdto dto)
        {
            var enrollment = new Enrollment
            {
                StudentId = dto.StudentId,
                CourseId = dto.CourseId
            };

            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            return Ok(enrollment);
        }

        [HttpGet]
        public async Task<IActionResult> GetEnrollments()
        {
            var data = await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .Select(e => new EnrollmentReadDTO
                {
                    Id = e.Id,
                    StudentName = e.Student.FirstName + " " + e.Student.LastName,
                    CourseName = e.Course.CourseName
                })
                .ToListAsync();

            return Ok(data);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEnrollment(int id, Enrollmentdto dto)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);

            if (enrollment == null)
                return NotFound();

           
            enrollment.StudentId = dto.StudentId;
            enrollment.CourseId = dto.CourseId;

            await _context.SaveChangesAsync();

            return Ok(enrollment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);

            if (enrollment == null)
                return NotFound();

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();

            return Ok("Enrollment removed");
        }
    }
}
