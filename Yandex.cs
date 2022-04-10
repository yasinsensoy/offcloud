using MailKit.Net.Imap;
using MimeKit;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;

namespace offcloud
{
    public class Yandex
    {
        public string Email { get; set; }
        public string Hata { get; set; }
        private ImapClient client;
        private string login, sifre;

        public Yandex(string ad, string soyad, string s = "12345652")
        {
            sifre = s;
            YeniMail(ad, soyad);
        }

        public string YeniMail(string ad, string soyad)
        {
            Email = "";
            Hata = "";
            try
            {
                CookieCollection yandex = new CookieCollection();
                WebHeaderCollection webHeader = new WebHeaderCollection();
                webHeader.Add("X-Requested-With", "XMLHttpRequest");
                string kaynak = Islemler.KaynakKoduAl("https://passport.yandex.com.tr/registration", "GET", "", "", yandex);
                string track_id = Islemler.TagYakala(kaynak, "track_id\" value=\"", "\"");
                string csrf_token = Islemler.TagYakala(kaynak, "csrf=\"", "\"");
                string post = $"track_id={track_id}&csrf_token={csrf_token}&";
                YandexCaptcha frm = new YandexCaptcha();
                frm.post = post;
                frm.yandex = yandex;
                frm.webHeader = webHeader;
                frm.ShowDialog();
                if (frm.onay)
                {
                    string captcha = frm.captcha;
                    login = ((dynamic)JObject.Parse(Islemler.KaynakKoduAl("https://passport.yandex.com.tr/registration-validations/suggestV2", "POST", $"{post}login=&firstname={ad}&lastname={soyad}", "", yandex, webHeader))).logins[0];
                    var kayit = (dynamic)JObject.Parse(Islemler.KaynakKoduAl("https://passport.yandex.com.tr/registration-validations/registration-alternative", "POST", $"{post}firstname={ad}&lastname={soyad}&surname=&login={login}&password={sifre}&password_confirm={sifre}&hint_question_id=12&hint_question=En sevdiğiniz müzisyenin soyadı&hint_question_custom=&hint_answer=Ahmet Kaya&captcha={""}&phone=&phoneCode=&human-confirmation=captcha&from=mail&eula_accepted=on&type=alternative", "", yandex, webHeader));
                    if (kayit.status == "ok")
                    {
                        string bitis = Islemler.KaynakKoduAl($"https://passport.yandex.com.tr/registration/finish?track_id={track_id}", "GET", "", "", yandex);
                        Email = login + "@yandex.com";
                        client = new ImapClient();
                        Baglan();
                    }
                    else
                        Hata = kayit.error[0].message.Value;
                }
                else
                    Hata = "Resim onaylanmadı.";
            }
            catch (Exception ex)
            {
                Hata = ex.Message;
            }
            return Email;
        }

        public void Baglan()
        {
            if (!client.IsConnected)
            {
                client.Connect("imap.yandex.com.tr", 993, true);
                client.Authenticate(login, sifre);
            }
        }

        public List<Mail> GelenKutusu()
        {
            List<Mail> mails = new List<Mail>();
            try
            {
                Baglan();
                client.Inbox.Open(MailKit.FolderAccess.ReadOnly);
                var inbox = client.Inbox;
                foreach (MimeMessage mail in inbox)
                {
                    string id = mail.MessageId;
                    string konu = mail.Subject;
                    DateTimeOffset zaman = mail.Date;
                    string gonderen = mail.From[0].Name;
                    string mesaj = mail.HtmlBody;
                    mails.Add(new Mail(id, konu, zaman, gonderen, mesaj));
                }
            }
            catch (Exception)
            {

            }
            return mails;
        }

        public void Kapat()
        {
            if (client.IsConnected)
                client.Disconnect(true);
        }

        public class Mail
        {
            public string Id { get; set; }
            public string Konu { get; set; }
            public DateTimeOffset Zaman { get; set; }
            public string Gonderen { get; set; }
            public string Mesaj { get; set; }

            public Mail(string id, string konu, DateTimeOffset zaman, string gonderen, string mesaj)
            {
                Id = id;
                Konu = konu;
                Zaman = zaman;
                Gonderen = gonderen;
                Mesaj = mesaj;
            }
        }
    }
}