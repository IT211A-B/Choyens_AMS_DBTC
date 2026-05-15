using Microsoft.AspNetCore.Mvc;

namespace AMS_DBTC_Frontend.Models
{
    public class IndexViewModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
