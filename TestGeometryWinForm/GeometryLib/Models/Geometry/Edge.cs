using System;

namespace GeometryLib.Models.Geometry
{
    public class Edge : EdgeInterface
    {
        public Point Org { get; set; }

        public Point Dest { get; set; }

        public Edge(Point org, Point dest)
        {
            this.Org = org;
            this.Dest = dest;
        }

        public Edge(double x0, double y0, double x1, double y1)
        {
            this.Org = new Point(x0, y0);
            this.Dest = new Point(x1, y1);
        }

        public Edge(Edge e)
        {
            this.Org = new Point(e.Org);
            this.Dest = new Point(e.Dest);
        }

        public Edge Rot()
        {
            Point m = 0.5 * (Org + Dest);
            Point v = Dest - Org;
            Point n = new Point(v.Y, -v.X);
            this.Org = m - 0.5 * n;
            this.Dest = m + 0.5 * n;
            return this;
        }

        public Edge Flip()
        {
            return this.Rot().Rot();
        }

        public Point Point(double t)
        {
            return new Point(this.Org + t * (this.Dest - this.Org));
        }

        public RelativeEdgePosition Intersect(EdgeInterface e, out double t)
        {
            Point a = this.Org;
            Point b = this.Dest;
            Point c = e.Org;
            Point d = e.Dest;
            Point n = new Point((d - c).Y, (c - d).X);
            double denom = DotProduct(n, b - a);
            if (denom == 0.0)
            {
                RelativePointPosition aClass = Geometry.Point.Classify(this.Org, (Edge)e);
                if ((aClass == RelativePointPosition.LEFT) || (aClass == RelativePointPosition.RIGHT))
                {
                    t = 0.0;
                    return RelativeEdgePosition.PARALLEL;
                }
                else
                {
                    t = 0.0;
                    return RelativeEdgePosition.COLLINEAR;
                }
            }
            
            double num = DotProduct(n, a - c);
            t = -num / denom;
            return RelativeEdgePosition.SKEW;
        }

        public RelativeEdgePosition Cross(EdgeInterface e, out double t)
        {
            double s = 0.0;
            RelativeEdgePosition crossType = e.Intersect(this, out s);
            if ((crossType == RelativeEdgePosition.COLLINEAR) || (crossType == RelativeEdgePosition.PARALLEL))
            {
                t = 0.0;
                return crossType;
            }
            if ((s < 0.0) || (s > 1.0))
            {
                t = 0.0;
                return RelativeEdgePosition.SKEW_NO_CROSS;
            }
            Intersect(e, out t);
            if ((0.0 <= t) && (t <= 1.0))
            {
                return RelativeEdgePosition.SKEW_CROSS;
            }
            else
            {
                return RelativeEdgePosition.SKEW_NO_CROSS;
            }
        }

        public static double DotProduct(Point p, Point q)
        {
            return p.X * q.X + p.Y * q.Y;
        }

        public bool IsVertical()
        {
            return this.Org.X == this.Dest.X;
        }

        public double Slope()
        {
            if (this.Org.X != this.Dest.X)
            {
                return (this.Dest.Y - this.Org.Y) / (this.Dest.X - this.Org.X);
            }
            return Double.MaxValue;
        }

        public double Y(double x)
        {
            return Slope() * (x - this.Org.X) + this.Org.Y;
        }
    }
}
