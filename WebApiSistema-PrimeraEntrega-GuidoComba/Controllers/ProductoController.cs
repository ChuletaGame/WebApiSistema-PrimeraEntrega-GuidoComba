using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
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
        public ActionResult<List<ProductoDTO>> ObtenerProdcutosPorIdUsuario(int IdUsuario)
        {
            if (IdUsuario < 0)
            {
                return base.BadRequest(new {mensaje="el id no puede ser negativo" , 
                    status = HttpStatusCode.BadRequest });
            }
            try
            {
                return this._productoData.ObtenerProdcutosPorIdDeUsuario(IdUsuario);
            }
            catch
            {
                return base.BadRequest(new
                {
                    mensaje = "Algo salio mal",
                    status = HttpStatusCode.Conflict
                });
            }
                
        }


        [HttpGet("ListadoDeProductos")]
        public List<Producto> ObtenerListaDeProductos()
        {
            return this._productoData.ListarProductos();
        }

        [HttpPost()]
        public IActionResult AgregarUnProducto([FromBody]ProductoDTO producto)
        {
            if (this._productoData.CrearProducto(producto))
            {
                return base.Ok(new {mensaje="Producto Agregado con exito", producto });
            }
            else
            {
                return base.Conflict(new { mensaje = "No se pudo agregar el producto" });
            }
            
        }

        [HttpPut()]
        public IActionResult ActualizarProductoPorId([FromBody] ProductoDTO productoDTO)
        {
            
            
            if(this._productoData.ModificarProducto( productoDTO))
            {
                return base.Ok(new { mensaje = "Producto Actualizado", productoDTO });
            }
            else
            {
                return base.BadRequest(new { mensaje = "El id no puede ser negativo" });
            }
            

            
        }
         


        [HttpDelete("{id}")]
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
