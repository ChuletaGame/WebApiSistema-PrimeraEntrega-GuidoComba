using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApiSistema_PrimeraEntrega_GuidoComba.DTOs;
using WebApiSistema_PrimeraEntrega_GuidoComba.models;
using WebApiSistema_PrimeraEntrega_GuidoComba.Service;

namespace WebApiSistema_PrimeraEntrega_GuidoComba.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoVendidoController : Controller
    {
        private ProductoVendidoData _productoVendidoData;
        public ProductoVendidoController(ProductoVendidoData prodcutoVendidoData)
        {
            this._productoVendidoData = prodcutoVendidoData;
        }
        [HttpGet("{idUsuario}")]
        public ActionResult<List<ProductoVendidoDTO>> ObtenerListadoDeProductosVendidosPorIdUsuario(int idUsuario)
        {
            if (idUsuario < 0) 
            {
                return base.BadRequest(new { mensaje = "id Incorrecto", status = HttpStatusCode.BadRequest });
            }
            try
            {
                return this._productoVendidoData.ObtenerProductosVendidosPorIdUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                return base.Conflict(new { mensaje = "Algo salio mal", status = HttpStatusCode.Conflict });
            }
        }
    }
}
