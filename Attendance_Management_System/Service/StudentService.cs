using Attendance_Management_System.DTO;
using Attendance_Management_System.Models;
using Attendance_Management_System.Repository;

namespace Attendance_Management_System.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Studentdto>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            return students.Select(MapToDto);
        }

        public async Task<Studentdto?> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            return student is null ? null : MapToDto(student);
        }

        public async Task<Studentdto> CreateStudentAsync(Studentdto dto)
        {
            var student = MapToEntity(dto);
            await _studentRepository.AddAsync(student);
            await _studentRepository.SaveChangesAsync();
            return MapToDto(student);
        }

        public async Task<bool> UpdateStudentAsync(int id, Studentdto dto)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student is null) return false;

            student.StudentNumber = dto.StudentNumber;
            student.FirstName = dto.FirstName;
            student.LastName = dto.LastName;
            student.Email = dto.Email;

            _studentRepository.Update(student);
            await _studentRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student is null) return false;

            _studentRepository.Delete(student);
            await _studentRepository.SaveChangesAsync();
            return true;
        }

        private static Studentdto MapToDto(Student s) => new Studentdto
        {
            Id = s.Id,
            StudentNumber = s.StudentNumber,
            FirstName = s.FirstName,
            LastName = s.LastName,
            Email = s.Email
        };

        private static Student MapToEntity(Studentdto dto) => new Student
        {
            StudentNumber = dto.StudentNumber,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email
        };
    }
}