using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Modelo
{
    public static class ConexionBD
    {
        private const string CadenaConexion = "Server=DESKTOP-V3P4M09\\SQLEXPRESS;Database=LaTiendaMasVeloz;Integrated Security=true;TrustServerCertificate=True;";

        public static SqlConnection ObtenerConexion()
        {
            var conexion = new SqlConnection(CadenaConexion);

            // Validación exhaustiva
            if (string.IsNullOrWhiteSpace(conexion.ConnectionString))
            {
                throw new InvalidOperationException("Cadena de conexión no configurada");
            }

            // Verificación de parámetros críticos
            var builder = new SqlConnectionStringBuilder(conexion.ConnectionString);
            if (string.IsNullOrEmpty(builder.DataSource) || string.IsNullOrEmpty(builder.InitialCatalog))
            {
                throw new InvalidOperationException("Cadena de conexión incompleta");
            }

            return conexion;
        }
    }
}
