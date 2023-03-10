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
    internal class ManejadorUsuario
    {

        public static string cadenaConexion = "Data Source=DESKTOP-DUE7KKA;Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static Usuario ObtenerUsuario(long IdUsuario)
        {
            Usuario usuario = new Usuario();

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand comando = new SqlCommand("SELECT * FROM Usuario WHERE Id=@IdUsuario", conn))
                {
                    SqlParameter usuarioIdParametro = new SqlParameter();

                    usuarioIdParametro.Value = IdUsuario;
                    usuarioIdParametro.SqlDbType = SqlDbType.BigInt;
                    usuarioIdParametro.ParameterName = "IdUsuario";

                    comando.Parameters.Add(usuarioIdParametro);

                    conn.Open();

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            usuario.Id = reader.GetInt64(0);
                            usuario.Nombre = reader.GetString(1);
                            usuario.Apellido = reader.GetString(2);
                            usuario.NombreUsuario = reader.GetString(3);
                            usuario.Contraseña = reader.GetString(4);
                            usuario.Mail = reader.GetString(5);

                        }
                    }
                }
            }

            return usuario;

        }
       
        public static Usuario Login(string nombreUsuario, string pass)
        {

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Usuario WHERE NombreUsuario = @nombreUsuario AND Contraseña = @pass", conn);

                SqlParameter parameterNombreUsuario = new SqlParameter();
                parameterNombreUsuario.ParameterName = "NombreUsuario";
                parameterNombreUsuario.SqlValue = SqlDbType.VarChar;
                parameterNombreUsuario.Value = nombreUsuario;

                SqlParameter parameterContrasena = new SqlParameter();
                parameterContrasena.ParameterName = "pass";
                parameterContrasena.SqlValue = SqlDbType.VarChar;
                parameterContrasena.Value = pass;

                command.Parameters.Add(parameterNombreUsuario);
                command.Parameters.Add(parameterContrasena);

                conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Usuario usuarioEncontrado = new Usuario();
                        reader.Read();
                        usuarioEncontrado.Nombre = reader.GetString(1);
                        usuarioEncontrado.Apellido = reader.GetString(2);
                        usuarioEncontrado.NombreUsuario = reader.GetString(3);
                        usuarioEncontrado.Mail = reader.GetString(5);

                        return usuarioEncontrado;
                    }
                }
            }

            return null;
        }

        public static int InsertarUsuario(Usuario usuario)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("INSERT INTO Usuario(Nombre, Apellido, NombreUsuario, Contraseña, Mail)" +
                                                    "VALUES(@nombre, @apellido, @nombreUsuario, @contrasena, @mail)", conn);

                comando.Parameters.AddWithValue("@nombre", usuario.Nombre);
                comando.Parameters.AddWithValue("@apellido", usuario.Apellido);
                comando.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                comando.Parameters.AddWithValue("@contrasena", usuario.Contraseña);
                comando.Parameters.AddWithValue("@mail", usuario.Mail);

                conn.Open();

                return comando.ExecuteNonQuery();

            }
        }


        public static int UpdateUsuario(Usuario usuario)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("UPDATE Usuario " +
                                                    "SET Nombre=@nombre," +
                                                    "Apellido=@apellido," +
                                                    "NombreUsuario=@nombreUsuario," +
                                                    "Contraseña=@contrasena," +
                                                    "Mail=@mail " +                                                 
                                                    "WHERE Id=@id", conn);

                comando.Parameters.AddWithValue("@id", usuario.Id);
                comando.Parameters.AddWithValue("@nombre", usuario.Nombre);
                comando.Parameters.AddWithValue("@apellido", usuario.Apellido);
                comando.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                comando.Parameters.AddWithValue("@contrasena", usuario.Contraseña);
                comando.Parameters.AddWithValue("@mail", usuario.Mail);

                conn.Open();

                return comando.ExecuteNonQuery();
            }
        }

        public static int EliminarUsuario(long idUsuario)
        {
            using (SqlConnection sqlConnection = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;

                    sqlCommand.Connection.Open();

                    sqlCommand.CommandText = "DELETE Usuario " +
                                             "WHERE Id = @idUsuario";

                    sqlCommand.Parameters.AddWithValue("@Id", idUsuario);

                    int registro = sqlCommand.ExecuteNonQuery();

                    sqlCommand.Connection.Close();

                    return registro;
                }
            }
        }
    }
}
