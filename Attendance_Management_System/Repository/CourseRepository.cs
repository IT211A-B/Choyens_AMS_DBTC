using Attendance_Management_System.Data;
using Attendance_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Attendance_Management_System.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Course>> GetCoursesByTeacherAsync(int teacherId) =>
            await _context.Courses
                .Include(c => c.Teacher)
                .Where(c => c.TeacherId == teacherId)
                .ToListAsync();

        public async Task<Course?> GetCourseWithDetailsAsync(int courseId) =>
            await _context.Courses
                .Include(c => c.Teacher)
                .Include(c => c.Enrollments)
                    .ThenInclude(e => e.Student)
                .FirstOrDefaultAsync(c => c.Id == courseId);
    }
}