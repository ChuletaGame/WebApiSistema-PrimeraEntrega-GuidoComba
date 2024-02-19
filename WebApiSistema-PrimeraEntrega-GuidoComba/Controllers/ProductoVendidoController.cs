using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("ListadoDeProductosVendidos")]
        public List<ProductoVendido> ObtenerListadoDeProductosVendidos()
        {
            return this._productoVendidoData.ListarProductosVendidos(); ;
        }
    }
}
