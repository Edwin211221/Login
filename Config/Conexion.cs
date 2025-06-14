using System;
using System.Data.SqlClient;

namespace Login.Config
{
    class Conexion
    {
        // Cambia tu cadena de conexión según sea necesario
        private readonly string cadenaConexion =
            "server=(local);database=Cuarto_MaySep2025;User Id=sa;Password=211221;Trusted_Connection=True";

        private SqlConnection conexion;

        public SqlConnection AbrirConexion()
        {
            if (conexion == null)
                conexion = new SqlConnection(cadenaConexion);

            // Aquí, siempre verifica y abre si está cerrada
            if (conexion.State == System.Data.ConnectionState.Closed)
                conexion.Open();

            return conexion;
        }

        public void CerrarConexion()
        {
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }
    }
}
