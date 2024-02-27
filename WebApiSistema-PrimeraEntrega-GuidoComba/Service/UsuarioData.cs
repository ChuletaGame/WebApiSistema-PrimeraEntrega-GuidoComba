using WebApiSistema_PrimeraEntrega_GuidoComba.database;
using WebApiSistema_PrimeraEntrega_GuidoComba.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSistema_PrimeraEntrega_GuidoComba.DTOs;
using WebApiSistema_PrimeraEntrega_GuidoComba.Mapper;

namespace WebApiSistema_PrimeraEntrega_GuidoComba.Service
{
    public  class UsuarioData
    {
        private CoderContext context;
        private UsuarioMapper usuarioMapper;
        public UsuarioData(CoderContext coderContext,UsuarioMapper usuarioMapper) 
        {
            this.context = coderContext;
            this.usuarioMapper = usuarioMapper;
        }

       
        public Usuario ObtenerUsuarioPorNombreDeUsuario(string nombreDeUsuario)
        {
            Usuario? usuarioBuscado = context.Usuarios.Where(u => u.NombreUsuario == nombreDeUsuario).FirstOrDefault();
            return usuarioBuscado;
        }

        public Usuario ObtenerUsuarioYPasswordDeUsuario(string Usuario, string Password)
        {
            Usuario? usuarioBuscado = context.Usuarios.Where(u => u.NombreUsuario == Usuario && u.Contraseña == Password).FirstOrDefault();
            return usuarioBuscado;
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

        public  bool CrearUsuario(UsuarioDTO dto)
        {
            Usuario u = new Usuario();
            u.Id = dto.Id;
            u.Nombre = dto.Nombre;
            u.Apellido = dto.Apellido;
            u.NombreUsuario = dto.NombreUsuario;
            u.Contraseña = dto.Contraseña;
            u.Mail = dto.Mail;

            context.Usuarios.Add(u);
            context.SaveChanges();

            return true;
        }

        public  bool ModificarUsuario(int id, UsuarioDTO usuarioDTO)
        {

            Usuario usuarioBuscado = context.Usuarios.Where(u => u.Id == id).FirstOrDefault();
            
            usuarioBuscado.Nombre = usuarioDTO.Nombre;
            usuarioBuscado.Apellido = usuarioDTO.Apellido;
            usuarioBuscado.Contraseña = usuarioDTO.Contraseña;
            usuarioBuscado.NombreUsuario = usuarioDTO.NombreUsuario;
            usuarioBuscado.Mail = usuarioDTO.Mail;

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
