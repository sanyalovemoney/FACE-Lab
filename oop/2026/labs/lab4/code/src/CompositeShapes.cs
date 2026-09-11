using System;
using System.Drawing;

namespace Lab4.Shapes
{
    public class LineWithCirclesShape : Shape
    {
        public LineWithCirclesShape(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2) { }

        public override void Draw(Graphics g, Pen pen, Brush brush)
        {
            // Draw Line (Simulating inheritance from LineShape)
            g.DrawLine(pen, X1, Y1, X2, Y2);

            // Draw Circles at ends (Simulating inheritance from EllipseShape)
            int radius = 3;
            g.FillEllipse(brush, X1 - radius, Y1 - radius, radius * 2, radius * 2);
            g.FillEllipse(brush, X2 - radius, Y2 - radius, radius * 2, radius * 2);
        }
    }

    public class CubeWireframeShape : Shape
    {
        public CubeWireframeShape(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2) { }

        public override void Draw(Graphics g, Pen pen, Brush brush)
        {
            int x = Math.Min(X1, X2), y = Math.Min(Y1, Y2);
            int w = Math.Abs(X1 - X2), h = Math.Abs(Y1 - Y2);
            int offset = w / 3;

            // Front face (Rect)
            g.DrawRectangle(pen, x, y, w, h);
            // Back face (Rect)
            g.DrawRectangle(pen, x + offset, y + offset, w, h);
            // Connecting lines (Lines)
            g.DrawLine(pen, x, y, x + offset, y + offset);
            g.DrawLine(pen, x + w, y, x + w + offset, y + offset);
            g.DrawLine(pen, x, y + h, x + offset, y + h + offset);
            g.DrawLine(pen, x + w, y + h, x + w + offset, y + h + offset);
        }
    }
}
