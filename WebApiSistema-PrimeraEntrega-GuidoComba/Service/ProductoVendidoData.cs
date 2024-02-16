using WebApiSistema_PrimeraEntrega_GuidoComba.database;
using WebApiSistema_PrimeraEntrega_GuidoComba.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSistema_PrimeraEntrega_GuidoComba.Service
{
    public class ProductoVendidoData
    {
        private CoderContext context;
        public ProductoVendidoData(CoderContext coderContext)
        {
            this.context = coderContext;
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
