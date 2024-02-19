using Microsoft.AspNetCore.Mvc;
using WebApiSistema_PrimeraEntrega_GuidoComba.database;
using WebApiSistema_PrimeraEntrega_GuidoComba.DTOs;
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

        [HttpPost("AgregadoDeUsuario")]
        public IActionResult AgregarUnUsuario([FromBody] UsuarioDTO usuario)
        {
            if (this._usuarioData.CrearUsuario(usuario))
            {
                return base.Ok(new { mensaje = "Usuario Agregado", usuario });
            }
            else
            {
                return base.Conflict(new { mensaje = "No se pudo agregar el nuevo Usuario" });
            }

        }

        [HttpPut("ActualizarUsuario")]
        public IActionResult ModificarUsuario(int id, UsuarioDTO usuario)
        {
            if (id > 0)
            {
                if (this._usuarioData.ModificarUsuario(id, usuario))
                {
                    return base.Ok(new { mensaje = "Usuario Actualizado", usuario });
                }
            }

            return base.BadRequest(new { mensaje = "El id no puede ser negativo" });
        }



        [HttpDelete("BorradoDeUsuario")]
        public IActionResult BorrarUsuario(int id)
        {
            if (id > 0)
            {
                if (this._usuarioData.EliminarUsuario(id))
                {
                    return base.Ok(new { mensaje = "Usuario borrado con exito" });
                }
                else
                {
                    return base.Conflict(new { mensaje = "No se pudo borrar el Usuario verifique sus datos" });
                }
            }
            return base.BadRequest(new { mensaje = "El id no puede ser negativo" });
        }

    }
}
