using WebApiSistema_PrimeraEntrega_GuidoComba.database;
using WebApiSistema_PrimeraEntrega_GuidoComba.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSistema_PrimeraEntrega_GuidoComba.Service
{
    public static class UsuarioData
    {
        public static Usuario ObtenerUsuario(int id)
        {
            using (CoderContext context = new CoderContext())
            {
                Usuario usuarioBuscado = context.Usuarios.Where(u => u.Id == id).FirstOrDefault();

                return usuarioBuscado;
            }
        }

        public static List<Usuario> ListarUsuarios()
        {
            using (CoderContext context = new CoderContext())
            {
                List<Usuario> usuarios = context.Usuarios.ToList();

                return usuarios;
            }
        }

        public static bool CrearUsuario(Usuario usuario)
        {
            using (CoderContext context = new CoderContext())
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();

                return true;
            }
        }

        public static bool ModificarUsuario(Usuario usuario, int id)
        {
            using (CoderContext context = new CoderContext())
            {
                Usuario usuarioBuscado = context.Usuarios.Where(u => u.Id == id).FirstOrDefault();
                
                usuarioBuscado.Nombre = usuario.Nombre;
                usuarioBuscado.Apellido = usuario.Apellido;
                usuarioBuscado.Contraseña = usuario.Contraseña;
                usuarioBuscado.NombreUsuario = usuario.NombreUsuario;
                usuarioBuscado.Mail = usuario.Mail;

                context.Usuarios.Update(usuarioBuscado);
                context.SaveChanges();

                return true;
            }
        }

        public static bool EliminarUsuario(int id)
        {
            using (CoderContext context = new CoderContext())
            {
                Usuario usuarioBorrado = context.Usuarios.Where(u => u.Id == id).FirstOrDefault();     
                if (usuarioBorrado is not null)
                {
                    context.Usuarios.Remove(usuarioBorrado);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }    
        }


    }
}
