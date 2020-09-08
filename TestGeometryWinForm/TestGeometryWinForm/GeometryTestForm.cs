using System;
using System.Windows.Forms;
using TestGeometryWinForm.Controllers;
using TestGeometryWinForm.Views;

namespace TestGeometryWinForm
{
    public partial class GeometryTestForm : Form
    {
        private DrawingBox drawingBox;

        private ControllerInterface intesectDrawController;

        private ControllerInterface pointInPolygonController;

        private ControllerInterface pointRelationPosController;

        public GeometryTestForm()
        {
            InitializeComponent();
        }

        private void GeometryTestForm_Load(object sender, EventArgs e)
        {
            drawingBox = new DrawingBox();
            drawingBox.Anchor = AnchorStyles.Left;
            drawingBox.Size = this.ClientSize;
            drawingBox.Paint += DrawingBox_Paint;
            this.Controls.Add(drawingBox);

            intesectDrawController = new IntersectDrawController(drawingBox);
            intesectDrawController.Test();

            pointInPolygonController = new PointInPolygonController(drawingBox);
            pointInPolygonController.Test();

            pointRelationPosController = new PointRelationPosController(drawingBox);
            pointRelationPosController.Test();
        }

        private void DrawingBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            drawingBox.SetGraphics(e.Graphics);
            intesectDrawController.Draw();
            pointInPolygonController.Draw();
            pointRelationPosController.Draw();
        }
    }
}
