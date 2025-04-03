using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Modelo
{
    public  class ConexionBD
    {

        private const string CadenaConexion = "Server=DESKTOP-V3P4M09\\SQLEXPRESS;Database=LaTiendaMasVeloz;Integrated Security=true;TrustServerCertificate=True;";
        //private const string CadenaConexion = "Server=DESKTOP-EMIE4FD\\SQLEXPRESS;Database=LaTiendaMasVeloz;Integrated Security=true;TrustServerCertificate=True;";

        public static SqlConnection ObtenerConexion()
        {
            var conexion = new SqlConnection(CadenaConexion);

            return conexion;
        }
    }
}
