using Microsoft.AspNetCore.Mvc;

namespace AMS_DBTC_Frontend.Service
{
    public class AttendanceService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
