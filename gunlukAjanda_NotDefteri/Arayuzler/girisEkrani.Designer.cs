
namespace gunlukAjanda_NotDefteri.Arayuzler
{
    partial class girisEkrani
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGirisKulAdi = new System.Windows.Forms.TextBox();
            this.txtGirisSifre = new System.Windows.Forms.TextBox();
            this.btnGirisYap = new System.Windows.Forms.Button();
            this.btnYeniHesap = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kullanıcı adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Şifre:";
            // 
            // txtGirisKulAdi
            // 
            this.txtGirisKulAdi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtGirisKulAdi.Location = new System.Drawing.Point(168, 79);
            this.txtGirisKulAdi.Margin = new System.Windows.Forms.Padding(4);
            this.txtGirisKulAdi.Name = "txtGirisKulAdi";
            this.txtGirisKulAdi.Size = new System.Drawing.Size(172, 30);
            this.txtGirisKulAdi.TabIndex = 2;
            // 
            // txtGirisSifre
            // 
            this.txtGirisSifre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtGirisSifre.Location = new System.Drawing.Point(168, 126);
            this.txtGirisSifre.Margin = new System.Windows.Forms.Padding(4);
            this.txtGirisSifre.Name = "txtGirisSifre";
            this.txtGirisSifre.Size = new System.Drawing.Size(172, 30);
            this.txtGirisSifre.TabIndex = 3;
            // 
            // btnGirisYap
            // 
            this.btnGirisYap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnGirisYap.Location = new System.Drawing.Point(58, 188);
            this.btnGirisYap.Margin = new System.Windows.Forms.Padding(4);
            this.btnGirisYap.Name = "btnGirisYap";
            this.btnGirisYap.Size = new System.Drawing.Size(250, 60);
            this.btnGirisYap.TabIndex = 4;
            this.btnGirisYap.Text = "Giriş Yap";
            this.btnGirisYap.UseVisualStyleBackColor = false;
            this.btnGirisYap.Click += new System.EventHandler(this.btnGirisYap_Click);
            // 
            // btnYeniHesap
            // 
            this.btnYeniHesap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnYeniHesap.Location = new System.Drawing.Point(58, 270);
            this.btnYeniHesap.Margin = new System.Windows.Forms.Padding(4);
            this.btnYeniHesap.Name = "btnYeniHesap";
            this.btnYeniHesap.Size = new System.Drawing.Size(250, 60);
            this.btnYeniHesap.TabIndex = 5;
            this.btnYeniHesap.Text = "Yeni Hesap Oluştur";
            this.btnYeniHesap.UseVisualStyleBackColor = false;
            this.btnYeniHesap.Click += new System.EventHandler(this.btnYeniHesap_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ajandanıza Hoşgeldiniz...";
            // 
            // girisEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(378, 356);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnYeniHesap);
            this.Controls.Add(this.btnGirisYap);
            this.Controls.Add(this.txtGirisSifre);
            this.Controls.Add(this.txtGirisKulAdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "girisEkrani";
            this.Text = "Giriş Ekranı";
            this.Load += new System.EventHandler(this.girisEkrani_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGirisKulAdi;
        private System.Windows.Forms.TextBox txtGirisSifre;
        private System.Windows.Forms.Button btnGirisYap;
        private System.Windows.Forms.Button btnYeniHesap;
        private System.Windows.Forms.Label label3;
    }
}