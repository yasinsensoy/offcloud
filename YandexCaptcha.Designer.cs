namespace offcloud
{
    partial class YandexCaptcha
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnyenile = new System.Windows.Forms.Button();
            this.resim = new System.Windows.Forms.PictureBox();
            this.btnonay = new System.Windows.Forms.Button();
            this.txtcaptcha = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.resim)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnyenile
            // 
            this.btnyenile.AutoSize = true;
            this.btnyenile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnyenile.Location = new System.Drawing.Point(3, 59);
            this.btnyenile.Name = "btnyenile";
            this.btnyenile.Size = new System.Drawing.Size(46, 23);
            this.btnyenile.TabIndex = 0;
            this.btnyenile.Text = "Yenile";
            this.btnyenile.UseVisualStyleBackColor = true;
            this.btnyenile.Click += new System.EventHandler(this.btnyenile_Click);
            // 
            // resim
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.resim, 3);
            this.resim.Location = new System.Drawing.Point(3, 3);
            this.resim.Name = "resim";
            this.resim.Size = new System.Drawing.Size(167, 50);
            this.resim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.resim.TabIndex = 1;
            this.resim.TabStop = false;
            // 
            // btnonay
            // 
            this.btnonay.AutoSize = true;
            this.btnonay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnonay.Enabled = false;
            this.btnonay.Location = new System.Drawing.Point(120, 59);
            this.btnonay.Name = "btnonay";
            this.btnonay.Size = new System.Drawing.Size(50, 23);
            this.btnonay.TabIndex = 2;
            this.btnonay.Text = "Onayla";
            this.btnonay.UseVisualStyleBackColor = true;
            this.btnonay.Click += new System.EventHandler(this.btnonay_Click);
            // 
            // txtcaptcha
            // 
            this.txtcaptcha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtcaptcha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtcaptcha.Location = new System.Drawing.Point(55, 59);
            this.txtcaptcha.Name = "txtcaptcha";
            this.txtcaptcha.Size = new System.Drawing.Size(59, 23);
            this.txtcaptcha.TabIndex = 0;
            this.txtcaptcha.TextChanged += new System.EventHandler(this.txtcaptcha_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.resim, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnonay, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtcaptcha, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnyenile, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(173, 85);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // YandexCaptcha
            // 
            this.AcceptButton = this.btnonay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(293, 158);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "YandexCaptcha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Captcha";
            this.Load += new System.EventHandler(this.Captcha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resim)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnyenile;
        private System.Windows.Forms.Button btnonay;
        private System.Windows.Forms.TextBox txtcaptcha;
        public System.Windows.Forms.PictureBox resim;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}