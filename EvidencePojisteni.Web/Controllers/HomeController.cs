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

        public IActionResult Pojisteni()
        {
            return View();
        }

        public IActionResult Pojistenci()
        {
            return View();
        }

        public IActionResult DetailPojisteni()
        {
            return View();
        }
        public IActionResult PridatPojisteniPojistenci()
        {
            return View();
        }

        public IActionResult DetailPojistence()
        {
            return View();
        }

        public IActionResult NovyPojistenec()
        {
            return View();
        }

        public IActionResult NovePojisteni()
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
