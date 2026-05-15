using Attendance_Management_System.Models;

namespace Attendance_Management_System.Repository
{
    public interface IEnrollmentRepository : IRepository<Enrollment>
    {
        Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentAsync(int studentId);
        Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseAsync(int courseId);
        Task<bool> IsStudentEnrolledAsync(int studentId, int courseId);
    }
}