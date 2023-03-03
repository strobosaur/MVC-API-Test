using Microsoft.AspNetCore.Mvc;
using MVC_API_Test.Models;
using System.Net;
using System.Text.Json;

namespace MVC_API_Test.Controllers
{
    public class APIController : Controller
    {
        // INDEX METHOD
        public IActionResult Index()
        {
            return View();
        }

        // DISPLAY USERS METHOD
        public IActionResult DisplayUsers()
        {
            using (var client = new WebClient())
            {
                client.BaseAddress = "https://reqres.in/api/users/";
                string str = client.DownloadString("");

                var parsed = JsonDocument.Parse(str);
                string filtered = parsed.RootElement.GetProperty("data").GetRawText();

                var listOfUsers = JsonSerializer.Deserialize<List<APIUser>>(filtered);

                return View(listOfUsers);
            }
        }
    }
}
