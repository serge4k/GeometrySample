using GeometryLib.Models.Geometry;
using TestGeometryWinForm.Views;

namespace TestGeometryWinForm.Controllers
{
    public class PointInPolygonController : SceneDrawController
    {
        private Polygon polygon;

        public PointInPolygonController(Views.ViewInterface view) : base(view)
        {
        }

        public override void Test()
        {
            ////polygon = new Polygon();
            ////polygon.Insert(50, 175);
            ////polygon.Insert(75, 225);
            ////polygon.Insert(100, 200);
            ////polygon.Insert(125, 225);
            ////polygon.Insert(175, 150);
            ////polygon.Insert(125, 150);
            ////polygon.Insert(100, 100);

            Point[] points = {
                new Point(100,100),
                new Point(125,150),
                new Point(175,150),
                new Point(125,225),
                new Point(100,200),
                new Point(75, 225),
                new Point(50, 175)
            };

            polygon = Polygon.StartPolygon(points);

            var p0 = new Point(100, 130);
            var t0 = Polygon.PointInPolygon2(p0, polygon);
            var c0 = t0 == PointInPolygonRelativePosition.INSIDE ? System.Drawing.Color.Maroon : System.Drawing.Color.White;

            Utils.FillViewDots(
                this.View,
                this.scene,
                (point) => Polygon.PointInPolygon2((Point)point, polygon),
                System.Drawing.Color.Green
                );
            
            this.scene.Add(new PolygonView(polygon, System.Drawing.Color.LightGreen));
            
            this.scene.Add(new PointView(p0, c0));
        }
    }
}
