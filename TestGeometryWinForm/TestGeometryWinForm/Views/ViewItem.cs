using System.Drawing;
using GeometryLib.Models.List;

namespace TestGeometryWinForm.Views
{
    public abstract class ViewItem : Node, ViewItemInterface
    {
        public Color BrushColor { get; set; }

        public Color PenColor { get; set; }

        public ViewItem()
        {
            this.BrushColor = Color.Black;
            this.PenColor = Color.Black;
        }

        public abstract void Draw(ViewInterface view);
    }
}
