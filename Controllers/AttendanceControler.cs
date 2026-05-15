using AMS_DBTC_Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace AMS_DBTC_Frontend.Controllers
{
    public class AttendanceController : Controller
    {
        // API URL of your backend
        private readonly string apiUrl = "https://localhost:7022/api/Attendance";

        // HTTP CLIENT
        private readonly HttpClient _httpClient;

        // CONSTRUCTOR
        public AttendanceController()
        {
            _httpClient = new HttpClient();
        }

        // =========================================================
        // LOAD ATTENDANCE PAGE
        // =========================================================
        public async Task<IActionResult> Index()
        {
            List<AttendanceViewModel> attendanceList = new();

            // GET ALL ATTENDANCE DATA FROM BACKEND API
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            // CHECK IF REQUEST IS SUCCESSFUL
            if (response.IsSuccessStatusCode)
            {
                // READ API RESPONSE
                string jsonData = await response.Content.ReadAsStringAsync();

                // CONVERT JSON TO LIST
                attendanceList = JsonConvert.DeserializeObject<List<AttendanceViewModel>>(jsonData);
            }

            // SEND DATA TO VIEW
            return View(attendanceList);
        }

        // =========================================================
        // CREATE ATTENDANCE
        // =========================================================

        // LOAD CREATE PAGE
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // SAVE ATTENDANCE
        [HttpPost]
        public async Task<IActionResult> Create(AttendanceCreateDTO attendance)
        {
            // CONVERT OBJECT TO JSON
            string jsonData = JsonConvert.SerializeObject(attendance);

            // PREPARE JSON CONTENT
            StringContent content = new StringContent(
                jsonData,
                Encoding.UTF8,
                "application/json"
            );

            // SEND POST REQUEST TO API
            HttpResponseMessage response =
                await _httpClient.PostAsync(apiUrl, content);

            // CHECK SUCCESS
            if (response.IsSuccessStatusCode)
            {
                // REDIRECT TO INDEX PAGE
                return RedirectToAction("Index");
            }

            return View(attendance);
        }

        // =========================================================
        // EDIT ATTENDANCE
        // =========================================================

        // LOAD EDIT PAGE
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            AttendanceCreateDTO attendance = new();

            // GET SINGLE ATTENDANCE DATA
            HttpResponseMessage response =
                await _httpClient.GetAsync($"{apiUrl}/{id}");

            // CHECK SUCCESS
            if (response.IsSuccessStatusCode)
            {
                string jsonData =
                    await response.Content.ReadAsStringAsync();

                attendance =
                    JsonConvert.DeserializeObject<AttendanceCreateDTO>(jsonData);
            }

            return View(attendance);
        }

        // UPDATE ATTENDANCE
        [HttpPost]
        public async Task<IActionResult> Edit(int id, AttendanceCreateDTO attendance)
        {
            // CONVERT OBJECT TO JSON
            string jsonData =
                JsonConvert.SerializeObject(attendance);

            // PREPARE JSON CONTENT
            StringContent content = new StringContent(
                jsonData,
                Encoding.UTF8,
                "application/json"
            );

            // SEND PUT REQUEST
            HttpResponseMessage response =
                await _httpClient.PutAsync($"{apiUrl}/{id}", content);

            // CHECK SUCCESS
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(attendance);
        }

        // =========================================================
        // DELETE ATTENDANCE
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            // SEND DELETE REQUEST
            HttpResponseMessage response =
                await _httpClient.DeleteAsync($"{apiUrl}/{id}");

            // CHECK SUCCESS
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}