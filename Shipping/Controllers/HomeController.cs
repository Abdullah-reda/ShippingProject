using BL.Contracts;
using DAL.Contracts;
using Domains;
using Microsoft.AspNetCore.Mvc;
using Shipping.Models;
using System.Diagnostics;

namespace Shipping.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IShippingType _shippingTypeRepository;
        public HomeController(ILogger<HomeController> logger, IShippingType shippingTypeRepository)
        {
            _logger = logger;
            _shippingTypeRepository = shippingTypeRepository;
        }
        public IActionResult Index()
        {
            var shippingTypes = _shippingTypeRepository.GetAll();
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
