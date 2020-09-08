using GeometryLib.Models.List;

namespace GeometryLib.Models.Geometry
{
    public class VertexNode : Node, VertexNodeInterface
    {
        public VertexInterface Vertex { get; set;  }

        public VertexNode(VertexInterface vertex)
        {
            this.Vertex = vertex;
        }

        public VertexNodeInterface Cw()
        {
            return (VertexNodeInterface)this.Next;
        }

        public VertexNodeInterface Ccw()
        {
            return (VertexNodeInterface)this.Prev;
        }

        public VertexNodeInterface Neighbor(Rotation rotation)
        {
            return (rotation == Rotation.CLOCKWISE) ? Cw() : Ccw();
        }
    }
}
