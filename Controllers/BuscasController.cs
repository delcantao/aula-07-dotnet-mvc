using Microsoft.AspNetCore.Mvc;
using SipWeb.NET.Models;
using System.Diagnostics;

namespace SipWeb.NET.Controllers
{
    
    // [Route("consultas-enriquecimento-cadastral")]
    public class BuscasController : Controller
    {
        private readonly ILogger<BuscasController> _logger;

        public ResultadoBuscaCep busca { get; set; }

        public BuscasController(ILogger<BuscasController> logger)
        {
            _logger = logger;
        }

        
        // [Route("busca-cep")]
        public IActionResult Cep()
        {
            var cep = ""; 
            var irNobcao = new ResultadoBuscaCep
            {
                Tipo = "RUAAAA",
                Endereco = "Jose de SA"
            };

			return View(irNobcao);
        }

        public IActionResult Cpf()
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
