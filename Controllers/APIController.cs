using Microsoft.AspNetCore.Mvc;

namespace MVC_API_Test.Controllers
{
    public class APIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
