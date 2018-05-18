using Obezite_ve_Kalori_Takip_Sitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Obezite_ve_Kalori_Takip_Sitesi.Data
{
    public static class DbInitializer
    {
        public static MyViewModel bütünGıdalar;
        public static void Initialize(FoodContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Baklagiller.Any())
            {
                return;   // DB has been seeded
            }                              

            bütünGıdalar = new MyViewModel();

            List<Baklagil> b = new List<Baklagil>();  /********************* start baklagil*******************/
            b.AddRange(new List<Baklagil>
            {
                new Baklagil("Bakla", 84),
                new Baklagil("Bamya", 33),
                new Baklagil("Bezelye", 42),
                new Baklagil("Börülce", 341),
                new Baklagil("Kestane içi", 210),
                new Baklagil("Kurufasulye", 336),
                new Baklagil("Kırmızı Barbunya", 124),
                new Baklagil("Kırmızı Mercimek", 329),
                new Baklagil("Nohut", 364),
                new Baklagil("Soya Fasulyesi", 147),
                new Baklagil("Yer Fıstığı", 567),
                new Baklagil("Yeşil Fasulye", 31),
                new Baklagil("Yeşil Mercimek", 257),                
            });                       
            Baklagil[] ba = b.ToArray();
            bütünGıdalar.baklagilList = ba;
            foreach (Baklagil bak in bütünGıdalar.baklagilList)
            {
                context.Baklagiller.Add(bak);
            }
            context.SaveChanges();  /**************** end baklagil *************/

            List<DenizÜrünü> d = new List<DenizÜrünü>();
            d.AddRange(new List<DenizÜrünü>
            {
                new DenizÜrünü("Alabalık", 190),
                new DenizÜrünü("Deniz Levreği", 124),
                new DenizÜrünü("Havyar", 264),
                new DenizÜrünü("Istakoz", 89),
                new DenizÜrünü("Kalamar", 175),
                new DenizÜrünü("Lüfer", 159),
                new DenizÜrünü("Mezgit", 90),
                new DenizÜrünü("Midye", 172),
                new DenizÜrünü("Sardalya", 208),
                new DenizÜrünü("Sazan", 162),
                new DenizÜrünü("Somon", 206),
                new DenizÜrünü("Ton Balığı", 132),

            });
            DenizÜrünü[] de = d.ToArray();
            bütünGıdalar.denizÜrünüList = de;
            foreach (DenizÜrünü den in bütünGıdalar.denizÜrünüList)
            {
                context.DenizÜrünleri.Add(den);
            }
            context.SaveChanges();    /****************end deniz ürünü *************/

            List<Et> e = new List<Et>();
            e.AddRange(new List<Et>
            {
                new Et("Bonfile", 138),
                new Et("Dana Kıyması", 246),
                new Et("Dana Eti (Orta Yağlı", 190),
                new Et("Kuzu Pirzola", 276),
                new Et("Tavuk", 219),
                new Et("Şinitzel", 156),
                new Et("Salam", 446),
                new Et("Sosis", 295),
                new Et("Sucuk", 452),
                new Et("Biftek", 278),                              
                new Et("Hindi", 189),
            });
            Et[] et = e.ToArray();
            bütünGıdalar.etList = et;
            foreach (Et ett in bütünGıdalar.etList)
            {
                context.Etler.Add(ett);
            }
            context.SaveChanges();    /****************end et *************/

            List<Kuruyemiş> k = new List<Kuruyemiş>();
            k.AddRange(new List<Kuruyemiş>
            {
                new Kuruyemiş("Badem", 600),
                new Kuruyemiş("Hindistan Cevizi", 603),
                new Kuruyemiş("Fındık", 650),
                new Kuruyemiş("Fıstık", 560),
                new Kuruyemiş("Çam Fıstığı", 600),
                new Kuruyemiş("Ceviz", 549),
                new Kuruyemiş("Patlamış Mısır", 478),
                new Kuruyemiş("Kabak Çekirdeği", 571),
                new Kuruyemiş("Ay Çekirdeği", 578),
                new Kuruyemiş("Leblebi", 267),
            });
            Kuruyemiş[] ku = k.ToArray();
            bütünGıdalar.kuruyemişList = ku;
            foreach (Kuruyemiş kur in bütünGıdalar.kuruyemişList)
            {
                context.Kuruyemişler.Add(kur);
            }
            context.SaveChanges();    /****************end kuruyemiş *************/

            List<Meyve> m = new List<Meyve>();
            m.AddRange(new List<Meyve>
            {
                new Meyve("Ahududu", 52),
                new Meyve("Ananas", 50),
                new Meyve("Armut", 57),
                new Meyve("Ayva", 57),
                new Meyve("Böğürtlen", 43),
                new Meyve("Dut", 43),
                new Meyve("Elma", 52),
                new Meyve("Erik", 46),
                new Meyve("İncir", 74),
                new Meyve("Karpuz", 30),
                new Meyve("Kayısı", 48),
                new Meyve("Kiraz", 50),
                new Meyve("Kivi", 61),
                new Meyve("Muz", 89),
                new Meyve("Nar", 83),
                new Meyve("Portakal", 47),
                new Meyve("Çilek", 32),
                new Meyve("Üzüm", 69),
                new Meyve("Şeftali", 39),
            });
            Meyve[] me = m.ToArray();
            bütünGıdalar.meyveList = me;
            foreach (Meyve mey in bütünGıdalar.meyveList)
            {
                context.Meyveler.Add(mey);
            }
            context.SaveChanges();    /****************end meyve *************/

            List<Sebze> s = new List<Sebze>();
            s.AddRange(new List<Sebze>
            {
                new Sebze("Bamya", 33),
                new Sebze("Bezelye", 81),
                new Sebze("Biber", 27),
                new Sebze("Brokoli", 34),
                new Sebze("Domates", 18),
                new Sebze("Enginar", 47),
                new Sebze("Ispanak", 23),
                new Sebze("Kabak", 26),
                new Sebze("Karnabahar", 25),
                new Sebze("Kıvırcık Lahana", 49),
                new Sebze("Mantar", 22),
                new Sebze("Marul", 15),
                new Sebze("Patates", 77),
                new Sebze("Patlıcan", 25),
                new Sebze("Pırasa", 61),
                new Sebze("Roka", 25),
                new Sebze("Salatalık", 16),
                new Sebze("Soğan", 40),
                new Sebze("Turp", 28),
            });
            Sebze[] se = s.ToArray();
            bütünGıdalar.sebzeList = se;
            foreach (Sebze seb in bütünGıdalar.sebzeList)
            {
                context.Sebzeler.Add(seb);
            }
            context.SaveChanges();    /****************end sebze *************/

            List<SütYumurta> sy = new List<SütYumurta>();
            sy.AddRange(new List<SütYumurta>
            {
                new SütYumurta("Yoğurt (Yağlı)", 95),
                new SütYumurta("Süt (Yağlı)", 68),
                new SütYumurta("Yoğurt (Yağlı, Meyveli)", 125),
                new SütYumurta("Beyaz Peynir (Yağlı)", 275),
                new SütYumurta("Kaşar Peyniri (Yağlı)", 413),
                new SütYumurta("Parmesan Peyniri (Yağlı)", 440),
                new SütYumurta("Yumurta", 80),
                new SütYumurta("Keçi Sütü", 69),
                new SütYumurta("Süzme Peynir", 98),
                new SütYumurta("Soya Sütü", 45),
                new SütYumurta("Süt Tozu", 496),
            });
            SütYumurta[] sü = sy.ToArray();
            bütünGıdalar.sütYumurtaList = sü;
            foreach (SütYumurta süt in bütünGıdalar.sütYumurtaList)
            {
                context.SütVeYumurtaÜrünleri.Add(süt);
            }
            context.SaveChanges();    /****************end sütYumurta *************/

            List<Yağ> y = new List<Yağ>();
            y.AddRange(new List<Yağ>
            {
                new Yağ("Ayçiçeği Yağı", 884),
                new Yağ("Balık Yağı", 1000),
                new Yağ("Fındık Yağı", 857),
                new Yağ("Kanola Yağı", 884),
                new Yağ("Margarin", 717),
                new Yağ("Palm Yağı", 882),
                new Yağ("Susam Yağı", 884),
                new Yağ("Tereyağı", 720),
                new Yağ("Zeytinyağı", 884),
            });
            Yağ[] ya = y.ToArray();
            bütünGıdalar.yağList = ya;
            foreach (Yağ yağ in bütünGıdalar.yağList)
            {
                context.Yağlar.Add(yağ);
            }
            context.SaveChanges();    /****************end yağ *************/


        }

        public static void setGenelÜrünler()
        {
            bütünGıdalar = new MyViewModel();

            List<Baklagil> b = new List<Baklagil>();  
            b.AddRange(new List<Baklagil>
            {
                new Baklagil("Bakla", 84),
                new Baklagil("Bamya", 33),
                new Baklagil("Bezelye", 42),
                new Baklagil("Börülce", 341),
                new Baklagil("Kestane içi", 210),
                new Baklagil("Kurufasulye", 336),
                new Baklagil("Kırmızı Barbunya", 124),
                new Baklagil("Kırmızı Mercimek", 329),
                new Baklagil("Nohut", 364),
                new Baklagil("Soya Fasulyesi", 147),
                new Baklagil("Yer Fıstığı", 567),
                new Baklagil("Yeşil Fasulye", 31),
                new Baklagil("Yeşil Mercimek", 257),
            });
            Baklagil[] ba = b.ToArray();
            bütünGıdalar.baklagilList = ba; /********************* end baklagil*******************/


            List<DenizÜrünü> d = new List<DenizÜrünü>();
            d.AddRange(new List<DenizÜrünü>
            {
                new DenizÜrünü("Alabalık", 190),
                new DenizÜrünü("Deniz Levreği", 124),
                new DenizÜrünü("Havyar", 264),
                new DenizÜrünü("Istakoz", 89),
                new DenizÜrünü("Kalamar", 175),
                new DenizÜrünü("Lüfer", 159),
                new DenizÜrünü("Mezgit", 90),
                new DenizÜrünü("Midye", 172),
                new DenizÜrünü("Sardalya", 208),
                new DenizÜrünü("Sazan", 162),
                new DenizÜrünü("Somon", 206),
                new DenizÜrünü("Ton Balığı", 132),
            });
            DenizÜrünü[] de = d.ToArray();
            bütünGıdalar.denizÜrünüList = de;  /********************* end denizürünü*******************/

            List<Et> e = new List<Et>();
            e.AddRange(new List<Et>
            {
                new Et("Bonfile", 138),
                new Et("Dana Kıyması", 246),
                new Et("Dana Eti (Orta Yağlı)", 190),
                new Et("Kuzu Pirzola", 276),
                new Et("Tavuk", 219),
                new Et("Şinitzel", 156),
                new Et("Salam", 446),
                new Et("Sosis", 295),
                new Et("Sucuk", 452),
                new Et("Biftek", 278),
                new Et("Hindi", 189),
            });
            Et[] et = e.ToArray();
            bütünGıdalar.etList = et;  /********************* end et*******************/

            List<Kuruyemiş> k = new List<Kuruyemiş>();
            k.AddRange(new List<Kuruyemiş>
            {
                new Kuruyemiş("Badem", 600),
                new Kuruyemiş("Hindistan Cevizi", 603),
                new Kuruyemiş("Fındık", 650),
                new Kuruyemiş("Fıstık", 560),
                new Kuruyemiş("Çam Fıstığı", 600),
                new Kuruyemiş("Ceviz", 549),
                new Kuruyemiş("Patlamış Mısır", 478),
                new Kuruyemiş("Kabak Çekirdeği", 571),
                new Kuruyemiş("Ay Çekirdeği", 578),
                new Kuruyemiş("Leblebi", 267),
            });
            Kuruyemiş[] ku = k.ToArray();
            bütünGıdalar.kuruyemişList = ku;    /********************* end kuruyemiş*******************/

            List<Meyve> m = new List<Meyve>();
            m.AddRange(new List<Meyve>
            {
                new Meyve("Ahududu", 52),
                new Meyve("Ananas", 50),
                new Meyve("Armut", 57),
                new Meyve("Ayva", 57),
                new Meyve("Böğürtlen", 43),
                new Meyve("Dut", 43),
                new Meyve("Elma", 52),
                new Meyve("Erik", 46),
                new Meyve("İncir", 74),
                new Meyve("Karpuz", 30),
                new Meyve("Kayısı", 48),
                new Meyve("Kiraz", 50),
                new Meyve("Kivi", 61),
                new Meyve("Muz", 89),
                new Meyve("Nar", 83),
                new Meyve("Portakal", 47),
                new Meyve("Çilek", 32),
                new Meyve("Üzüm", 69),
                new Meyve("Şeftali", 39),
            });
            Meyve[] me = m.ToArray();
            bütünGıdalar.meyveList = me;   /********************* end meyve*******************/

            List<Sebze> s = new List<Sebze>();
            s.AddRange(new List<Sebze>
            {
                new Sebze("Bamya", 33),
                new Sebze("Bezelye", 81),
                new Sebze("Biber", 27),
                new Sebze("Brokoli", 34),
                new Sebze("Domates", 18),
                new Sebze("Enginar", 47),
                new Sebze("Ispanak", 23),
                new Sebze("Kabak", 26),
                new Sebze("Karnabahar", 25),
                new Sebze("Kıvırcık Lahana", 49),
                new Sebze("Mantar", 22),
                new Sebze("Marul", 15),
                new Sebze("Patates", 77),
                new Sebze("Patlıcan", 25),
                new Sebze("Pırasa", 61),
                new Sebze("Roka", 25),
                new Sebze("Salatalık", 16),
                new Sebze("Soğan", 40),
                new Sebze("Turp", 28),
            });
            Sebze[] se = s.ToArray();
            bütünGıdalar.sebzeList = se;     /********************* end sebze*******************/

            List<SütYumurta> sy = new List<SütYumurta>();
            sy.AddRange(new List<SütYumurta>
            {
                new SütYumurta("Yoğurt (Yağlı)", 95),
                new SütYumurta("Süt (Yağlı)", 68),
                new SütYumurta("Yoğurt (Yağlı, Meyveli)", 125),
                new SütYumurta("Beyaz Peynir (Yağlı)", 275),
                new SütYumurta("Kaşar Peyniri (Yağlı)", 413),
                new SütYumurta("Parmesan Peyniri (Yağlı)", 440),
                new SütYumurta("Yumurta", 80),
                new SütYumurta("Keçi Sütü", 69),
                new SütYumurta("Süzme Peynir", 98),
                new SütYumurta("Soya Sütü", 45),
                new SütYumurta("Süt Tozu", 496),
            });
            SütYumurta[] sü = sy.ToArray();
            bütünGıdalar.sütYumurtaList = sü;    /********************* end sütYumurta*******************/

            List<Yağ> y = new List<Yağ>();
            y.AddRange(new List<Yağ>
            {
                new Yağ("Ayçiçeği Yağı", 884),
                new Yağ("Balık Yağı", 1000),
                new Yağ("Fındık Yağı", 857),
                new Yağ("Kanola Yağı", 884),
                new Yağ("Margarin", 717),
                new Yağ("PalmYağı", 882),
                new Yağ("Susam Yağı", 884),
                new Yağ("Tereyağı", 720),
                new Yağ("Zeytinyağı", 884),
            });
            Yağ[] ya = y.ToArray();
            bütünGıdalar.yağList = ya;          /********************* end yağ*******************/

        }
    }
}
