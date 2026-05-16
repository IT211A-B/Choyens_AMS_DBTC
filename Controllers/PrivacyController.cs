using AMS_DBTC_Frontend.Models;
using AMS_DBTC_Frontend.Service;
using AMS_DBTC_Frontend.Services;
using Microsoft.AspNetCore.Mvc;

namespace AMS_DBTC_Frontend.Controllers
{
    public class PrivacyController : Controller
    {
        private readonly StudentService _studentService;

        public PrivacyController(StudentService studentService)
        {
            _studentService = studentService;
        }

        // DISPLAY STUDENTS
        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetPrivacysAsync();

            return View(students);
        }

        // CREATE PAGE
        public IActionResult Create()
        {
            return View();
        }

        // CREATE
        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            await _studentService.CreateStudentAsync(student);

            return RedirectToAction("Index");
        }

        // EDIT PAGE
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);

            return View(student);
        }

        // UPDATE
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            await _studentService.UpdateStudentAsync(id, student);

            return RedirectToAction("Index");
        }

        // DELETE
        public async Task<IActionResult> Delete(int id)
        {
            await _studentService.DeletePrivacyAsync(id);

            return RedirectToAction("Index");
        }
    }
}