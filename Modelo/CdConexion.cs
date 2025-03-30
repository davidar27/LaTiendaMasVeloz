using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Modelo
{
    public class CdConexion
    {
        //private SqlConnection Conexion = new SqlConnection("Server=DESKTOP-V3P4M09\\SQLEXPRESS;DataBase= InventarioTienda;Integrated Security=true;TrustServerCertificate=True");
        private SqlConnection Conexion = new SqlConnection("Server=DESKTOP-EMIE4FD\\SQLEXPRESS;Database=InventarioTienda;Integrated Security=true;TrustServerCertificate=True;User ID=David;Password=david123.;");
        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }
        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }
    }
}
