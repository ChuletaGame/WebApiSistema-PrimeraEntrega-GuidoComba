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
    public static class ProductoData
    {
        public static Producto ObtenerProducto(int id)
        {
            using (CoderContext context = new CoderContext())
            {
                Producto productoBuscado = context.Productos.Where(u => u.Id == id).FirstOrDefault();

                return productoBuscado;
            }


        }

        public static List<Producto> ListarProductos()
        {
            using (CoderContext context = new CoderContext())
            {
                List<Producto> productos = context.Productos.ToList();

                return productos;
            }
        }

        public static bool CrearProducto(Producto producto)
        {
            using (CoderContext context = new CoderContext())
            {
                context.Productos.Add(producto);
                context.SaveChanges();

                return true;
            }
        }

        public static bool ModificarProducto(Producto producto, int id)
        {
            using (CoderContext context = new CoderContext())
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
        }

        public static bool EliminarProducto(int id)
        {
            using (CoderContext context = new CoderContext())
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
}
