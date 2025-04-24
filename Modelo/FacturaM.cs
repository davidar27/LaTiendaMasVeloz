using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Modelo.Entities;

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

        public DataTable ObtenerDetallesFacturaM(int idFactura)
        {
            DataTable detallesFactura = new DataTable();

            try
            {
                using (SqlConnection connection = ConexionBD.ObtenerConexion())
                using (SqlCommand command = new SqlCommand("sp_ObtenerDetallesPorFactura", connection))
                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@id_factura", SqlDbType.Int).Value = idFactura;

                    da.Fill(detallesFactura);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener detalles de factura: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al obtener detalles de factura: " + ex.Message, ex);
            }

            return detallesFactura;
        }



        public int AgregarFacturaM(string tipoFactura, int? idCliente, int idEmpleado)
        {
            int facturaId = 0;

            using (SqlConnection connection = ConexionBD.ObtenerConexion())
            using (SqlCommand command = new SqlCommand("sp_InsertarFactura", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@tipo_factura", SqlDbType.VarChar, 50)
                       .Value = (object)tipoFactura ?? DBNull.Value;
                command.Parameters.Add("@id_cliente", SqlDbType.Int)
                       .Value = idCliente.HasValue ? (object)idCliente.Value : DBNull.Value;
                command.Parameters.Add("@id_empleado", SqlDbType.Int)
                       .Value = idEmpleado;

                connection.Open();
                facturaId = Convert.ToInt32(command.ExecuteScalar());
            }

            return facturaId;
        }

        public void AgregarDetalleFacturaM(int idFactura, int idProducto, int cantidad)
        {
            using (SqlConnection connection = ConexionBD.ObtenerConexion())
            using (SqlCommand command = new SqlCommand("sp_InsertarDetalleFactura", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id_factura", SqlDbType.Int).Value = idFactura;
                command.Parameters.Add("@id_producto", SqlDbType.Int).Value = idProducto;
                command.Parameters.Add("@cantidad", SqlDbType.Int).Value = cantidad;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }




        public void EliminarFacturaM(string idfactura)
        {
            try
            {
                using (SqlConnection connection = ConexionBD.ObtenerConexion())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("DELETE FROM Facturas WHERE id_factura = @id_factura", connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@id_factura", idfactura);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al eliminar usuario: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al eliminar usuario: " + ex.Message, ex);
            }
        }


        public Factura ObtenerFacturaPorIdM(int idFactura)
        {
            Factura factura = new Factura();
            using var conn = ConexionBD.ObtenerConexion();
            using var cmd = new SqlCommand("sp_ObtenerFacturaPorId", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@id_factura", idFactura);
            conn.Open();
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                factura.IdFactura = reader.GetInt32(0);
                factura.TipoFactura = reader.GetString(1);
                factura.Fecha = reader.GetDateTime(2);
                factura.IdCliente = reader.IsDBNull(3) ? null : reader.GetInt32(3);
                factura.IdEmpleado = reader.GetInt32(4);
            }

            reader.NextResult();
            while (reader.Read())
            {
                factura.Detalles.Add(new DetalleFactura
                {
                    IdDetalle = reader.GetInt32(0),
                    IdProducto = reader.GetInt32(1),
                    NombreProducto = reader.GetString(2),
                    Cantidad = reader.GetInt32(3),
                    Precio = reader.GetDecimal(4)
                });
            }

            return factura;
        }


        public void EditarFacturaM(Factura factura)
        {
            using var conn = ConexionBD.ObtenerConexion();
            conn.Open();

            using (var cmd = new SqlCommand("sp_ActualizarFactura", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_factura", factura.IdFactura);
                cmd.Parameters.AddWithValue("@tipo_factura", factura.TipoFactura);
                cmd.Parameters.AddWithValue("@id_cliente", factura.IdCliente ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@id_empleado", factura.IdEmpleado);
                cmd.ExecuteNonQuery();
            }

            using (var cmd = new SqlCommand("sp_ReemplazarDetallesFactura", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_factura", factura.IdFactura);
                cmd.ExecuteNonQuery();
            }

            foreach (var d in factura.Detalles)
            {
                using var cmdDet = new SqlCommand("sp_InsertarDetalleFactura", conn);
                cmdDet.CommandType = CommandType.StoredProcedure;
                cmdDet.Parameters.AddWithValue("@id_factura", factura.IdFactura);
                cmdDet.Parameters.AddWithValue("@id_producto", d.IdProducto);
                cmdDet.Parameters.AddWithValue("@cantidad", d.Cantidad);
                cmdDet.Parameters.AddWithValue("@precio", d.Precio);
                cmdDet.ExecuteNonQuery();
            }
        }


    }


}
