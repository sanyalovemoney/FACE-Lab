using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Lab2.Shapes;

namespace Lab2
{
    public partial class MainWindow : Form
    {
        private enum ShapeType { Point, Line, Rectangle, Ellipse }
        private ShapeType _currentType = ShapeType.Line;
        private List<Shape> _shapes = new List<Shape>();

        private Point _startPoint;
        private Point _currentPoint;
        private bool _isDrawing = false;

        private MenuStrip _menuStrip;

        public MainWindow()
        {
            this.Text = "Graphic Object Editor - Lab 2";
            this.Size = new Size(800, 600);
            this.DoubleBuffered = true; // Prevent flickering

            InitializeMenu();
        }

        private void InitializeMenu()
        {
            _menuStrip = new MenuStrip();
            var objectsMenu = new ToolStripMenuItem("Objects");

            objectsMenu.DropDownItems.Add("Point", null, (s, e) => { _currentType = ShapeType.Point; UpdateTitle(); });
            objectsMenu.DropDownItems.Add("Line", null, (s, e) => { _currentType = ShapeType.Line; UpdateTitle(); });
            objectsMenu.DropDownItems.Add("Rectangle", null, (s, e) => { _currentType = ShapeType.Rectangle; UpdateTitle(); });
            objectsMenu.DropDownItems.Add("Ellipse", null, (s, e) => { _currentType = ShapeType.Ellipse; UpdateTitle(); });

            _menuStrip.Items.Add(objectsMenu);
            this.MainMenuStrip = _menuStrip;
            this.Controls.Add(_menuStrip);

            UpdateTitle();
        }

        private void UpdateTitle()
        {
            this.Text = $"Graphic Object Editor - Lab 2 [{_currentType}]";
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
                this.Invalidate(); // Trigger repaint for rubber-band
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
                    case ShapeType.Point:
                        shape = new PointShape(_startPoint.X, _startPoint.Y, e.Location.X, e.Location.Y);
                        break;
                    case ShapeType.Line:
                        shape = new LineShape(_startPoint.X, _startPoint.Y, e.Location.X, e.Location.Y);
                        break;
                    case ShapeType.Rectangle:
                        shape = new RectShape(_startPoint.X, _startPoint.Y, e.Location.X, e.Location.Y);
                        break;
                    case ShapeType.Ellipse:
                        shape = new EllipseShape(_startPoint.X, _startPoint.Y, e.Location.X, e.Location.Y);
                        break;
                }

                if (shape != null)
                {
                    _shapes.Add(shape);
                }
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

            // Draw all existing shapes
            foreach (var shape in _shapes)
            {
                // Simple color logic: Rect is orange, Ellipse is white as per WORKFLOW.md
                if (shape is RectShape) brush = Brushes.Orange;
                else if (shape is EllipseShape) brush = Brushes.White;
                else brush = Brushes.LightGray;

                shape.Draw(g, pen, brush);
            }

            // Draw rubber-band shape
            if (_isDrawing)
            {
                Pen rubberPen = new Pen(Color.Gray, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
                Brush rubberBrush = new SolidBrush(Color.FromArgb(100, Color.LightGray));

                Shape rubberShape = null;
                switch (_currentType)
                {
                    case ShapeType.Point:
                        rubberShape = new PointShape(_startPoint.X, _startPoint.Y, _currentPoint.X, _currentPoint.Y);
                        break;
                    case ShapeType.Line:
                        rubberShape = new LineShape(_startPoint.X, _startPoint.Y, _currentPoint.X, _currentPoint.Y);
                        break;
                    case ShapeType.Rectangle:
                        rubberShape = new RectShape(_startPoint.X, _startPoint.Y, _currentPoint.X, _currentPoint.Y);
                        break;
                    case ShapeType.Ellipse:
                        rubberShape = new EllipseShape(_startPoint.X, _startPoint.Y, _currentPoint.X, _currentPoint.Y);
                        break;
                }

                if (rubberShape != null)
                {
                    rubberShape.Draw(g, rubberPen, rubberBrush);
                }
            }
        }
    }
}
