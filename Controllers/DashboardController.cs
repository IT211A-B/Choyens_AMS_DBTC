using Microsoft.AspNetCore.Mvc;

public class Dashboard : Controller
{
    public IActionResult Index()
    {
        var stats = new DashboardViewModel { TotalStudents = 150, TotalTeachers = 12 };
        return View(stats);
    }
}
