using Attendance_Management_System.DTO;
using Attendance_Management_System.Models;
using Attendance_Management_System.Repository;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Attendance_Management_System.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<CourseReadDTO>> GetAllCoursesAsync()
        {
            var courses = await _courseRepository.GetAllAsync();
            return courses.Select(MapToReadDto);
        }

        public async Task<CourseReadDTO?> GetCourseByIdAsync(int id)
        {
            var course = await _courseRepository.GetCourseWithDetailsAsync(id);
            return course is null ? null : MapToReadDto(course);
        }

        public async Task<CourseReadDTO> CreateCourseAsync(Coursedto dto)
        {
            var course = MapToEntity(dto);
            await _courseRepository.AddAsync(course);
            await _courseRepository.SaveChangesAsync();

            
            var created = await _courseRepository.GetCourseWithDetailsAsync(course.Id);
            return MapToReadDto(created!);
        }

        public async Task<bool> UpdateCourseAsync(int id, Coursedto dto)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course is null) return false;

            course.CourseCode = dto.CourseCode;
            course.CourseName = dto.CourseName;
            course.TeacherId = dto.TeacherId;

            _courseRepository.Update(course);
            await _courseRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course is null) return false;

            _courseRepository.Delete(course);
            await _courseRepository.SaveChangesAsync();
            return true;
        }

        private static CourseReadDTO MapToReadDto(Course c) => new CourseReadDTO
        {
            Id = c.Id,
            CourseCode = c.CourseCode,
            CourseName = c.CourseName,
            TeacherName = c.Teacher?.Name ?? string.Empty
        };

        private static Course MapToEntity(Coursedto dto) => new Course
        {
            CourseCode = dto.CourseCode,
            CourseName = dto.CourseName,
            TeacherId = dto.TeacherId
        };
    }
}