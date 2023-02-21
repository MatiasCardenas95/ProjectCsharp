using ApiSistemaGestion.Manejador;
using ApiSistemaGestion.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSistemaGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("{idUsuario}")]
        public Usuario obtenerUsuario(long idUsuario )
        {
            return ManejadorUsuario.ObtenerUsuario(idUsuario);
        }

        [HttpGet("{nombreUsuario}/{pass}")]
        public Usuario Login(string nombreUsuario, string pass)
        {
            return ManejadorUsuario.Login(nombreUsuario, pass);
        }

        [HttpPost]
        public void CrearUsuario(Usuario usuario) 
        {
            ManejadorUsuario.InsertarUsuario(usuario);
        }

        [HttpPut]

        public void ModificarUsuario(Usuario usuario) 
        {
            ManejadorUsuario.UpdateUsuario(usuario);
        }

        [HttpDelete("{idUsuario}")]
        public void EliminarUsuario(long idUsuario) 
        {
            ManejadorUsuario.EliminarUsuario(idUsuario);
        }

    }
}
