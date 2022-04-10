using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace offcloud
{
    static class Islemler
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);

        public static CookieCollection cook;
        public static Kayit kayit = new Kayit();
        public static object kitle = new object();
        public static string key;
        public const int WM_SETTEXT = 0x000C;

        public static string Proxy { get; set; } = "";

        public static string KaynakKoduAl(string url, string method = WebRequestMethods.Http.Get, string postdegeri = "",string posttype= "", CookieCollection cookie = null, WebHeaderCollection header = null, bool otoyonlendir = true)
        {
            lock (kitle)
            {
                try
                {
                    HttpWebRequest request = WebRequest.CreateHttp(url);
                    request.CookieContainer = new CookieContainer();
                    if (!(cookie is null))
                        request.CookieContainer.Add(cookie);
                    request.Accept = "*/*";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.117 Safari/537.36";
                    request.Referer = url;
                    request.Method = method;
                    if (Proxy != "")
                        request.Proxy = new WebProxy(Proxy, true);
                    request.AllowAutoRedirect = false;
                    if (!(header is null))
                        request.Headers.Add(header);
                    if (method == WebRequestMethods.Http.Post && postdegeri != "")
                    {
                        byte[] p = Encoding.UTF8.GetBytes(postdegeri);
                        if (posttype == "")
                            posttype = "application/x-www-form-urlencoded; charset=UTF-8";
                        request.ContentType = posttype;
                        request.ContentLength = p.Length;
                        Stream stream = request.GetRequestStream();
                        stream.Write(p, 0, p.Length);
                        stream.Close();
                    }
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    if (!(cookie is null))
                        cookie.Add(response.Cookies);
                    string source = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    response.Close();
                    return source;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public static void IconYukle(Form form)
        {
            form.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        public static string Cevir(string text)
        {
            return text.Replace("ı", "i").Replace("ğ", "g").Replace("ü", "u").Replace("ş", "s").Replace("ö", "o").Replace("ç", "c");
        }

        public static string Duzenle(string deger)
        {
            for (int i = 32; i <= 255; i++)
                deger = deger.Replace($"\\u{i:x4}", ((char)i).ToString()).Replace($"\\x{i:x}", ((char)i).ToString());
            return deger;
        }


        public static string TagYakala(string veri, string baslangic, string bitis, int index = 1)
        {
            string deger = "";
            try
            {
                string[] a = veri.Split(new string[] { baslangic }, StringSplitOptions.None);
                if (a.Length > 1)
                    deger = a[index].Split(new string[] { bitis }, StringSplitOptions.None)[0];
            }
            catch { }
            return deger;
        }

        public static string Ip()
        {
            return TagYakala(KaynakKoduAl("http://checkip.dyndns.org"), "Current IP Address: ", "<");
        }

        public static void IndirmeGonder(string link, string klasor = "", string kuyruk = "", int parca = 1000, long boyut = 0)
        {
            Process s;
            Process[] kontrol = Process.GetProcessesByName("Şensoy Downloader");
            if (kontrol.Length == 0)
            {
                s = new Process();
                s.StartInfo.FileName = @"D:\Programlar\Şensoy Downloader\Şensoy Downloader\bin\Debug\Şensoy Downloader.exe";
                s.Start();
                s.WaitForInputIdle();
                s.Refresh();
            }
            else
                s = kontrol[0];
            do
            {
                Thread.Sleep(5);
                s.Refresh();
            }
            while (s.MainWindowTitle != "Şensoy Downloader");
            SendMessage(s.MainWindowHandle, WM_SETTEXT, (IntPtr)1, $"{link}[ayrac]{parca}[ayrac]{klasor}[ayrac]{boyut}[ayrac]{kuyruk}");
        }

        public static string RastgeleSifre(int uzunluk)
        {
            const string deger = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder sifre = new StringBuilder();
            Random rnd = new Random();
            while (0 < uzunluk--)
            {
                sifre.Append(deger[rnd.Next(deger.Length)]);
            }
            return sifre.ToString();
        }

        public static string KalanSureDuzenle(TimeSpan sure)
        {
            string format = "";
            if (sure.Days > 0) format = sure.Days + " gün";
            if (sure.Hours > 0) format += (format == "" ? "" : " ") + sure.Hours + " saat";
            if (sure.Minutes > 0) format += (format == "" ? "" : " ") + sure.Minutes + " dak"; ;
            format += (format == "" ? "" : " ") + sure.Seconds + " san";
            return format;
        }

        public static string BoyutDuzenle(long size, int decimals = 3)
        {
            string[] sizes = { "Bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            double formattedSize = size;
            int sizeIndex = 0;
            while (formattedSize >= 1024 && sizeIndex < sizes.Length)
            {
                formattedSize /= 1024;
                sizeIndex += 1;
            }
            return string.Format("{0} {1}", Math.Round(formattedSize, decimals).ToString("N3"), sizes[sizeIndex]);
        }
    }
}
