using Attendance_Management_System.DTO;

namespace Attendance_Management_System.Service
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseReadDTO>> GetAllCoursesAsync();
        Task<CourseReadDTO?> GetCourseByIdAsync(int id);
        Task<CourseReadDTO> CreateCourseAsync(Coursedto dto);
        Task<bool> UpdateCourseAsync(int id, Coursedto dto);
        Task<bool> DeleteCourseAsync(int id);
    }
}