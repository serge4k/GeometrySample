using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGeometryWinForm.Views;

namespace TestGeometryWinForm.Controllers
{
    public abstract class Controller : ControllerInterface
    {
        public ViewInterface View { get; set; }

        public Controller(ViewInterface view)
        {
            this.View = view;
        }

        public abstract void Test();

        public abstract void Draw();
    }
}
