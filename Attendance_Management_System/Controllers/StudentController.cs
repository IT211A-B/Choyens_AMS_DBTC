using Attendance_Management_System.Data;
using Attendance_Management_System.DTO;
using Attendance_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Attendance_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Studentdto dto)
        {
            var student = new Student
            {
                StudentNumber = dto.StudentNumber,
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return Ok(student);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentReadDTO>>> GetStudents()
        {
            var students = await _context.Students
                .Select(s => new StudentReadDTO
                {
                    Id = s.Id,
                    StudentNumber = s.StudentNumber,
                    FullName = s.FirstName + " " + s.LastName
                })
                .ToListAsync();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentReadDTO>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            var dto = new StudentReadDTO
            {
                Id = student.Id,
                StudentNumber = student.StudentNumber,
                FullName = student.FirstName + " " + student.LastName
            };

            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Studentdto dto)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

           
            student.StudentNumber = dto.StudentNumber;
            student.FirstName = dto.FirstName;
            student.LastName = dto.LastName;

            await _context.SaveChangesAsync();

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Student deleted successfully" });
        }
    }
}