namespace GeometryLib.Models.Geometry
{
    public interface PolygonInterface
    {
        VertexInterface Advance(Rotation rotation);
        VertexInterface Ccw();
        VertexInterface Cw();
        Edge Edge();
        VertexInterface Insert(double x, double y);
        VertexInterface Insert(PointInterface p);
        VertexInterface Neighbor(Rotation rotation);
        Point Point();
        void Remove();
        VertexInterface SetV(VertexInterface v);
        int Size();
        Polygon Split(VertexInterface b);
        VertexInterface V();
    }
}