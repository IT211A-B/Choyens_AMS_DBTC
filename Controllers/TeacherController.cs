using Microsoft.AspNetCore.Mvc;

public class Teacher : Controller
{
    public IActionResult Index() => View(new List<TeacherViewModel>());
}
