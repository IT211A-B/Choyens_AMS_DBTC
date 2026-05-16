using AMS_DBTC_Frontend.Models;
using Newtonsoft.Json;
using System.Text;

namespace AMS_DBTC_Frontend.Services
{
    public interface IAttendanceService
    {
        Task<List<AttendanceDto>> GetAllAttendanceAsync();

        Task<AttendanceDto?> GetAttendanceByIdAsync(int id);

        Task<bool> CreateAttendanceAsync(AttendanceDto dto);

        Task<bool> UpdateAttendanceAsync(int id, AttendanceDto dto);

        Task<bool> DeleteAttendanceAsync(int id);
    }
}