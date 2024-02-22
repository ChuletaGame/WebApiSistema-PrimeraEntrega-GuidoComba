using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApiSistema_PrimeraEntrega_GuidoComba.DTOs;
using WebApiSistema_PrimeraEntrega_GuidoComba.models;
using WebApiSistema_PrimeraEntrega_GuidoComba.Service;

namespace WebApiSistema_PrimeraEntrega_GuidoComba.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : Controller
    {
        private VentaData _ventaData;
        public VentaController(VentaData ventaData)
        {
            this._ventaData = ventaData;
        }
        [HttpPost("{idUsuario}")]
        public IActionResult CrearVenta(int idUsuario, [FromBody] List<ProductoDTO> productos)
        {
            if (productos.Count == 0)
            {
                return base.BadRequest(new { mensaje = "No se pudo agregar la venta" ,status = HttpStatusCode.BadRequest });
            }
            try
            {
                this._ventaData.AgregarNuevaVenta(idUsuario, productos);
                IActionResult result = base.Created(nameof(CrearVenta), new
                {
                    mensaje = "Ventra creada con exito",
                    status = HttpStatusCode.Created,
                    nuevaventa = productos
                });
                return result;
            }
            catch (Exception ex) 
            {
                return base.Conflict(new { mensaje = "No se pudo agregar la venta" , status = HttpStatusCode.Conflict });
            }

        }



        [HttpGet("ListadoDeVenta")]
        public List<Venta> ObtenerListadoDeVenta()
        {
            return this._ventaData.ListarVenta();
        }

        [HttpPost("AgregadoDeVenta")]
        public IActionResult AgregarUnaVenta([FromBody] VentaDTO venta)
        {
            if (this._ventaData.CrearVenta(venta))
            {
                return base.Ok(new { mensaje = "Venta Agregada", venta });
            }
            else
            {
                return base.Conflict(new { mensaje = "No se pudo agregar la venta" });
            }

        }

        [HttpPut("ActualizarVenta")]
        public IActionResult ModificarVenta(int id, VentaDTO ventaDTO)
        {
            if (id > 0)
            {
                if (this._ventaData.ModificarVenta(id, ventaDTO))
                {
                    return base.Ok(new { mensaje = "Venta Actualizada", ventaDTO });
                }
            }

            return base.BadRequest(new { mensaje = "El id no puede ser negativo" });
        }



        [HttpDelete("BorradoDeVenta")]
        public IActionResult BorrarVenta(int id)
        {
            if (id > 0)
            {
                if (this._ventaData.EliminarVenta(id))
                {
                    return base.Ok(new { mensaje = "venta borrada con exito" });
                }
                else
                {
                    return base.Conflict(new { mensaje = "No se pudo borrar la venta verifique sus datos" });
                }
            }
            return base.BadRequest(new { mensaje = "El id no puede ser negativo" });
        }

    }
}
