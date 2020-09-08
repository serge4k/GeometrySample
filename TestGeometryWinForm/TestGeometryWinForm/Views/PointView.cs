using GeometryLib.Models.Geometry;
using System.Drawing.Drawing2D;

namespace TestGeometryWinForm.Views
{
    public class PointView : ViewItem
    {
        public Point Point { get; set; }

        public PointView(Point point)
        {
            this.Point = new Point(point);
            this.BrushColor = System.Drawing.Color.Black;
        }

        public PointView(Point point, System.Drawing.Color color)
        {
            this.Point = new Point(point);
            this.BrushColor = color;
        }

        public override void Draw(ViewInterface view)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure(); // Start the first figure.
            path.AddEllipse((float)(Point.X) - 1, (float)view.Height - (float)Point.Y - 1, 2, 2);
            path.CloseFigure(); // Second figure is closed.

            view.SetPenColor(this.BrushColor);
            view.Path(path);
        }
    }
}
