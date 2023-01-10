using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class FirstController : Controller
    {
        public String Index()
        {
            return "Hello World";
        }
        public IActionResult Hello()
        {
            ViewBag.Selam = "Naber";
            return View();
        }
        public IActionResult Info()
        {
            Person person = new()
            {
                Name = "John",
                Age = 18,
                Location = "United States"
            };
            return View(person);
        }
    }
}
