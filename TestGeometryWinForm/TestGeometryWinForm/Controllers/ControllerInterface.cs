using TestGeometryWinForm.Views;

namespace TestGeometryWinForm.Controllers
{
    public interface ControllerInterface
    {
        ViewInterface View { get; set; }

        void Draw();

        void Test();
    }
}