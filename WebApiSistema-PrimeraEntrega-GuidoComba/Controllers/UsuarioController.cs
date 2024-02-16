using Microsoft.AspNetCore.Mvc;
using WebApiSistema_PrimeraEntrega_GuidoComba.database;
using WebApiSistema_PrimeraEntrega_GuidoComba.models;
using WebApiSistema_PrimeraEntrega_GuidoComba.Service;

namespace WebApiSistema_PrimeraEntrega_GuidoComba.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private UsuarioData _usuarioData;
        public UsuarioController(UsuarioData usuarioData) 
        {
            this._usuarioData = usuarioData;
        }
        [HttpGet("ListadoDeUsuarios")]
        public List<Usuario> ObtenerListadoDeUsuarios()
        {
            return this._usuarioData.ListarUsuarios();
        }
        
    }
}
