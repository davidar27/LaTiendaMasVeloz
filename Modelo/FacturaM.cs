using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Modelo
{
    public class FacturaM
    {
        public DataTable ObtenerFacturasM()
        {
            DataTable Factura = new DataTable();

            try
            {
                using (SqlConnection connection = ConexionBD.ObtenerConexion())
                using (SqlCommand command = new SqlCommand("sp_ObtenerFacturas", connection))
                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    Debug.WriteLine(Factura);
                    da.Fill(Factura);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener productos: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al obtener productos: " + ex.Message, ex);
            }

            return Factura;
        }
    }
}
