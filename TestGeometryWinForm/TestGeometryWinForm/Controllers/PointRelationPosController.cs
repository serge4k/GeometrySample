using GeometryLib.Models.Geometry;
using TestGeometryWinForm.Views;

namespace TestGeometryWinForm.Controllers
{
    public class PointRelationPosController : SceneDrawController
    {
        private Edge edge;

        public PointRelationPosController(ViewInterface view) : base(view)
        {
        }

        public override void Test()
        {
            edge = new Edge(50, 175, 100, 100);

            var p0 = new Point(100, 100);
            var t0 = Point.Classify(p0, edge);
            var c0 = t0 == RelativePointPosition.DESTINTION ? System.Drawing.Color.Blue : System.Drawing.Color.White;

            scene.Add(new PointView(p0, c0));

            Utils.FillViewDots(
                this.View,
                scene,
                (point) => {
                    return Point.Classify(point, edge);
                    },
                System.Drawing.Color.Magenta,
                2
                );
        }

    }
}
