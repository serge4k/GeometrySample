namespace GeometryLib.Models.Geometry
{
    public interface PolygonAccessInterface
    {
        int Size();
        Edge Edge();
        Point Point();
        VertexInterface V();
        VertexInterface SetV(VertexInterface v);
    }
}