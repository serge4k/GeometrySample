using System;
using System.Collections.Generic;
using GeometryLib.Models.Geometry;
using TestGeometryWinForm.Views;

namespace TestGeometryWinForm.Controllers
{
    public class Utils
    {
        public static void FillViewDots(Views.ViewInterface view, List<ViewItemInterface> scene, Func<Point, PointInPolygonRelativePosition> func, int offset = 0)
        {
            FillViewDots(view, scene, func, System.Drawing.Color.Green, offset);
        }

        public static void FillViewDots(Views.ViewInterface view, List<ViewItemInterface> scene, Func<Point, PointInPolygonRelativePosition> func, System.Drawing.Color color, int offset = 0)
        {
            for (double y = 0; y < view.Height; y += 5)
            {
                for (double x = 0; x < view.Width; x += 5)
                {
                    var point = new Point(x, y);
                    PointInPolygonRelativePosition pos = func(point);
                    bool inside = pos == PointInPolygonRelativePosition.BOUNDARY || pos == PointInPolygonRelativePosition.INSIDE;
                    if (inside)
                    {
                        scene.Add(new PointView(point, color));
                        ///scene1.Add(new PointView(point, inside ? System.Drawing.Color.Green : System.Drawing.Color.Red));
                    }
                }
            }
        }

        public static void FillViewDots(Views.ViewInterface view, List<ViewItemInterface> scene, Func<Point, RelativePointPosition> func, int offset = 0)
        {
            FillViewDots(view, scene, func, System.Drawing.Color.Green, offset);
        }

        public static void FillViewDots(Views.ViewInterface view, List<ViewItemInterface> scene, Func<Point, RelativePointPosition> func, System.Drawing.Color color, int offset = 0)
        {
            for (double y = offset; y < view.Height; y += 10)
            {
                for (double x = offset; x < view.Width; x += 10)
                {
                    var point = new Point(x, y);
                    RelativePointPosition pos = func(point);
                    bool inside = pos == RelativePointPosition.RIGHT || pos == RelativePointPosition.BETWEEN || pos == RelativePointPosition.ORIGIN || pos == RelativePointPosition.DESTINTION;
                    if (inside)
                    {
                        scene.Add(new PointView(point, color));
                        ///scene1.Add(new PointView(point, inside ? System.Drawing.Color.Green : System.Drawing.Color.Red));
                    }
                }
            }
        }
    }
}
