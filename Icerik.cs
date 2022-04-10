using System;
using System.IO;
using System.Windows.Forms;

namespace offcloud
{
    public partial class Icerik : Form
    {
        public string[] dosyalar;
        public string id, server;
        private string anaklasor;

        public Icerik()
        {
            InitializeComponent();
            Islemler.IconYukle(this);
        }

        private void Icerik_Load(object sender, EventArgs e)
        {
            ımageList1 = IconBul.GetSharedInstance();
            dataGridView1.Rows.Clear();
            int say = -1;
            foreach (string d in dosyalar)
            {
                say++;
                string ad = Path.GetFileName(d);
                if (string.IsNullOrEmpty(ad))
                    continue;
                string klasor = Path.GetDirectoryName(d);
                DataGridViewRow item = dataGridView1.Rows[dataGridView1.Rows.Add()];
                int imageindex = IconBul.GetImageIndexByExtention(Path.GetExtension(d));
                item.Cells[0].Value = ad;
                (item.Cells[0] as TextAndImageCell).Image = ımageList1.Images[imageindex];
                item.Cells[1].Value = klasor;
                item.Tag = $"https://{server}.offcloud.com/cloud/download/{id}/{say}/{ad}";
            }
            anaklasor = Path.GetDirectoryName(dosyalar[0]).Split('/')[0];
            Text = anaklasor;
            dataGridView1.Width = dataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 20;
            CenterToParent();
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            seçilenleriİndirToolStripMenuItem.Enabled = dataGridView1.SelectedRows.Count > 0;
        }

        private void seçilenleriİndirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                Islemler.IndirmeGonder((string)row.Tag, (string)row.Cells[1].Value, anaklasor);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 2)
            {
                string link = (string)dataGridView1.Rows[e.RowIndex].Tag;
                string klasor = (string)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                Islemler.IndirmeGonder(link, klasor, anaklasor);
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == 3)
            {
                string link = (string)dataGridView1.Rows[e.RowIndex].Tag;
                Uri uri = new Uri(link);
                Clipboard.SetText(uri.AbsoluteUri);
            }
        }
    }
}