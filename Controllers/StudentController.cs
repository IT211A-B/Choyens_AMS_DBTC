using Microsoft.AspNetCore.Mvc;
using AMS_Choyenss_Domen_FE_.Models;

namespace AMS_Choyenss_Domen_FE_.Controllers
{
    public class Student : Controller
    {
        public IActionResult Index()
        {
            // Mock data for testing
            var students = new List<StudentViewModel>
            {
                new StudentViewModel { Id = 1, Name = "John Doe", Email = "john@example.com", Course = "BSIT" },
                new StudentViewModel { Id = 2, Name = "Jane Smith", Email = "jane@example.com", Course = "BSCS" }
            };

            return View(students);
        }
    }
}
