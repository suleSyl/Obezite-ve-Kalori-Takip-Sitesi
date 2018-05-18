using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obezite_ve_Kalori_Takip_Sitesi.Models
{
    public class MyViewModel
    {
        public int ID { get; set; }
        public Baklagil[] baklagilList;
        public DenizÜrünü[] denizÜrünüList;
        public Et[] etList;
        public Kuruyemiş[] kuruyemişList;
        public Meyve[] meyveList;
        public Sebze[] sebzeList;
        public SütYumurta[] sütYumurtaList;
        public Yağ[] yağList;
    }
}
