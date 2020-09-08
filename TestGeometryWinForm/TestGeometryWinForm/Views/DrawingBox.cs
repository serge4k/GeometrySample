using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGeometryWinForm.Views
{
    public class DrawingBox : Panel, ViewInterface, IDisposable
    {
        private Graphics graphics;

        private Pen pen;

        private Brush brush;

        public DrawingBox()
        {
            this.DoubleBuffered = true;
            pen = Pens.Black;
            brush = Brushes.Black;
        }

        double ViewInterface.Width => this.ClientSize.Width;

        double ViewInterface.Height => this.ClientSize.Height;

        public void Circle(double x, double y, double r)
        {
            graphics.FillEllipse(this.brush, (float)(x - r/2 + 1), (float)(y - r/2 + 1), (float)(r / 2), (float)(r / 2));
        }

        public void Line(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(this.pen, (float)x0, (float)y0, (float)x1, (float)y1);
        }

        public void Scene(List<ViewItemInterface> scene)
        {
            foreach(var item in scene)
            {
                item.Draw(this);
            }
        }

        public void SetBrushColor(Color color)
        {
            this.brush = new SolidBrush(color);
        }

        public void SetPenColor(Color color)
        {
            this.pen = new Pen(color);
        }

        internal void SetGraphics(Graphics graphics)
        {
            this.graphics = graphics;
        }
    }
}
