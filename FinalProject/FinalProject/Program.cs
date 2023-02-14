using System.ComponentModel;
using System.Data.SqlClient;
using FinalProject.Manejador;
using FinalProject.Modelo;

namespace FinalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Trae a un Usuario
            /*
            Usuario usuario = ManejadorUsuario.ObtenerUsuario(2);

            Console.WriteLine("Nombre: " + usuario.Nombre + "\n"+
                              "Apellido: " + usuario.Apellido + "\n" +
                              "Nombre Usuario: " + usuario.NombreUsuario + "\n" +
                              "Contraseña: " + usuario.Contraseña + "\n" +
                              "Mail: " + usuario.Mail);
            
            */

            Producto producto = ManejadorProducto.ObtenerProducto(1);

            //Trae lista de productos Por un Usuario
            /*
            List<Producto> productos = ManejadorProducto.ObtenerProductos(1);

            Console.WriteLine("Productos del usuario: ");

            foreach (Producto producto in productos)
            {
                Console.WriteLine(producto.Descripciones);
            }
            */

            //Trae una lista de productos vendidos por el Usuario
            /*
            List<Producto> productosVendidos = ManejadorProductoVendido.ObtenerProductosVendidos(1);

            Console.WriteLine("Productos vendidos por el Usuario: ");

            foreach (var productVendido in productosVendidos)
            {
                Console.WriteLine(productVendido.Descripciones);
            }
            */

            //Trae lista de Ventas Por un Usuario
            /*
            List<Venta> ventas = ManejadorVenta.ObtenerVentas(1);

            Console.WriteLine("Ventas del usuario: ");

            foreach (var ventasUsuario in ventas)
            {
                Console.WriteLine(ventasUsuario.Id + ventasUsuario.Comentarios);
            }
            */

            //Inicio de sesion, devuelve el nombre de usuario Encontrado, sino devuelve un NUll
            /*
            Usuario usuarioLogueado = ManejadorUsuario.Login("tcasazza", "SoyTobiasCasazza");

            if (usuarioLogueado == null)
            {
                Console.WriteLine("Contraseña o Usuario incorrectos");
            }
            else
            {
                Console.WriteLine("Bienvenido " + usuarioLogueado.NombreUsuario);

            }
            */
        }

    }
    
}