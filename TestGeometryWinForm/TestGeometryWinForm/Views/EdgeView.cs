using GeometryLib.Models.Geometry;

namespace TestGeometryWinForm.Views
{
    public class EdgeView : ViewItem
    {
        public Edge Edge { get; set; }

        public EdgeView (Edge edge)
        {
            this.Edge = edge;
        }

        public EdgeView(Edge edge, System.Drawing.Color color)
        {
            this.Edge = edge;
            this.PenColor = color;
        }

        public override void Draw(ViewInterface view)
        {
            view.SetPenColor(this.PenColor);
            view.Line(Edge.Org.X, view.Height - 1 - Edge.Org.Y, Edge.Dest.X, view.Height - 1 - Edge.Dest.Y);
        }
    }
}
