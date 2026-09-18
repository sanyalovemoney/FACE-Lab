using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Lab6.Object3
{
    public class Object3Form : Form
    {
        public Object3Form()
        {
            this.Text = "Object 3 - Graph";
            this.Size = new Size(500, 500);
            this.DoubleBuffered = true;

            this.Load += (s, e) => this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            string data = Clipboard.GetText();
            if (string.IsNullOrEmpty(data)) return;

            string[] pointsStr = data.Split(';');
            List<Point> points = new List<Point>();
            foreach (var s in pointsStr)
            {
                string[] xy = s.Split(',');
                if (xy.Length == 2) points.Add(new Point(int.Parse(xy[0]), int.Parse(xy[1])));
            }

            g.DrawEllipse(Pens.Black, 50, 50, 400, 400);
            foreach (var p in points)
            {
                g.FillEllipse(Brushes.Red, p.X, p.Y, 3, 3);
            }
        }
    }
}
