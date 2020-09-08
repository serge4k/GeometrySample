namespace GeometryLib.Models.Geometry
{
    public interface EdgeInterface
    {
        Point Org { get; set; }

        Point Dest { get; set; }

        Edge Rot();

        Edge Flip();

        Point Point(double t);

        RelativeEdgePosition Intersect(EdgeInterface e, out double t);

        RelativeEdgePosition Cross(EdgeInterface e, out double t);

        bool IsVertical();

        double Slope();

        double Y(double x);
    }
}
