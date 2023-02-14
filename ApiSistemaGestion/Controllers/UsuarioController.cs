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
        [HttpPut]

        public void ModificarUsuario(Usuario usuario) 
        {
            ManejadorUsuario.UpdateUsuario(usuario);
        }

    }
}
