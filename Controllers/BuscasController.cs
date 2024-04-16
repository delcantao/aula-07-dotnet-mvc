using Microsoft.AspNetCore.Mvc;
using SipWeb.NET.Models;
using System.Diagnostics;
using Microsoft.Data.SqlClient;

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
        
        [HttpGet]
        public IActionResult Cep()
        {
           
			return View(new ResultadoBuscaCep());
        }
        [HttpPost]
        public IActionResult Cep(string cep)
        {
            
            var resultado = new ResultadoBuscaCep(); 
            using var sql = new SqlConnection(Environment.GetEnvironmentVariable("STRINGCONN_THDC6").Replace("Network Library=DBMSSOCN;", "TrustServerCertificate=yes;"));
            sql.Open();
            var cmd = sql.CreateCommand();
            cmd.CommandText = $"SELECT * FROM CEP_DNE.DBO.T_SEND_CEP WHERE END_CEP = '{cep}'";
            var dataReader = cmd.ExecuteReader();

            if (dataReader.Read())
            { 
                  
                resultado.UF = dataReader["End_UF"].ToString();
                resultado.Cidade = dataReader["End_Cidade"].ToString();
                resultado.Bairro = dataReader["End_Bairro"].ToString(); 
                resultado.Endereco = dataReader["End_Logradouro"].ToString(); 
                resultado.CEP = dataReader["End_Cep"].ToString();
                resultado.De = dataReader["Num_Inicial"].ToString();
                resultado.Ate = dataReader["Num_Final"].ToString(); 
                resultado.Obs = dataReader["Dcr_Obs"].ToString(); 
                    
            }
            else
            {
                resultado.ErrorMessage = "O Cep não foi encontrado.";
            }

          
        

            return View(resultado);

        }
 
        [HttpGet]
        public IActionResult CepJson(string cep)
        {
            var resultado = new ResultadoBuscaCep(); 
            using var sql = new SqlConnection(Environment.GetEnvironmentVariable("STRINGCONN_THDC6").Replace("Network Library=DBMSSOCN;", "TrustServerCertificate=yes;"));
            sql.Open();
            var cmd = sql.CreateCommand();
            cmd.CommandText = $"SELECT * FROM CEP_DNE.DBO.T_SEND_CEP WHERE END_CEP = '{cep}'";
            var dataReader = cmd.ExecuteReader();

            if (dataReader.Read())
            { 
                  
                resultado.UF = dataReader["End_UF"].ToString();
                resultado.Cidade = dataReader["End_Cidade"].ToString();
                resultado.Bairro = dataReader["End_Bairro"].ToString(); 
                resultado.Endereco = dataReader["End_Logradouro"].ToString(); 
                resultado.CEP = dataReader["End_Cep"].ToString();
                resultado.De = dataReader["Num_Inicial"].ToString();
                resultado.Ate = dataReader["Num_Final"].ToString(); 
                resultado.Obs = dataReader["Dcr_Obs"].ToString(); 
                    
            }
            else
            {
                resultado.ErrorMessage = "O Cep não foi encontrado.";
            }

            return View("Cep", resultado);
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
