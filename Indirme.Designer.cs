namespace offcloud
{
    partial class Indirme
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblad = new System.Windows.Forms.Label();
            this.lbldurum = new System.Windows.Forms.Label();
            this.btngoster = new System.Windows.Forms.Button();
            this.lblhiz = new System.Windows.Forms.Label();
            this.lblkalan = new System.Windows.Forms.Label();
            this.btntekrar = new System.Windows.Forms.Button();
            this.btniptal = new System.Windows.Forms.Button();
            this.btnsil = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnindir = new System.Windows.Forms.Button();
            this.btnkopyala = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblmagnet = new System.Windows.Forms.LinkLabel();
            this.progressBar1 = new offcloud.TextProgressBar();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblad
            // 
            this.lblad.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblad, 7);
            this.lblad.ForeColor = System.Drawing.Color.White;
            this.lblad.Location = new System.Drawing.Point(3, 3);
            this.lblad.Margin = new System.Windows.Forms.Padding(3);
            this.lblad.MaximumSize = new System.Drawing.Size(542, 0);
            this.lblad.Name = "lblad";
            this.lblad.Size = new System.Drawing.Size(35, 13);
            this.lblad.TabIndex = 0;
            this.lblad.Text = "label1";
            // 
            // lbldurum
            // 
            this.lbldurum.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lbldurum, 7);
            this.lbldurum.ForeColor = System.Drawing.Color.White;
            this.lbldurum.Location = new System.Drawing.Point(3, 19);
            this.lbldurum.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lbldurum.MaximumSize = new System.Drawing.Size(542, 0);
            this.lbldurum.Name = "lbldurum";
            this.lbldurum.Size = new System.Drawing.Size(35, 13);
            this.lbldurum.TabIndex = 1;
            this.lbldurum.Text = "label2";
            // 
            // btngoster
            // 
            this.btngoster.AutoSize = true;
            this.btngoster.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btngoster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btngoster.Enabled = false;
            this.btngoster.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btngoster.Location = new System.Drawing.Point(229, 90);
            this.btngoster.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btngoster.Name = "btngoster";
            this.btngoster.Size = new System.Drawing.Size(47, 22);
            this.btngoster.TabIndex = 3;
            this.btngoster.Text = "İçerik";
            this.btngoster.UseVisualStyleBackColor = true;
            this.btngoster.Click += new System.EventHandler(this.btngoster_Click);
            // 
            // lblhiz
            // 
            this.lblhiz.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblhiz, 7);
            this.lblhiz.ForeColor = System.Drawing.Color.White;
            this.lblhiz.Location = new System.Drawing.Point(3, 35);
            this.lblhiz.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblhiz.MaximumSize = new System.Drawing.Size(542, 0);
            this.lblhiz.Name = "lblhiz";
            this.lblhiz.Size = new System.Drawing.Size(35, 13);
            this.lblhiz.TabIndex = 4;
            this.lblhiz.Text = "label4";
            // 
            // lblkalan
            // 
            this.lblkalan.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblkalan, 7);
            this.lblkalan.ForeColor = System.Drawing.Color.White;
            this.lblkalan.Location = new System.Drawing.Point(3, 51);
            this.lblkalan.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblkalan.MaximumSize = new System.Drawing.Size(542, 0);
            this.lblkalan.Name = "lblkalan";
            this.lblkalan.Size = new System.Drawing.Size(35, 13);
            this.lblkalan.TabIndex = 5;
            this.lblkalan.Text = "label4";
            // 
            // btntekrar
            // 
            this.btntekrar.AutoSize = true;
            this.btntekrar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btntekrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btntekrar.Enabled = false;
            this.btntekrar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btntekrar.Location = new System.Drawing.Point(385, 90);
            this.btntekrar.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btntekrar.Name = "btntekrar";
            this.btntekrar.Size = new System.Drawing.Size(81, 22);
            this.btntekrar.TabIndex = 6;
            this.btntekrar.Text = "Tekrar Dene";
            this.btntekrar.UseVisualStyleBackColor = true;
            this.btntekrar.Click += new System.EventHandler(this.btntekrar_Click);
            // 
            // btniptal
            // 
            this.btniptal.AutoSize = true;
            this.btniptal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btniptal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btniptal.Enabled = false;
            this.btniptal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btniptal.Location = new System.Drawing.Point(504, 90);
            this.btniptal.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btniptal.Name = "btniptal";
            this.btniptal.Size = new System.Drawing.Size(41, 22);
            this.btniptal.TabIndex = 7;
            this.btniptal.Text = "İptal";
            this.btniptal.UseVisualStyleBackColor = true;
            this.btniptal.Click += new System.EventHandler(this.btniptal_Click);
            // 
            // btnsil
            // 
            this.btnsil.AutoSize = true;
            this.btnsil.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnsil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnsil.Enabled = false;
            this.btnsil.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnsil.Location = new System.Drawing.Point(469, 90);
            this.btnsil.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnsil.Name = "btnsil";
            this.btnsil.Size = new System.Drawing.Size(32, 22);
            this.btnsil.TabIndex = 8;
            this.btnsil.Text = "Sil";
            this.btnsil.UseVisualStyleBackColor = true;
            this.btnsil.Click += new System.EventHandler(this.btnsil_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnindir
            // 
            this.btnindir.AutoSize = true;
            this.btnindir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnindir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnindir.Enabled = false;
            this.btnindir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnindir.Location = new System.Drawing.Point(279, 90);
            this.btnindir.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnindir.Name = "btnindir";
            this.btnindir.Size = new System.Drawing.Size(41, 22);
            this.btnindir.TabIndex = 10;
            this.btnindir.Text = "İndir";
            this.btnindir.UseVisualStyleBackColor = true;
            this.btnindir.Click += new System.EventHandler(this.btnindir_Click);
            // 
            // btnkopyala
            // 
            this.btnkopyala.AutoSize = true;
            this.btnkopyala.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnkopyala.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnkopyala.Enabled = false;
            this.btnkopyala.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnkopyala.Location = new System.Drawing.Point(323, 90);
            this.btnkopyala.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnkopyala.Name = "btnkopyala";
            this.btnkopyala.Size = new System.Drawing.Size(59, 22);
            this.btnkopyala.TabIndex = 12;
            this.btnkopyala.Text = "Kopyala";
            this.btnkopyala.UseVisualStyleBackColor = true;
            this.btnkopyala.Click += new System.EventHandler(this.btnkopyala_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.progressBar1, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblkalan, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btngoster, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblhiz, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnindir, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbldurum, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnkopyala, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblad, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btntekrar, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnsil, 5, 5);
            this.tableLayoutPanel1.Controls.Add(this.btniptal, 6, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblmagnet, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(548, 115);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // lblmagnet
            // 
            this.lblmagnet.ActiveLinkColor = System.Drawing.Color.DodgerBlue;
            this.lblmagnet.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblmagnet, 7);
            this.lblmagnet.ForeColor = System.Drawing.Color.White;
            this.lblmagnet.LinkArea = new System.Windows.Forms.LinkArea(0, 20);
            this.lblmagnet.LinkColor = System.Drawing.Color.White;
            this.lblmagnet.Location = new System.Drawing.Point(3, 67);
            this.lblmagnet.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblmagnet.MaximumSize = new System.Drawing.Size(542, 0);
            this.lblmagnet.Name = "lblmagnet";
            this.lblmagnet.Size = new System.Drawing.Size(54, 17);
            this.lblmagnet.TabIndex = 13;
            this.lblmagnet.TabStop = true;
            this.lblmagnet.Text = "linkLabel1";
            this.lblmagnet.UseCompatibleTextRendering = true;
            this.lblmagnet.VisitedLinkColor = System.Drawing.Color.Orange;
            this.lblmagnet.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblmagnet_LinkClicked);
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.AliceBlue;
            this.progressBar1.CustomText = "";
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(3, 90);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.ProgressColor = System.Drawing.Color.LimeGreen;
            this.progressBar1.Size = new System.Drawing.Size(223, 22);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 11;
            this.progressBar1.TextColor = System.Drawing.Color.Black;
            this.progressBar1.TextFont = new System.Drawing.Font("Leelawadee UI", 9F, System.Drawing.FontStyle.Bold);
            this.progressBar1.VisualMode = offcloud.ProgressBarDisplayMode.CustomText;
            // 
            // Indirme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.Name = "Indirme";
            this.Size = new System.Drawing.Size(548, 115);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label lblad;
        public System.Windows.Forms.Label lbldurum;
        public System.Windows.Forms.Button btngoster;
        public System.Windows.Forms.Label lblhiz;
        public System.Windows.Forms.Button btntekrar;
        public System.Windows.Forms.Button btniptal;
        public System.Windows.Forms.Button btnsil;
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label lblkalan;
        public System.Windows.Forms.Button btnindir;
        public TextProgressBar progressBar1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btnkopyala;
        private System.Windows.Forms.LinkLabel lblmagnet;
    }
}
