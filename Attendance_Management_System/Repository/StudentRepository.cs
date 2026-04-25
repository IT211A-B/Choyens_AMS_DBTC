using Attendance_Management_System.Data;
using Attendance_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Attendance_Management_System.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Student?> GetStudentWithEnrollmentsAsync(int studentId) =>
            await _context.Students
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Course)
                .FirstOrDefaultAsync(s => s.Id == studentId);

        public async Task<IEnumerable<Student>> GetStudentsByCourseAsync(int courseId) =>
            await _context.Students
                .Where(s => s.Enrollments.Any(e => e.CourseId == courseId))
                .Include(s => s.Enrollments)
                .ToListAsync();
    }
}