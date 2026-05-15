using Attendance_Management_System.Data;
using Attendance_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Attendance_Management_System.Repository
{
    public class EnrollmentRepository : Repository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentAsync(int studentId) =>
            await _context.Enrollments
                .Include(e => e.Course)
                .Where(e => e.StudentId == studentId)
                .ToListAsync();

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseAsync(int courseId) =>
            await _context.Enrollments
                .Include(e => e.Student)
                .Where(e => e.CourseId == courseId)
                .ToListAsync();

        public async Task<bool> IsStudentEnrolledAsync(int studentId, int courseId) =>
            await _context.Enrollments
                .AnyAsync(e => e.StudentId == studentId && e.CourseId == courseId);
    }
}