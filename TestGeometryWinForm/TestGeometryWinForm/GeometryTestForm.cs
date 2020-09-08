using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestGeometryWinForm.Controllers;
using TestGeometryWinForm.Views;

namespace TestGeometryWinForm
{
    public partial class GeometryTestForm : Form
    {
        private DrawingBox drawingBox;

        private IntersectDrawController intesectDrawController;

        private PointInPolygonController pointInPolygonController;

        private PointRelationPosController pointRelationPosController;

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
            intesectDrawController.IntersectTest();

            pointInPolygonController = new PointInPolygonController(drawingBox);
            pointInPolygonController.PointInPolygonTest();

            pointRelationPosController = new PointRelationPosController(drawingBox);
            pointRelationPosController.PointRelationPosTest();
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
