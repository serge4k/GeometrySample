using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGeometryWinForm.Views;

namespace TestGeometryWinForm.Controllers
{
    public abstract class SceneDrawController : Controller
    {
        protected List<ViewItemInterface> scene;

        protected SceneDrawController(ViewInterface view) : base(view)
        {
            this.scene = new List<ViewItemInterface>();
        }

        protected void SceneAdd(ViewItemInterface viewItem)
        {
            this.scene.Add(viewItem);
        }

        protected void SceneClear()
        {
            this.scene.Clear();
        }

        public override void Draw()
        {
            this.View.Scene(scene);
        }
    }
}
