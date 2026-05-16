using AMS_DBTC_Frontend.Models;
using AMS_DBTC_Frontend.Services;
using Microsoft.AspNetCore.Mvc;

namespace AMS_DBTC_Frontend.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly EnrollmentService _enrollmentService;

        public EnrollmentController(EnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        // DISPLAY PAGE
        public async Task<IActionResult> Index()
        {
            var enrollments = await _enrollmentService.GetEnrollmentsAsync();

            return View(enrollments);
        }

        // CREATE
        [HttpPost]
        public async Task<IActionResult> Create(EnrollmentViewModel model)
        {
            await _enrollmentService.CreateEnrollmentAsync(model);

            return RedirectToAction("Enrollment");
        }

        // UPDATE
        [HttpPost]
        public async Task<IActionResult> Update(int id, EnrollmentViewModel model)
        {
            await _enrollmentService.UpdateEnrollmentAsync(id, model);

            return RedirectToAction("Enollment");
        }

        // DELETE
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _enrollmentService.DeleteEnrollmentAsync(id);

            return RedirectToAction("Enrollment");
        }
    }
}