using AMS_DBTC_Frontend.Services;
using Microsoft.AspNetCore.Mvc;

namespace AMS_DBTC_Frontend.Controllers
{
    public class TeacherController : Controller
    {
        private readonly TeacherApiService _teacherService;

        public TeacherController(TeacherApiService teacherService)
        {
            _teacherService = teacherService;
        }

        // PAGE

        public IActionResult Teacher()
        {
            return View();
        }
    }
}