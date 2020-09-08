namespace GeometryLib.Models.List
{
    public class Node : BaseClass, NodeInterface
    {
        public NodeInterface Next { get; set; }

        public NodeInterface Prev { get; set; }

        public Node()
        {
            this.Next = this;
            this.Prev = this;
        }

        public NodeInterface Insert(NodeInterface b)
        {
            NodeInterface c = Next;
            b.Next = c;
            b.Prev = this;
            this.Next = b;
            c.Prev = b;
            return b;
        }

        public NodeInterface Remove()
        {
            this.Prev.Next = this.Next;
            this.Next.Prev = this.Prev;
            this.Next = this.Prev = this;
            return this;
        }

        public void Splice(NodeInterface b)
        {
            NodeInterface a = this;
            NodeInterface an = a.Next;
            NodeInterface bn = b.Next;
            a.Next = bn;
            b.Next = an;
            an.Next = b;
            bn.Prev = a;
        }

        protected override void OnDisposing()
        {
            
        }
    }
}
