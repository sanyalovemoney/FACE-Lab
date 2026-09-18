using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

namespace Lab6.Manager
{
    public class ManagerForm : Form
    {
        private TextBox txtN, txtXMin, txtXMax, txtYMin, txtYMax;
        private Button btnRun;

        public ManagerForm()
        {
            this.Text = "Lab 6 - Manager";
            this.Size = new Size(300, 400);

            AddInput("nPoints:", txtN = new TextBox { Text = "10" });
            AddInput("X Min:", txtXMin = new TextBox { Text = "0" });
            AddInput("X Max:", txtXMax = new TextBox { Text = "100" });
            AddInput("Y Min:", txtYMin = new TextBox { Text = "0" });
            AddInput("Y Max:", txtYMax = new TextBox { Text = "100" });

            btnRun = new Button { Text = "Run", Location = new Point(100, 250), Size = new Size(100, 30) };
            btnRun.Click += OnRunClicked;
            this.Controls.Add(btnRun);
        }

        private void AddInput(string label, TextBox tb)
        {
            Label lbl = new Label { Text = label, Location = new Point(20, 20 + (this.Controls.Count * 40)), AutoSize = true };
            tb.Location = new Point(120, 20 + (this.Controls.Count * 40));
            tb.Size = new Size(100, 20);
            this.Controls.Add(lbl);
            this.Controls.Add(tb);
        }

        private void OnRunClicked(object sender, EventArgs e)
        {
            string paramsStr = $"{txtN.Text};{txtXMin.Text};{txtXMax.Text};{txtYMin.Text};{txtYMax.Text}";
            Clipboard.SetText(paramsStr);

            try {
                Process.Start("Object2.exe");
                Process.Start("Object3.exe");
                MessageBox.Show("System started. Data passed via Clipboard.");
            } catch (Exception ex) {
                MessageBox.Show("Error launching apps: " + ex.Message);
            }
        }
    }
}
