using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal.Resources
{
    public class BotonRedondeado : Button
    {
        private int radio = 20;

        public int Radio
        {
            get { return radio; }
            set { radio = value; Invalidate(); }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radio, radio, 180, 90); // Esquina superior izquierda
            path.AddArc(Width - radio, 0, radio ,radio, 270, 90); // Esquina superior derecha
            path.AddArc(Width - radio, Height - radio, radio , radio, 0, 90); // Esquina inferior derecha
            path.AddArc(0, Height - radio, radio , radio, 90, 90); // Esquina inferior izquierda
            path.CloseFigure();

            this.Region = new Region(path);

            using (Pen pen = new Pen(this.FlatAppearance.BorderColor, 1))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }
    }
}