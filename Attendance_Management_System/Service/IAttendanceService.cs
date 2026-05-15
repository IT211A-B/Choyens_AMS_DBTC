using Attendance_Management_System.DTO;

namespace Attendance_Management_System.Service
{
    public interface IAttendanceService
    {
        Task<IEnumerable<Attendancedto>> GetAllAttendancesAsync();
        Task<Attendancedto?> GetAttendanceByIdAsync(int id);
        Task<IEnumerable<Attendancedto>> GetAttendanceByStudentAsync(int studentId);
        Task<IEnumerable<Attendancedto>> GetAttendanceByCourseAsync(int courseId);
        Task<Attendancedto> CreateAttendanceAsync(Attendancedto dto);
        Task<bool> UpdateAttendanceAsync(int id, Attendancedto dto);
        Task<bool> DeleteAttendanceAsync(int id);
    }
}