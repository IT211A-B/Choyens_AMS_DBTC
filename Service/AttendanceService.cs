using AMS_DBTC_Frontend.Models;
using Newtonsoft.Json;
using System.Text;

namespace AMS_DBTC_Frontend.Services
{

    public class AttendanceService : IAttendanceService
    {
        private readonly HttpClient _httpClient;

        // BACKEND API URL
        private const string apiUrl =
            "https://localhost:7082/api/Attendance";

        public AttendanceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET ALL ATTENDANCE
        public async Task<List<AttendanceDto>> GetAllAttendanceAsync()
        {
            var response =
                await _httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
                return new List<AttendanceDto>();

            var json =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<AttendanceDto>>(json)
                   ?? new List<AttendanceDto>();
        }

        // GET ATTENDANCE BY ID
        public async Task<AttendanceDto?> GetAttendanceByIdAsync(int id)
        {
            var response =
                await _httpClient.GetAsync($"{apiUrl}/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            var json =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<AttendanceDto>(json);
        }

        // CREATE ATTENDANCE
        public async Task<bool> CreateAttendanceAsync(AttendanceDto dto)
        {
            var json =
                JsonConvert.SerializeObject(dto);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            var response =
                await _httpClient.PostAsync(apiUrl, content);

            return response.IsSuccessStatusCode;
        }

        // UPDATE ATTENDANCE
        public async Task<bool> UpdateAttendanceAsync(int id, AttendanceDto dto)
        {
            var json =
                JsonConvert.SerializeObject(dto);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            var response =
                await _httpClient.PutAsync($"{apiUrl}/{id}", content);

            return response.IsSuccessStatusCode;
        }

        // DELETE ATTENDANCE
        public async Task<bool> DeleteAttendanceAsync(int id)
        {
            var response =
                await _httpClient.DeleteAsync($"{apiUrl}/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}