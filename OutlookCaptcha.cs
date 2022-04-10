using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Windows.Forms;

namespace offcloud
{
    public partial class OutlookCaptcha : Form
    {
        public string kaynak,mail, ciphervalue,ad,soyad,hata;
        public CookieCollection outlook;
        public WebHeaderCollection webHeader;
        public bool onay = false;
        private string hid;

        public OutlookCaptcha()
        {
            InitializeComponent();
            Islemler.IconYukle(this);
        }

        private void btnonay_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string uaid = Islemler.TagYakala(kaynak, "uaid\":\"", "\"");
            string siteid = Islemler.TagYakala(kaynak, "siteId\":\"", "\"");
            string hfid = Islemler.TagYakala(kaynak, "SessionID=", "&"); ;
            string ski = Islemler.TagYakala(kaynak, "SKI=\"", "\"");
            string uiflvr = Islemler.TagYakala(kaynak, "uiflvr\":", ",");
            string scid = Islemler.TagYakala(kaynak, "scid\":", ",");
            string hsid = Islemler.TagYakala(kaynak, "SiteID=", "&"); ;
            string hpgid = Islemler.TagYakala(kaynak, "hpgid\":", ",");
            var kayit = (dynamic)JObject.Parse(Islemler.KaynakKoduAl("https://signup.live.com/API/CreateAccount?lic=1", "POST", "{\"MemberName\":\"" + mail + "\",\"CheckAvailStateMap\":[\"" + mail + ":undefined\"],\"EvictionWarningShown\":[],\"UpgradeFlowToken\":{},\"FirstName\":\"" + ad + "\",\"LastName\":\"" + soyad + "\",\"MemberNameChangeCount\":1,\"MemberNameAvailableCount\":1,\"MemberNameUnavailableCount\":0,\"CipherValue\":\"" + ciphervalue + "\",\"SKI\":\"" + ski + "\",\"BirthDate\":\"" + $"{rnd.Next(1, 28)}:{rnd.Next(1, 12)}:{rnd.Next(1990, 2000)}" + "\",\"Country\":\"TR\",\"IsOptOutEmailDefault\":true,\"IsOptOutEmailShown\":true,\"IsOptOutEmail\":true,\"LW\":true,\"SiteId\":\"" + siteid + "\",\"IsRDM\":0,\"WReply\":null,\"ReturnUrl\":null,\"SignupReturnUrl\":null,\"uiflvr\":" + uiflvr + ",\"uaid\":\"" + uaid + "\",\"SuggestedAccountType\":\"EASI\",\"SuggestionType\":\"Prefer\",\"HFId\":\"" + hfid + "\",\"HType\":\"visual\",\"HSId\":\""+hsid+"\",\"HId\":\""+hid+"\",\"HSol\":\""+txtcaptcha.Text+"\",\"scid\":" + scid + ",\"hpgid\":" + hpgid + "}", "application/json", outlook, webHeader));
            if (kayit.status == "ok")
            {
                onay = true;
                Close();
            }
            else
            {
                MessageBox.Show("Hatalı kod.", "Yanlış", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                string fid = Islemler.TagYakala(kaynak, "SessionID=", "&");
                string siteid= Islemler.TagYakala(kaynak, "SiteID=", "&");
                string hip = Islemler.Duzenle(Islemler.KaynakKoduAl($"https://wus.client.hip.live.com/GetHIP/GetHIPAMFE/HIPAMFE?dc=WUS&mkt=tr-TR&id={siteid}&fid={fid}&type=visual", "GET", "", "", outlook));
                hid = Islemler.TagYakala(hip, "hid=", "&");
                string r = Islemler.TagYakala(hip, "hipChallengeUrl\":\"", "\"");
                resim.ImageLocation = r;
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
