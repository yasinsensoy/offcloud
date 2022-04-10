using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace offcloud
{
    public partial class Indirme : UserControl
    {
        public string Id, Durum, Ad;
        public long Boyut, Indirilen, KalanSure, kalan;
        public bool bitti = false;
        private readonly CookieCollection cook;
        private readonly  string Link, Server;

        public Indirme(string id, string link, string server, CookieCollection cookie)
        {
            InitializeComponent();
            lblad.Text = "";
            lbldurum.Text = "";
            lblhiz.Text = "";
            lblkalan.Text = "";
            Id = id;
            Link = link;
            lblmagnet.Text = link;
            lblmagnet.LinkArea = new LinkArea(0, link.Length);
            Server = server;
            cook = cookie;
        }

        public Indirme()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (KalanSure > 0)
            {
                lblkalan.Text = "Kalan Süre: " + Islemler.KalanSureDuzenle(TimeSpan.FromSeconds(KalanSure));
                KalanSure--;
            }
            else
                lblkalan.Text = "Kalan Süre: 0 san";
        }

        private void lblmagnet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((Form1)ParentForm).txtlink.Text = Link;
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            string iptal = Islemler.KaynakKoduAl($"https://offcloud.com/cloud/cancel/{Id}", "GET", "", "", cook);
            if (iptal != "{}")
                MessageBox.Show("İptal edilemedi. Lütfen tekrar deneyin.", "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            string sil = Islemler.KaynakKoduAl($"https://offcloud.com/cloud/remove/{Id}", "GET", "", "", cook);
            if (sil.Contains("success"))
                ((Form1)ParentForm).Yenile();
            else
                MessageBox.Show("Silme başarısız. Hata: " + sil, "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btntekrar_Click(object sender, EventArgs e)
        {
            string tekrar = Islemler.KaynakKoduAl($"https://offcloud.com/cloud/tryagain/{Id}", "GET", "", "", cook);
            if (tekrar.Contains("error"))
                MessageBox.Show("Hata oluştu lütfen tekrar deneyin.", "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                ((Form1)ParentForm).Yenile();
        }

        private void btnindir_Click(object sender, EventArgs e)
        {
            string ext = Path.GetExtension(Ad);
            string link = $"https://{Server}.offcloud.com/cloud/{(ext != "" ? "download" : "zip")}/{Id}/{(Ad == "" ? "undefined.zip" : Ad + (ext != "" ? "" : ".zip")) }";
            Islemler.IndirmeGonder(link);
        }

        private void btnkopyala_Click(object sender, EventArgs e)
        {
            string ext = Path.GetExtension(Ad);
            string link = $"https://{Server}.offcloud.com/cloud/{(ext != "" ? "download" : "zip")}/{Id}/{(Ad == "" ? "undefined.zip" : Ad + (ext != "" ? "" : ".zip")) }";
            Uri uri = new Uri(link);
            Clipboard.SetText(uri.AbsoluteUri);
        }

        private void btngoster_Click(object sender, EventArgs e)
        {
            string icerik = Islemler.KaynakKoduAl($"https://{Server}.offcloud.com/cloud/list/{Id}", "GET", "", "", cook);
            if(icerik== "İşlem zaman aşımına uğradı")
            {
                MessageBox.Show(icerik, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dynamic data = JObject.Parse(icerik);
            var dosyalar = data.entries;
            if (dosyalar is null)
            {
                MessageBox.Show("Bulunamadı tekrar deneyin.", "Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Icerik frm = new Icerik
            {
                dosyalar = dosyalar.ToObject<string[]>(),
                id = Id,
                server = Server
            };
            frm.ShowDialog();
        }
    }
}