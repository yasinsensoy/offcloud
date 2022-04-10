using System;
using System.IO;
using System.Net.Torrent;
using System.Threading;
using System.Windows.Forms;

namespace offcloud
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string l = "";
            if (args.Length > 0)
            {
                if (File.Exists(args[0]))
                {
                    Metadata metadata = Metadata.FromFile(args[0]);
                    l = $"magnet:?xt=urn:btih:{metadata.HashString.ToLower()}&dn={metadata.Name}";
                }
                else if (args[0].Substring(0, 7) == "magnet:")
                    l = args[0];
            }
            Mutex mutex = new Mutex(true, "offcloud", out bool kontrol);
            if (kontrol == false)
            {
                IntPtr handle = Islemler.FindWindow(null, "offcloud");
                Islemler.SendMessage(handle, Islemler.WM_SETTEXT, (IntPtr)52200, l);
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(l));
            GC.KeepAlive(mutex);
        }
    }
}