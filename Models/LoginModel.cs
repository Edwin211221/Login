using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Login.Models
{
    public class LoginModel : UsuarioModel
    {
        private Config.Conexion _conexion = new Config.Conexion();
        public string Error { get; set; }

        public string VerificarLogin(LoginModel loginModel)
        {
            try
            {
                using (SqlConnection con = _conexion.AbrirConexion())
                {
                    // Usa COUNT(*) para saber si existe al menos un usuario válido
                    string cadena = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @usuario AND Contrasenia = @contrasenia";
                    SqlCommand sqlCommand = new SqlCommand(cadena, con);

                    sqlCommand.Parameters.AddWithValue("@usuario", loginModel.NombreUsuario);
                    sqlCommand.Parameters.AddWithValue("@contrasenia", loginModel.Contrasenia);

                    int contador = (int)sqlCommand.ExecuteScalar();

                    if (contador > 0)
                    {
                        return "ok";
                    }
                    else
                    {
                        Error = "El usuario o la contraseña son incorrectos";
                        return Error;
                    }
                }
            }
            catch (Exception ex)
            {
                Error = "Error al intentar el login: " + ex.Message;
                return Error;
            }
        }
    }
}