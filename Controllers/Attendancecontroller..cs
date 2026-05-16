using AMS_DBTC_Frontend.Models;
using AMS_DBTC_Frontend.Services;
using Microsoft.AspNetCore.Mvc;

namespace AMS_DBTC_Frontend.Controllers
{
    public class AttendanceController : Controller
    {
        // SERVICE
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        // DISPLAY ALL ATTENDANCE
        public async Task<IActionResult> Index()
        {
            var attendanceList =
                await _attendanceService.GetAllAttendanceAsync();

            return View(attendanceList);
        }

        // CREATE PAGE
        public IActionResult Create()
        {
            return View();
        }

        // SAVE ATTENDANCE
        [HttpPost]
        public async Task<IActionResult> Create(AttendanceDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var success =
                await _attendanceService.CreateAttendanceAsync(dto);

            if (success)
                return RedirectToAction("Index");

            return View(dto);
        }

        // EDIT PAGE
        public async Task<IActionResult> Edit(int id)
        {
            var attendance =
                await _attendanceService.GetAttendanceByIdAsync(id);

            if (attendance == null)
                return NotFound();

            var dto = new AttendanceDto
            {
                Id = attendance.Id,
                StudentId = attendance.StudentId,
                CourseId = attendance.CourseId,
                Date = attendance.Date,
                Status = attendance.Status,
                IsPresent = attendance.IsPresent
            };

            return View(dto);
        }

        // UPDATE ATTENDANCE
        [HttpPost]
        public async Task<IActionResult> Edit(int id, AttendanceDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var success =
                await _attendanceService.UpdateAttendanceAsync(id, dto);

            if (success)
                return RedirectToAction("Index");

            return View(dto);
        }

        // DELETE PAGE
        public async Task<IActionResult> Delete(int id)
        {
            var attendance =
                await _attendanceService.GetAttendanceByIdAsync(id);

            if (attendance == null)
                return NotFound();

            return View(attendance);
        }

        // CONFIRM DELETE
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _attendanceService.DeleteAttendanceAsync(id);

            return RedirectToAction("Index");
        }
    }
}