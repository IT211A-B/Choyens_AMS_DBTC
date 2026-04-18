using Attendance_Management_System.Data;
using Attendance_Management_System.DTO;
using Attendance_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Attendance_Management_System.Controllers
{
    [Route("api/teachers")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TeachersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Teacherdto dto)
        {
            var teacher = new Teacher { Name = dto.Name };

            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            return Ok(teacher);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherReadDTO>>> GetTeachers()
        {
            var teachers = await _context.Teachers
                .Select(t => new TeacherReadDTO
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();

            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherReadDTO>> GetTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher == null)
                return NotFound();

            var dto = new TeacherReadDTO
            {
                Id = teacher.Id,
                Name = teacher.Name
            };

            return Ok(dto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, Teacherdto dto)
        {
            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher == null)
                return NotFound();

            teacher.Name = dto.Name;

            await _context.SaveChangesAsync();

            return Ok(teacher);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher == null)
                return NotFound();

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Teacher deleted successfully" });
        }
    }
}
