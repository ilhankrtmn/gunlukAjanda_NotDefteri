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
    public partial class anasayfa : Form
    {  
        public anasayfa()
        {
            InitializeComponent();
            tabControlAltMenu.DrawItem += new DrawItemEventHandler(cntAltMenu_DrawItem);
        }
        
        private void anasayfa_Load(object sender, EventArgs e)
        {
            viewArayuzYapılcaklar.Columns.Add("içerik",300);

            viewAjanda.Columns.Add("Tarih",150);
            viewAjanda.Columns.Add("Saat",75);
            viewAjanda.Columns.Add("Dakika",75);
            viewAjanda.Columns.Add("İçerik",450);

            viewNotlar.Columns.Add("Not Defteri", 130);
            viewNotlar.Columns.Add("Not Başlığı", 150);

            viewGunluk.Columns.Add("Günlük Başlığı",275);

            viewKisi.Columns.Add("Ad",80);
            viewKisi.Columns.Add("Soyad",80);
            viewKisi.Columns.Add("Cinsiyet", 75);
            viewKisi.Columns.Add("Doğum Tarihi",140);
            viewKisi.Columns.Add("E Posta",200);
            viewKisi.Columns.Add("Telefon Numarası",140);

            cmbAjandaSaat.Items.AddRange(saatDizi);
            cmbAjandaDakika.Items.AddRange(dakikaDizi);
            cmbKisiCinsiyet.Items.AddRange(cinsiyetdizi);

            lblAd.Text = baglanti.verigetir("select ad from hakkinda");
            lblYapimci.Text = baglanti.verigetir("select yapimci from hakkinda");
            lblSurumu.Text = baglanti.verigetir("select versiyon from hakkinda");
            lblHaklar.Text = baglanti.verigetir("select haklar from hakkinda");
        }
        private void cntAltMenu_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabControlAltMenu.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControlAltMenu.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Black);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Calibri", 13.0f, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        
        String[] saatDizi = {"00","01","02","03","04","05","06","07","08","09","10","11",
            "12","13","14","15","16","17","18","19","20","21","22","23"};
        String[] dakikaDizi = {"00","01","02","03","04","05","06","07","08","09","10","11",
            "12","13","14","15","16","17","18","19","20","21","22","23","24","25","26","27",
            "28","29","30","31","32","33","34","35","36","37","38","39","40","41","42","43",
            "44","45","46","47","48","49","50","51","52","53","54","55","56","57","58","59"};
        String[] cinsiyetdizi = { "Erkek", "Kadın", "Diğer" };
        String sqlsorgu,sqlsorgu1;
        int id;

        Ajanda ajanda = new Ajanda();
        Arkadas arkadas = new Arkadas();
        Kullanici kul = new Kullanici();
        Gunluk gnlk = new Gunluk();
        Not not = new Not();
        girisEkrani g = new girisEkrani();
        vtBaglanti baglanti = new vtBaglanti();
        Mesaj msj = new Mesaj();

        //BİLGİLER
        public void AjandaBilgi()
        {
            ajanda.tarih = dateAjandaTarihi.Text;
            ajanda.saat = cmbAjandaSaat.Text;
            ajanda.dakika = cmbAjandaDakika.Text;
            ajanda.icerik = txtAjandaIcerik.Text;
            if (chcYapilacak.Checked==true)
            {
                ajanda.yapilacak = 1;   // seçiliyse ajanda.yapilacak 1 seçili değilse 2
            }
            else
            {
                ajanda.yapilacak = 2;
            }
            
        }
        public void NotDefteriBilgi()
        {
            not.defterAdi = cmbNotDefteri.Text;
            not.tarih = dateNotTarihi.Text;
            not.baslik = txtNotBasligi.Text;
            not.icerik = txtNotIcerik.Text;
        }
        public void GunlukBilgi()
        {
            gnlk.tarih = dateGunlukTarihi.Text;
            gnlk.baslik = txtGunlukBaslik.Text;
            gnlk.icerik = txtGunlukIcerik.Text;
        }
        public void ArkadasBilgi()
        {
            arkadas.ad = txtKisiAd.Text;
            arkadas.soyad = txtKisiSoyad.Text;
            arkadas.dogumTarihi = dateKisiDogumTarihi.Text;
            arkadas.ePosta = txtKisiEposta.Text;
            arkadas.telNo = txtKisiTelNo.Text;
            arkadas.cinsiyet = cmbKisiCinsiyet.Text;   
        }

        public void MesajBilgi()
        {
            msj.baslik = txtMesajBasligi.Text;
            msj.icerik = txtMesajIcerik.Text;
        }

        public void verileriNesnedeGöster(ListView liste, string listeadi)
        {
            if (liste.SelectedItems.Count > 0)
            {
                if (listeadi == "ajanda2")
                {
                    txtAjandaIcerik.Text = liste.SelectedItems[0].SubItems[3].Text;
                    
                }
                if (listeadi == "ajanda")
                {
                    dateAjandaTarihi.Text = liste.SelectedItems[0].SubItems[0].Text;
                    cmbAjandaSaat.Text = liste.SelectedItems[0].SubItems[1].Text;
                    cmbAjandaDakika.Text = liste.SelectedItems[0].SubItems[2].Text;
                    txtAjandaIcerik.Text = liste.SelectedItems[0].SubItems[3].Text;
                    int a = int.Parse(liste.SelectedItems[0].SubItems[4].Text);
                    if (a==1)//1 ise yapılacak
                    {
                        chcYapilacak.Checked = true;
                    }
                    else
                    {
                        chcYapilacak.Checked = false;
                    }
                    ajanda.id = int.Parse(liste.SelectedItems[0].SubItems[5].Text);
                }

                if (listeadi == "notdefteri")
                {
                    cmbNotDefteri.Text = liste.SelectedItems[0].SubItems[0].Text;           
                    txtNotBasligi.Text = liste.SelectedItems[0].SubItems[1].Text;            
                    txtNotIcerik.Text = liste.SelectedItems[0].SubItems[2].Text;
                    dateNotTarihi.Text = liste.SelectedItems[0].SubItems[3].Text;
                    not.id= int.Parse(liste.SelectedItems[0].SubItems[4].Text);
                    not.veriid = int.Parse(liste.SelectedItems[0].SubItems[5].Text);
                }

                if (listeadi == "gunluk")
                {                    
                    txtGunlukBaslik.Text = liste.SelectedItems[0].SubItems[0].Text;
                    txtGunlukIcerik.Text = liste.SelectedItems[0].SubItems[1].Text;
                    dateGunlukTarihi.Text = liste.SelectedItems[0].SubItems[2].Text;
                    gnlk.id = int.Parse(liste.SelectedItems[0].SubItems[3].Text);
                    gnlk.veriid = int.Parse(liste.SelectedItems[0].SubItems[4].Text);
                }

                if (listeadi == "arkadas")
                {
                    txtKisiAd.Text = liste.SelectedItems[0].SubItems[0].Text;
                    txtKisiSoyad.Text = liste.SelectedItems[0].SubItems[1].Text;
                    cmbKisiCinsiyet.Text = liste.SelectedItems[0].SubItems[2].Text;
                    dateKisiDogumTarihi.Text = liste.SelectedItems[0].SubItems[3].Text;
                    txtKisiEposta.Text = liste.SelectedItems[0].SubItems[4].Text;
                    txtKisiTelNo.Text = liste.SelectedItems[0].SubItems[5].Text;
                    arkadas.id = int.Parse(liste.SelectedItems[0].SubItems[6].Text);
                    kul.kisiBilgiid = int.Parse(liste.SelectedItems[0].SubItems[7].Text);
                }
            }
        }
        


        private void viewAjanda_SelectedIndexChanged(object sender, EventArgs e)
        {
            verileriNesnedeGöster(viewAjanda, "ajanda");
        }
        private void viewGunluk_SelectedIndexChanged(object sender, EventArgs e)
        {
            verileriNesnedeGöster(viewGunluk, "gunluk");
        }
        private void viewNotlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            verileriNesnedeGöster(viewNotlar, "notdefteri");
        }
        private void viewKisi_SelectedIndexChanged(object sender, EventArgs e)
        {
            verileriNesnedeGöster(viewKisi, "arkadas");
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////ANASAYFA
        private void calendarArayuzTarihi_DateChanged(object sender, DateRangeEventArgs e)
        {
            string tarih = calendarArayuzTarihi.SelectionEnd.ToString();
            MessageBox.Show(tarih);
            sqlsorgu = "select a.ajandaıd,a.tarıh,a.saat,a.dakika,a.icerik,a.yapilacak From ajanda a " +
                 "INNER JOIN KULLANICI k ON k.kullaniciID = a.kullaniciID " +
                 "WHERE k.kullanıcııd = '" + girisEkrani.girisKulID + "' and a.yapilacak=1 and a.tarih='" + tarih + "'";
            baglanti.verileriGoruntule(viewArayuzYapılcaklar, "ajanda2", sqlsorgu);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////AJANDA
        private void btnAjandaListele_Click(object sender, EventArgs e)
        {
            sqlsorgu = "select a.ajandaıd,a.tarıh,a.saat,a.dakika,a.icerik,a.yapilacak From ajanda a " +
                 "INNER JOIN KULLANICI k ON k.kullaniciID = a.kullaniciID " +
                 "WHERE k.kullanıcııd = '"+ girisEkrani.girisKulID + "'";           
            baglanti.verileriGoruntule(viewAjanda, "ajanda", sqlsorgu);
        }

        private void btnAjandaKaydet_Click(object sender, EventArgs e)
        {
            AjandaBilgi();
            sqlsorgu = "insert into ajanda (kullaniciID,tarih,saat,dakika,icerik,yapilacak) " +
                "values(" + girisEkrani.girisKulID + ",'" + ajanda.tarih + "',"+ajanda.saat+","+ajanda.dakika+",'"+ajanda.icerik+"',"+ajanda.yapilacak+")";
            baglanti.veriEkle(sqlsorgu);
        }

        private void btnAjandaSil_Click(object sender, EventArgs e)
        {
            AjandaBilgi();
            sqlsorgu = "delete from ajanda where ajandaid='" + ajanda.id + "'";
            baglanti.veriSil(sqlsorgu);
        }

        private void btnAjandaGuncelle_Click(object sender, EventArgs e)
        {
            AjandaBilgi();
            verileriNesnedeGöster(viewAjanda, "ajanda");
            sqlsorgu = "update ajanda set tarih='"+ajanda.tarih+"',saat="+ajanda.saat+",dakika="+ajanda.dakika+
                ",icerik='"+ajanda.icerik+"',yapilacak="+ajanda.yapilacak+" where ajandaid ="+ajanda.id;
            baglanti.veriGuncelle(sqlsorgu);
        }

        private void btnAjandaTemizle_Click(object sender, EventArgs e)
        {
            dateAjandaTarihi.Text="";
            cmbAjandaSaat.Text = "";
            cmbAjandaDakika.Text = "";
            txtAjandaIcerik.Text = "";
            chcYapilacak.Checked = false;
            txtAjandaArama.Text = "";
        }

        private void btnAjandaArama_Click(object sender, EventArgs e)
        {
            sqlsorgu = "select * from ajanda where tarih like'" + txtAjandaArama.Text + "%' and kullanıcııd = '" + girisEkrani.girisKulID + "'" ;
            baglanti.verileriGoruntule(viewAjanda, "ajanda", sqlsorgu);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////NOTLAR
        private void btnNotListele_Click(object sender, EventArgs e)
        {
            sqlsorgu = "select n.defteradi,v.baslik,v.icerik,v.tarih,n.notid,v.veriid from kullanıcı k " +
                "INNER JOIN notlar n ON k.kullaniciid = n.kullaniciid " +
                "INNER JOIN veriler v ON v.veriid = n.veriid " +
                "where k.kullaniciid ='" + girisEkrani.girisKulID+"' and v.verituru="+2;
            baglanti.verileriGoruntule(viewNotlar, "notlar", sqlsorgu);
        }
        
        private void btnNotKaydet_Click(object sender, EventArgs e)
        {
            NotDefteriBilgi();
            id = baglanti.idDondur("veriler", "veriid", new List<(string, string, OracleDbType)> {
                                                                                         ("tarih",not.tarih , OracleDbType.Varchar2),
                                                                                         ("baslik", not.baslik, OracleDbType.Varchar2),
                                                                                         ("icerik",not.icerik, OracleDbType.Varchar2),
                                                                                         ("verituru", "2", OracleDbType.Int16)});
            /*sqlsorgu = "Insert Into veriler (tarih,baslik,icerik,veriTuru) " +
                "values('" + not.tarih + "','" + not.baslik + "','" + not.icerik + "'," + 2 + ")";
            baglanti.veriEkle(sqlsorgu);*/
            sqlsorgu1 = "insert into notlar(defteradi,kullaniciID,veriID) " +
                            "values('" + not.defterAdi + "'," + girisEkrani.girisKulID + "," + id + ")";//buradaki 2 değeri değişecek eklenen yeni değer gelicek.   
            baglanti.veriEkle(sqlsorgu1);
        }

        private void btnNotSil_Click(object sender, EventArgs e)
        {
            NotDefteriBilgi();
            sqlsorgu = "delete from notlar where notID=" + not.id;
            sqlsorgu1 = "delete from veriler where veriID=" + not.veriid;
            baglanti.veriSil(sqlsorgu);
            baglanti.veriSil(sqlsorgu1);     
        }

        private void btnNotGuncelle_Click(object sender, EventArgs e)
        {
            NotDefteriBilgi();
            verileriNesnedeGöster(viewNotlar, "notlar");
            sqlsorgu = "update veriler set tarih='" + not.tarih + "',baslik='" + not.baslik + "',icerik='" + not.icerik + "'where veriid=" + not.veriid;
            sqlsorgu1 = "update notlar set defteradi='" + not.defterAdi + "' where notid=" + not.veriid;
            baglanti.veriGuncelle(sqlsorgu);
            baglanti.veriGuncelle(sqlsorgu1);
        }

        private void btnNotTemizle_Click(object sender, EventArgs e)
        {
            cmbNotDefteri.Text = "";
            dateNotTarihi.Text = "";
            txtNotBasligi.Text = "";
            txtNotIcerik.Text = "";
            txtNotArama.Text = "";
        }

        private void btnNotArama_Click(object sender, EventArgs e)
        {
            sqlsorgu = "select n.defteradi,v.baslik,v.icerik,v.tarih,n.notid,v.veriid from kullanıcı k " +
                "INNER JOIN notlar n ON k.kullaniciid = n.kullaniciid " +
                "INNER JOIN veriler v ON v.veriid = n.veriid " +
                "where v.baslik like'" + txtNotArama.Text + "%' and k.kullaniciid ='" + girisEkrani.girisKulID + "' and v.verituru=" + 2;            
            baglanti.verileriGoruntule(viewNotlar, "notlar", sqlsorgu);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////GÜNLÜK
        private void btnGunlukListele_Click(object sender, EventArgs e)
        {
            sqlsorgu = "select v.baslik,v.icerik,v.tarih,g.gunlukid,v.veriid from kullanıcı k " +
                "INNER JOIN Gunluk g ON k.kullaniciid = g.kullaniciid " +
                "INNER JOIN veriler v ON v.veriid = g.veriid " +
                "where k.kullaniciid ='" + girisEkrani.girisKulID + "' and v.verituru=" + 1;
            baglanti.verileriGoruntule(viewGunluk, "gunluk", sqlsorgu);
        }
        private void btnGunlukKaydet_Click(object sender, EventArgs e)
        {
            GunlukBilgi();
            id = baglanti.idDondur("veriler", "veriID", new List<(string, string, OracleDbType)> {
                                                                                         ("tarih",gnlk.tarih , OracleDbType.Varchar2),
                                                                                         ("baslik", gnlk.baslik, OracleDbType.Varchar2),
                                                                                         ("icerik",gnlk.icerik, OracleDbType.Varchar2),
                                                                                         ("verituru", "1", OracleDbType.Int16)});
            /*sqlsorgu = "Insert Into veriler (tarih,baslik,icerik,veriTuru) " +
                "values('" + gnlk.tarih + "','" + gnlk.baslik + "','" + gnlk.icerik + "'," + 1 + ")";
            baglanti.veriEkle(sqlsorgu);*/
            sqlsorgu1 = "insert into gunluk(kullaniciID,veriID) " +
                            "values("+ girisEkrani.girisKulID + "," + id + ")";//buradaki 2 değeri değişecek eklenen yeni değer gelicek.   
            baglanti.veriEkle(sqlsorgu1);
        }

        private void btnGunlukSil_Click(object sender, EventArgs e)
        {
            GunlukBilgi();
            sqlsorgu = "delete from gunluk where gunlukID=" + gnlk.id;
            sqlsorgu1 = "delete from veriler where veriID=" + gnlk.veriid;
            baglanti.veriSil(sqlsorgu);
            baglanti.veriSil(sqlsorgu1);
        }

        private void btnGunlukGuncelle_Click(object sender, EventArgs e)
        {
            GunlukBilgi();
            verileriNesnedeGöster(viewGunluk, "gunluk");
            sqlsorgu = "update veriler set tarih='" + gnlk.tarih + "',baslik='" + gnlk.baslik + "',icerik='" + gnlk.icerik + "'where veriid=" + gnlk.veriid;            
            baglanti.veriGuncelle(sqlsorgu);           
        }

        private void btnGunlukTemizle_Click(object sender, EventArgs e)
        {
            dateGunlukTarihi.Text = "";
            txtGunlukBaslik.Text = "";
            txtGunlukIcerik.Text = "";
            txtGunlukArama.Text = "";
        }

        private void btnGunlukArama_Click(object sender, EventArgs e)
        {
            sqlsorgu = "select v.baslik,v.icerik,v.tarih,g.gunlukid,v.veriid from kullanıcı k " +
                "INNER JOIN Gunluk g ON k.kullaniciid = g.kullaniciid " +
                "INNER JOIN veriler v ON v.veriid = g.veriid " +
                 "where v.baslik like'" + txtGunlukArama.Text + "%' and k.kullaniciid ='" + girisEkrani.girisKulID + "' and v.verituru=" + 1;
            baglanti.verileriGoruntule(viewGunluk, "gunluk", sqlsorgu);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////KİSİLER
        private void btnKisiListele_Click(object sender, EventArgs e)
        {
            sqlsorgu = "select kb.ad,kb.soyad,kb.cinsiyet,kb.dogumtarihi,kb.eposta,kb.telefon,a.arkadasıd,kb.kisiBilgiID From arkadas a " +
                 "INNER JOIN kisibilgi kb ON a.kisiBilgiID = kb.kisiBilgiID " +
                 "WHERE kullanıcııd = '" + girisEkrani.girisKulID + "'";
            baglanti.verileriGoruntule(viewKisi, "kisiler", sqlsorgu);
        }

        private void btnKisiKaydet_Click(object sender, EventArgs e)
        {
            ArkadasBilgi();
            id = baglanti.idDondur("KISIBILGI", "kisibilgiid", new List<(string, string, OracleDbType)> {
                                                                                         ("ad",arkadas.ad , OracleDbType.Varchar2),
                                                                                         ("soyad", arkadas.soyad, OracleDbType.Varchar2),
                                                                                         ("cinsiyet",arkadas.cinsiyet, OracleDbType.Varchar2),
                                                                                         ("dogumTarihi",arkadas.dogumTarihi, OracleDbType.Varchar2),
                                                                                         ("ePosta",arkadas.ePosta, OracleDbType.Varchar2),
                                                                                         ("telefon", arkadas.telNo, OracleDbType.Varchar2),
                                                                                         ("kullaniciTuru", "2", OracleDbType.Int16)});
            /*sqlsorgu = "Insert Into KISIBILGI (ad,soyad,cinsiyet,dogumTarihi,ePosta,telefon,kullaniciTuru) " +
                            "values('" + arkadas.ad + "','" + arkadas.soyad + "','" + arkadas.cinsiyet + "','" +
                            arkadas.dogumTarihi + "','" + arkadas.ePosta + "','" + arkadas.telNo + "'," + 3 + ")";
            baglanti.veriEkle(sqlsorgu);*/
            sqlsorgu1 = "Insert Into arkadas (kullaniciID,kisiBilgiID) " +
                            "values(" + girisEkrani.girisKulID + ","+ id + ")";// 45 değeri yerine kisibilgisine eklenecek olan değer gelicek.
            
            baglanti.veriEkle(sqlsorgu1);
        }

        private void btnKisiSil_Click(object sender, EventArgs e)
        {
            ArkadasBilgi();
            sqlsorgu = "delete from arkadas where arkadasid=" + arkadas.id;
            sqlsorgu1 = "delete from kisibilgi where kisibilgiID="+kul.kisiBilgiid;
            baglanti.veriSil(sqlsorgu);
            baglanti.veriSil(sqlsorgu1);
        }

        private void btnKisiGuncelle_Click(object sender, EventArgs e)
        {
            ArkadasBilgi();
            verileriNesnedeGöster(viewKisi, "kisiler");
            sqlsorgu = "update KISIBILGI set ad='" + arkadas.ad + "',soyad='" + arkadas.soyad 
                + "',cinsiyet='" + arkadas.cinsiyet + "',dogumTarihi='" + arkadas.dogumTarihi 
                + "',ePosta='" + arkadas.ePosta + "',telefon='" + arkadas.telNo+"'"+
                " where kisiBilgiID =" + kul.kisiBilgiid;
            baglanti.veriGuncelle(sqlsorgu);
        }

        private void btnKisiTemizle_Click(object sender, EventArgs e)
        {
            txtKisiAd.Text = "";
            txtKisiSoyad.Text = "";
            dateKisiDogumTarihi.Text = "";
            txtKisiEposta.Text = "";
            txtKisiTelNo.Text = "";
            cmbKisiCinsiyet.Text = "";
            txtKisilerArama.Text = "";
        }

        private void btnKisiArama_Click(object sender, EventArgs e)
        {
            //where tarih like'" + txtAjandaArama.Text + "%' and kullanıcııd = '" + girisEkrani.girisKulID + "'"
            sqlsorgu = "select kb.ad,kb.soyad,kb.cinsiyet,kb.dogumtarihi,kb.eposta,kb.telefon,a.arkadasıd,kb.kisiBilgiID From arkadas a " +
                 "INNER JOIN kisibilgi kb ON a.kisiBilgiID = kb.kisiBilgiID " +
                 "WHERE kb.ad like'" + txtKisilerArama.Text + "%' and kb.kısıbılgııd=" + 3 + " and kullanıcııd = '" + girisEkrani.girisKulID + "'";

            baglanti.verileriGoruntule(viewKisi, "kisiler", sqlsorgu);
        }

        private void btnMesajGonder_Click(object sender, EventArgs e)
        {
            MesajBilgi();

            /*
             * "Insert Into arkadas (kullaniciID,kisiBilgiID) " +
                            "values(" + girisEkrani.girisKulID + ","+ id + ")";
             * 
             * 
             * 
             * */
            sqlsorgu = "insert into mesaj (kullaniciid,baslik,icerik) " +
                "values(" + girisEkrani.girisKulID + ",'" + msj.baslik + "','" + msj.icerik + "')";
            baglanti.veriEkle(sqlsorgu);
        }

        

        private void btnYeniNotDefteri_Click(object sender, EventArgs e)
        {
            NotDefteriOlustur n = new NotDefteriOlustur();
            n.Show();
        }

        
    }
}
