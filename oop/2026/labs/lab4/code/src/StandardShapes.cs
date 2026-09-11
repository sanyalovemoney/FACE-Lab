using System.Drawing;

namespace Lab4.Shapes
{
    public class PointShape : Shape
    {
        public PointShape(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2) { }
        public override void Draw(Graphics g, Pen pen, Brush brush) => g.FillRectangle(brush, X1, Y1, 2, 2);
    }

    public class LineShape : Shape
    {
        public LineShape(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2) { }
        public override void Draw(Graphics g, Pen pen, Brush brush) => g.DrawLine(pen, X1, Y1, X2, Y2);
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
    }
}
