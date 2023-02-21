using ApiSistemaGestion.Manejador;
using ApiSistemaGestion.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSistemaGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet("{id}")]
        public Producto ObtenerProducto (long id)
        {
           return  ManejadorProducto.ObtenerProducto(id);
        }
        
        [HttpGet("{idUsuario}")]

        public List<Producto> obtenerProductos (long idUsuario)
        {
            return ManejadorProducto.ObtenerProductos(idUsuario);
        }

        [HttpPost]
        public void CrearProducto (Producto producto) 
        {
            ManejadorProducto.InsertarProducto (producto);
        }

        [HttpPut]
        public void ModificarProducto(Producto producto)
        { 
            ManejadorProducto.UpdateProducto (producto);
        }

        [HttpDelete]
        public string EliminarProducto(long id) 
        {
            return ManejadorProducto.EliminarProducto(id) == 1 ? "Se elimino el producto" : "No se pudo eliminar";
        }
        
    }
}
