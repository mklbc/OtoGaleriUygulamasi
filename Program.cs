using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.Arm;

namespace OtoGaleriUygulamasi_Temel_TP195
{
    internal class Program
    {
        static Galeri OtoGaleri = new Galeri();
        static int wrongAttempts = 0;

        static void Main(string[] args)
        {
            SahteArabaEkle();
            Uygulama();
        }

        static void Uygulama()
        {
            Menu();
            while (wrongAttempts < 10)
            {
                Console.WriteLine();
                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine().ToUpper();
                if (secim == "X")
                {
                    Console.WriteLine("Ana menüye geri dönülüyor...");
                    break;
                }
                else
                {
                    switch (secim)
                    {
                        case "1":
                        case "K":
                            ArabaKirala();
                            break;
                        case "2":
                        case "T":
                            ArabaTeslimAl();
                            break;
                        case "3":
                        case "R":
                            KiradakiArabalarListele();
                            break;
                        case "4":
                        case "M":
                            GaleridekiArabalarListele();
                            break;
                        case "5":
                        case "A":
                            TumArabalarListele();
                            break;
                        case "6":
                        case "I":
                            KiralamaIptal();
                            break;
                        case "7":
                        case "Y":
                            ArabaEkle();
                            break;
                        case "8":
                        case "S":
                            ArabaSil();
                            break;
                        case "9":
                        case "G":
                            GaleriBilgileri();
                            break;
                        default:
                            wrongAttempts++;
                            Console.WriteLine("Hatalı işlem gerçekleştirildi.Tekrar deneyin.");
                            break;
                    }
                }
            }
            if (wrongAttempts == 10)
            {
                Console.WriteLine("Çok fazla hatalı giriş yaptınız. Program sonlandırılıyor.");
            }
        }

        static void Menu()
        {
            Console.WriteLine("Galeri Otomasyon");
            Console.WriteLine("1- Araba Kirala (K)");
            Console.WriteLine("2- Araba Teslim Al (T)");
            Console.WriteLine("3- Kiradaki Arabaları Listele (R)");
            Console.WriteLine("4- Galerideki Arabaları Listele (M)");
            Console.WriteLine("5- Tüm Arabaları Listele (A)");
            Console.WriteLine("6- Kiralama İptali (I)");
            Console.WriteLine("7- Araba Ekle (Y)");
            Console.WriteLine("8- Araba Sil (S)");
            Console.WriteLine("9- Bilgileri Göster (G)");
            Console.WriteLine("X- Ana Menüye Dön");
        }



        static void ArabaKirala()
        {
            Console.WriteLine();
            Console.WriteLine("-Araba Kirala-");
            Console.WriteLine();
            Console.Write("Kiralanacak arabanın plakası: ");
            string plaka = Console.ReadLine();
            Console.Write("Kiralanma Süresi: ");

            int sure = Convert.ToInt32(Console.ReadLine());

            OtoGaleri.ArabaKirala(plaka, sure);
        }

        static void ArabaTeslimAl()
        {
            Console.WriteLine();
            Console.WriteLine("-Araba Teslim Al-");
            Console.WriteLine();
            Console.WriteLine("Teslim edilecek arabanın plakası: ");
            string plaka = Console.ReadLine();
            OtoGaleri.ArabaTeslimAl(plaka);
        }

        static void SahteArabaEkle()
        {
            Araba car1 = new Araba("34TT2305", "Opel", 50, "SUV");
            OtoGaleri.arabalar.Add(car1);
            Araba car2 = new Araba("36MN2304", "Fiat", 150, "Hatchback");
            OtoGaleri.arabalar.Add(car2);

        }
        static void KiradakiArabalarListele()
        {
            Console.WriteLine();
            Console.WriteLine("-Kiradaki Arabalar-");
            Console.WriteLine();
            var kiradakiArabalar = OtoGaleri.arabalar.Where(a => a.Durum == "Kirada").ToList();
            if (kiradakiArabalar.Any())
            {
                foreach (var araba in kiradakiArabalar)
                {
                    Console.WriteLine($"Plaka: {araba.Plaka}, Marka: {araba.Marka}, Kiralama Bedeli: {araba.KiralamaBedeli} TL, Kiralama Süresi: {string.Join(", ", araba.KiralamaSureleri)}");
                }
            }
            else
            {
                Console.WriteLine("Kirada hiç araba bulunmamaktadır.");
            }
        }

        static void GaleridekiArabalarListele()
        {
            Console.WriteLine();
            Console.WriteLine("-Galerideki Arabalar-");
            Console.WriteLine();
            var galeridekiArabalar = OtoGaleri.arabalar.Where(a => a.Durum == "Galeride").ToList();
            if (galeridekiArabalar.Any())
            {
                foreach (var araba in galeridekiArabalar)
                {
                    Console.WriteLine($"Plaka: {araba.Plaka}, Marka: {araba.Marka}, Kiralama Bedeli: {araba.KiralamaBedeli} TL");
                }
            }
            else
            {
                Console.WriteLine("Galeride hiç araba bulunmamaktadır.");
            }
        }

