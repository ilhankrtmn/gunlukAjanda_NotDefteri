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
    public partial class NotDefteriOlustur : Form
    {
        vtBaglanti baglanti = new vtBaglanti();
        string sqlsorgu;
        public NotDefteriOlustur()
        {
            InitializeComponent();
        }

        private void NotDefteriOlustur_Load(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            sqlsorgu = "insert into notlar(defteradi) values('" + txtDefterAdi.Text + "')";
            baglanti.veriEkle(sqlsorgu);
        }
    }
}
