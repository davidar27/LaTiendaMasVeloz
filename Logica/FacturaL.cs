using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Logica
{
    public class FacturaL
    {

        private FacturaM facturaM = new FacturaM();

        public DataTable ObtenerFacturaL()
        {
            DataTable Factura = facturaM.ObtenerFacturasM();
            return Factura;
        }
    }
}
