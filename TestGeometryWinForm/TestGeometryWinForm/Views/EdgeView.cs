using GeometryLib.Models.Geometry;
using System.Drawing.Drawing2D;

namespace TestGeometryWinForm.Views
{
    public class EdgeView : ViewItem
    {
        public EdgeInterface Edge { get; set; }

        public EdgeView (EdgeInterface edge)
        {
            this.Edge = edge;
        }

        public EdgeView(EdgeInterface edge, System.Drawing.Color color)
        {
            this.Edge = edge;
            this.PenColor = color;
        }

        public override void Draw(ViewInterface view)
        {
            view.SetPenColor(this.PenColor);
            
            GraphicsPath path = new GraphicsPath();
            path.StartFigure(); // Start the first figure.
            path.AddLine((float)(Edge.Org.X), (float)view.Height - (float)Edge.Org.Y, (float)Edge.Dest.X, (float)view.Height - (float)Edge.Dest.Y);
            path.CloseFigure(); // Second figure is closed.

            view.Path(path);
        }
    }
}
