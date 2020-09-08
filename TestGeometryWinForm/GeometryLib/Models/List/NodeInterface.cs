namespace GeometryLib.Models.List
{
    public interface NodeInterface
    {
        NodeInterface Next { get; set; }

        NodeInterface Prev { get; set; }

        NodeInterface Insert(NodeInterface node);

        NodeInterface Remove();

        void Splice(NodeInterface node);
    }
}
