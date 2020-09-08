namespace GeometryLib.Models.Geometry
{
    interface EdgeInterface
    {
        Point Org { get; set; }

        Point Dest { get; set; }

        Edge Rot();

        Edge Flip();

        Point Point(double t);

        RelativeEdgePosition Intersect(Edge e, out double t);

        RelativeEdgePosition Cross(Edge e, out double t);

        bool IsVertical();

        double Slope();

        double Y(double x);
    }
}
