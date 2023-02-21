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
    internal class ManejadorProducto
    {
        public static string cadenaConexion = "Data Source=DESKTOP-DUE7KKA;Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static Producto ObtenerProducto(long idProducto)
        {
            Producto producto = new Producto();

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {

                SqlCommand comando = new SqlCommand("SELECT * FROM Producto WHERE Id=@idProducto", conn);

                comando.Parameters.AddWithValue("@idProducto", idProducto);

                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    producto.Id = reader.GetInt64(0);
                    producto.Descripciones = reader.GetString(1);
                    producto.Costo = reader.GetDecimal(2);
                    producto.PrecioVenta = reader.GetDecimal(3);
                    producto.Stock = reader.GetInt32(4);
                    producto.IdUsuario = reader.GetInt64(5);

                }
            }

            return producto;

        }

        public static List<Producto> ObtenerProductos(long idUsuario)
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand comando = new SqlCommand("SELECT * FROM Producto WHERE IdUsuario = @idUsuario ", conn))
                {
                    SqlParameter usuarioIdParametro = new SqlParameter();

                    usuarioIdParametro.Value = idUsuario;
                    usuarioIdParametro.SqlDbType = SqlDbType.BigInt;
                    usuarioIdParametro.ParameterName = "idUsuario";

                    comando.Parameters.Add(usuarioIdParametro);

                    conn.Open();

                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Producto productoTemporal = new Producto();
                            productoTemporal.Id = reader.GetInt64(0);
                            productoTemporal.Descripciones = reader.GetString(1);
                            productoTemporal.Costo = reader.GetDecimal(2);
                            productoTemporal.PrecioVenta = reader.GetDecimal(3);
                            productoTemporal.Stock = reader.GetInt32(4);
                            productoTemporal.IdUsuario = reader.GetInt64(5);

                            productos.Add(productoTemporal);
                        }
                    }
                }

                return productos;

            }
        }

        public static int InsertarProducto(Producto producto)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("INSERT INTO Producto(Descripciones, Costo, PrecioVenta, Stock, IdUsuario)" +
                                                    "VALUES(@descripciones, @costo, @precioVenta, @stock, @idUsuario)", conn);

                comando.Parameters.AddWithValue("@descripciones", producto.Descripciones);
                comando.Parameters.AddWithValue("@costo", producto.Costo);
                comando.Parameters.AddWithValue("@precioVenta", producto.PrecioVenta);
                comando.Parameters.AddWithValue("@stock", producto.Stock);
                comando.Parameters.AddWithValue("@idUsuario", producto.IdUsuario);

                conn.Open();

                return comando.ExecuteNonQuery();

            }
        }

        public static int UpdateProducto(Producto producto)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("UPDATE Producto " +
                                                    "SET Descripciones=@descripciones," +
                                                    "Costo=@costo," + 
                                                    "PrecioVenta=@precioVenta," +
                                                    "Stock=@stock," +
                                                    "IdUsuario=@idUsuario " +
                                                    "WHERE Id=@id", conn);
                
                comando.Parameters.AddWithValue("@descripciones", producto.Descripciones);
                comando.Parameters.AddWithValue("@costo", producto.Costo);
                comando.Parameters.AddWithValue("@precioVenta", producto.PrecioVenta);
                comando.Parameters.AddWithValue("@stock", producto.Stock);
                comando.Parameters.AddWithValue("@idUsuario", producto.IdUsuario);
                comando.Parameters.AddWithValue("@id", producto.Id);

                conn.Open();

                return comando.ExecuteNonQuery();
            }
        }

        public static int EliminarProducto(long idProducto)
        {
            using (SqlConnection sqlConnection = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;

                    sqlCommand.Connection.Open();

                    sqlCommand.CommandText = "DELETE ProductoVendido " +
                                             "WHERE IdProducto = @idProducto";      
                                               
                    sqlCommand.Parameters.AddWithValue("@idProducto", idProducto);

                    int registro = sqlCommand.ExecuteNonQuery();

                    sqlCommand.CommandText = " DELETE Producto " +                                               
                                             "WHERE Id = @idProducto";

                    registro = sqlCommand.ExecuteNonQuery();

                    sqlCommand.Connection.Close();

                    return registro;
                }
            }
        }





    }
}


