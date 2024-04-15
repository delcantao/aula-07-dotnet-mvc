using Microsoft.AspNetCore.Mvc;
using SipWeb.NET.Models;
using System.Diagnostics;

namespace SipWeb.NET.Controllers
{
    [Route("login")]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public ResultadoBuscaCep busca { get; set; }

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }
        [HttpGet("/")]
        public IActionResult Index()
        {
            var usuario = "";
            var senha = "";

             
            return View(new LoginModel
            {
                Error = null
            });
        }
        [HttpPost("/")]
        public IActionResult Login(string cliente, string usuario, string senha)
        {
            if (cliente == "ASAS" && usuario == "ASAS" && senha == "ASAS")
            {
			    return Redirect($"Buscas/Cep");
            }
            return View("Index", new LoginModel
            {
                Error = "Credenciais Inválidas"
            });
            
        }

      
    }
}
