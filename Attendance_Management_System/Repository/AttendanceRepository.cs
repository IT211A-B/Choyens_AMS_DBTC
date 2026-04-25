using Attendance_Management_System.Data;
using Attendance_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Attendance_Management_System.Repository
{
    public class AttendanceRepository : Repository<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Attendance>> GetAttendanceByStudentAsync(int studentId) =>
            await _context.Attendances
                .Include(a => a.Student)
                .Include(a => a.Course)
                .Where(a => a.StudentId == studentId)
                .ToListAsync();

        public async Task<IEnumerable<Attendance>> GetAttendanceByCourseAsync(int courseId) =>
            await _context.Attendances
                .Include(a => a.Student)
                .Where(a => a.CourseId == courseId)
                .ToListAsync();

        public async Task<IEnumerable<Attendance>> GetAttendanceByDateRangeAsync(DateTime from, DateTime to) =>
            await _context.Attendances
                .Include(a => a.Student)
                .Include(a => a.Course)
                .Where(a => a.Date >= from && a.Date <= to)
                .ToListAsync();
    }
}