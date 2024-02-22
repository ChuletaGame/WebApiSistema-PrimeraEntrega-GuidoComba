using WebApiSistema_PrimeraEntrega_GuidoComba.DTOs;
using WebApiSistema_PrimeraEntrega_GuidoComba.models;

namespace WebApiSistema_PrimeraEntrega_GuidoComba.Mapper
{
    public class VentaMapper
    {
        public static  Venta MapearToVenta (VentaDTO dto)
        {
            Venta venta = new Venta();
            venta.Id = dto.Id;
            venta.Comentarios = dto.Comentarios;
            venta.IdUsuario = dto.IdUsuario;

            return venta;
        }

        public VentaDTO MapearToDto(Venta venta)
        {
            VentaDTO dto = new VentaDTO();
            dto.Id = venta.Id;
            dto.Comentarios = venta.Comentarios;
            dto.IdUsuario = venta.IdUsuario;

            return dto;
        }
    }
}
