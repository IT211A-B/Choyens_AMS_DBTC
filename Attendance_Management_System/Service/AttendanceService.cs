using Attendance_Management_System.DTO;
using Attendance_Management_System.Models;
using Attendance_Management_System.Repository;

namespace Attendance_Management_System.Service
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<IEnumerable<Attendancedto>> GetAllAttendancesAsync()
        {
            var records = await _attendanceRepository.GetAllAsync();
            return records.Select(MapToDto);
        }

        public async Task<Attendancedto?> GetAttendanceByIdAsync(int id)
        {
            var record = await _attendanceRepository.GetByIdAsync(id);
            return record is null ? null : MapToDto(record);
        }

        public async Task<IEnumerable<Attendancedto>> GetAttendanceByStudentAsync(int studentId)
        {
            var records = await _attendanceRepository.GetAttendanceByStudentAsync(studentId);
            return records.Select(MapToDto);
        }

        public async Task<IEnumerable<Attendancedto>> GetAttendanceByCourseAsync(int courseId)
        {
            var records = await _attendanceRepository.GetAttendanceByCourseAsync(courseId);
            return records.Select(MapToDto);
        }

        public async Task<Attendancedto> CreateAttendanceAsync(Attendancedto dto)
        {
            var attendance = MapToEntity(dto);
            await _attendanceRepository.AddAsync(attendance);
            await _attendanceRepository.SaveChangesAsync();
            return MapToDto(attendance);
        }

        public async Task<bool> UpdateAttendanceAsync(int id, Attendancedto dto)
        {
            var attendance = await _attendanceRepository.GetByIdAsync(id);
            if (attendance is null) return false;

            attendance.StudentId = dto.StudentId;
            attendance.CourseId = dto.CourseId;
            attendance.Date = dto.Date;
            attendance.Status = dto.Status;
            attendance.IsPresent = dto.IsPresent;

            _attendanceRepository.Update(attendance);
            await _attendanceRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAttendanceAsync(int id)
        {
            var attendance = await _attendanceRepository.GetByIdAsync(id);
            if (attendance is null) return false;

            _attendanceRepository.Delete(attendance);
            await _attendanceRepository.SaveChangesAsync();
            return true;
        }

        private static Attendancedto MapToDto(Attendance a) => new Attendancedto
        {
            Id = a.Id,
            StudentId = a.StudentId,
            CourseId = a.CourseId,
            Date = a.Date,
            Status = a.Status,
            IsPresent = a.IsPresent
        };

        private static Attendance MapToEntity(Attendancedto dto) => new Attendance
        {
            StudentId = dto.StudentId,
            CourseId = dto.CourseId,
            Date = dto.Date,
            Status = dto.Status,
            IsPresent = dto.IsPresent
        };
    }
}