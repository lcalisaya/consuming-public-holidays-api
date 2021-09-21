using ConsumingHolidaysAPI.Interfaces;
using ConsumingHolidaysAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ConsumingHolidaysAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHolidaysAPIService _holidaysAPIService;

        public HomeController(ILogger<HomeController> logger, IHolidaysAPIService holidaysAPIService)
        {
            _logger = logger;
            _holidaysAPIService = holidaysAPIService;
        }

        public async Task<IActionResult> Index(string countryCode = "AR", int year = 2021)
        {
            var holidays = new List<HolidayModel>();
            holidays = await _holidaysAPIService.GetHolidays(countryCode, year);
            return View(holidays);
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
