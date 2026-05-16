using AMS_DBTC_Frontend.Models;
using AMS_DBTC_Frontend.Service;
using Newtonsoft.Json;

namespace AMS_DBTC_Frontend.Services
{
    public class StudentService
    {
        private readonly HttpClient _httpClient;

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Student>> GetPrivacysAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7266/swagger/index.html");

            if (!response.IsSuccessStatusCode)
            {
                return new List<Student>();
            }

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Student>>(json);
        }

        internal async Task CreateStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }

        internal async Task DeletePrivacyAsync(int id)
        {
            throw new NotImplementedException();
        }

        internal async Task<string?> GetStudentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        internal async Task<string?> GetStudentsAsync()
        {
            throw new NotImplementedException();
        }

        internal async Task UpdateStudentAsync(int id, Student student)
        {
            throw new NotImplementedException();
        }
    }
}