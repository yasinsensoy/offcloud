using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace offcloud
{
    public partial class Form1 : Form
    {
        private string hmail, hsifre;
        private Thread thread;
        private Tip tip;

        private enum MesajTip
        {
            Hata, Basarili, Islem
        }

        public Form1(string link)
        {
            InitializeComponent();
            Islemler.IconYukle(this);
            txtlink.Text = link;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Islemler.WM_SETTEXT && m.WParam.ToInt32() == 52200)
            {
                string msj = Marshal.PtrToStringAuto(m.LParam);
                if (msj != "")
                {
                    txtlink.Text = msj;
                    txtlink.Focus();
                }
                Islemler.SetForegroundWindow(Handle);
            }
            else
                base.WndProc(ref m);
        }

        private void btnkayit_Click(object sender, EventArgs e)
        {
            TipSec frm = new TipSec();
            frm.ShowDialog();
            if (frm.secildi)
            {
                tip = frm.tip;
                if (!backgroundWorker1.IsBusy)
                    backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                Mesaj("Tip seçmediniz.", MesajTip.Hata);
                return;
            }
        }

        private void btngiris_Click(object sender, EventArgs e)
        {
            tip = Tip.Sifreli;
            Giris();
        }

        private void Giris()
        {
            if (!backgroundWorker3.IsBusy)
                backgroundWorker3.RunWorkerAsync();
        }

        private void Islem(bool islem)
        {
            Invoke((MethodInvoker)delegate
            {
                panel3.Enabled = !islem;
                btnkayit.Enabled = !islem;
                btnhesapsec.Enabled = !islem;
                btngiris.Enabled = !islem;
                btnyenile.Enabled = !islem;
                btnproxy.Enabled = !islem;
                txtmail.ReadOnly = islem;
                txtsifre.ReadOnly = islem;
            });
        }

        private void backgroundWorker3_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Islem(true);
            Mesaj("Giriş yapılıyor.", MesajTip.Islem);
            if (tip == Tip.Sifreli)
            {
                Islemler.cook = new CookieCollection();
                string giris = Islemler.KaynakKoduAl("https://offcloud.com/api/login", "POST", $"username={txtmail.Text}&password={txtsifre.Text}", "", Islemler.cook);
                if (Islemler.TagYakala(giris, "email\": \"", "\"") == txtmail.Text)
                {
                    Islemler.key = Islemler.TagYakala(Islemler.KaynakKoduAl("https://offcloud.com/api/key", "POST", "", "", Islemler.cook), "apiKey\": \"", "\"");
                    Mesaj("Giriş başarılı.", MesajTip.Basarili);
                    hmail = txtmail.Text;
                    hsifre = txtsifre.Text;
                    Yenile();
                }
                else
                    Mesaj("Giriş başarısız.\nHata: " + giris, MesajTip.Hata);
            }
            else
            {
                string key = Islemler.TagYakala(Islemler.KaynakKoduAl("https://offcloud.com/api/key", "POST", "", "", Islemler.cook), "apiKey\": \"", "\"");
                if (key != "")
                {
                    Islemler.key = key;
                    Mesaj("Giriş başarılı.", MesajTip.Basarili);
                    hmail = txtmail.Text;
                    hsifre = txtsifre.Text;
                    Yenile();
                }
                else
                    Mesaj("Giriş başarısız.", MesajTip.Hata);
            }
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Islem(false);
        }

        private void Mesaj(string mesaj, MesajTip hata)
        {
            Invoke((MethodInvoker)delegate
            {
                lblmesaj.Text = mesaj;
                lblmesaj.ForeColor = hata == MesajTip.Basarili ? Color.LimeGreen : (hata == MesajTip.Hata ? Color.Red : Color.Yellow);
            });
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            Islem(true);
            string kaynak = Islemler.KaynakKoduAl("https://offcloud.com/cloud/request", "POST", $"url={txtlink.Text}", "", Islemler.cook);
            if (kaynak.Contains("not_available") || kaynak.Contains("error"))
            {
                Mesaj("Link eklenemedi." + (kaynak.Contains("error") ? $" Hata: {Islemler.TagYakala(kaynak, "error\": \"", "\"")}" : ""), MesajTip.Hata);
                Islem(false);
            }
            else
                Yenile();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //RastgeleIsim rastgeleIsim = new RastgeleIsim(RastgeleIsim.Cinsiyet.Erkek);
            //Outlook yandex = new Outlook(rastgeleIsim.Ad, rastgeleIsim.Soyad, Islemler.RastgeleSifre(14));
            try
            {
                RegistryKey rkey = Registry.ClassesRoot.CreateSubKey(@"Magnet\shell\open\command");
                rkey.SetValue("", $"\"{Application.ExecutablePath}\" \"%1\"");
                rkey.Close();
                RegistryKey rkey1 = Registry.ClassesRoot.CreateSubKey(@"Magnet\DefaultIcon");
                rkey1.SetValue("", $"\"{Application.ExecutablePath}\"");
                rkey1.Close();
                RegistryKey rkey2 = Registry.ClassesRoot.CreateSubKey(@"bittorrent\shell\open\command");
                rkey2.SetValue("", $"\"{Application.ExecutablePath}\" \"%1\"");
                rkey2.Close();
                RegistryKey rkey3 = Registry.ClassesRoot.CreateSubKey(@"bittorrent\DefaultIcon");
                rkey3.SetValue("", $"\"{Path.Combine(Application.StartupPath, "torrent.ico")}\"");
                rkey3.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ServicePointManager.DefaultConnectionLimit = 10000;
            if (Islemler.kayit.hesaplar.Count > 0)
            {
                Hesap hsp = Islemler.kayit.hesaplar.OrderByDescending(a => a.Tarih).ToList()[0];
                txtmail.Text = hsp.Email;
                txtsifre.Text = hsp.Sifre;
                Islemler.cook = hsp.Cookie;
                tip = hsp.Tip;
                Giris();
            }
        }

        private void btnhesapsec_Click(object sender, EventArgs e)
        {
            if (Islemler.kayit.hesaplar.Count <= 0)
            {
                MessageBox.Show("Hesap bulunamadı.", "Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Hesaplar frm = new Hesaplar();
            frm.hesaplar = Islemler.kayit.hesaplar.OrderByDescending(a => a.Tarih).ToList();
            frm.ShowDialog();
            if (frm.secilen != null)
            {
                txtmail.Text = frm.secilen.Email;
                txtsifre.Text = frm.secilen.Sifre;
                Islemler.cook = frm.secilen.Cookie;
                tip = frm.secilen.Tip;
                btngiris.PerformClick();
            }
        }

        private void btnyenile_Click(object sender, EventArgs e)
        {
            Yenile();
        }

        public void Yenile()
        {
            toolStripStatusLabel2.Text = "";
            toolStripStatusLabel1.Text = "";
            toolStripStatusLabel3.Text = "";
            toolStripStatusLabel4.Text = "";
            if (!backgroundWorker2.IsBusy)
                backgroundWorker2.RunWorkerAsync();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (thread != null)
            {
                thread.Abort();
                thread.Join();
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                Islem(true);
                Invoke((MethodInvoker)delegate
                {
                    txtmail.Text = "";
                    txtsifre.Text = "";
                });
                Mesaj("İp kontrol ediliyor...", MesajTip.Islem);
                string ip = Islemler.Ip();
                if (Islemler.kayit.hesaplar.FirstOrDefault(h => h.OIp == ip) != null)
                {
                    Mesaj("Bu ip ile daha önce hesap oluşturulmuş.", MesajTip.Hata);
                    return;
                }
                Mesaj("Mail Oluşturuluyor...", MesajTip.Islem);
                if (thread != null)
                {
                    thread.Abort();
                    thread.Join();
                }
                Invoke((MethodInvoker)delegate
                {
                    flowLayoutPanel1.Controls.Clear();
                    toolStripStatusLabel2.Text = "";
                    toolStripStatusLabel1.Text = "";
                    toolStripStatusLabel3.Text = "";
                    toolStripStatusLabel4.Text = "";
                });
                Islemler.cook = new CookieCollection();
                RastgeleIsim rastgeleIsim = new RastgeleIsim(RastgeleIsim.Cinsiyet.Erkek);
                Yandex yandex = null;
                string sifre = "";
                string email = "";
                if (tip == Tip.Sifreli)
                {
                    sifre = Islemler.RastgeleSifre(8);
                    yandex = new Yandex(rastgeleIsim.Ad, rastgeleIsim.Soyad, sifre);
                    email = yandex.Email;
                    Invoke((MethodInvoker)delegate
                    {
                        txtmail.Text = email;
                        txtsifre.Text = sifre;
                    });
                    if (!string.IsNullOrEmpty(yandex.Hata))
                        throw new Exception("Mail oluşturulamadı. Hata: " + yandex.Hata);
                }
                else
                {
                    Random rnd = new Random();
                    email = $"{Islemler.Cevir(rastgeleIsim.Ad.ToLower())}{rnd.Next(1, 100)}{Islemler.Cevir(rastgeleIsim.Soyad.ToLower())}{rnd.Next(10, 1000)}@yandex.com";
                    Invoke((MethodInvoker)delegate { txtmail.Text = email; });
                }
                Mesaj("Kayıt olunuyor...", MesajTip.Islem);
                string kayit = Islemler.KaynakKoduAl("https://offcloud.com/auth/register/classic", "POST", $"email={email}&promocode=&source=","", Islemler.cook, null, false);
                string error = Islemler.TagYakala(kayit, "\"error\": \"", "\"");
                if (!string.IsNullOrEmpty(error))
                    throw new Exception("Hata: " + error);
                if (Islemler.cook["noWelcomeGift"] != null)
                    throw new Exception("Bu ip ile bedava daha önce alınmış.");
                if (!kayit.Contains("Redirecting"))
                    throw new Exception("Hesap oluşturma başarısız. Hata: " + kayit);
                if (tip == Tip.Sifreli)
                {
                    Mesaj("Kayıt olundu. Mail bekleniyor...", MesajTip.Islem);
                    List<Yandex.Mail> mails;
                    Yandex.Mail mail = null;
                    int say = 60;
                    do
                    {
                        do
                        {
                            Thread.Sleep(1000);
                            mails = yandex.GelenKutusu();
                            Mesaj($"Kayıt olundu. Mail bekleniyor... ({say--})", MesajTip.Islem);
                        }
                        while (mails.Count <= 0 && say >= 0);
                        foreach (Yandex.Mail m in mails)
                        {
                            if (m.Gonderen.ToLower() == "offcloud.com")
                            {
                                mail = m;
                                break;
                            }
                        }
                    }
                    while (mail == null && say >= 0);
                    if (mail != null)
                    {
                        string icerik = mail.Mesaj;
                        string hash = Islemler.TagYakala(icerik, "set-password?hash=", "\"");
                        string sifredegis = Islemler.KaynakKoduAl("https://offcloud.com/auth/set-password", "POST", $"password={sifre}&hash={hash}", "", Islemler.cook);
                    }
                    else
                        tip = Tip.Sifresiz;
                }
                if (yandex != null)
                    yandex.Kapat();
            }
            catch (Exception ex)
            {
                Mesaj(ex.Message, MesajTip.Hata);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Islem(false);
            Giris();
        }

        private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Mesaj("Yenileniyor...", MesajTip.Islem);
            Islem(true);
            if (thread != null)
            {
                thread.Abort();
                thread.Join();
            }
            Invoke((MethodInvoker)delegate { flowLayoutPanel1.Controls.Clear(); });
            string kaynak = Islemler.KaynakKoduAl("https://offcloud.com/cloud/history", "POST", "", "", Islemler.cook);
            string[] indirmeler = Islemler.TagYakala(kaynak, "history\": [", "],").Trim().Split(new string[] { "}," }, StringSplitOptions.RemoveEmptyEntries);
            string ids = "";
            foreach (string indirme in indirmeler)
            {
                string id = Islemler.TagYakala(indirme, "requestId\": \"", "\"");
                string link = Islemler.TagYakala(indirme, "originalLink\": \"", "\"");
                string server = Islemler.TagYakala(indirme, "server\": \"", "\"");
                string status = Islemler.TagYakala(indirme, "status\": \"", "\"");
                string filename = Islemler.TagYakala(indirme, "fileName\": \"", "\"");
                long.TryParse(Islemler.TagYakala(indirme, "fileSize\": ", ","), out long b);
                long.TryParse(Islemler.TagYakala(indirme, "downloadingSpeed\": \"", "\""), out long hiz);
                Indirme cntrl = new Indirme(id, link, server, Islemler.cook)
                {
                    Durum = status,
                    Boyut = b,
                    Ad = filename
                };
                cntrl.lblad.Text = "Ad: " + cntrl.Ad;
                cntrl.lbldurum.Text = "Durum: " + cntrl.Durum + (cntrl.Durum == "error" ? $" ({Islemler.TagYakala(indirme, "errorMessage\": \"", "\"")})" : "");
                double ilerleme = (cntrl.Boyut == 0 ? 0 : (cntrl.Indirilen / (double)cntrl.Boyut * 100.0F));
                cntrl.progressBar1.Value = Convert.ToInt32(ilerleme);
                cntrl.progressBar1.CustomText = $"{Islemler.BoyutDuzenle(cntrl.Indirilen)}/{Islemler.BoyutDuzenle(cntrl.Boyut)} (%{ilerleme:N2})";
                cntrl.lblhiz.Text = $"İndirme Hızı: {Islemler.BoyutDuzenle(hiz)}/san";
                cntrl.btntekrar.Enabled = cntrl.Durum == "error" || cntrl.Durum == "canceled";
                cntrl.btnsil.Enabled = cntrl.Durum != "downloading";
                cntrl.btniptal.Enabled = cntrl.Durum == "downloading";
                Invoke((MethodInvoker)delegate { flowLayoutPanel1.Controls.Add(cntrl); });
                ids += (ids == "" ? "" : "&") + "requestIds[]=" + id;
            }
            if (indirmeler.Length > 0)
            {
                thread = new Thread(new ThreadStart(delegate { Islem(Islemler.cook, ids); }));
                thread.Start();
            }
            string hak = Islemler.KaynakKoduAl("https://offcloud.com/stats/usage-left", "POST", "", "", Islemler.cook);
            string ip = Islemler.Ip();
            int khak = Convert.ToInt32(Islemler.TagYakala(hak, "premium\": ", ","));
            long alan = Convert.ToInt64(Islemler.TagYakala(hak, "cloud\": ", ","));
            if (khak > 0 && alan > 0)
                Invoke((MethodInvoker)delegate { panel3.Enabled = true; });
            Invoke((MethodInvoker)delegate
            {
                toolStripStatusLabel2.Text = "Kullanıcı: " + hmail;
                toolStripStatusLabel1.Text = "İp: " + ip;
                toolStripStatusLabel3.Text = "Kalan hak: " + khak;
                toolStripStatusLabel4.Text = "Kalan alan: " + Islemler.BoyutDuzenle(alan);
            });
            Hesap hesap = Islemler.kayit.hesaplar.FirstOrDefault(a => a.Email == hmail && a.Sifre == hsifre);
            if (hesap == null)
                Islemler.kayit.hesaplar.Add(new Hesap(hmail, hsifre, ip, ip, khak, alan, Islemler.cook, tip));
            else
            {
                hesap.Hak = khak;
                hesap.Alan = alan;
                hesap.KIp = ip;
                hesap.Cookie = Islemler.cook;
            }
            Islemler.kayit.Kaydet();
            Mesaj("Yenileme başarılı.", MesajTip.Basarili);
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Islem(false);
        }

        private void btnproxy_Click(object sender, EventArgs e)
        {
            Proxy frm = new Proxy();
            frm.ShowDialog();
        }

        private void Islem(CookieCollection cook, string id)
        {
            try
            {
                string ids = id;
                do
                {
                    string[] kaynak = Islemler.KaynakKoduAl("https://offcloud.com/api/cloud/status?key=" + Islemler.key, "POST", ids, "", cook).Split(new string[] { "}," }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (Indirme i in flowLayoutPanel1.Controls)
                    {
                        if (i.bitti)
                            continue;
                        string k = kaynak.FirstOrDefault(a => a.Contains(i.Id));
                        if (string.IsNullOrEmpty(k))
                            continue;
                        long hiz = 0;
                        i.Durum = Islemler.TagYakala(k, "status\": \"", "\"");
                        long b = 0;
                        long.TryParse(Islemler.TagYakala(k, "fileSize\": ", ","), out b);
                        i.Boyut = b;
                        long indirilen = Convert.ToInt64(Islemler.TagYakala(k, "amount\": ", ","));
                        long ifark = indirilen - i.Indirilen;
                        i.Indirilen = indirilen;
                        if (i.Durum == "downloading")
                            long.TryParse(Islemler.TagYakala(k, "downloadingSpeed\": \"", "\""), out hiz);
                        i.Ad = Islemler.TagYakala(k, "fileName\": \"", "\"");
                        long sure = hiz == 0 ? 0 : ((i.Boyut - i.Indirilen) / hiz);
                        if (sure != i.kalan)
                        {
                            i.kalan = sure;
                            i.KalanSure = i.kalan;
                        }
                        i.Invoke((MethodInvoker)delegate
                        {
                            if (!i.timer1.Enabled)
                                i.timer1.Start();
                            i.lblad.Text = "Ad: " + i.Ad;
                            i.lbldurum.Text = "Durum: " + i.Durum + (i.Durum == "error" ? $" ({Islemler.TagYakala(k, "errorMessage\": \"", "\"")})" : "");
                            double ilerleme = (i.Boyut == 0 ? 0 : (i.Indirilen / (double)i.Boyut * 100.0F));
                            i.progressBar1.Value = Convert.ToInt32(ilerleme);
                            i.progressBar1.CustomText = $"{Islemler.BoyutDuzenle(i.Indirilen)}/{Islemler.BoyutDuzenle(i.Boyut)} (%{ilerleme:N2})";
                            i.lblhiz.Text = $"İndirme Hızı: {Islemler.BoyutDuzenle(hiz)}/san";
                            i.btntekrar.Enabled = i.Durum == "error" || i.Durum == "canceled";
                            i.btnsil.Enabled = i.Durum != "downloading";
                            i.btniptal.Enabled = i.Durum == "downloading";
                        });
                        if (i.Durum == "downloaded")
                        {
                            i.Invoke((MethodInvoker)delegate
                            {
                                i.timer1.Stop();
                                i.lblkalan.Text = "";
                                i.progressBar1.CustomText = $"{Islemler.BoyutDuzenle(i.Indirilen)}/{Islemler.BoyutDuzenle(i.Boyut)} (%{100:N2})";
                                i.progressBar1.Value = 100;
                                i.btngoster.Enabled = true;
                                i.btnindir.Enabled = true;
                                i.btnkopyala.Enabled = true;
                            });
                            string a = "requestIds[]=" + i.Id;
                            ids = ids.Replace("&" + a, "").Replace(a + "&", "").Replace(a, "");
                            i.bitti = true;
                        }
                        if (i.Durum == "error")
                        {
                            string tekrar = Islemler.KaynakKoduAl($"https://offcloud.com/cloud/tryagain/{i.Id}", "GET", "", "", cook);
                            if (!tekrar.Contains("error"))
                                Invoke((MethodInvoker)delegate { Yenile(); });
                        }
                    }
                    Thread.Sleep(3000);
                }
                while (ids != "");
            }
            catch (ThreadAbortException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}