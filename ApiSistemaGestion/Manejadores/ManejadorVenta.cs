using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiSistemaGestion.Modelos;

namespace ApiSistemaGestion.Manejador
{
    internal class ManejadorVenta
    {
        public static string cadenaConexion = "Data Source=DESKTOP-DUE7KKA;Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static Venta ObtenerVenta(long idVenta)
        {
            Venta venta = new Venta();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Venta WHERE Venta.Id = @idVenta", conexion);

                comando.Parameters.AddWithValue("@idVenta", idVenta);

                conexion.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    venta.Id = reader.GetInt64(0);
                    venta.Comentarios = reader.GetString(1);
                    venta.IdUsuario = reader.GetInt64(2);
                }
            }
            return venta;
        }


        public static List<Venta> ObtenerVentas(long idUsuario)
        {
            List<long> ventas = new List<long>();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT Venta.Id FROM Venta " +
                                                    " WHERE IdUsuario = @idUsuario", conexion);

                comando.Parameters.AddWithValue("@idUsuario", idUsuario);

                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ventas.Add(reader.GetInt64(0));
                    }
                }
            }

            List<Venta> listaVentas = new List<Venta>();

            foreach (var id in ventas)
            {
                Venta ventaTemporal = ObtenerVenta(id);
                listaVentas.Add(ventaTemporal);
            }
            return listaVentas;
        }
    }


}

