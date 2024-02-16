using WebApiSistema_PrimeraEntrega_GuidoComba.database;
using WebApiSistema_PrimeraEntrega_GuidoComba.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSistema_PrimeraEntrega_GuidoComba.Service
{
    public  class UsuarioData
    {
        private CoderContext context;
        public UsuarioData(CoderContext coderContext) 
        {
            this.context = coderContext;
        }


        public  Usuario ObtenerUsuario(int id)
        {
            Usuario usuarioBuscado = context.Usuarios.Where(u => u.Id == id).FirstOrDefault();
            return usuarioBuscado;        
        }

        public  List<Usuario> ListarUsuarios()
        {
            List<Usuario> usuarios = context.Usuarios.ToList();
            return usuarios;
        }

        public  bool CrearUsuario(Usuario usuario)
        {

            context.Usuarios.Add(usuario);
            context.SaveChanges();
            return true;
        }

        public  bool ModificarUsuario(Usuario usuario, int id)
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

        public bool EliminarUsuario(int id)
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
