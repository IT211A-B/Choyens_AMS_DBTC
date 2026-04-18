using Attendance_Management_System.Data;
using Attendance_Management_System.DTO;
using Attendance_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Attendance_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Coursedto dto)
        {
            var course = new Course
            {
                CourseCode = dto.CourseCode,
                CourseName = dto.CourseName,
                TeacherId = dto.TeacherId
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return Ok(course);
        }

        
        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _context.Courses
                .Include(c => c.Teacher)
                .Select(c => new CourseReadDTO
                {
                    Id = c.Id,
                    CourseCode = c.CourseCode,
                    CourseName = c.CourseName,
                    TeacherName = c.Teacher.Name
                })
                .ToListAsync();

            return Ok(courses);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, Coursedto dto)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
                return NotFound();

            course.CourseCode = dto.CourseCode;
            course.CourseName = dto.CourseName;
            course.TeacherId = dto.TeacherId;

            await _context.SaveChangesAsync();

            return Ok(course);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
                return NotFound();

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return Ok("Course deleted");
        }
    }
}
