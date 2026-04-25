using Attendance_Management_System.DTO;

namespace Attendance_Management_System.Service
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacherdto>> GetAllTeachersAsync();
        Task<Teacherdto?> GetTeacherByIdAsync(int id);
        Task<Teacherdto> CreateTeacherAsync(Teacherdto dto);
        Task<bool> UpdateTeacherAsync(int id, Teacherdto dto);
        Task<bool> DeleteTeacherAsync(int id);
    }
}