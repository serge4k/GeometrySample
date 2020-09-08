using System;

namespace GeometryLib.Models.Geometry
{
    public class Polygon : BaseClass, PolygonInterface
    {
        private VertexInterface _v;

        private int _size;

        public Polygon()
        {
            this._v = null;
            this._size = 0;
        }

        public Polygon(Polygon p)
        {
            this._size = p._size;
            if (this._size == 0)
            {
                this._v = null;
            }
            else
            {
                this._v = new Vertex((VertexInterface)p.Point());
                for (int i = 1; i < this._size; i++)
                {
                    p.Advance(Rotation.CLOCKWISE);
                    this._v = this._v.Insert(new Vertex((VertexInterface)p.Point()));
                }
                p.Advance(Rotation.CLOCKWISE);
                this._v = this._v.Cw();
            }
        }

        public Polygon(VertexInterface v)
        {
            this._v = new Vertex(v);
            Resize();
        }

        private void Resize()
        {
            if (this._v == null)
            {
                this._size = 0;
            }
            else
            {
                VertexInterface v = this._v.Cw();
                for (this._size = 1; !v.Equals(this._v); this._size++, v = v.Cw())
                    ;
            }
        }

        public VertexInterface V()
        {
            return this._v;
        }

        public int Size()
        {
            return this._size;
        }

        public Point Point()
        {
            return (Point)this._v;
        }

        public Edge Edge()
        {
            return new Edge(Point(), (Point)this._v.Cw());
        }

        public VertexInterface Cw()
        {
            return this._v.Cw();
        }

        public VertexInterface Ccw()
        {
            return this._v.Ccw();
        }

        public VertexInterface Neighbor(Rotation rotation)
        {
            return this._v.Neighbor(rotation);
        }

        public VertexInterface Advance(Rotation rotation)
        {
            return this._v = this._v.Neighbor(rotation);
        }

        public VertexInterface SetV(VertexInterface v)
        {
            return this._v = v;
        }

        public VertexInterface Insert(double x, double y)
        {
            return Insert(new Vertex(x, y));
        }

        public VertexInterface Insert(PointInterface p)
        {
            if (this._size++ == 0)
            {
                this._v = new Vertex(p);
            }
            else
            {
                this._v = this._v.Insert(new Vertex(p));
            }
            return this._v;
        }

        public void Remove()
        {
            VertexInterface v = this._v;
            this._v = (--this._size == 0) ? null : this._v.Ccw();
            v.Remove();
        }

        public Polygon Split(VertexInterface b)
        {
            VertexInterface bp = this._v.Split(b);
            Resize();
            return new Polygon(bp);
        }

        protected override void OnDisposing()
        {
            if (this._v != null)
            {
                VertexInterface w = this._v.Cw();
                while (!this._v.Equals(w))
                {
                    w.Remove();
                    w = this._v.Cw();
                }
                this._v = null;
            }
        }

