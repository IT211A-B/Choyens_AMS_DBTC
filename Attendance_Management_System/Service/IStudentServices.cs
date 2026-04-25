using Attendance_Management_System.DTO;

namespace Attendance_Management_System.Service
{
    public interface IStudentService
    {
        Task<IEnumerable<Studentdto>> GetAllStudentsAsync();
        Task<Studentdto?> GetStudentByIdAsync(int id);
        Task<Studentdto> CreateStudentAsync(Studentdto dto);
        Task<bool> UpdateStudentAsync(int id, Studentdto dto);
        Task<bool> DeleteStudentAsync(int id);
    }
}