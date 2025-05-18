using System;
using System.Collections.Generic;
using System.Linq;

namespace OtoGaleriUygulamasi_Temel_TP195
{
    internal class Galeri
    {
        public List<Araba> arabalar = new List<Araba>();
        public List<Araba> KiradakiArabalar = new List<Araba>();
        public int ToplamArabaSayisi => arabalar.Count;

        public int KiradakiArabaSayisi
        {
            get
            {
                return arabalar.Count(a => a.Durum == "Kirada");
            }
        }

        public int GaleridekiArabaSayisi
        {
            get
            {
                return arabalar.Count(a => a.Durum == "Galeride");
            }
        }

        public int ToplamArabaKiralamaSureleri
        {
            get
            {
                return arabalar.Sum(a => a.ToplamKiralamaSureleri);
            }
        }

        public int ToplamArabaKiralamaAdeti => arabalar.Count(a => a.Durum == "Kirada");

        public float Ciro
        {
            get
            {
                return arabalar.Where(a => a.Durum == "Kirada")
                               .Sum(a => a.KiralamaBedeli * a.KiralamaSureleri.Count);
            }
        }


        public void ArabaKirala(string plaka, int sure)
        {
            Araba a = null;

            foreach (Araba item in arabalar)
            {
                if (item.Plaka == plaka)
                {
                    a = item;
                }
            }

            if (a != null)
            {
                a.Durum = "Kirada";
                a.KiralamaSureleri.Add(sure);
            }
        }




        public void ArabaEkle(string plaka, string marka, int kiralamaBedeli, string aTipi)
        {
            Araba a = new Araba(plaka, marka, kiralamaBedeli, aTipi);
            this.arabalar.Add(a);
        }


        //public void ArabaEkle(string plaka, string marka, int kiralamaBedeli, string aracTipi)
        //{
        //    if (arabalar.Any(a => a.Plaka == plaka))
        //    {
        //        Console.WriteLine("Bu plakada bir araba zaten mevcut.");
        //    }
        //    else
        //    {
        //        Araba yeniAraba = new Araba(plaka, marka, kiralamaBedeli, aracTipi);
        //        arabalar.Add(yeniAraba);
        //        Console.WriteLine("Araba başarıyla eklendi.");
        //    }
        //}


        public void ArabaTeslimAl(string plaka)
        {
            Araba a = null;

            foreach (Araba item in arabalar)
            {
                if (item.Plaka == plaka)
                {
                    a = item;
                }
            }
            if (a != null)
            {
                a.Durum = "Galeride";
            }
        }

        public void KiralamaIptal(string plaka)
        {
            var araba = arabalar.FirstOrDefault(a => a.Plaka == plaka && a.Durum == "Kirada");

            if (araba != null)
            {
                araba.KiralamaSureleri.RemoveAt(araba.KiralamaSureleri.Count - 1);
                araba.Durum = "Galeride";
                Console.WriteLine("Kiralama iptal edildi.");
            }
            else
            {
                Console.WriteLine("Kiralama iptal edilemedi. Araba ya galeride ya da kirada değil.");
            }
        }
    }
}