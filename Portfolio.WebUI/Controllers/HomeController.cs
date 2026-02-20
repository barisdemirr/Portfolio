using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Abstract;
using Portfolio.WebUI.Models;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IHeroSectionService heroSectionService)
        {
            _logger = logger;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {   


            return View();
        }

        

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
