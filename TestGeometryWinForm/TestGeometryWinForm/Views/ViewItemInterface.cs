using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGeometryWinForm.Views
{
    public interface ViewItemInterface
    {
        System.Drawing.Color BrushColor { get; set; }

        void Draw(ViewInterface view);
    }
}
