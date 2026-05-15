using Attendance_Management_System.Models;

namespace Attendance_Management_System.Repository
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        Task<Teacher?> GetTeacherWithCoursesAsync(int teacherId);
    }
}