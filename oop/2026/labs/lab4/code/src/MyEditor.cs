using System;
using System.Collections.Generic;
using System.Drawing;
using Lab4.Shapes;

namespace Lab4
{
    public class MyEditor
    {
        private List<Shape> _shapes = new List<Shape>();

        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        public void DrawAll(Graphics g, Pen pen, Brush brush)
        {
            foreach (var shape in _shapes)
            {
                // Applying colors based on type
                if (shape is RectShape) brush = Brushes.Orange;
                else if (shape is EllipseShape) brush = Brushes.White;
                else if (shape is LineWithCirclesShape) brush = Brushes.Yellow;
                else if (shape is CubeWireframeShape) brush = Brushes.Cyan;
                else brush = Brushes.LightGray;

                shape.Draw(g, pen, brush);
            }
        }

        public void Clear()
        {
            _shapes.Clear();
        }
    }
}
