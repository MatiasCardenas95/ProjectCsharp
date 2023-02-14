﻿using ApiSistemaGestion.Manejador;
using ApiSistemaGestion.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSistemaGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
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
        public string EliminarProducto(int id) 
        {
            return ManejadorProducto.EliminarProducto(id) == 1 ? "Se elimino el producto" : "No se pudo eliminar";
        }
        
    }
}