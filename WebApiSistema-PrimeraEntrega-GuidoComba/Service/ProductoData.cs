using WebApiSistema_PrimeraEntrega_GuidoComba.database;
using WebApiSistema_PrimeraEntrega_GuidoComba.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


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

        public  bool CrearProducto(Producto producto)
        {
            context.Productos.Add(producto);
            context.SaveChanges();

            return true;
        }

        public  bool ModificarProducto(Producto producto, int id)
        {
            Producto ProductoBuscado = context.Productos.Where(p => p.Id == id).FirstOrDefault();

            ProductoBuscado.Descripciones = producto.Descripciones;
            ProductoBuscado.Costo = producto.Costo;
            ProductoBuscado.PrecioVenta = producto.PrecioVenta;
            ProductoBuscado.Stock = producto.Stock;
            ProductoBuscado.IdUsuario = producto.IdUsuario;

            context.Productos.Update(ProductoBuscado);
            context.SaveChanges();

            return true;
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
