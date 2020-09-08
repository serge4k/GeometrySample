namespace GeometryLib.Models.List
{
    public class ListNode<T> : Node where T : class
    {
        public T Val;

        public ListNode(T val)
        {
            this.Val = val;
        }
    }
}
