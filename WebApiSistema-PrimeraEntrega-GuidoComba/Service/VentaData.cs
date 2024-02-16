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
    public  class VentaData
    {
        private CoderContext context;
        public VentaData(CoderContext coderContext)
        {
            this.context = coderContext;
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

        public  bool CrearVenta(Venta venta)
        {
            context.Venta.Add(venta);
            context.SaveChanges();

            return true;
        }

        public  bool ModificarVenta(Venta venta, int id)
        {
            Venta VentaBuscada = context.Venta.Where(v => v.Id == id).FirstOrDefault();

            VentaBuscada.Comentarios = venta.Comentarios;
            VentaBuscada.IdUsuario = venta.IdUsuario;
            
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
