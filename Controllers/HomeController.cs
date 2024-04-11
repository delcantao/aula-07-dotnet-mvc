using Microsoft.AspNetCore.Mvc;
using SipWeb.NET.Models;
using System.Diagnostics;

namespace SipWeb.NET.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public ResultadoBuscaCep busca { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var irNobcao = new ResultadoBuscaCep
            {
                Tipo = "RUAAAA",
                Endereco = "Jose de SA"
            };

			return View(irNobcao);
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
