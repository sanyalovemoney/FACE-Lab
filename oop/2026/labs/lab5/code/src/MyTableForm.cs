using System;
using System.Drawing;
using System.Windows.Forms;
using Lab5.Shapes;

namespace Lab5
{
    public class MyTableForm : Form
    {
        private ListView _listView;

        public MyTableForm()
        {
            this.Text = "Shapes Table";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            _listView = new ListView
            {
                View = View.Details,
                Dock = DockStyle.Fill,
                FullRowSelect = true
            };

            _listView.Columns.Add("Name", 100);
            _listView.Columns.Add("X1", 50);
            _listView.Columns.Add("Y1", 50);
            _listView.Columns.Add("X2", 50);
            _listView.Columns.Add("Y2", 50);

            this.Controls.Add(_listView);
        }

        public void UpdateData()
        {
            _listView.Items.Clear();
            foreach (var s in MyEditor.Instance.GetShapes())
            {
                var item = new ListViewItem(s.GetName());
                item.SubItems.Add(s.X1.ToString());
                item.SubItems.Add(s.Y1.ToString());
                item.SubItems.Add(s.X2.ToString());
                item.SubItems.Add(s.Y2.ToString());
                _listView.Items.Add(item);
            }
        }
    }
}
