using GeometryLib.Models.List;

namespace GeometryLib.Models.Geometry
{
    public class Vertex : Point, VertexInterface 
    {
        public VertexNodeInterface Node { get; set; }

        public NodeInterface Next
        {
            get => this.Node.Next;
            set
            {
                this.Node.Next = value;
            }
        }

        public NodeInterface Prev
        {
            get => this.Node.Prev;
            set
            {
                this.Node.Prev = value;
            }
        }

        public Vertex(double x, double y) : base (x ,y)
        {
            this.Node = new VertexNode(this);
        }

        public Vertex(PointInterface b) : base (b)
        {
            this.Node = new VertexNode(this);
        }

        public Vertex Remove()
        {
            this.Node.Remove();
            return this;
        }

        public void Splice(VertexInterface b)
        {
            this.Node.Splice(b.Node);
        }

        public VertexInterface Insert(VertexInterface vertex)
        {
            return ((VertexNodeInterface)(this.Node.Insert(vertex.Node))).Vertex;
        }

        public VertexInterface Cw()
        {
            return ((VertexNodeInterface)(this.Node.Cw())).Vertex;
        }

        public VertexInterface Ccw()
        {
            return ((VertexNodeInterface)(this.Node.Ccw())).Vertex;
        }

        public VertexInterface Neighbor(Rotation rotation)
        {
            return ((VertexNodeInterface)(this.Node.Neighbor(rotation))).Vertex;
        }

        VertexInterface VertexInterface.Remove()
        {
            return ((VertexNodeInterface)(this.Node.Remove())).Vertex;
        }

        public VertexInterface Split(VertexInterface b)
        {
            VertexInterface bp = ((VertexNodeInterface)(b.Node.Ccw().Insert(new VertexNode(new Vertex(b))))).Vertex;
            Insert(new Vertex(this));
            Splice(bp);
            return bp;
        }

        public static bool operator <(Vertex a, Vertex p)
        {
            return ((a.X < p.X) || ((a.X == p.X) && (a.Y < p.Y)));
        }

        public static bool operator >(Vertex a, Vertex p)
        {
            return ((a.X > p.X) || ((a.X == p.X) && (a.Y > p.Y)));
        }
    }
}
