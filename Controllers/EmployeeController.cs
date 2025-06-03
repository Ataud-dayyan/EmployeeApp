using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
