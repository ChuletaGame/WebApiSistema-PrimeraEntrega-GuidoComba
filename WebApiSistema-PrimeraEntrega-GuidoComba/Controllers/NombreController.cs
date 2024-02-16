using Microsoft.AspNetCore.Mvc;

namespace WebApiSistema_PrimeraEntrega_GuidoComba.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NombreController : Controller
    {
        [HttpGet]
        public string ObtenerNombre()
        {
            return "Guido Comba";
        }
        [HttpGet("Listado")]
        public List<String> ObtenerListadoDeNombres() 
        {
            List<String> list = new List<String>() { "Jose, pepe, mariano" };
            //return new List<String> { "Jose, pepe, mariano" }; Esta tambien es una opcion valida

            return list;
        }
    }
}
