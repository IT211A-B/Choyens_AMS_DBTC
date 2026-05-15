using Attendance_Management_System.Models;

namespace Attendance_Management_System.Repository
{
    public interface IAttendanceRepository : IRepository<Attendance>
    {
        Task<IEnumerable<Attendance>> GetAttendanceByStudentAsync(int studentId);
        Task<IEnumerable<Attendance>> GetAttendanceByCourseAsync(int courseId);
        Task<IEnumerable<Attendance>> GetAttendanceByDateRangeAsync(DateTime from, DateTime to);
    }
}