using EvidencePojisteni.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EvidencePojisteni.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Policy()
        {
            return View();
        }

        public IActionResult Person()
        {
            Person[] person = new Person[]
            {
                new Person("Jan", "Novák", "123456789", 30),
                new Person("Eva", "Svobodová", "987654321", 25),
                new Person("Petr", "Dvoøák", "456789123", 40)
            };
            return View(person);
        }

        public IActionResult DetailPolicy()
        {
            return View();
        }
        public IActionResult AddPolicyToPerson()
        {
            return View();
        }

        public IActionResult NewPerson()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
