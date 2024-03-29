﻿using Microsoft.AspNetCore.Mvc;
using System.Net;
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

        [HttpGet("{nombreDeUsuario}")]
        public ActionResult<Usuario> ObtenerUsuariosPorNombreDeUsuario(string nombreDeUsuario)
        {
            if (string.IsNullOrWhiteSpace(nombreDeUsuario))
            {
                return base.BadRequest(new { mensaje = "El nombre del usuario no puede estar vacio" });
            }
            try
            {
                Usuario usuario = _usuarioData.ObtenerUsuarioPorNombreDeUsuario(nombreDeUsuario);
                return usuario;
            }
            catch 
            {
                return base.Conflict(new { mensaje = "No se pudo obtener el Usuario", status = HttpStatusCode.Conflict });
            }
            
        }
        [HttpGet("{Usuario}/{Password}")]
        public ActionResult<Usuario> ObtenerUsuarioYPasswordDeUsuario(string Usuario, string Password)
        {
            if (string.IsNullOrWhiteSpace(Usuario)&& string.IsNullOrWhiteSpace(Password))
            {
                return base.BadRequest(new { mensaje = "El nombre del usuario no puede estar vacio" });
            }
            try
            {
                Usuario usuario = _usuarioData.ObtenerUsuarioYPasswordDeUsuario(Usuario,Password);
                return usuario;
            }
            catch (Exception ex)
            {
                return base.Conflict(new { mensaje = "No se pudo obtener el Usuario", status = HttpStatusCode.Conflict });
            }

        }



        [HttpGet("ListadoDeUsuarios")]
        public List<Usuario> ObtenerListadoDeUsuarios()
        {
            return this._usuarioData.ListarUsuarios();
        }

        [HttpPost()]
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

        [HttpPut()]
        public IActionResult ModificarUsuario( UsuarioDTO usuario)
        {
            
            if (this._usuarioData.ModificarUsuario( usuario))
            {
                return base.Ok(new { mensaje = "Usuario Actualizado", usuario });
            }
            else
            {
                return base.BadRequest(new { mensaje = "El id no puede ser negativo" });
            }
            

            
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
