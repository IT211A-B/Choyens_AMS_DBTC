using Attendance_Management_System.DTO;
using Attendance_Management_System.Models;
using Attendance_Management_System.Repository;

namespace Attendance_Management_System.Service
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<IEnumerable<Enrollmentdto>> GetAllEnrollmentsAsync()
        {
            var enrollments = await _enrollmentRepository.GetAllAsync();
            return enrollments.Select(MapToDto);
        }

        public async Task<Enrollmentdto?> GetEnrollmentByIdAsync(int id)
        {
            var enrollment = await _enrollmentRepository.GetByIdAsync(id);
            return enrollment is null ? null : MapToDto(enrollment);
        }

        public async Task<IEnumerable<Enrollmentdto>> GetEnrollmentsByStudentAsync(int studentId)
        {
            var enrollments = await _enrollmentRepository.GetEnrollmentsByStudentAsync(studentId);
            return enrollments.Select(MapToDto);
        }

        public async Task<Enrollmentdto> CreateEnrollmentAsync(Enrollmentdto dto)
        {
            var alreadyEnrolled = await _enrollmentRepository.IsStudentEnrolledAsync(dto.StudentId, dto.CourseId);
            if (alreadyEnrolled)
                throw new InvalidOperationException("Student is already enrolled in this course.");

            var enrollment = MapToEntity(dto);
            await _enrollmentRepository.AddAsync(enrollment);
            await _enrollmentRepository.SaveChangesAsync();
            return MapToDto(enrollment);
        }

        public async Task<bool> DeleteEnrollmentAsync(int id)
        {
            var enrollment = await _enrollmentRepository.GetByIdAsync(id);
            if (enrollment is null) return false;

            _enrollmentRepository.Delete(enrollment);
            await _enrollmentRepository.SaveChangesAsync();
            return true;
        }

        private static Enrollmentdto MapToDto(Enrollment e) => new Enrollmentdto
        {
            Id = e.Id,
            StudentId = e.StudentId,
            CourseId = e.CourseId
        };

        private static Enrollment MapToEntity(Enrollmentdto dto) => new Enrollment
        {
            StudentId = dto.StudentId,
            CourseId = dto.CourseId
        };
    }
}