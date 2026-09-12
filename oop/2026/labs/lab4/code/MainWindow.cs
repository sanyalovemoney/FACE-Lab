using System;
using System.Drawing;
using System.Windows.Forms;
using Lab4.Shapes;

namespace Lab4
{
    public partial class MainWindow : Form
    {
        private enum ShapeType { Point, Line, Rectangle, Ellipse, LineCircles, Cube }
        private ShapeType _currentType = ShapeType.Line;
        private MyEditor _editor = new MyEditor();

        private Point _startPoint;
        private Point _currentPoint;
        private bool _isDrawing = false;

        private MenuStrip _menuStrip;
        private ToolStrip _toolStrip;

        public MainWindow()
        {
            this.Text = "Graphic Object Editor - Lab 4";
            this.Size = new Size(800, 600);
            this.DoubleBuffered = true;

            InitializeMenu();
            InitializeToolbar();
        }

        private void InitializeMenu()
        {
            _menuStrip = new MenuStrip();
            var objectsMenu = new ToolStripMenuItem("Objects");

            objectsMenu.DropDownItems.Add("Point", null, (s, e) => { _currentType = ShapeType.Point; UpdateTitle(); });
            objectsMenu.DropDownItems.Add("Line", null, (s, e) => { _currentType = ShapeType.Line; UpdateTitle(); });
            objectsMenu.DropDownItems.Add("Rectangle", null, (s, e) => { _currentType = ShapeType.Rectangle; UpdateTitle(); });
            objectsMenu.DropDownItems.Add("Ellipse", null, (s, e) => { _currentType = ShapeType.Ellipse; UpdateTitle(); });
            objectsMenu.DropDownItems.Add("LineWithCircles", null, (s, e) => { _currentType = ShapeType.LineCircles; UpdateTitle(); });
            objectsMenu.DropDownItems.Add("Cube", null, (s, e) => { _currentType = ShapeType.Cube; UpdateTitle(); });

            _menuStrip.Items.Add(objectsMenu);
            this.MainMenuStrip = _menuStrip;
            this.Controls.Add(_menuStrip);

            UpdateTitle();
        }

        private void InitializeToolbar()
        {
            _toolStrip = new ToolStrip();

            _toolStrip.Items.Add(new ToolStripButton("Point") { ToolTipText = "Point", Click = (s, e) => { _currentType = ShapeType.Point; UpdateTitle(); } });
            _toolStrip.Items.Add(new ToolStripButton("Line") { ToolTipText = "Line", Click = (s, e) => { _currentType = ShapeType.Line; UpdateTitle(); } });
            _toolStrip.Items.Add(new ToolStripButton("Rect") { ToolTipText = "Rectangle", Click = (s, e) => { _currentType = ShapeType.Rectangle; UpdateTitle(); } });
            _toolStrip.Items.Add(new ToolStripButton("Ellipse") { ToolTipText = "Ellipse", Click = (s, e) => { _currentType = ShapeType.Ellipse; UpdateTitle(); } });
            _toolStrip.Items.Add(new ToolStripButton("L-Circ") { ToolTipText = "Line with Circles", Click = (s, e) => { _currentType = ShapeType.LineCircles; UpdateTitle(); } });
            _toolStrip.Items.Add(new ToolStripButton("Cube") { ToolTipText = "Cube Wireframe", Click = (s, e) => { _currentType = ShapeType.Cube; UpdateTitle(); } });

            this.Controls.Add(_toolStrip);
        }

        private void UpdateTitle()
        {
            this.Text = $"Graphic Object Editor - Lab 4 [{_currentType}]";
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                _isDrawing = true;
                _startPoint = e.Location;
                _currentPoint = e.Location;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_isDrawing)
            {
                _currentPoint = e.Location;
                this.Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (_isDrawing && e.Button == MouseButtons.Left)
            {
                _isDrawing = false;
                Shape shape = null;

                switch (_currentType)
                {
                    case ShapeType.Point: shape = new PointShape(_startPoint.X, _startPoint.Y, e.Location.X, e.Location.Y); break;
                    case ShapeType.Line: shape = new LineShape(_startPoint.X, _startPoint.Y, e.Location.X, e.Location.Y); break;
                    case ShapeType.Rectangle: shape = new RectShape(_startPoint.X, _startPoint.Y, e.Location.X, e.Location.Y); break;
                    case ShapeType.Ellipse: shape = new EllipseShape(_startPoint.X, _startPoint.Y, e.Location.X, e.Location.Y); break;
                    case ShapeType.LineCircles: shape = new LineWithCirclesShape(_startPoint.X, _startPoint.Y, e.Location.X, e.Location.Y); break;
                    case ShapeType.Cube: shape = new CubeWireframeShape(_startPoint.X, _startPoint.Y, e.Location.X, e.Location.Y); break;
                }

                if (shape != null) _editor.AddShape(shape);
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Pen pen = new Pen(Color.Black, 1);
            Brush brush = Brushes.White;

            _editor.DrawAll(g, pen, brush);

            if (_isDrawing)
            {
                Pen rubberPen = new Pen(Color.Gray, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
                Brush rubberBrush = new SolidBrush(Color.FromArgb(100, Color.LightGray));

                Shape rubberShape = null;
                switch (_currentType)
                {
                    case ShapeType.Point: rubberShape = new PointShape(_startPoint.X, _startPoint.Y, _currentPoint.X, _currentPoint.Y); break;
                    case ShapeType.Line: rubberShape = new LineShape(_startPoint.X, _startPoint.Y, _currentPoint.X, _currentPoint.Y); break;
                    case ShapeType.Rectangle: rubberShape = new RectShape(_startPoint.X, _startPoint.Y, _currentPoint.X, _currentPoint.Y); break;
                    case ShapeType.Ellipse: rubberShape = new EllipseShape(_startPoint.X, _startPoint.Y, _currentPoint.X, _currentPoint.Y); break;
                    case ShapeType.LineCircles: rubberShape = new LineWithCirclesShape(_startPoint.X, _startPoint.Y, _currentPoint.X, _currentPoint.Y); break;
                    case ShapeType.Cube: rubberShape = new CubeWireframeShape(_startPoint.X, _startPoint.Y, _currentPoint.X, _currentPoint.Y); break;
                }

                if (rubberShape != null) rubberShape.Draw(g, rubberPen, rubberBrush);
            }
        }
    }
}
