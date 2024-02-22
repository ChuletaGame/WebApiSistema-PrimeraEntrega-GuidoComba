using WebApiSistema_PrimeraEntrega_GuidoComba.database;
using WebApiSistema_PrimeraEntrega_GuidoComba.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiSistema_PrimeraEntrega_GuidoComba.DTOs;
using WebApiSistema_PrimeraEntrega_GuidoComba.Mapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WebApiSistema_PrimeraEntrega_GuidoComba.Service
{
    public  class VentaData
    {
        private CoderContext context;
        private ProductoVendidoData productoVendidoData;
        private ProductoData productoData;
        private VentaMapper ventaMapper;
        public VentaData(CoderContext coderContext, ProductoVendidoData productoVendidoData, ProductoData productoData,VentaMapper ventaMapper)
        {
            this.context = coderContext;
            this.productoVendidoData = productoVendidoData;
            this.ventaMapper = ventaMapper;
            this.productoData = productoData;
        }


        public List<VentaDTO> ObtenerVentasPorIdUsuario(int idUsuario)
        {
            return this.context.Venta.Where(v => v.IdUsuario == idUsuario)
                .Select(v=> this.ventaMapper.MapearToDto(v)).ToList();
        }
        public bool AgregarNuevaVenta(int idUsuario, List<ProductoDTO> productosDTO)
        {
            Venta venta = new Venta();
            List<string> nombredeProductos = productosDTO.Select(p => p.Descripciones).ToList();
            string comentarios = string.Join(",", nombredeProductos); 
            venta.Comentarios = comentarios;
            venta.IdUsuario = idUsuario;

            EntityEntry<Venta>? resultado = this.context.Venta.Add(venta);
            resultado.State = Microsoft.EntityFrameworkCore.EntityState.Added;
            this.context.SaveChanges();

            this.MarcarComoProductosVendidos(productosDTO, venta.Id);

            this.ActualizarStockDeProductosVendidos(productosDTO);

            return true;
        }

        private void MarcarComoProductosVendidos(List<ProductoDTO> productoDTOs, int idVenta)
        {
            productoDTOs.ForEach(p =>
            {
                ProductoVendidoDTO productoVendidoDTO = new ProductoVendidoDTO();
                productoVendidoDTO.IdProducto = p.Id;
                productoVendidoDTO.Stock = p.Stock;
                productoVendidoDTO.IdVenta = idVenta;

                this.productoVendidoData.AgregarUnProductoVendido(productoVendidoDTO);

            });
        }

        private void ActualizarStockDeProductosVendidos(List<ProductoDTO> productoDTOs)
        {

            productoDTOs.ForEach(p =>
            {
                ProductoDTO productoActual = this.productoData.ObtenerProdcutosPorIdProducto(p.Id);
                productoActual.Stock -= p.Stock;
                this.productoData.ActualizarProducto(productoActual);

            });
        }




        public  Venta ObtenerVenta(int id)
        {
            Venta ventaBuscado = context.Venta.Where(u => u.Id == id).FirstOrDefault();

            return ventaBuscado;
        }

        public  List<Venta> ListarVenta()
        {
            List<Venta> venta = context.Venta.ToList();

            return venta;
        }

        public  bool CrearVenta(VentaDTO dto)
        {
            Venta v = VentaMapper.MapearToVenta(dto);

            context.Venta.Add(v);
            context.SaveChanges();

            return true;
        }

        public  bool ModificarVenta( int id, VentaDTO ventaDTO)
        {
            Venta VentaBuscada = context.Venta.Where(v => v.Id == id).FirstOrDefault();

            VentaBuscada.Comentarios = ventaDTO.Comentarios;
            VentaBuscada.IdUsuario = ventaDTO.IdUsuario;
            
            context.Venta.Update(VentaBuscada);
            context.SaveChanges();

            return true;
        }

        public  bool EliminarVenta(int id)
        {
            Venta ventaABorrado = context.Venta.Include(p => p.ProductoVendidos).Where(v => v.Id == id).FirstOrDefault();

            if (ventaABorrado is not null)
            {
                context.Venta.Remove(ventaABorrado);
                context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
