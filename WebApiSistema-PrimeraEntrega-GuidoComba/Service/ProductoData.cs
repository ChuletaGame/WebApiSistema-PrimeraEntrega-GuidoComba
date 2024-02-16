using WebApiSistema_PrimeraEntrega_GuidoComba.database;
using WebApiSistema_PrimeraEntrega_GuidoComba.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiSistema_PrimeraEntrega_GuidoComba.DTOs;


namespace WebApiSistema_PrimeraEntrega_GuidoComba.Service
{
    public class ProductoData
    {
        private CoderContext context;
        public ProductoData(CoderContext coderContext)
        {
            this.context = coderContext;
        }

        public  Producto ObtenerProducto(int id)
        {
            Producto productoBuscado = context.Productos.Where(u => u.Id == id).FirstOrDefault();

            return productoBuscado;
        }

        public  List<Producto> ListarProductos()
        {
            List<Producto> productos = context.Productos.ToList();

            return productos;
        }

        public  bool CrearProducto(ProductoDTO dto)
        {
            Producto p = new Producto();
            p.Id = dto.Id;
            p.Descripciones = dto.Descripciones;
            p.Costo = dto.Costo;
            p.Stock = dto.Stock;
            p.PrecioVenta = dto.PrecioVenta;
            p.IdUsuario = dto.IdUsuario;
            

            context.Productos.Add(p);
            context.SaveChanges();

            return true;
        }

        public  bool ModificarProducto( int id, ProductoDTO productoDTO)
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

        public  bool EliminarProducto(int id)
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

    }
}
