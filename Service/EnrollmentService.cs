using AMS_DBTC_Frontend.Models;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace AMS_DBTC_Frontend.Services
{
    public class EnrollmentService
    {
        private readonly HttpClient _httpClient;

        public EnrollmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET ALL ENROLLMENTS
        public async Task<List<EnrollmentViewModel>> GetEnrollmentsAsync()
        {
            var response = await _httpClient.GetAsync("api/enrollments");

            if (!response.IsSuccessStatusCode)
                return new List<EnrollmentViewModel>();

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<EnrollmentViewModel>>(json)
                   ?? new List<EnrollmentViewModel>();
        }

        // CREATE ENROLLMENT
        public async Task<bool> CreateEnrollmentAsync(EnrollmentViewModel model)
        {
            var json = JsonConvert.SerializeObject(model);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(
                "api/enrollments",
                content
            );

            return response.IsSuccessStatusCode;
        }

        // UPDATE ENROLLMENT
        public async Task<bool> UpdateEnrollmentAsync(int id, EnrollmentViewModel model)
        {
            var json = JsonConvert.SerializeObject(model);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PutAsync(
                $"api/enrollments/{id}",
                content
            );

            return response.IsSuccessStatusCode;
        }

        // DELETE ENROLLMENT
        public async Task<bool> DeleteEnrollmentAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(
                $"api/enrollments/{id}"
            );

            return response.IsSuccessStatusCode;
        }
    }
}