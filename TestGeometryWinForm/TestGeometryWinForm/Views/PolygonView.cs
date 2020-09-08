using GeometryLib.Models.Geometry;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TestGeometryWinForm.Views
{
    class PolygonView : ViewItem
    {
        public Polygon Polygon { get; set; }

        public PolygonView(Polygon polygon)
        {
            this.Polygon = polygon;
        }

        public PolygonView(Polygon polygon, System.Drawing.Color color)
        {
            this.Polygon = polygon;
            this.PenColor = color;
        }

        public override void Draw(ViewInterface view)
        {
            var points = new PointF[this.Polygon.Size()];

            for (int i = 0; i < this.Polygon.Size(); i++, this.Polygon.Advance(Rotation.CLOCKWISE))
            {
                points[i] = new PointF((float)this.Polygon.Point().X, (float)view.Height - (float)this.Polygon.Point().Y);
            }

            GraphicsPath path = new GraphicsPath();
            path.StartFigure(); // Start the first figure.
            path.AddLines(points);
            path.CloseFigure(); // Second figure is closed.

            view.SetPenColor(this.PenColor);
            view.Path(path);
        }
    }
}
