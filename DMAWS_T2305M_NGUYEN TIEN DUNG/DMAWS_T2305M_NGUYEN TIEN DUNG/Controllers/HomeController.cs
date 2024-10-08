using DMAWS_T2305M_NGUYEN_TIEN_DUNG.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DMAWS_T2305M_NGUYEN_TIEN_DUNG.Models;

namespace DMAWS_T2305M_NGUYEN_TIEN_DUNG.Controllers
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