        static void TumArabalarListele(bool sadeceKiradakiler = false, bool sadeceGaleridekiler = false)
        {
            var liste = OtoGaleri.arabalar.ToList();

            if (liste.Count == 0)
            {
                Console.WriteLine("Listede araba bulunamadı.");
                return;
            }

            Console.WriteLine("Plaka".PadRight(15) + "Marka".PadRight(15) + "K. Bedeli".PadRight(17) + "Araba Tipi".PadRight(15) + "K. Sayısı".PadRight(15) + "Durum");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            foreach (var araba in liste)
            {
                Console.WriteLine($"{araba.Plaka.PadRight(15)}{araba.Marka.PadRight(16)} {Convert.ToString(araba.KiralamaBedeli).PadRight(15)} {araba.AracTipi.PadRight(18)} {Convert.ToString(araba.KiralamaSayisi).PadRight(8)} {araba.Durum}");
            }
        }

        static void KiralamaIptal()
        {
            Console.WriteLine();
            Console.WriteLine("-Kiralama İptali-");
            Console.WriteLine();
            Console.WriteLine("Kiralaması iptal edilecek arabanın plakası: ");
            string plaka = Console.ReadLine();
            OtoGaleri.KiralamaIptal(plaka);
        }


        static void ArabaEkle()
        {
            Console.WriteLine("-Araba Ekle-");
            Console.Write("Plaka : ");
            string plaka = Console.ReadLine();

            Console.Write("Marka : ");
            string marka = Console.ReadLine();

            Console.Write("Kiralama Bedeli : ");
            int kiralamaBedeli = Convert.ToInt32(Console.ReadLine());

           if (OtoGaleri.ArabaEkle(plaka, marka, kiralamaBedeli, AracTipi()) = true )
            {
           
            }


        static string AracTipi()
        {
            Console.Write("Araç Tipi : ");

            Console.WriteLine("SUV için 1 ");
            Console.WriteLine("Hatchback için 2 ");
            Console.WriteLine("Sedan için 3 ");
            Console.Write("Araba Tipi: ");
            Console.WriteLine("");
            

            string secim = Console.ReadLine();
            switch (secim)
            {
                case "1":
                    return "SUV";

                case "2":
                    return "Hatchback";

                case "3":
                    return "Sedan"; 
                   
                default:
                    return "Giriş Tanımlanamadı. Tekrar deneyin.";
            }

        }
           
        //static void ArabaEkle()
        //{
        //    Console.WriteLine( );
        //    Console.WriteLine("-Araba Ekle-");
        //    Console.WriteLine( );
        //    Console.WriteLine("Plaka: ");
        //    string plaka = Console.ReadLine();

        //    Console.WriteLine("Marka: ");
        //    string marka = Console.ReadLine();

        //    int kiralamaBedeli;
        //    Console.WriteLine("Kiralama bedeli: ");
        //    while (!int.TryParse(Console.ReadLine(), out kiralamaBedeli))
        //    {
        //        Console.WriteLine("Geçerli bir fiyat giriniz.");
        //    }

        //    Console.WriteLine("Araç tipi: ");
        //    string aracTipi = Console.ReadLine();

        //    OtoGaleri.ArabaEkle(plaka, marka, kiralamaBedeli, aracTipi);
        //}

        static void ArabaSil()
        {
            Console.WriteLine();
            Console.WriteLine("-Araba Sil-");
            Console.WriteLine();
            Console.WriteLine("Silinecek arabanın plakası: ");
            string plaka = Console.ReadLine();
            var araba = OtoGaleri.arabalar.FirstOrDefault(a => a.Plaka == plaka);

            if (araba != null)
            {
                OtoGaleri.arabalar.Remove(araba);
                Console.WriteLine($"Araba {plaka} başarıyla silindi.");
            }
            else
            {
                Console.WriteLine("Belirtilen plakada araba bulunamadı.");
            }
        }

        static void GaleriBilgileri()
        {
            Console.WriteLine();
            Console.WriteLine("-Galeri Bilgileri-");
            Console.WriteLine();
            Console.WriteLine($"Toplam Araba Sayısı: {OtoGaleri.ToplamArabaSayisi}");
            Console.WriteLine($"Kiradaki Araba Sayısı: {OtoGaleri.KiradakiArabaSayisi}");
            Console.WriteLine($"Galerideki Araba Sayısı: {OtoGaleri.GaleridekiArabaSayisi}");
            Console.WriteLine($"Toplam Kiralama Süreleri: {OtoGaleri.ToplamArabaKiralamaSureleri}");
            Console.WriteLine($"Toplam Kiralama Adeti: {OtoGaleri.ToplamArabaKiralamaAdeti}");
            Console.WriteLine($"Galeri Cirosu: {OtoGaleri.Ciro} TL");
        }
    }
}