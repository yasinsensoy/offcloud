using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Windows.Forms;

namespace offcloud
{
    public partial class YandexCaptcha : Form
    {
        public string captcha, post;
        public CookieCollection yandex;
        public WebHeaderCollection webHeader;
        public bool onay = false;

        public YandexCaptcha()
        {
            InitializeComponent();
            Islemler.IconYukle(this);
        }

        private void btnonay_Click(object sender, EventArgs e)
        {
            var checkHuman = (dynamic)JObject.Parse(Islemler.KaynakKoduAl("https://passport.yandex.com.tr/registration-validations/checkHuman", "POST", $"{post}answer={txtcaptcha.Text}", "", yandex, webHeader));
            if (checkHuman.status == "ok")
            {
                captcha = txtcaptcha.Text;
                onay = true;
                Close();
            }
            else
            {
                MessageBox.Show("Hatalı kod.\n" + checkHuman.errors[0], "Yanlış", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Yenile();
            }
        }

        private void btnyenile_Click(object sender, EventArgs e)
        {
            Yenile();
        }

        private void Yenile()
        {
            try
            {
                resim.ImageLocation = ((dynamic)JObject.Parse(Islemler.KaynakKoduAl("https://passport.yandex.com.tr/registration-validations/textcaptcha", "POST", $"{post}language=tr&ocr=true", "", yandex, webHeader))).image_url;
                txtcaptcha.Text = "";
                txtcaptcha.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Captcha_Load(object sender, EventArgs e)
        {
            Yenile();
        }

        private void txtcaptcha_TextChanged(object sender, EventArgs e)
        {
            btnonay.Enabled = txtcaptcha.TextLength > 0;
        }
    }
}
