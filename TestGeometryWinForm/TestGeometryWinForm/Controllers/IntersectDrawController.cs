using System.Collections.Generic;
using GeometryLib.Models.Geometry;
using TestGeometryWinForm.Views;

namespace TestGeometryWinForm.Controllers
{
    public class IntersectDrawController : SceneDrawController
    {
        private Edge edge0;
        private Edge edge1;

        public IntersectDrawController(ViewInterface view) : base(view)
        {
        }

        public void IntersectTest()
        {
            this.scene = new List<ViewItemInterface>();
            edge0 = new Edge(10, 10, 100, 50);
            edge1 = new Edge(100, 5, 5, 100);
            this.scene.Add(new EdgeView(edge0));
            this.scene.Add(new EdgeView(edge1));

            double t;
            RelativeEdgePosition pos = edge0.Intersect(edge1, out t);
            Point crossPoint = null;
            if (pos != RelativeEdgePosition.PARALLEL && pos != RelativeEdgePosition.COLLINEAR)
            {
                crossPoint = new Point(edge0.Point(t));
                this.scene.Add(new PointView(crossPoint));
            }            
            
        }
    }
}
