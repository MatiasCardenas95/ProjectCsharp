using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Modelo;

namespace FinalProject.Manejador
{
    internal class ManejadorUsuario
    {

        public static string cadenaConexion = "Data Source=DESKTOP-DUE7KKA;Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static Usuario ObtenerUsuario(int IdUsuario)
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
    }
}
