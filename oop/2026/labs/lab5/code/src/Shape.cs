using System.Drawing;
using System.Collections.Generic;
using System.IO;

namespace Lab5.Shapes
{
    public abstract class Shape
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }

        public Shape(int x1, int y1, int x2, int y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        public abstract void Draw(Graphics g, Pen pen, Brush brush);
        public abstract string GetName();
    }

    public class PointShape : Shape
    {
        public PointShape(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2) { }
        public override void Draw(Graphics g, Pen pen, Brush brush) => g.FillRectangle(brush, X1, Y1, 2, 2);
        public override string GetName() => "Point";
    }

    public class LineShape : Shape
    {
        public LineShape(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2) { }
        public override void Draw(Graphics g, Pen pen, Brush brush) => g.DrawLine(pen, X1, Y1, X2, Y2);
        public override string GetName() => "Line";
    }

    public class RectShape : Shape
    {
        public RectShape(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2) { }
        public override void Draw(Graphics g, Pen pen, Brush brush)
        {
            int x = Math.Min(X1, X2), y = Math.Min(Y1, Y2);
            int w = Math.Abs(X1 - X2), h = Math.Abs(Y1 - Y2);
            g.FillRectangle(brush, x, y, w, h);
            g.DrawRectangle(pen, x, y, w, h);
        }
        public override string GetName() => "Rectangle";
    }

    public class EllipseShape : Shape
    {
        public EllipseShape(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2) { }
        public override void Draw(Graphics g, Pen pen, Brush brush)
        {
            int x = Math.Min(X1, X2), y = Math.Min(Y1, Y2);
            int w = Math.Abs(X1 - X2), h = Math.Abs(Y1 - Y2);
            g.FillEllipse(brush, x, y, w, h);
            g.DrawEllipse(pen, x, y, w, h);
        }
        public override string GetName() => "Ellipse";
    }

    public class LineWithCirclesShape : Shape
    {
        public LineWithCirclesShape(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2) { }
        public override void Draw(Graphics g, Pen pen, Brush brush)
        {
            g.DrawLine(pen, X1, Y1, X2, Y2);
            int radius = 3;
            g.FillEllipse(brush, X1 - radius, Y1 - radius, radius * 2, radius * 2);
            g.FillEllipse(brush, X2 - radius, Y2 - radius, radius * 2, radius * 2);
        }
        public override string GetName() => "LineWithCircles";
    }

    public class CubeWireframeShape : Shape
    {
        public CubeWireframeShape(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2) { }
        public override void Draw(Graphics g, Pen pen, Brush brush)
        {
            int x = Math.Min(X1, X2), y = Math.Min(Y1, Y2);
            int w = Math.Abs(X1 - X2), h = Math.Abs(Y1 - Y2);
            int offset = w / 3;
            g.DrawRectangle(pen, x, y, w, h);
            g.DrawRectangle(pen, x + offset, y + offset, w, h);
            g.DrawLine(pen, x, y, x + offset, y + offset);
            g.DrawLine(pen, x + w, y, x + w + offset, y + offset);
            g.DrawLine(pen, x, y + h, x + offset, y + h + offset);
            g.DrawLine(pen, x + w, y + h, x + w + offset, y + h + offset);
        }
        public override string GetName() => "CubeWireframe";
    }
}
