using gunlukAjanda_NotDefteri.Nesneler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gunlukAjanda_NotDefteri.Arayuzler
{
    
    public partial class girisEkrani : Form
    {
        public girisEkrani()
        {
            InitializeComponent();
        }


        Kullanici kul = new Kullanici();
        vtBaglanti baglanti = new vtBaglanti();
        string sqlsorgu;
        public static string girisKulID; // anasayfaya gidince o veriyi tutması için tanımladık.

        private void girisEkrani_Load(object sender, EventArgs e)
        {

        }

        public void girisEkraniBilgi()
        {            
            kul.kullaniciAdi = txtGirisKulAdi.Text;
            kul.sifre = txtGirisSifre.Text;
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            girisEkraniBilgi();
            if (txtGirisKulAdi.Text != "" && txtGirisSifre.Text != "")
            {
                sqlsorgu = "select * from KULLANICI where kullaniciadi='" + kul.kullaniciAdi + "' and sifre='" + kul.sifre + "'";
                Boolean deger = baglanti.GirisKontrol(sqlsorgu);
                if (deger == true)
                {
                    //kullanıcı tipini belirliyoruz ona göre kullanıcı ekranı veya yönetici ekranı açılacak.
                    sqlsorgu = "Select b.kullanıcıturu From KULLANICI k " +
                    "INNER JOIN KISIBILGI b ON k.kisiBilgiID = b.kisiBilgiID " +
                    "where k.kullaniciid = (select kullaniciid from KULLANICI where kullaniciadi='" + kul.kullaniciAdi + "' and sifre='" + kul.sifre + "')";
                    byte kullanicituru = byte.Parse(baglanti.verigetir(sqlsorgu));
                    
                    //MessageBox.Show("kişinin turu =" + kullanicituru);
                    if (kullanicituru == 1)//kullanıcı türü 1 ise yönetici oluyor o yüzden yönetici sayfasını açıyoruz.
                    {
                        this.Close();
                        yoneticiSayfasi y = new yoneticiSayfasi();
                        y.Show();
                    }
                    else if (kullanicituru == 2)//kullanıcı türü 2 ise normal kullanıcı oluyor o yüzden kullanıcı sayfasını açıyoruz.
                    {
                        /* hangi kullanıcı giriş yapmış onu buluyoruz ve Kullanici sınıfındaki değişkeni atıyoruz
                        bu sayede her seferinde sqlsorgusu yazmak yerine değişkenin değerini kullanıcaz.*/
                        sqlsorgu = "select kullaniciid from KULLANICI where kullaniciadi='" + kul.kullaniciAdi + "' and sifre='" + kul.sifre + "'";
                        girisKulID = baglanti.verigetir(sqlsorgu).ToString();
                        //MessageBox.Show("kişinin idsi =" + girisKulID);
                        this.Close();
                        anasayfa a = new anasayfa();
                        a.Show();
                    }
                    else
                    {
                        MessageBox.Show("YETKİSİZ GİRİŞ DENENDİ\n\nUYGULAMA KAPATILIYOR...");
                        this.Close();
                    }
                }    
            }
            else
            {
                MessageBox.Show("KULLANICI ADI  veya ŞİFRE BOŞ OLAMAZ!");
            }
        }

        private void btnYeniHesap_Click(object sender, EventArgs e)
        {
            this.Hide();
            yeniHesapArayuz hesapOlustur = new yeniHesapArayuz();
            hesapOlustur.Show();
        }

        
    }
}
