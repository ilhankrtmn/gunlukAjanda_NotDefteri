using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gunlukAjanda_NotDefteri.Arayuzler;
using gunlukAjanda_NotDefteri.Nesneler;
using Oracle.ManagedDataAccess.Client;

namespace gunlukAjanda_NotDefteri
{
    public class vtBaglanti
    {
        //Arayuzler.anasayfa a = new Arayuzler.anasayfa();
        Form1 frm = new Form1();

        


        OracleConnection baglanti = new OracleConnection("User Id=SYSTEM;Password=1234;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=localhost)(PORT=1521)))");
        OracleCommand komut = new OracleCommand();
        string deger;
        /* public List<Gunluk> listViewListele(string sorgu)
         {
             List<Gunluk> gunluks = new List<Gunluk>();
             baglanti.Open();
             OracleCommand komut = new OracleCommand(sorgu, baglanti);
             OracleDataReader dr = komut.ExecuteReader();
             while (dr.Read())
             {
                 Gunluk g = new Gunluk();
                 g.kitapAdi = dr["KITAPAD"].ToString();
                 g.kitapRenk = dr["KITAPRENK"].ToString();
                 g.kitapid = int.Parse(dr["KITAPID"].ToString());
                 gunluks.Add(g);
             }

             baglanti.Close();
             return gunluks;
         }
        */




        public void verileriGoruntule(ListView liste, string listeadi, string sorgu)
        {
            liste.Items.Clear();
            baglanti.Open();
            komut.Connection = baglanti;

           

            if (listeadi == "ajanda2")
            {
                komut.CommandText = sorgu;
                OracleDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = oku["icerik"].ToString();
                    liste.Items.Add(ekle);
                }
            }
            if (listeadi == "ajanda")
            {
                komut.CommandText = sorgu;
                OracleDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = oku["tarih"].ToString();
                    ekle.SubItems.Add(oku["saat"].ToString());
                    ekle.SubItems.Add(oku["dakika"].ToString());
                    ekle.SubItems.Add(oku["icerik"].ToString());      
                    ekle.SubItems.Add(oku["yapilacak"].ToString());
                    ekle.SubItems.Add(oku["ajandaid"].ToString());
                    liste.Items.Add(ekle);
                }
            }