        public static bool PointInConvexPolygon(Point s, Polygon p)
        {
            if (p.Size() == 1)
            {
                return (s.Equals(p.Point()));
            }
            if (p.Size() == 2)
            {
                RelativePointPosition c = Geometry.Point.Classify(s, p.Edge());
                return ((c == RelativePointPosition.BETWEEN) || c == RelativePointPosition.ORIGIN) || (c == RelativePointPosition.DESTINTION);
            }
            var org = p.V();
            for (int i = 0; i < p.Size(); i++, p.Advance(Rotation.CLOCKWISE))
            {
                if (Geometry.Point.Classify(s, p.Edge()) == RelativePointPosition.LEFT)
                {
                    p.SetV(org);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// "Beam" method
        /// </summary>
        /// <param name="a">point</param>
        /// <param name="p">polygon</param>
        /// <returns>position</returns>
        public static PointInPolygonRelativePosition PointInPolygon(Point a, Polygon p)
        {
            int parity = 0;
            for (int i = 0; i < p.Size(); i++, p.Advance(Rotation.CLOCKWISE))
            {
                Edge e = p.Edge();
                switch (EdgeType(a, e))
                {
                    case EdgeInPolygonRelativePosition.TOUCHING:
                        return PointInPolygonRelativePosition.BOUNDARY;
                    case EdgeInPolygonRelativePosition.CROSSING:
                        parity = 1 - parity;
                        break;
                }
            }
            return parity != 0 ? PointInPolygonRelativePosition.INSIDE : PointInPolygonRelativePosition.OUTSIDE;
        }

        public static EdgeInPolygonRelativePosition EdgeType(Point a, Edge e)
        {
            Point v = e.Org;
            Point w = e.Dest;
            switch (Geometry.Point.Classify(a, e))
            {
                case RelativePointPosition.LEFT:
                    return ((v.Y < a.Y) && (a.Y <= w.Y)) ? EdgeInPolygonRelativePosition.CROSSING : EdgeInPolygonRelativePosition.INESSENTIAL;
                case RelativePointPosition.RIGHT:
                    return ((w.Y < a.Y) && (a.Y <= v.Y)) ? EdgeInPolygonRelativePosition.CROSSING : EdgeInPolygonRelativePosition.INESSENTIAL;
                case RelativePointPosition.BETWEEN:
                case RelativePointPosition.ORIGIN:
                case RelativePointPosition.DESTINTION:
                    return EdgeInPolygonRelativePosition.TOUCHING;
                default:
                    return EdgeInPolygonRelativePosition.INESSENTIAL;
            }
        }

        /// <summary>
        /// "Andge" method
        /// </summary>
        /// <param name="a">point</param>
        /// <param name="p">polygon</param>
        /// <returns>position</returns>
        public static PointInPolygonRelativePosition PointInPolygon2(Point a, Polygon p)
        {
            double total = 0.0;
            for (int i = 0; i < p.Size(); i++, p.Advance(Rotation.CLOCKWISE))
            {
                Edge e = p.Edge();
                double x = SingleAngle(a, e);
                if (x == 180.0)
                {
                    return PointInPolygonRelativePosition.BOUNDARY;
                }
                total += x;
            }
            return (total < -180.0) ? PointInPolygonRelativePosition.INSIDE : PointInPolygonRelativePosition.OUTSIDE;
        }

        public static double SingleAngle(Point a, Edge e)
        {
            Point v = e.Org - a;
            Point w = e.Dest - a;
            double va = v.PolarAngle();
            double wa = w.PolarAngle();
            if ((va == -1.0) || (wa == -1.0))
            {
                return 180.0;
            }
            double x = wa - va;
            if ((x == 180.0) || (x == -180.0))
            {
                return 180.0;
            }
            else if (x < -180.0)
            {
                return x + 360.0;
            }
            else if  (x > 180.0)
            {
                return x - 360.0;
            }
            else
            {
                return x;
            }
        }

        public static Vertex LeastVertex(Polygon p, Vertex.Cmp cmp)
        {
            var bestV = p.V();
            p.Advance(Rotation.CLOCKWISE);
            for (int i = 1; i < p.Size(); p.Advance(Rotation.CLOCKWISE), i++)
            {
                if (cmp((Point)p.V(), (Point)bestV) < 0)
                {
                    bestV = p.V();
                }
            }
            p.SetV(bestV);
            return (Vertex)bestV;
        }

        public static int LeftToRigthCmp(Vertex a, Vertex b)
        {
            if (a < b)
            {
                return -1;
            }
            if (a > b)
            {
                return 1;
            }
            return 0;
        }

        public static int RigthToLeftCmp(Vertex a, Vertex b)
        {
            return LeftToRigthCmp(b, a);
        }

        /// <summary>
        /// Create CLOCKWISE oriented poligon from any ordered array
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Polygon StartPolygon(Point[] s)
        {
            Polygon p = new Polygon();
            if (s.Length == 0)
            {
                throw new Exception("Point array is empty");
            }
            p.Insert(new Vertex(s[0]));
            var origin = p.V();
            var originPt = origin;
            for (int i = 1; i < s.Length; i++)
            {
                p.SetV(origin);

                p.Advance(Rotation.CLOCKWISE);
                while (PolarCmp((Point)originPt, s[i], (Point)p.V()) < 0)
                {
                    p.Advance(Rotation.CLOCKWISE);
                }
                p.Advance(Rotation.COUNTERCLOCKWISE);
                p.Insert(s[i]);
            }
            return p;
        }

        public static int PolarCmp(Point originPt, Point p, Point q)
        {
            Point vp = p - originPt;
            Point vq = q - originPt;
            double pPolar = vp.PolarAngle();
            double qPolar = vq.PolarAngle();
            if (pPolar < qPolar)
            {
                return -1;
            }
            if (pPolar > qPolar)
            {
                return 1;
            }
            if (vp.Length() < vq.Length())
            {
                return -1;
            }
            if (vp.Length() > vq.Length())
            {
                return 1;
            }
            return 0;
        }

        public static Polygon InsertionHull(Point[] s)
        {
            Polygon p = new Polygon();
            if (s.Length == 0)
            {
                throw new Exception("Point array is empty");
            }
            p.Insert(s[0]);
            Point somePoint;
            for (int i = 1;  i < s.Length; i++)
            {
                if (Polygon.PointInConvexPolygon(s[i], p))
                {
                    continue;
                }
                somePoint = s[i];
                LeastVertex(p, (a, b) =>
                {
                    double distA = (somePoint - a).Length();
                    double distB = (somePoint - b).Length();
                    if (distA < distB)
                    {
                        return -1;
                    }
                    else if (distA > distB)
                    {
                        return 1;
                    }
                    return 0;
                });
                SupportingLine(s[i], p, RelativePointPosition.LEFT);
                var l = p.V();
                SupportingLine(s[i], p, RelativePointPosition.RIGHT);
                p.Split(l).Dispose();
                p.Insert(s[i]);
            }
            return p;
        }

        private static void SupportingLine(Point s, Polygon p, RelativePointPosition side)
        {
            Rotation rotation = (side == RelativePointPosition.LEFT) ? Rotation.CLOCKWISE : Rotation.COUNTERCLOCKWISE;
            var a = p.V();
            var b = p.Neighbor(rotation);
            RelativePointPosition c = Geometry.Point.Classify((Point)b, s, (Point)a);
            while ((c == side) || (c == RelativePointPosition.BEYOND) || (c == RelativePointPosition.BETWEEN))
            {
                p.Advance(rotation);
                a = p.V();
                b = p.Neighbor(rotation);
                c = Geometry.Point.Classify((Point)b, s, (Point)a);
            }
        }
    }
}
