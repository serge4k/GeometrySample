using System;

namespace GeometryLib.Models.List
{
    interface ListInterface<T> : IDisposable where T : class
    {
        T Insert(T val);

        T Append(T val);

        List<T> Append(List<T> l);

        T Prepend(T val);

        void Val(T val);

        T Val();

        T Next();

        T Prev();

        T First();

        T Last();

        int Length();

        bool IsFirst();

        bool IsLast();

        bool IsHead();

        void Clear();

        T Remove();
    }
}
