using WebApiSistema_PrimeraEntrega_GuidoComba.DTOs;
using WebApiSistema_PrimeraEntrega_GuidoComba.models;

namespace WebApiSistema_PrimeraEntrega_GuidoComba.Mapper
{
    public class ProductoVendidoMapper
    {
        public  ProductoVendido MapearToProdcutoVendido(ProductoVendidoDTO dto) 
        {
            ProductoVendido productoVendido = new ProductoVendido();

            productoVendido.Id = dto.Id;
            productoVendido.Stock = dto.Stock;
            productoVendido.IdProducto = dto.IdProducto;
            productoVendido.IdVenta = dto.IdVenta;

            return productoVendido;
        }

        public  ProductoVendidoDTO MapearToDTO(ProductoVendido productoVendido)
        {
            ProductoVendidoDTO dto = new ProductoVendidoDTO();

            dto.Id = productoVendido.Id;
            dto.Stock = productoVendido.Stock;
            dto.IdProducto = productoVendido.IdProducto;
            dto.IdVenta = productoVendido.IdVenta;

            return dto;
        }
    }
}
