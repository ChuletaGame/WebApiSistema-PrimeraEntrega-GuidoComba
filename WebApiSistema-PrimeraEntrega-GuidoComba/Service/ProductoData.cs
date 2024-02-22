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


namespace WebApiSistema_PrimeraEntrega_GuidoComba.Service
{
    public class ProductoData
    {
        private CoderContext context;
        private ProductoMapper productoMapper;
        public ProductoData(CoderContext coderContext, ProductoMapper productoMapper)
        {
            this.context = coderContext;
            this.productoMapper = productoMapper;
        }

        public List<ProductoDTO> ObtenerProdcutosPorIdDeUsuario(int idUsuario)
        {
            return context.Productos.Where(p=>p.IdUsuario == idUsuario).Select(p=>this.productoMapper.MapearToDTO(p)).ToList();
     
        }


        public Producto ObtenerProducto(int id)
        {
            Producto productoBuscado = context.Productos.Where(u => u.Id == id).FirstOrDefault();

            return productoBuscado;
        }

        public List<Producto> ListarProductos()
        {
            List<Producto> productos = context.Productos.ToList();

            return productos;
        }

        public bool CrearProducto(ProductoDTO dto)
        {
            Producto p =productoMapper.MapearToProdcuto(dto);
            
            context.Productos.Add(p);
            context.SaveChanges();

            return true;
        }

        public bool ModificarProducto( int id, ProductoDTO productoDTO)
        {
            Producto? ProductoBuscado = context.Productos.Where(p => p.Id == id).FirstOrDefault();
            if (ProductoBuscado is not null)
            {
                ProductoBuscado.Descripciones = productoDTO.Descripciones;
                ProductoBuscado.Costo = productoDTO.Costo;
                ProductoBuscado.PrecioVenta = productoDTO.PrecioVenta;
                ProductoBuscado.Stock = productoDTO.Stock;
                ProductoBuscado.IdUsuario = productoDTO.IdUsuario;

                context.Productos.Update(ProductoBuscado);
                context.SaveChanges();

                return true;
            }
            

            return false;
        }

        public bool EliminarProducto(int id)
        {
            Producto productoABorrado = context.Productos.Include(p => p.ProductoVendidos).Where(p => p.Id == id).FirstOrDefault();

            if (productoABorrado is not null)
            {
                context.Productos.Remove(productoABorrado);
                context.SaveChanges();
                return true;
            }

            return false;
        }

        internal void ActualizarProducto(ProductoDTO productoActual)
        {
            throw new NotImplementedException();
        }

        internal ProductoDTO ObtenerProdcutosPorIdProducto(int id)
        {
            throw new NotImplementedException();
        }
    }
}
