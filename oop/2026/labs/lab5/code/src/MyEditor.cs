using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Lab5.Shapes;

namespace Lab5
{
    public class MyEditor
    {
        private static MyEditor _instance;
        private static readonly object _lock = new object();
        private List<Shape> _shapes = new List<Shape>();

        private MyEditor() { }

        public static MyEditor Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new MyEditor();
                    return _instance;
                }
            }
        }

        public void AddShape(Shape shape) => _shapes.Add(shape);

        public List<Shape> GetShapes() => _shapes;

        public void DrawAll(Graphics g, Pen pen, Brush brush)
        {
            foreach (var shape in _shapes)
            {
                if (shape is RectShape) brush = Brushes.Orange;
                else if (shape is EllipseShape) brush = Brushes.White;
                else if (shape is LineWithCirclesShape) brush = Brushes.Yellow;
                else if (shape is CubeWireframeShape) brush = Brushes.Cyan;
                else brush = Brushes.LightGray;

                shape.Draw(g, pen, brush);
            }
        }

        public void SaveToFile(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (var s in _shapes)
                {
                    sw.WriteLine($"{s.GetName()}\t{s.X1}\t{s.Y1}\t{s.X2}\t{s.Y2}");
                }
            }
        }
    }
}
