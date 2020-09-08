namespace GeometryLib.Models.Geometry
{
    public interface VertexInterface : PointInterface
    {
        VertexNodeInterface Node { get; set; }

        VertexInterface Cw();

        VertexInterface Ccw();

        VertexInterface Neighbor(Rotation rotation);

        VertexInterface Insert(VertexInterface v);

        VertexInterface Remove();

        void Splice(VertexInterface b);

        VertexInterface Split(VertexInterface b);
    }
}
