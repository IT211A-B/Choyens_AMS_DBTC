using Attendance_Management_System.Models;

namespace Attendance_Management_System.Repository
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<IEnumerable<Course>> GetCoursesByTeacherAsync(int teacherId);
        Task<Course?> GetCourseWithDetailsAsync(int courseId);
    }
}