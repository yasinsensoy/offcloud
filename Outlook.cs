using MailKit.Net.Imap;
using MimeKit;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace offcloud
{
    public class Outlook
    {
        public string Email { get; set; }
        public string Hata { get; set; }
        private ImapClient client;
        private string sifre;

        public Outlook(string ad, string soyad, string s = "12345652")
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
                CookieCollection outlook = new CookieCollection();
                WebHeaderCollection webHeader = new WebHeaderCollection();
                string kaynak = Islemler.Duzenle( Islemler.KaynakKoduAl("https://signup.live.com/?lic=1", "GET", "","", outlook) );
                string uaid = Islemler.TagYakala(kaynak, "uaid\":\"", "\"");
                string uiflvr = Islemler.TagYakala(kaynak, "uiflvr\":", ",");
                string scid = Islemler.TagYakala(kaynak, "scid\":", ",");
                string hpgid = Islemler.TagYakala(kaynak, "hpgid\":", ",");
                string key = Islemler.TagYakala(kaynak, "Key=\"", "\"");
                string randomnum = Islemler.TagYakala(kaynak, "randomNum=\"", "\"");
                Islemler.KaynakKoduAl(Islemler.TagYakala(kaynak, "behavioralTelemetryUrl\":\"", "\""), "GET", "", "", outlook);
                webHeader.Add("canary", Islemler.TagYakala(kaynak, "apiCanary\":\"", "\""));
                Email = $"{Islemler.Cevir(ad.ToLower())}{Islemler.Cevir(soyad.ToLower())}@outlook.com";
                var mn = (dynamic)JObject.Parse(Islemler.KaynakKoduAl("https://signup.live.com/API/CheckAvailableSigninNames?lic=1", "POST", "{\"signInName\":\"" + Email + "\",\"uaid\":\"" + uaid + "\",\"includeSuggestions\":true,\"uiflvr\":" + uiflvr + ",\"scid\":" + scid + ",\"hpgid\":" + hpgid + "}", "application/json", outlook, webHeader));
                webHeader["canary"] = mn.apiCanary.Value;
                if (!mn.isAvailable.Value)
                    Email = mn.suggestions[0].Value;
                OutlookCaptcha frm = new OutlookCaptcha();
                frm.outlook = outlook;
                frm.webHeader = webHeader;
                frm.kaynak = kaynak;
                frm.mail = Email;
                frm.ad = ad;
                frm.soyad = soyad;
                frm.ciphervalue = CipherValue(key,randomnum,sifre);
                frm.ShowDialog();
                if (frm.onay && string.IsNullOrEmpty(frm.hata))
                {
                    client = new ImapClient();
                    Baglan();
                }
                else if (!frm.onay && !string.IsNullOrEmpty(frm.hata))
                    Hata = frm.hata;
                else
                    Hata = "Resim onaylanmadı.";
            }
            catch (Exception ex)
            {
                Hata = ex.Message;
            }
            return Email;
        }

        public string CipherValue(string key,string randomnum,string sifre)
        {
            key = "e=10001;m=abef72b26a0f2555ad7e7f8b3f4972878235c2df6ea147e58f062a176964eb6dda829756960fdec18fbcabb9cf4d57493ef885093f4bd1a846a63bdebdeefd20eebe71d9f5eb6f8ddb8e9ee7c9de12c6f6963f8486a3434ce0289eeaf5fea94ae1474e13ebcd03d0b7ffdb353b9db4abdda91240bb03e5110282743a9bfe993e578b49b0adde478b3caf7d8a0c7b0355ff8ef106018cedcccfde2db51bca63af10bbb30ce1168d5efdb5e84b01b02c2ffe4d5b6b6c67e1ea54be792a887fc41a866591bfe7afab22c80db20d50d6515dcaa6b039ca3c06dbc623817340d429f43e7a079858f4b863990074051e7d7109be2f1f194114b25537d63ec630b4d789";
            randomnum = "F515D0488BC1032F8028A6371E32A7F6B50CA498777DC57021297E0E42EAECAF2C486DD68A2E188FEC863BCF181114F8F5CF90BE5405B2E8C0CB594E66CFAE46B144864A70F697808C796DFA35E8ED3A23091DFCF4B0163802C3837D176F85D524EFC05F";
            sifre = "wqf21rq3f";
            int n = 0;
            int[] t=new int[sifre.Length+5];
            t[n++] = 1;
            t[n++] = 1;
            t[n++] = sifre.Length;
            foreach (char s in sifre)
                t[n++] =  Convert.ToInt32(s);
            t[n++] = 0;
            t[n] = 0;

            string m = Islemler.TagYakala(key,";m=","");
            int b = Convert.ToInt32( Math.Ceiling(Convert.ToDouble(m.Length) / 4));
            int[] data = new int[b];
            int data1 =Convert.ToInt32(Islemler.TagYakala(key, "e=", ";"),16);
            for (int i = 0; i < b; i++)
            {
                string aa = m.Substring(4 * i, 4);
                data[b - 1 - i] = Convert.ToInt32(aa, 16);
            }
            //RSAEncrypt(t, data, data1,randomnum);

            return "";
        }

