using Attendance_Management_System.DTO;
using Attendance_Management_System.Models;
using Attendance_Management_System.Repository;

namespace Attendance_Management_System.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<IEnumerable<Teacherdto>> GetAllTeachersAsync()
        {
            var teachers = await _teacherRepository.GetAllAsync();
            return teachers.Select(MapToDto);
        }

        public async Task<Teacherdto?> GetTeacherByIdAsync(int id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);
            return teacher is null ? null : MapToDto(teacher);
        }

        public async Task<Teacherdto> CreateTeacherAsync(Teacherdto dto)
        {
            var teacher = MapToEntity(dto);
            await _teacherRepository.AddAsync(teacher);
            await _teacherRepository.SaveChangesAsync();
            return MapToDto(teacher);
        }

        public async Task<bool> UpdateTeacherAsync(int id, Teacherdto dto)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);
            if (teacher is null) return false;

            teacher.Name = dto.Name;
            teacher.Email = dto.Email;

            _teacherRepository.Update(teacher);
            await _teacherRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTeacherAsync(int id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);
            if (teacher is null) return false;

            _teacherRepository.Delete(teacher);
            await _teacherRepository.SaveChangesAsync();
            return true;
        }

        private static Teacherdto MapToDto(Teacher t) => new Teacherdto
        {
            Id = t.Id,
            Name = t.Name,
            Email = t.Email
        };

        private static Teacher MapToEntity(Teacherdto dto) => new Teacher
        {
            Name = dto.Name,
            Email = dto.Email
        };
    }
}