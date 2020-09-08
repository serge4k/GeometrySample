using GeometryLib.Models.Geometry;

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
            view.SetBrushColor(this.BrushColor);
            view.Circle(Point.X, view.Height - 1 - Point.Y, 5);
        }
    }
}
