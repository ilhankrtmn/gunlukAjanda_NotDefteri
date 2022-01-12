
namespace gunlukAjanda_NotDefteri.Arayuzler
{
    partial class NotDefteriOlustur
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
            this.btnKaydet = new System.Windows.Forms.Button();
            this.txtDefterAdi = new System.Windows.Forms.TextBox();
            this.btnNotDefteriSil = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Defter adını giriniz:";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(29, 114);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(192, 73);
            this.btnKaydet.TabIndex = 1;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtDefterAdi
            // 
            this.txtDefterAdi.Location = new System.Drawing.Point(194, 48);
            this.txtDefterAdi.Name = "txtDefterAdi";
            this.txtDefterAdi.Size = new System.Drawing.Size(237, 30);
            this.txtDefterAdi.TabIndex = 2;
            // 
            // btnNotDefteriSil
            // 
            this.btnNotDefteriSil.Location = new System.Drawing.Point(239, 114);
            this.btnNotDefteriSil.Name = "btnNotDefteriSil";
            this.btnNotDefteriSil.Size = new System.Drawing.Size(192, 73);
            this.btnNotDefteriSil.TabIndex = 3;
            this.btnNotDefteriSil.Text = "Sil";
            this.btnNotDefteriSil.UseVisualStyleBackColor = true;
            // 
            // NotDefteriOlustur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 229);
            this.Controls.Add(this.btnNotDefteriSil);
            this.Controls.Add(this.txtDefterAdi);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "NotDefteriOlustur";
            this.Text = "NotDefteriOlustur";
            this.Load += new System.EventHandler(this.NotDefteriOlustur_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.TextBox txtDefterAdi;
        private System.Windows.Forms.Button btnNotDefteriSil;
    }
}