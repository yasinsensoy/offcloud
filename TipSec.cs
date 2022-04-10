using System;
using System.Windows.Forms;

namespace offcloud
{
    public partial class TipSec : Form
    {
        public bool secildi = false;
        public Tip tip;

        public TipSec()
        {
            InitializeComponent();
            Islemler.IconYukle(this);
        }

        private void TipSec_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0: tip = Tip.Sifreli; break;
                case 1: tip = Tip.Sifresiz; break;
            }
            secildi = true;
            Close();
        }
    }
}