//        public string RSAEncrypt(int[] e, int[] tn, int te, string randomNum)
//        {
//            int[] n;
//            int i = 42;
//            int o = 2 * tn.Length - i;
//            for (int a = 0; a < e.Length; a += o)
//            {
//                if (a + o >= e.Length)
//                {
//                    int[] r = RSAEncryptBlock(e, tn,te, randomNum);
//                }
//                else
//                {
//                    int[] r = RSAEncryptBlock(e, tn, te, randomNum);
//                }
//            }
//            var s = byteArrayToBase64(n);
//            return s;
//}

        //public int[] RSAEncryptBlock(int[] e, int[] tn, int te, string n)
        //{
        //    int[] i = tn;
        //    int o = te;
        //    int a = e.Length;
        //    int r = 2 * i.Length;
        //      int s = 42;
        //    if (a + s > r)
        //        return null;
        //    applyPKCSv2Padding(e, r, n);
        //    e = e.Reverse().ToArray();
        //    var l = byteArrayToMP(e);
        //    var d = modularExp(l, o, i);
        //    d.Length = i.Length;
        //    var c = mpToByteArray(d);
        //    return c = c.Reverse().ToArray();
        //}

        //public void applyPKCSv2Padding(int[] e, int t, string n)
        //{
        //    int i;
        //    int o = e.Length;
        //    int[] a = { 218, 57, 163, 238, 94, 107, 75, 13, 50, 85, 191, 239, 149, 96, 24, 144, 175, 216, 7, 9 };
        //    int r = t - o - 40 - 2;
        //    int[] s = new int[r+1];
        //    for (i = 0; r > i; i++)
        //    {
        //        s[i] = 0;
        //    }
        //    s[r] = 1;
        //    int[] l = a.Concat(s).Concat(e).ToArray();
        //    object[] d = new object[21];
        //    for (i = 0; 20 > i; i++)
        //    {
        //        d[i] = new Random().Next(256);
        //    }

        //    d = SHA1(d.Concat(new object[] { n}).ToArray());
        //    var c = MGF(d, t - 21);
        //    var u = XORarrays(l, c);
        //    var p = MGF(u, 20);
        //    var m = XORarrays(d, p);
        //      int[] f = { 0};
        //    f = f.Concat(m).Concat(u).ToArray();
        //    for (i = 0; i < f.Length; i++)
        //    {
        //        e[i] = f[i];
        //    }
        //}

//        public object[] SHA1(object[] e)
//        {
//            int t;
//            object[] n = e;
//            PadSHA1Input(n);
//            var i = {
//        "A": 1732584193,
//        "B": 4023233417,
//        "C": 2562383102,
//        "D": 271733878,
//        "E": 3285377520
//    };
//    for (t = 0; t<n.length; t += 64) {
//        SHA1RoundFunction(i, n, t)
//    }
//    List<object> o = new List<object>();
//    wordToBytes(i.A, o, 0);
//    wordToBytes(i.B, o, 4);
//    wordToBytes(i.C, o, 8);
//    wordToBytes(i.D, o, 12);
//    wordToBytes(i.E, o, 16);
//   return o.to
//}
//public void wordToBytes(e, t, n)
//{
//    int i;
//    for (i = 3; i >= 0; i--)
//    {
//        t[n + i] = 255 & e,
//        e >>>= 8
//    }
//}
//public void PadSHA1Input(object[] e)
//{
//    var t, n = e.length, i = n, o = n % 64, a = 55 > o ? 56 : 120;
//    for (e[i++] = 128,
//    t = o + 1; a > t; t++)
//    {
//        e[i++] = 0
//    }
//    var r = 8 * n;
//    for (t = 1; 8 > t; t++)
//    {
//        e[i + 8 - t] = 255 & r,
//        r >>>= 8
//    }
//}
//function SHA1RoundFunction(e, t, n)
//{
//    var i, o, a, r = 1518500249, s = 1859775393, l = 2400959708, d = 3395469782, c = [], u = e.A, p = e.B, m = e.C, f = e.D, g = e.E;
//    for (o = 0,
//    a = n; 16 > o; o++,
//    a += 4)
//    {
//        c[o] = t[a] << 24 | t[a + 1] << 16 | t[a + 2] << 8 | t[a + 3] << 0
//    }
//    for (o = 16; 80 > o; o++)
//    {
//        c[o] = rotateLeft(c[o - 3] ^ c[o - 8] ^ c[o - 14] ^ c[o - 16], 1)
//    }
//    var v;
//    for (i = 0; 20 > i; i++)
//    {
//        v = rotateLeft(u, 5) + (p & m | ~p & f) + g + c[i] + r & 4294967295,
//        g = f,
//        f = m,
//        m = rotateLeft(p, 30),
//        p = u,
//        u = v
//    }
//    for (i = 20; 40 > i; i++)
//    {
//        v = rotateLeft(u, 5) + (p ^ m ^ f) + g + c[i] + s & 4294967295,
//        g = f,
//        f = m,
//        m = rotateLeft(p, 30),
//        p = u,
//        u = v
//    }
//    for (i = 40; 60 > i; i++)
//    {
//        v = rotateLeft(u, 5) + (p & m | p & f | m & f) + g + c[i] + l & 4294967295,
//        g = f,
//        f = m,
//        m = rotateLeft(p, 30),
//        p = u,
//        u = v
//    }
//    for (i = 60; 80 > i; i++)
//    {
//        v = rotateLeft(u, 5) + (p ^ m ^ f) + g + c[i] + d & 4294967295,
//        g = f,
//        f = m,
//        m = rotateLeft(p, 30),
//        p = u,
//        u = v
//    }
//    e.A = e.A + u & 4294967295,
//    e.B = e.B + p & 4294967295,
//    e.C = e.C + m & 4294967295,
//    e.D = e.D + f & 4294967295,
//    e.E = e.E + g & 4294967295
//}
//function rotateLeft(e, t)
//{
//    var n = e >>> 32 - t
//      , i = (1 << 32 - t) - 1
//      , o = e & i;
//    return o << t | n
//}

public void Baglan()
        {
            if (!client.IsConnected)
            {
                client.Connect("outlook.office365.com", 993, true);
                client.Authenticate(Email, sifre);
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