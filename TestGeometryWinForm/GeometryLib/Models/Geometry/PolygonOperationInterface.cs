namespace GeometryLib.Models.Geometry
{
    public interface PolygonOperationInterface
    {
        VertexInterface Advance(Rotation rotation);
        VertexInterface Ccw();
        VertexInterface Cw();
        VertexInterface Insert(double x, double y);
        VertexInterface Insert(PointInterface p);
        VertexInterface Neighbor(Rotation rotation);
        void Remove();
        Polygon Split(VertexInterface b);
    }
}