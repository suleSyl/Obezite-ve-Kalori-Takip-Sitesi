﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obezite_ve_Kalori_Takip_Sitesi.Models
{
    public class Sebze
    {
        public int ID { get; set; }
        public string Yiyecek { get; set; }
        public int Kalori { get; set; }

        public Sebze(string yiyecek, int kalori)
        {
            this.Yiyecek = yiyecek;
            this.Kalori = kalori;
        }

        public Sebze()
        {
        }
    }
}
