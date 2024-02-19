using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("ListadoDeVenta")]
        public List<Venta> ObtenerListadoDeVenta()
        {
            return this._ventaData.ListarVenta();
        }

    }
}
