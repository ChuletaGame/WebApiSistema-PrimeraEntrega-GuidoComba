using WebApiSistema_PrimeraEntrega_GuidoComba.database;
using WebApiSistema_PrimeraEntrega_GuidoComba.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSistema_PrimeraEntrega_GuidoComba.Service
{
    public static class ProductoVendidoData
    {

        public static ProductoVendido ObtenerProductoVendido (int id)
        {
            using (CoderContext context = new CoderContext())
            {
                ProductoVendido productoBuscadoVendido = context.ProductoVendidos.Where(u => u.Id == id).FirstOrDefault();

                return productoBuscadoVendido;
            }

        }

        public static List<ProductoVendido> ListarProductosVendidos()
        {
            using (CoderContext context = new CoderContext())
            {
                List<ProductoVendido> productoVendido = context.ProductoVendidos.ToList();

                return productoVendido;
            }
        }

        public static bool CrearProductoVendido(ProductoVendido productoVendido)
        {
            using (CoderContext context = new CoderContext())
            {
                context.ProductoVendidos.Add(productoVendido);
                context.SaveChanges();

                return true;
            }
        }

        public static bool ModificarProductoVendido(ProductoVendido productoVendido, int id)
        {
            using (CoderContext context = new CoderContext())
            {
                ProductoVendido ProductoVendidoBuscado = context.ProductoVendidos.Where(pv => pv.Id == id).FirstOrDefault();


                ProductoVendidoBuscado.Stock = productoVendido.Stock;
                ProductoVendidoBuscado.IdProducto = productoVendido.IdProducto;
                ProductoVendidoBuscado.IdVenta = productoVendido.IdVenta;

                context.ProductoVendidos.Add(ProductoVendidoBuscado);
                context.SaveChanges();

                return true;
            }
        }

        public static bool EliminarProductoVendido(int id)
        {
            using (CoderContext context = new CoderContext())
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
}
