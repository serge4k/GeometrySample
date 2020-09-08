using System;

namespace GeometryLib.Models.Geometry
{
    public class Point : PointInterface
    {
        public double X { get; set; }

        public double Y { get; set; }

        public delegate int Cmp(Point a, Point b);
        
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public Point(PointInterface point)
        {
            this.X = point.X;
            this.Y = point.Y;
        }

        public static Point operator +(Point a, Point p)
        {
            return new Point(a.X + p.X, a.Y + p.Y);
        }

        public static Point operator -(Point a, Point p)
        {
            return new Point(a.X - p.X, a.Y - p.Y);
        }

        public static Point operator *(double s, Point p)
        {
            return new Point(s * p.X, s * p.Y);
        }

        public double this[int i]
        {
            get
            {
                return (i == 0) ? this.X : this.Y;
            }
        }

        public static bool operator ==(Point a, Point p)
        {
            if (a as object == null || p as object == null)
            {
                return false;
            }
            return (a.X == p.X) && (a.Y == p.Y);
        }

        public static bool operator !=(Point a, Point p)
        {
            return !(a == p);
        }

        public override bool Equals(object obj)
        {
            var point = obj as Point;
            return point != null &&
                   X == point.X &&
                   Y == point.Y;
        }

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }

        public static bool operator <(Point a, Point p)
        {
            return ((a.X < p.X) || ((a.X == p.X) && (a.Y < p.Y)));
        }

        public static bool operator >(Point a, Point p)
        {
            return ((a.X > p.X) || ((a.X == p.X) && (a.Y > p.Y)));
        }

        public static int Orientation(Point p0, Point p1, Point p2)
        {
            Point a = p1 - p0;
            Point b = p2 - p0;
            double sa = a.X * b.Y - b.X * a.Y;
            if (sa > .0)
            {
                return 1;
            }
            if (sa < .0)
            {
                return -1;
            }
            return 0;
        }

        public double Length()
        {
            return Math.Sqrt(this.X * this.X + this.Y * this.Y);
        }
        public static RelativePointPosition Classify(Point p2,Edge e)
        {
            return Classify(p2, e.Org, e.Dest);
        }

        public static RelativePointPosition Classify(Point p2, Point p0, Point p1)
        {
            Point a = (Point)p1 - (Point)p0;
            Point b = (Point)p2 - (Point)p0;
            double sa = a.X * b.Y - b.X * a.Y;
            if (sa > .0)
            {
                return RelativePointPosition.LEFT;
            }
            if (sa < .0)
            {
                return RelativePointPosition.RIGHT;
            }
            if ((a.X * b.X < .0) || (a.Y * b.Y < .0))
            {
                return RelativePointPosition.BEHIND;
            }
            if (a.Length() < b.Length())
            {
                return RelativePointPosition.BEYOND;
            }
            if (p0 == p2)
            {
                return RelativePointPosition.ORIGIN;
            }
            if (p1 == p2)
            {
                return RelativePointPosition.DESTINTION;
            }
            return RelativePointPosition.BETWEEN;
        }

        public double PolarAngle()
        {
            if ((this.X == 0.0) && (this.Y == 0.0))
            {
                return -1.0;
            }
            if (this.X == 0.0)
            {
                return ((this.Y > 0.0) ? 90 : 270);
            }
            double theta = Math.Atan(this.Y / this.X); // In radian
            theta *= 360 / (2 * Math.PI);
            if (this.X > 0.0)
            {
                return ((this.Y >= 0.0) ? theta : 360 + theta);
            }
            else
            {
                return (180 + theta);
            }
        }

        public double Distance(Edge e)
        {
            Edge ab = new Edge(e);
            ab.Flip().Rot(); // turn ab to 90 grad counterclockwise
            Point n = new Point(ab.Dest - ab.Org); // n - vector perpedicular to the Edge e
            n = (1.0 / n.Length()) * n; // normalize vector n
            Edge f = new Edge(this, this + n); // The f edge is positioned on current point
            f.Intersect(e, out double t); // t = signed distance across vector f to point
            return t;
        }
    }
}
