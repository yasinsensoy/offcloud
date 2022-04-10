using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace offcloud
{
    public class Kayit
    {
        private XmlSerializer serializer = new XmlSerializer(typeof(Hesap[]));
        public List<Hesap> hesaplar = new List<Hesap>();
        private string kayit, yol;

        public Kayit(string kayitadi = "hesaplar")
        {
            kayit = kayitadi;
            yol = Path.Combine(Application.StartupPath, kayit);
            Yukle();
        }

        public string Kaydet()
        {
            try
            {
                using (FileStream fs = File.Open(yol, FileMode.Create))
                    serializer.Serialize(fs, hesaplar.ToArray());
                return "Kaydedildi";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Yukle()
        {
            if (File.Exists(yol))
            {
                try
                {
                    using (FileStream fs = File.Open(yol, FileMode.Open))
                        hesaplar = new List<Hesap>((Hesap[])serializer.Deserialize(fs));
                    return "Yüklendi";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else
                return "Dosya bulunamadı";
        }
    }

    [Serializable()]
    public class Hesap
    {
        [XmlAttribute("email")]
        public string Email { get; set; }

        [XmlAttribute("sifre")]
        public string Sifre { get; set; }

        [XmlAttribute("oip")]
        public string OIp { get; set; }

        [XmlAttribute("kip")]
        public string KIp { get; set; }

        [XmlAttribute("hak")]
        public int Hak { get; set; }

        [XmlAttribute("alan")]
        public long Alan { get; set; }

        [XmlAttribute("tarih")]
        public DateTime Tarih { get; set; }

        [XmlAttribute("cookie")]
        public string[] Cook { get; set; }

        [XmlAttribute("tip")]
        public Tip Tip { get; set; }

        [XmlIgnore]
        public CookieCollection Cookie
        {
            get
            {
                CookieCollection cook = new CookieCollection();
                foreach (string item in Cook)
                {
                    string[] d = item.Split(';');
                    cook.Add(new Cookie(d[0], d[1], d[2], d[3]));
                }
                return cook;
            }
            set
            {
                List<string> c = new List<string>();
                foreach (Cookie item in value)
                    c.Add($"{item.Name};{item.Value};{item.Path};{item.Domain}");
                Cook = c.ToArray();
            }
        }

        public Hesap(string email, string sifre, string oip, string kip, int hak, long alan, CookieCollection cookie, Tip tip)
        {
            Email = email;
            Sifre = sifre;
            OIp = oip;
            KIp = kip;
            Hak = hak;
            Alan = alan;
            Tarih = DateTime.Now;
            Cookie = cookie;
            Tip = tip;
        }

        public Hesap()
        { }
    }
}

public enum Tip { Sifreli, Sifresiz }