using GeometryLib.Models.Geometry;

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
            for (int i = 0; i < this.Polygon.Size(); i++, this.Polygon.Advance(Rotation.CLOCKWISE))
            {
                var viewEdge = new EdgeView(this.Polygon.Edge(), this.PenColor);
                viewEdge.Draw(view);
            }
        }
    }
}
