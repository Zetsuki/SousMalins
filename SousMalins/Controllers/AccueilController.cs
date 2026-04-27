using Microsoft.AspNetCore.Mvc;
using SousMalins.Models;
using System.Diagnostics;

namespace SousMalins.Controllers
{
    public class AccueilController : Controller
    {
        public IActionResult IndexAccueil()
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
