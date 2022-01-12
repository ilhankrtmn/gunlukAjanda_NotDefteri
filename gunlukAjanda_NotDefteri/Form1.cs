using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace gunlukAjanda_NotDefteri
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Arayuzler.girisEkrani aaa = new Arayuzler.girisEkrani();
            Arayuzler.yeniHesapArayuz b = new Arayuzler.yeniHesapArayuz();
            Arayuzler.anasayfa c = new Arayuzler.anasayfa();
            Arayuzler.yoneticiSayfasi d = new Arayuzler.yoneticiSayfasi();
            aaa.Show();
            //b.Show();
            //c.Show();
            //d.Show();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }
    }
}
