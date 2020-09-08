using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGeometryWinForm.Views
{
    public interface ViewInterface
    {
        double Width { get; }

        double Height { get; }

        void SetBrushColor(Color color);

        void SetPenColor(Color color);

        void Line(double x0, double y0, double x1, double y1);

        void Circle(double x, double y, double r);

        void Scene(List<ViewItemInterface> scene);
    }
}
