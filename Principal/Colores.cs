using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal
{
    class Colores
    {
        public static Color FondoPrincipal = Color.FromArgb(242, 242, 242);
        public static Color FondoSection = Color.FromArgb(255, 255, 255);
        public static Color ColorBotonFilter = Color.FromArgb(255, 87, 51);
        public static Color ColorBotonAgregar = Color.FromArgb(76, 217, 99);
        public static Color TextoPrincipal = Color.Black;
        public static Color FondoTabla = Color.LightGray;


        // Fuente personalizada
        public static Font FuenteTitulo = new Font("Arial", 14, FontStyle.Bold);
        public static Font FuenteNormal = new Font("Arial", 12, FontStyle.Regular);
        public static Font FuenteBoton = new Font("Arial", 12, FontStyle.Bold);
    }
}
