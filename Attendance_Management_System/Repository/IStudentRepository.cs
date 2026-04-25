using Attendance_Management_System.Models;

namespace Attendance_Management_System.Repository
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<Student?> GetStudentWithEnrollmentsAsync(int studentId);
        Task<IEnumerable<Student>> GetStudentsByCourseAsync(int courseId);
    }
}