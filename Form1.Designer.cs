namespace offcloud
{
    partial class Form1
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

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnkayit = new System.Windows.Forms.Button();
            this.btnyenile = new System.Windows.Forms.Button();
            this.btnhesapsec = new System.Windows.Forms.Button();
            this.btngiris = new System.Windows.Forms.Button();
            this.txtsifre = new System.Windows.Forms.TextBox();
            this.txtmail = new System.Windows.Forms.TextBox();
            this.lblmesaj = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnekle = new System.Windows.Forms.Button();
            this.txtlink = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnproxy = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.TableLayoutPanel();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnkayit
            // 
            this.btnkayit.AutoSize = true;
            this.btnkayit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnkayit.BackColor = System.Drawing.Color.Gray;
            this.btnkayit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnkayit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnkayit.Location = new System.Drawing.Point(179, 55);
            this.btnkayit.Name = "btnkayit";
            this.btnkayit.Size = new System.Drawing.Size(74, 23);
            this.btnkayit.TabIndex = 3;
            this.btnkayit.Text = "Kayıt Ol";
            this.btnkayit.UseVisualStyleBackColor = false;
            this.btnkayit.Click += new System.EventHandler(this.btnkayit_Click);
            // 
            // btnyenile
            // 
            this.btnyenile.AutoSize = true;
            this.btnyenile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnyenile.BackColor = System.Drawing.Color.Gray;
            this.btnyenile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnyenile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnyenile.Location = new System.Drawing.Point(56, 55);
            this.btnyenile.Name = "btnyenile";
            this.btnyenile.Size = new System.Drawing.Size(50, 23);
            this.btnyenile.TabIndex = 5;
            this.btnyenile.Text = "Yenile";
            this.btnyenile.UseVisualStyleBackColor = false;
            this.btnyenile.Click += new System.EventHandler(this.btnyenile_Click);
            // 
            // btnhesapsec
            // 
            this.btnhesapsec.AutoSize = true;
            this.btnhesapsec.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnhesapsec.BackColor = System.Drawing.Color.Gray;
            this.btnhesapsec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnhesapsec.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnhesapsec.Location = new System.Drawing.Point(179, 3);
            this.btnhesapsec.Name = "btnhesapsec";
            this.tableLayoutPanel1.SetRowSpan(this.btnhesapsec, 2);
            this.btnhesapsec.Size = new System.Drawing.Size(74, 46);
            this.btnhesapsec.TabIndex = 4;
            this.btnhesapsec.Text = "Hesap Seç";
            this.btnhesapsec.UseVisualStyleBackColor = false;
            this.btnhesapsec.Click += new System.EventHandler(this.btnhesapsec_Click);
            // 
            // btngiris
            // 
            this.btngiris.AutoSize = true;
            this.btngiris.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btngiris.BackColor = System.Drawing.Color.Gray;
            this.btngiris.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btngiris.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btngiris.Location = new System.Drawing.Point(112, 55);
            this.btngiris.Name = "btngiris";
            this.btngiris.Size = new System.Drawing.Size(61, 23);
            this.btngiris.TabIndex = 2;
            this.btngiris.Text = "Giriş";
            this.btngiris.UseVisualStyleBackColor = false;
            this.btngiris.Click += new System.EventHandler(this.btngiris_Click);
            // 
            // txtsifre
            // 
            this.txtsifre.BackColor = System.Drawing.Color.Black;
            this.txtsifre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.txtsifre, 3);
            this.txtsifre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtsifre.ForeColor = System.Drawing.Color.White;
            this.txtsifre.Location = new System.Drawing.Point(3, 29);
            this.txtsifre.Name = "txtsifre";
            this.txtsifre.Size = new System.Drawing.Size(170, 20);
            this.txtsifre.TabIndex = 2;
            // 
            // txtmail
            // 
            this.txtmail.BackColor = System.Drawing.Color.Black;
            this.txtmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.txtmail, 3);
            this.txtmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtmail.ForeColor = System.Drawing.Color.White;
            this.txtmail.Location = new System.Drawing.Point(3, 3);
            this.txtmail.Name = "txtmail";
            this.txtmail.Size = new System.Drawing.Size(170, 20);
            this.txtmail.TabIndex = 1;
            // 
            // lblmesaj
            // 
            this.lblmesaj.AutoSize = true;
            this.lblmesaj.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.SetColumnSpan(this.lblmesaj, 5);
            this.lblmesaj.ForeColor = System.Drawing.Color.Green;
            this.lblmesaj.Location = new System.Drawing.Point(3, 84);
            this.lblmesaj.Margin = new System.Windows.Forms.Padding(3);
            this.lblmesaj.Name = "lblmesaj";
            this.lblmesaj.Size = new System.Drawing.Size(52, 13);
            this.lblmesaj.TabIndex = 3;
            this.lblmesaj.Text = "saffasfsaf";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 5);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 103);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(571, 323);
            this.flowLayoutPanel1.TabIndex = 4;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // btnekle
            // 
            this.btnekle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnekle.BackColor = System.Drawing.Color.Gray;
            this.btnekle.FlatAppearance.BorderSize = 0;
            this.btnekle.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnekle.ForeColor = System.Drawing.Color.White;
            this.btnekle.Location = new System.Drawing.Point(256, 3);
            this.btnekle.Name = "btnekle";
            this.btnekle.Size = new System.Drawing.Size(56, 70);
            this.btnekle.TabIndex = 5;
            this.btnekle.Text = "Ekle";
            this.btnekle.UseVisualStyleBackColor = false;
            this.btnekle.Click += new System.EventHandler(this.btnekle_Click);
            // 
            // txtlink
            // 
            this.txtlink.BackColor = System.Drawing.Color.Black;
            this.txtlink.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtlink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtlink.ForeColor = System.Drawing.Color.White;
            this.txtlink.Location = new System.Drawing.Point(3, 3);
            this.txtlink.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.txtlink.Multiline = true;
            this.txtlink.Name = "txtlink";
            this.txtlink.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtlink.Size = new System.Drawing.Size(247, 70);
            this.txtlink.TabIndex = 0;
            this.txtlink.Text = resources.GetString("txtlink.Text");
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Black;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 429);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(577, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(0, 17);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnproxy, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnyenile, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblmesaj, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtmail, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtsifre, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnkayit, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnhesapsec, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btngiris, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(577, 429);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnproxy
            // 
            this.btnproxy.AutoSize = true;
            this.btnproxy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnproxy.BackColor = System.Drawing.Color.Gray;
            this.btnproxy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnproxy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnproxy.Location = new System.Drawing.Point(3, 55);
            this.btnproxy.Name = "btnproxy";
            this.btnproxy.Size = new System.Drawing.Size(47, 23);
            this.btnproxy.TabIndex = 0;
            this.btnproxy.Text = "Proxy";
            this.btnproxy.UseVisualStyleBackColor = false;
            this.btnproxy.Click += new System.EventHandler(this.btnproxy_Click);
            // 
            // panel3
            // 
            this.panel3.ColumnCount = 2;
            this.panel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panel3.Controls.Add(this.btnekle, 1, 0);
            this.panel3.Controls.Add(this.txtlink, 0, 0);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(259, 3);
            this.panel3.Name = "panel3";
            this.panel3.RowCount = 1;
            this.tableLayoutPanel1.SetRowSpan(this.panel3, 3);
            this.panel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panel3.Size = new System.Drawing.Size(315, 75);
            this.panel3.TabIndex = 2;
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            this.backgroundWorker3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker3_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(577, 451);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "offcloud";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnkayit;
        private System.Windows.Forms.Button btngiris;
        private System.Windows.Forms.TextBox txtsifre;
        private System.Windows.Forms.TextBox txtmail;
        private System.Windows.Forms.Button btnhesapsec;
        private System.Windows.Forms.Button btnekle;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblmesaj;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Button btnyenile;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel panel3;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.Button btnproxy;
        public System.Windows.Forms.TextBox txtlink;
    }
}

