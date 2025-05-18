using System;
using System.Collections.Generic;
using System.Linq;

namespace OtoGaleriUygulamasi_Temel_TP195
{
    internal class Araba
    {
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public float KiralamaBedeli { get; set; }
        public string AracTipi { get; set; }
        public string Durum { get; set; }
        public int KiralamaSayisi { get; set; }
        public List<int> KiralamaSureleri { get; set; } = new List<int>();

        public int ToplamKiralamaSureleri => KiralamaSureleri.Sum();

        public Araba(string plaka, string marka, float kiralamaBedeli, string aracTipi)
        {
            Plaka = plaka;
            Marka = marka;
            KiralamaBedeli = kiralamaBedeli;
            AracTipi = aracTipi;
            Durum = "Galeride";  
        }
    }
}