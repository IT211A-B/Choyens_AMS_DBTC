using Microsoft.AspNetCore.Mvc;

public class Attendance : Controller
{
    public IActionResult Index()
    {
        var list = new List<AttendanceViewModel>(); // Fetch from DB here
        return View(list);
    }
}
