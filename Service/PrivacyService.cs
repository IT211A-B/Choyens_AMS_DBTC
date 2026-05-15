using Microsoft.AspNetCore.Mvc;

namespace AMS_DBTC_Frontend.Service
{
    public class PrivacyService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