            if (listeadi == "notlar")
            {
                komut.CommandText = sorgu;
                OracleDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = oku["defteradi"].ToString();
                    ekle.SubItems.Add(oku["baslik"].ToString());
                    ekle.SubItems.Add(oku["icerik"].ToString());
                    ekle.SubItems.Add(oku["tarih"].ToString());
                    ekle.SubItems.Add(oku["notID"].ToString());
                    ekle.SubItems.Add(oku["veriID"].ToString());
                    liste.Items.Add(ekle);
                }
            }

            if (listeadi == "gunluk")
            {
                komut.CommandText = sorgu;
                OracleDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = oku["baslik"].ToString();
                    ekle.SubItems.Add(oku["icerik"].ToString());
                    ekle.SubItems.Add(oku["tarih"].ToString());
                    ekle.SubItems.Add(oku["gunlukID"].ToString());
                    ekle.SubItems.Add(oku["veriID"].ToString());
                    liste.Items.Add(ekle);
                }
            }

            if (listeadi == "kisiler")
            {
                komut.CommandText = sorgu;
                OracleDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = oku["ad"].ToString();
                    ekle.SubItems.Add(oku["soyad"].ToString());
                    ekle.SubItems.Add(oku["cinsiyet"].ToString());
                    ekle.SubItems.Add(oku["dogumtarihi"].ToString());
                    ekle.SubItems.Add(oku["eposta"].ToString());
                    ekle.SubItems.Add(oku["telefon"].ToString());
                    ekle.SubItems.Add(oku["arkadasID"].ToString());
                    ekle.SubItems.Add(oku["kisiBilgiID"].ToString());
                    liste.Items.Add(ekle);
                }
            }

            if (listeadi == "mesajlar")
            {
                komut.CommandText = sorgu;
                OracleDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = oku["eposta"].ToString();
                    ekle.SubItems.Add(oku["baslik"].ToString());
                    ekle.SubItems.Add(oku["icerik"].ToString());
                    ekle.SubItems.Add(oku["mesajid"].ToString());
                    liste.Items.Add(ekle);
                }
            }

            if (listeadi == "rapor")
            {
                komut.CommandText = sorgu;
                OracleDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = oku["ad"].ToString();
                    ekle.SubItems.Add(oku["SOYAD"].ToString());
                    ekle.SubItems.Add(oku["ajandasayisi"].ToString());
                    ekle.SubItems.Add(oku["notsayisi"].ToString());
                    ekle.SubItems.Add(oku["gunluksayisi"].ToString());
                    ekle.SubItems.Add(oku["arkadassayisi"].ToString());
                    liste.Items.Add(ekle);
                }
            }

            baglanti.Close();
        }
        

        public Boolean KayitVarmi(string sorgu)
        {
            komut.Connection = baglanti;
            komut.CommandText = sorgu;
            baglanti.Open();
            OracleDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                baglanti.Close();
                return false;
            }
            else
            {
                baglanti.Close();
                return true;
            }
        }

        public void comboveri(string sorgu, string sutun, ComboBox adi)
        {
            komut.CommandText = sorgu;
            komut.Connection = baglanti;
            //komut.CommandType = OracleDbType.Array;
            OracleDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                adi.Items.Add(dr[sutun]);
            }
            baglanti.Close();
        }


        public string verigetir(string sorgu)
        {
            komut.Connection = baglanti;
            komut.CommandText = sorgu;
            baglanti.Open();
            deger = komut.ExecuteScalar().ToString();
            baglanti.Close();
            return deger;
        }

        

        public void veriEkle(string sorgu)
        {
            baglanti.Open();
            OracleCommand komut = new OracleCommand(sorgu, baglanti);
            OracleDataReader oku = komut.ExecuteReader();
            
            while (oku.Read())
            {
                MessageBox.Show(oku[0].ToString());
            }
            //komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public void veriSil(string sorgu)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = sorgu;
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public void veriGuncelle(string sorgu)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = sorgu;
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public Boolean GirisKontrol(string sorgu)
        {

            komut.Connection = baglanti;
            komut.CommandText = sorgu;
            baglanti.Open();
            OracleDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            { 
                baglanti.Close();
                return true;           
            }
            else
            {
                MessageBox.Show("KULLANICI ADI  veya ŞİFRE HATALI!");
                baglanti.Close();
                return false;
            }
        }

        public int idDondur(string tablo, string idismi, List<(string sutun, string degeri, OracleDbType dt)> values)
        {
            string sutun = String.Join(",", values.Select(x => x.sutun));
            string value = ":" + String.Join(",:", values.Select(x => x.Item1));

            List<string> whereItems = new List<string>();
            foreach (var item in values)
            {
                whereItems.Add(item.sutun + "=:" + item.sutun + "_where");
            }
            string where = String.Join(" AND ", whereItems);

            string insert_query = "Insert Into " + tablo + " (" + sutun + ") Values (" + value + ")";
            string select_query = "Select * From " + tablo + " where " + where;

            baglanti.Open();
            OracleCommand cmd = new OracleCommand(insert_query, baglanti);
            string s = insert_query;
            foreach (var item in values)
            {
                cmd.Parameters.Add(item.sutun, item.dt).Value = item.degeri;
                s = s.Replace(":" + item.sutun, item.degeri);
            }
            cmd.ExecuteNonQuery();

            cmd.Dispose();

            string ss = "";
            OracleCommand oracleCommand = new OracleCommand(select_query, baglanti);
            foreach (var item in values)
            {
                oracleCommand.Parameters.Add(item.sutun + "_where", item.dt).Value = item.degeri;
                ss = ss.Replace(":" + item.sutun + "_where", item.degeri);
            }
            OracleDataReader dr = oracleCommand.ExecuteReader();

            while (dr.Read())
            {
                int id = int.Parse(dr[idismi].ToString());
                baglanti.Close();
                return id;
            }
            baglanti.Close();

            return int.MaxValue;
        }

    }
}
