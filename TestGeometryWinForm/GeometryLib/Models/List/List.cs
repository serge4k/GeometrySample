namespace GeometryLib.Models.List
{
    public class List<T> : BaseClass, ListInterface<T> where T : class
    {
        private ListNode<T> header;

        private ListNode<T> win;

        private int _length;

        public List()
        {
            this.header = new ListNode<T>(null);
            this.win = this.header;
        }

        protected override void OnDisposing()
        {
            Clear();
        }

        public T Insert(T val)
        {
            this.win.Insert(new ListNode<T>(val));
            ++this._length;
            return val;
        }

        public T Append(T val)
        {
            this.header.Prev.Insert(new ListNode<T>(val));
            ++this._length;
            return val;
        }

        public List<T> Append(List<T> l)
        {
            ListNode<T> a = (ListNode<T>)this.header.Prev;
            a.Splice(l.header);
            this._length += l._length;
            l.header.Remove();
            l._length = 0;
            l.win = this.header;
            return this;
        }

        public T Prepend(T val)
        {
            this.header.Insert(new ListNode<T>(val));
            ++this._length;
            return val;
        }

        public void Val(T val)
        {
            if (!this.win.Equals(this.header))
            {
                this.win.Val = val;
            }
        }

        public T Val()
        {
            return this.win.Val;
        }

        public T Next()
        {
            this.win = (ListNode<T>)win.Next;
            return win.Val;
        }

        public T Prev()
        {
            this.win = (ListNode<T>)win.Prev;
            return win.Val;
        }

        public T First()
        {
            this.win = (ListNode<T>)this.header.Next;
            return this.win.Val;
        }

        public T Last()
        {
            this.win = (ListNode<T>)this.header.Prev;
            return this.win.Val;
        }

        public int Length()
        {
            return this._length;
        }

        public bool IsFirst()
        {
            return ((this.win.Equals(this.header.Next)) && this._length > 0);
        }

        public bool IsLast()
        {
            return ((this.win.Equals(this.header.Prev)) && this._length > 0);
        }

        public bool IsHead()
        {
            return this.win.Equals(this.header);
        }

        public void Clear()
        {
            while (this._length > 0)
            {
                First();
                Remove();
            }
            header.Dispose();
        }

        public T Remove()
        {
            if (this.win.Equals(this.header))
            {
                return null;
            }
            T val = this.win.Val;
            this.win = (ListNode<T>)this.win.Prev;
            ((ListNode<T>)this.win.Next).Remove();
            --this._length;
            return this.win.Val;
        }
    }
}
