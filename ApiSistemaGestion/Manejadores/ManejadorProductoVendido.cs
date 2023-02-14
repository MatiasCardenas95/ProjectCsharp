using ApiSistemaGestion.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSistemaGestion.Manejador
{
    internal class ManejadorProductoVendido
    {
        public static string cadenaConexion = "Data Source=DESKTOP-DUE7KKA;Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static List<Producto> ObtenerProductosVendidos(long idUsuario)
        {
            List<long> idProductos = new List<long>();

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT IdProducto FROM Venta" +
                                                    " INNER JOIN ProductoVendido" +
                                                    " ON Venta.Id = ProductoVendido.IdVenta" +
                                                    " WHERE IdUsuario = @idUsuario", conn);

                comando.Parameters.AddWithValue("@idUsuario", idUsuario);

                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        idProductos.Add(reader.GetInt64(0));
                    }
                }
            }

            List<Producto> productos = new List<Producto>();

            foreach (var productoId in idProductos)
            {
                Producto prodTemp = ManejadorProducto.ObtenerProducto(productoId);
                productos.Add(prodTemp);
            }

            return productos;
        }
    }
}
