using Attendance_Management_System.DTO;

namespace Attendance_Management_System.Service
{
    public interface IEnrollmentService
    {
        Task<IEnumerable<Enrollmentdto>> GetAllEnrollmentsAsync();
        Task<Enrollmentdto?> GetEnrollmentByIdAsync(int id);
        Task<IEnumerable<Enrollmentdto>> GetEnrollmentsByStudentAsync(int studentId);
        Task<Enrollmentdto> CreateEnrollmentAsync(Enrollmentdto dto);
        Task<bool> DeleteEnrollmentAsync(int id);
    }
}