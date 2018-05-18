using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obezite_ve_Kalori_Takip_Sitesi.Models
{
    public class Baklagil
    {
        public int ID { get; set; }
        public string Yiyecek { get; set; }
        public int Kalori { get; set; }

        public Baklagil(string yiyecek, int kalori)
        {
            Yiyecek = yiyecek;
            Kalori = kalori;
        }

        public Baklagil()
        {
        }
    }
}
