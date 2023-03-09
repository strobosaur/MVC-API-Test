using Microsoft.AspNetCore.Mvc;
using MVC_API_Test.Models;
using System.Net;
using System.Text.Json;

namespace MVC_API_Test.Controllers
{
    public class APIController : Controller
    {
        public static List<APIUser> listOfUsers = new List<APIUser>();

        // INDEX METHOD
        public IActionResult Index()
        {
            return View();
        }

        // DISPLAY USERS METHOD
        public IActionResult DisplayUsers()
        {
            if (listOfUsers == null || listOfUsers.Count < 1)
            {
                using (var client = new WebClient())
                {
                    client.BaseAddress = "https://reqres.in/api/users/";
                    string str = client.DownloadString("");

                    var parsed = JsonDocument.Parse(str);
                    string filtered = parsed.RootElement.GetProperty("data").GetRawText();

                    listOfUsers = JsonSerializer.Deserialize<List<APIUser>>(filtered);
                }
            }

            return View(listOfUsers);
        }

        // GET USER BY ID
        public IActionResult Edit(int? id)
        {
            APIUser user = listOfUsers.Find(x => x.id == id);

            return View(user);
        }

        // POST USER BY ID
        [HttpPost]
        public IActionResult Edit(APIUser? user)
        {
            var userTemp = listOfUsers.Find(x => x.id == user.id);
            if (userTemp != null)
            {
                listOfUsers.Remove(userTemp);
                listOfUsers.Add(user);
            }

            return View(listOfUsers.OrderBy(x => x.id));
        }
    }
}
