using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gunlukAjanda_NotDefteri.Nesneler
{
    public class Not
    {
        public int id { get; set; }
        public string defterAdi { get; set; }
        public string baslik { get; set; }
        public string icerik { get; set; }
        public string tarih { get; set; }

        public int veriid { get; set; }
    }
}
