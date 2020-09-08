using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

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

        void Path(GraphicsPath path);

        void Scene(List<ViewItemInterface> scene);
    }
}
