using WebApiSistema_PrimeraEntrega_GuidoComba.DTOs;
using WebApiSistema_PrimeraEntrega_GuidoComba.models;

namespace WebApiSistema_PrimeraEntrega_GuidoComba.Mapper
{
    public class ProductoMapper
    {
        public  Producto MapearToProdcuto(ProductoDTO dto)
        {
            Producto prodcuto = new Producto();
            prodcuto.Id = dto.Id;
            prodcuto.Descripciones = dto.Descripciones;
            prodcuto.Costo = dto.Costo;
            prodcuto.Stock = dto.Stock;
            prodcuto.PrecioVenta = dto.PrecioVenta;
            prodcuto.IdUsuario = dto.IdUsuario;

            return prodcuto;
        }

        public  ProductoDTO MapearToDTO(Producto prodcuto)
        {
            ProductoDTO dto = new ProductoDTO();
            dto.Id = prodcuto.Id;
            dto.Descripciones = prodcuto.Descripciones;
            dto.Costo = prodcuto.Costo;
            dto.Stock = prodcuto.Stock;
            dto.PrecioVenta = prodcuto.PrecioVenta;
            dto.IdUsuario = prodcuto.IdUsuario;

            return dto;
        }

    }
}
