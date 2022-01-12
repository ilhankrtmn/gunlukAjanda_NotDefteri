using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using gunlukAjanda_NotDefteri.Nesneler;
using Oracle.ManagedDataAccess.Client;

namespace gunlukAjanda_NotDefteri.Arayuzler
{
    public partial class yoneticiSayfasi : Form
    {
        public yoneticiSayfasi()
        {
            InitializeComponent();
        }

        private void yoneticiSayfasi_Load(object sender, EventArgs e)
        {
            viewMesaj.Columns.Add("Kullanıcı", 130);
            viewMesaj.Columns.Add("Mesaj Başlığı", 150);

            viewRapor.Columns.Add("Ad",120);
            viewRapor.Columns.Add("Soyad", 120);
            viewRapor.Columns.Add("Ajanda Sayısı", 100);
            viewRapor.Columns.Add("Not Sayısı", 100);
            viewRapor.Columns.Add("Günlük Sayısı", 100);
            viewRapor.Columns.Add("Arkadaş Sayısı", 100);

            baglanti.comboveri("select * from kisibilgi where kullanicituru=2", "ePosta", cmbMailKime);
        }

        vtBaglanti baglanti = new vtBaglanti();
        Hakkinda hakkinda = new Hakkinda();
        anasayfa anasayfa = new anasayfa();
        Mesaj msj = new Mesaj();
        string sqlsorgu;
        public void HakkindaBilgi()
        {
            hakkinda.ad = txtHakAd.Text;
            hakkinda.yapimci = txtYapimci.Text;
            hakkinda.versiyon = txtVersiyon.Text;
            hakkinda.haklar = txtHaklar.Text;
        }

        public void verileriNesnedeGöster(ListView liste, string listeadi)
        {
            if (liste.SelectedItems.Count > 0)
            {

                if (listeadi == "mesajlar")
                {
                    txtMesajKimden.Text = liste.SelectedItems[0].SubItems[0].Text;
                    txtMesajBasligi.Text = liste.SelectedItems[0].SubItems[1].Text;
                    txtMesajIcerik.Text = liste.SelectedItems[0].SubItems[2].Text;
                    msj.id = int.Parse(liste.SelectedItems[0].SubItems[3].Text);
                }
            }
        }


        


        private void btnHakkindaGuncelle_Click(object sender, EventArgs e)
        {
            HakkindaBilgi();
            sqlsorgu = "update hakkinda set ad='" + hakkinda.ad + "',yapimci='" + hakkinda.yapimci
               + "',versiyon='" + hakkinda.versiyon + "',haklar='" + hakkinda.haklar
               + "' where ad = (select ad from hakkinda)" ;
            baglanti.veriGuncelle(sqlsorgu);
        }

        private void btnMesajListele_Click(object sender, EventArgs e)
        {
            sqlsorgu = "Select b.eposta,m.baslik,m.icerik,m.mesajid From kullanıcı k " +
                "INNER JOIN mesaj m ON k.kullaniciid = m.kullaniciid " +
                "INNER JOIN kisibilgi b ON k.kisibilgiid = b.kisibilgiid ";
            baglanti.verileriGoruntule(viewMesaj, "mesajlar", sqlsorgu);
        }

        private void btnMesajSil_Click(object sender, EventArgs e)
        {
            HakkindaBilgi();
            sqlsorgu = "delete from mesaj where mesajid='" + msj.id + "'";
            baglanti.veriSil(sqlsorgu);
        }

        private void btnMesajArama_Click(object sender, EventArgs e)
        {
            sqlsorgu = "Select b.eposta,m.baslik,m.icerik,m.mesajid From kullanıcı k " +
                "INNER JOIN mesaj m ON k.kullaniciid = m.kullaniciid " +
                "INNER JOIN kisibilgi b ON k.kisibilgiid = b.kisibilgiid " +
                "where m.baslik like'"+ txtMesajArama.Text+"%'";
            baglanti.verileriGoruntule(viewMesaj, "mesajlar", sqlsorgu);


            /*
             * sqlsorgu = "select v.baslik,v.icerik,v.tarih,g.gunlukid,v.veriid from kullanıcı k " +
                "INNER JOIN Gunluk g ON k.kullaniciid = g.kullaniciid " +
                "INNER JOIN veriler v ON v.veriid = g.veriid " +
                 "where v.baslik like'" + txtGunlukArama.Text + "%' and k.kullaniciid ='" + girisEkrani.girisKulID + "' and v.verituru=" + 1;
             * 
             * 
             * 
             * 
             * 
             * 
             * */
        }

        private void viewMesaj_SelectedIndexChanged(object sender, EventArgs e)
        {
            verileriNesnedeGöster(viewMesaj, "mesajlar");
        }

        private void btnRaporListele_Click(object sender, EventArgs e)
        {
            sqlsorgu = "Select b.ad,b.soyad,r.ajandasayisi,r.notsayisi,r.gunluksayisi,r.arkadassayisi From kullanıcı k " +
                "INNER JOIN rapor r ON k.kullaniciid = r.kullaniciid " +
                "INNER JOIN kisibilgi b ON k.kisibilgiid = b.kisibilgiid ";
            baglanti.verileriGoruntule(viewRapor, "rapor", sqlsorgu);
        }

        private void btnRaporArama_Click(object sender, EventArgs e)
        {
            sqlsorgu = "Select b.ad,b.soyad,r.ajandasayisi,r.notsayisi,r.gunluksayisi,r.arkadassayisi From kullanıcı k " +
                "INNER JOIN rapor r ON k.kullaniciid = r.kullaniciid " +
                "INNER JOIN kisibilgi b ON k.kisibilgiid = b.kisibilgiid "+
                "where b.ad like'" + txtRaporArama.Text + "%'";
            baglanti.verileriGoruntule(viewRapor, "rapor", sqlsorgu);
        }

        private void btnAktar_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
            xla.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook wb = xla.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);

            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)xla.ActiveSheet;
            int i = 1;
            int j = 1;
            foreach (ListViewItem item in viewRapor.Items)
            {
                ws.Cells[i, j] = item.Text.ToString();
                foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
                {
                    ws.Cells[i, j] = subitem.Text.ToString();
                    j++;
                }
                j = 1;
                i++;
            }
        }
    }
}
