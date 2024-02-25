using WebApiSistema_PrimeraEntrega_GuidoComba.DTOs;
using WebApiSistema_PrimeraEntrega_GuidoComba.models;

namespace WebApiSistema_PrimeraEntrega_GuidoComba.Mapper
{
    public class UsuarioMapper
    {
        public Usuario MapearToUsuario(UsuarioDTO dto) 
        {
            Usuario usuario = new Usuario();
            usuario.Id = dto.Id;
            usuario.Nombre = dto.Nombre;
            usuario.Apellido = dto.Apellido;
            usuario.NombreUsuario = dto.NombreUsuario;
            usuario.Contraseña = dto.Contraseña;
            usuario.Mail = dto.Mail;

            return usuario;

        }

        public UsuarioDTO MapearToDTO(Usuario usuario)
        {
            UsuarioDTO dto = new UsuarioDTO();
            dto.Id = usuario.Id;
            dto.Nombre = usuario.Nombre;
            dto.Apellido = usuario.Apellido;
            dto.NombreUsuario = usuario.NombreUsuario;
            dto.Contraseña = usuario.Contraseña;
            dto.Mail = usuario.Mail;

            return dto;

        }


    }
}
