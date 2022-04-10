using System;
using System.Windows.Forms;

namespace offcloud
{
    public partial class Proxy : Form
    {
        public Proxy()
        {
            InitializeComponent();
            Islemler.IconYukle(this);
        }

        private void Proxy_Load(object sender, EventArgs e)
        {
            txtproxy.Text = Islemler.Proxy;
        }

        private void btntest_Click(object sender, EventArgs e)
        {
            string p = Islemler.Proxy;
            Islemler.Proxy = txtproxy.Text.Trim();
            MessageBox.Show($"İp: {Islemler.Ip()}", "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Islemler.Proxy = p;
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            Islemler.Proxy = txtproxy.Text.Trim();
            btnkaydet.Enabled = false;
        }

        private void txtproxy_TextChanged(object sender, EventArgs e)
        {
            btnkaydet.Enabled = Islemler.Proxy != txtproxy.Text.Trim();
        }
    }
}
