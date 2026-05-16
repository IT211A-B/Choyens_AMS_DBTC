using AMS_DBTC_Frontend.Models;
using System.Text;
using System.Text.Json;

namespace AMS_DBTC_Frontend.Services
{
    public class TeacherApiService
    {
        private readonly HttpClient _httpClient;

        public TeacherApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET ALL

        public async Task<List<TeacherViewModel>> GetTeachersAsync()
        {
            var response = await _httpClient.GetAsync("api/teachers");

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<TeacherViewModel>>(json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                })!;
        }

        // GET BY ID

        public async Task<TeacherViewModel> GetTeacherByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/teachers/{id}");

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TeacherViewModel>(json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                })!;
        }

        // CREATE

        public async Task CreateTeacherAsync(TeacherViewModel teacher)
        {
            var json = JsonSerializer.Serialize(teacher);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync("api/teachers", content);

            response.EnsureSuccessStatusCode();
        }

        // UPDATE

        public async Task UpdateTeacherAsync(int id, TeacherViewModel teacher)
        {
            var json = JsonSerializer.Serialize(teacher);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PutAsync($"api/teachers/{id}", content);

            response.EnsureSuccessStatusCode();
        }

        // DELETE

        public async Task DeleteTeacherAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/teachers/{id}");

            response.EnsureSuccessStatusCode();
        }
    }
}