using gunlukAjanda_NotDefteri.Nesneler;
using Oracle.ManagedDataAccess.Client;
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
    public partial class yeniHesapArayuz : Form
    {
        public yeniHesapArayuz()
        {
            InitializeComponent();
        }
        private void yeniHesapArayuz_Load(object sender, EventArgs e)
        {
            cmbCinsiyet.Items.AddRange(cinsiyetdizi);
        }

        String[] cinsiyetdizi = { "Erkek", "Kadın", "Diğer" };
        //değişken tutma burada olmuyor
        int a = 1;
        Kullanici kul = new Kullanici();
        vtBaglanti baglanti = new vtBaglanti();
        girisEkrani giris = new girisEkrani();
        string sqlsorgu,sqlsorgu1;

        public void yeniKayitBilgi()
        {
            kul.ad = txtAd.Text;
            kul.soyad = txtSoyad.Text;
            kul.kullaniciAdi = txtKulAdi.Text;
            kul.sifre = txtSifre.Text;
            kul.cinsiyet = cmbCinsiyet.Text;
            kul.dogumTarihi = dateDogumTarihi.Text;
            kul.ePosta = txtEposta.Text;
            kul.telNo = txtTelNo.Text;
        }
        // kullanciadı aynı olamaz o yüzden onu kkontrol etmeliyiz.

        private void btnKaydol_Click(object sender, EventArgs e)
        {
            yeniKayitBilgi();
            // BU KISIMDA GİRİLEN DEĞERLER BOŞ MU DOLU MU KONTROL ET.
            if (kul.ad != "" && kul.soyad != "" && kul.kullaniciAdi != "" && kul.sifre != "" && kul.cinsiyet != "" && kul.dogumTarihi != "" && kul.ePosta != "" && kul.telNo != "")
            {
                // aynı kullanıcı adı ve e posta olamaz onu kontrol ediyoruz.
                sqlsorgu = "select * from kullanici where kullaniciadi='" + kul.kullaniciAdi + "'";
                bool kontrol = baglanti.KayitVarmi(sqlsorgu);
                if (kontrol == true)
                {
                    sqlsorgu = "select * from kisibilgi where ePosta='" + kul.ePosta + "'";
                    bool kontrol2 = baglanti.KayitVarmi(sqlsorgu);
                    if (kontrol2 == true)
                    {
                        sqlsorgu = "select * from kisibilgi where telefon='" + kul.telNo + "'";
                        bool kontrol3 = baglanti.KayitVarmi(sqlsorgu);
                        if (kontrol3 == true)
                        {


                            int id = baglanti.idDondur("KISIBILGI","kisibilgiid", new List<(string, string, OracleDbType)> {
                                                                                         ("ad",kul.ad , OracleDbType.Varchar2),
                                                                                         ("soyad", kul.soyad, OracleDbType.Varchar2),
                                                                                         ("cinsiyet", kul.cinsiyet, OracleDbType.Varchar2),
                                                                                         ("dogumTarihi", kul.dogumTarihi, OracleDbType.Varchar2),
                                                                                         ("ePosta", kul.ePosta, OracleDbType.Varchar2),
                                                                                         ("telefon", kul.telNo, OracleDbType.Varchar2),
                                                                                         ("kullaniciTuru", "2", OracleDbType.Int16)});

                            int id2 = baglanti.idDondur("KULLANICI", "kullaniciid", new List<(string, string, OracleDbType)> {
                                                                                         ("kullaniciAdi",kul.kullaniciAdi , OracleDbType.Varchar2),
                                                                                         ("sifre", kul.sifre, OracleDbType.Varchar2),
                                                                                         ("kisiBilgiID", id.ToString(), OracleDbType.Int16)});


                            sqlsorgu = "Insert into Rapor (kullaniciid,ajandasayisi,notsayisi,gunluksayisi,arkadassayisi) " + "values(" + id2 + "," + 0 + "," + 0 + "," + 0 + "," + 0 + ")";
                            baglanti.veriEkle(sqlsorgu);
                            this.Hide(); // kayıt ekranı kapatıp giriş ekranına dönüyor
                            giris.Show();
                        }
                        else
                        {
                            MessageBox.Show("Telefon numarası daha önce kullanılmış.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Eposta daha önce kullanılmış.");
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı daha önce kullanılmış.");
                }
            }
            else
            {
                MessageBox.Show("BOŞ DEĞER OLAMAZ!");
            }
        }
    }
}







/*
 *if (kul.ad != "" && kul.soyad != "" && kul.kullaniciAdi != "" && kul.sifre != "" && kul.cinsiyet != "" && kul.dogumTarihi != "" && kul.ePosta != "" && kul.telNo != "")
            {
                // aynı kullanıcı adı ve e posta olamaz onu kontrol ediyoruz.
                sqlsorgu = "select * from kullanici where kullaniciadi='" + kul.kullaniciAdi + "'";
                bool kontrol = baglanti.KayitVarmi(sqlsorgu);
                if (kontrol == true)
                {
                    sqlsorgu = "select * from kisibilgi where ePosta='" + kul.ePosta + "'";
                    bool kontrol2 = baglanti.KayitVarmi(sqlsorgu);
                    if (kontrol2 == true)
                    {
                        sqlsorgu = "select * from kisibilgi where telefon='" + kul.telNo + "'";
                        bool kontrol3 = baglanti.KayitVarmi(sqlsorgu);
                        if (kontrol3 == true)
                        {
                            sqlsorgu1 = "Insert Into KISIBILGI (ad,soyad,cinsiyet,dogumTarihi,ePosta,telefon,kullaniciTuru) " +
                            "values('" + kul.ad + "','" + kul.soyad + "','" + kul.cinsiyet + "','" + kul.dogumTarihi + "','" + kul.ePosta + "','" + kul.telNo + "'," + 2 + ")";
                            sqlsorgu2 = "Insert Into KULLANICI (kullaniciAdi,sifre,kisiBilgiID) " +
                            "values('" + kul.kullaniciAdi + "','" + kul.sifre + "'," + a++ + ")";//buradaki a++ değeri olmuyor.  
                            baglanti.veriEkle(sqlsorgu1);
                            baglanti.veriEkle(sqlsorgu2);
                            this.Hide(); // kayıt ekranı kapatıp giriş ekranına dönüyor
                            giris.Show();
                        }
                        else
                        {
                            MessageBox.Show("Telefon numarası daha önce kullanılmış.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Eposta daha önce kullanılmış.");
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı daha önce kullanılmış.");
                }



            }
            else
            {
                MessageBox.Show("BOŞ DEĞER OLAMAZ!");
            } 
 * */
