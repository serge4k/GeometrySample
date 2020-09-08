using GeometryLib.Models.Geometry;

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
            view.Line(Edge.Org.X, view.Height - 1 - Edge.Org.Y, Edge.Dest.X, view.Height - 1 - Edge.Dest.Y);
        }
    }
}
