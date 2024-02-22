using WebApiSistema_PrimeraEntrega_GuidoComba.database;
using WebApiSistema_PrimeraEntrega_GuidoComba.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSistema_PrimeraEntrega_GuidoComba.Mapper;
using WebApiSistema_PrimeraEntrega_GuidoComba.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WebApiSistema_PrimeraEntrega_GuidoComba.Service
{
    public class ProductoVendidoData
    {
        private CoderContext context;
        private ProductoVendidoMapper productoVendidoMapper;
        public ProductoVendidoData(CoderContext coderContext,ProductoVendidoMapper productoVendidoMapper)
        {
            this.context = coderContext;
            this.productoVendidoMapper = productoVendidoMapper;
        }

        public List<ProductoVendidoDTO> ObtenerProductosVendidosPorIdUsuario(int idUsuario)
        {
            List<Producto>? productos = this.context.Productos
                .Include(p=>p.ProductoVendidos).Where(p=> p.IdUsuario == idUsuario).ToList();

            List<ProductoVendido?>? pVendidos = productos.Select(p=>p.ProductoVendidos.ToList().
            Find(pv => pv.IdProducto == p.Id)).Where(p=> !object.ReferenceEquals(p,null)).ToList();

            List<ProductoVendidoDTO> dto = pVendidos.Select(p=> this.productoVendidoMapper.MapearToDTO(p)).ToList();

            return dto;
        }

        public bool AgregarUnProductoVendido (ProductoVendidoDTO productoVendidoDTO)
        {
            ProductoVendido ProductoVendido = this.productoVendidoMapper.MapearToProdcutoVendido(productoVendidoDTO);
            EntityEntry<ProductoVendido>? resultado = this.context.ProductoVendidos.Add(ProductoVendido);
            resultado.State = Microsoft.EntityFrameworkCore.EntityState.Added;
            context.SaveChanges();

            return true;
        }



        public  ProductoVendido ObtenerProductoVendido (int id)
        {
            ProductoVendido productoBuscadoVendido = context.ProductoVendidos.Where(u => u.Id == id).FirstOrDefault();
            
            return productoBuscadoVendido;
        }

        public  List<ProductoVendido> ListarProductosVendidos()
        {
            List<ProductoVendido> productoVendido = context.ProductoVendidos.ToList();

            return productoVendido;
        }

        public  bool CrearProductoVendido(ProductoVendido productoVendido)
        {
            context.ProductoVendidos.Add(productoVendido);
            context.SaveChanges();

            return true;
        }

        public  bool ModificarProductoVendido(ProductoVendido productoVendido, int id)
        {
            ProductoVendido ProductoVendidoBuscado = context.ProductoVendidos.Where(pv => pv.Id == id).FirstOrDefault();

            ProductoVendidoBuscado.Stock = productoVendido.Stock;
            ProductoVendidoBuscado.IdProducto = productoVendido.IdProducto;
            ProductoVendidoBuscado.IdVenta = productoVendido.IdVenta;

            context.ProductoVendidos.Add(ProductoVendidoBuscado);
            context.SaveChanges();

            return true;
        }

        public  bool EliminarProductoVendido(int id)
        {
            ProductoVendido productoABorradoVendido = context.ProductoVendidos.Where(pv => pv.Id == id).FirstOrDefault();

            if (productoABorradoVendido is not null)
            {
                context.ProductoVendidos.Remove(productoABorradoVendido);
                context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
