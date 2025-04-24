using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entities
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public string TipoFactura { get; set; }
        public int? IdCliente { get; set; }
        public int? IdProveedor { get; set; }
        public DateTime Fecha { get; set; }


        public int IdEmpleado { get; set; }
        public List<DetalleFactura> Detalles { get; set; } = new List<DetalleFactura>();
    }
}
