using GeometryLib.Models.List;

namespace GeometryLib.Models.Geometry
{
    public interface VertexNodeInterface : NodeInterface
    {
        VertexInterface Vertex { get; set; }

        VertexNodeInterface Cw();

        VertexNodeInterface Ccw();

        VertexNodeInterface Neighbor(Rotation rotation);
    }
}
