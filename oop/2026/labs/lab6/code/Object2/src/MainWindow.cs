using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Lab6.Object2
{
    public class Object2Form : Form
    {
        private ListBox lbPoints;

        public Object2Form()
        {
            this.Text = "Object 2 - Data Gen";
            this.Size = new Size(300, 400);

            lbPoints = new ListBox { Dock = DockStyle.Fill };
            this.Controls.Add(lbPoints);

            this.Load += (s, e) => GenerateData();
        }

        private void GenerateData()
        {
            string data = Clipboard.GetText();
            if (string.IsNullOrEmpty(data)) return;

            string[] p = data.Split(';');
            int n = int.Parse(p[0]);
            int xMin = int.Parse(p[1]), xMax = int.Parse(p[2]);
            int yMin = int.Parse(p[3]), yMax = int.Parse(p[4]);

            Random rnd = new Random();
            List<string> points = new List<string>();
            for (int i = 0; i < n; i++)
            {
                int x = rnd.Next(xMin, xMax + 1);
                int y = rnd.Next(yMin, yMax + 1);
                points.Add($"{x},{y}");
                lbPoints.Items.Add($"{x},{y}");
            }

            Clipboard.SetText(string.Join(";", points));
        }
    }
}
