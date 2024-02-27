using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiSistema_PrimeraEntrega_GuidoComba.DTOs;
using WebApiSistema_PrimeraEntrega_GuidoComba.models;
using WebApiSistema_PrimeraEntrega_GuidoComba.Service;

namespace WebApiSistema_PrimeraEntrega_GuidoComba.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        private ProductoData _productoData;

        public ProductoController(ProductoData productoData)
        {
            this._productoData = productoData;
        }

        [HttpGet("{idUsuario}")]
        public List<ProductoDTO> ObtenerProdcutosPorIdUsuario(int IdUsuario)
        {
            return this._productoData.ObtenerProdcutosPorIdDeUsuario(IdUsuario);
        }


        [HttpGet("ListadoDeProductos")]
        public List<Producto> ObtenerListaDeProductos()
        {
            return this._productoData.ListarProductos();
        }

        [HttpPost("AgregadoDeProducto")]
        public IActionResult AgregarUnProducto([FromBody]ProductoDTO producto)
        {
            if (this._productoData.CrearProducto(producto))
            {
                return base.Ok(new {mensaje="Producto Agregado", producto });
            }
            else
            {
                return base.Conflict(new { mensaje = "No se pudo agregar el producto" });
            }
            
        }

        [HttpPut("ActualizarProducto")]
        public IActionResult ActualizarProductoPorId(int id , ProductoDTO productoDTO)
        {
            if(id > 0)
            {
                if(this._productoData.ModificarProducto(id, productoDTO))
                {
                    return base.Ok(new { mensaje = "Producto Actualizado", productoDTO });
                }
            }

            return base.BadRequest(new { mensaje = "El id no puede ser negativo" });
        }
         


        [HttpDelete("BorradoDeProducto")]
        public IActionResult BorrarProducto(int id)
        {
            if (id > 0)
            {
                if (this._productoData.EliminarProducto(id))
                {
                    return base.Ok(new { mensaje = "producto borrado con exito"});
                }
                else
                {
                    return base.Conflict(new { mensaje = "No se pudo borrar el producto verifique sus datos" });
                }
            }
            return base.BadRequest(new {mensaje = "El id no puede ser negativo"});
        }

    }
}
