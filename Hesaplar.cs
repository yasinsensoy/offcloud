using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace offcloud
{
    public partial class Hesaplar : Form
    {
        public List<Hesap> hesaplar;
        public Hesap secilen = null;

        public Hesaplar()
        {
            InitializeComponent();
            Islemler.IconYukle(this);
        }

        private void Hesaplar_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            foreach (Hesap hesap in hesaplar)
            {
                ListViewItem item = listView1.Items.Add(hesap.Email);
                item.SubItems.Add(hesap.Sifre);
                item.SubItems.Add(hesap.OIp);
                item.SubItems.Add(hesap.KIp);
                item.SubItems.Add(hesap.Hak.ToString());
                item.SubItems.Add(Islemler.BoyutDuzenle(hesap.Alan));
                item.SubItems.Add(hesap.Tarih.ToString());
                item.Tag = hesap;
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            int genislik = 0;
            foreach (ColumnHeader sutun in listView1.Columns)
                genislik += sutun.Width;
            listView1.Width = genislik + 21;
            CenterToParent();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                secilen = (Hesap)listView1.SelectedItems[0].Tag;
                Close();
            }
        }
    }
}