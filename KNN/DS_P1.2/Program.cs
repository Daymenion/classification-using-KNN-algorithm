using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Linq.Expressions;

namespace DS_P1._2
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Banknot> anaDizi = new List<Banknot>();

            try
            {
                using(StreamReader sr = new StreamReader("data_banknote_authentication.txt")) 
                {
                    string satir;
                   

                    while (sr.Peek() >= 0) //peek dosya sonuna gelinip gelinmediğini kontrol eden metot
                    {
                        string[] degerler = new string[5];
                        satir = sr.ReadLine();
                        degerler = satir.Split(',');
                        Banknot banknot = new Banknot(
                            double.Parse(degerler[0], System.Globalization.CultureInfo.InvariantCulture), 
                            double.Parse(degerler[1], System.Globalization.CultureInfo.InvariantCulture),
                            double.Parse(degerler[2], System.Globalization.CultureInfo.InvariantCulture),
                            double.Parse(degerler[3], System.Globalization.CultureInfo.InvariantCulture),
                            degerler[4]);
                        anaDizi.Add(banknot);
                        //Cultureinfo kullandık çünkü girilen değerdeki noktayı görnüyordu.
                    }
                    Console.WriteLine("Dosya okundu");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Dosya Bulunamadi");
                Console.WriteLine(e.Message);
            }

            string devam = "d";
            while (devam != "q")
            {
                Console.WriteLine("\t(1)Banknot sınıflandırma \n\t(2)Başarı ölçümü \n\t(3)Listeleme\n");
                string secim = Console.ReadLine();
                if (secim == "1")
                {
                    Banknot b = DegerAl();// metod çağırılarak kullanıcıdan banknotun değerleri alınıyor
                    Console.WriteLine("k değerini giriniz=");
                    int k = int.Parse(Console.ReadLine());
                    TurBelirle(Karsilastir(b, anaDizi, k));//b nesnesinin türü belirleniyor

                   
                }
                else if (secim == "2")
                {
                    BasariOlcumu(anaDizi);

                }
                else if (secim == "3")
                {
                    Listeleme(anaDizi);
                }
                else if (secim == "q")
                {
                    break;
                }
                Console.WriteLine("Devam etmek istiyor musunuz? Devam icin herhangibir tusa bas cikmak icin q'a bas");
                devam =  Console.ReadLine();
            }
        }

        static Banknot DegerAl()
        {
            Console.WriteLine("banknot değerlerini ',' ile ayırarak yazınız");
            string[] girdiDeger = Console.ReadLine().Split(',');
            Banknot banknot = new Banknot(double.Parse(girdiDeger[0], System.Globalization.CultureInfo.InvariantCulture),
                double.Parse(girdiDeger[1], System.Globalization.CultureInfo.InvariantCulture),
                double.Parse(girdiDeger[2], System.Globalization.CultureInfo.InvariantCulture),
                double.Parse(girdiDeger[3], System.Globalization.CultureInfo.InvariantCulture), "");
            //Cultureinfo kullandık çünkü girilen değerdeki noktayı görnüyordu.
            return banknot;
        }

        private class BanknotUzaklik
        {
            public Banknot banknot { get; set; }
            public double uzaklik { get; set; } //KNN algoritmamızdaki bankot değerini ve uzaklığı tutuyor.
        }

        static List<Banknot> Karsilastir(Banknot banknot,List<Banknot> anaDizi,int k)
        {
            // anadizideki banknotların verilen banknota uzaklıklarını tutmak için bir 
            // BanknotUzaklık listesi tanımlanıyor.
            List<BanknotUzaklik> banknotUzakliklari = new List<BanknotUzaklik>();

            foreach (Banknot b in anaDizi)
            {  //uzaklığı hesaplıyoruz
                double uzaklik = Math.Sqrt(Math.Pow(b.VaryansDegeri - banknot.VaryansDegeri, 2) +
                         Math.Pow(b.CarpiklikDegeri - banknot.CarpiklikDegeri, 2) +
                         Math.Pow(b.BasiklikDegeri - banknot.BasiklikDegeri, 2) +
                         Math.Pow(b.EntropiDegeri - banknot.EntropiDegeri, 2));

                banknotUzakliklari.Add(new BanknotUzaklik { banknot = b, uzaklik = uzaklik }); //bankotuzaklığa ıtemlerı eklıyoruz
            }

            // BanknotUzaklın nesneleri uzaklıklarına göre artan sıralanıp
            // K tanesi seçiliyor ve Banknot nesneleri listesi döndürülüyor.
            return banknotUzakliklari.OrderBy(x => x.uzaklik).Take(k).Select(x => x.banknot).ToList();  
        } 
        
        static string TurBelirle(List<Banknot> benzerKBanknot)
        { //banknotuzaklık (karsılastırdan gelen uzaklık ve banknot bılgı listemiz)

            int gecerli = 0;
            int gecersiz = 0;
            Banknot b =new Banknot();
            for (int i=0; i < benzerKBanknot.Count; ++i)
            {
                b = (Banknot)benzerKBanknot[i];
                Console.WriteLine(b.degerYazdir());
                if (b.Tur == "1") //nesnenin tür değeri 1 e eşitse geçerli sayısını 1 arttırıyoruz, 0 da geçersiz arttırılıyor.
                {
                    gecerli++;
                }
                else
                {
                    gecersiz++;
                }
            }
            if (gecerli > gecersiz) //k değerine göre hangisi çoksa ona göre geçerli ve geçersiz diyoruz
            {
                Console.WriteLine("Gecerli");
                return "Gecerli";
            }
            else if(gecerli<gecersiz)
            {
                Console.WriteLine("Gecersiz");
                return "Gecersiz";
            }
            else
            {  //eşitlik oluşursa en yakın değeri şeçiyoruz ve onun türünü döndürüyoruz. En yakını ise şöyle belirliyoruz:
                //(karsılastır fonksiyonuna uzaklığa göre artan yolladığı için ilk terim en yakın olandır)
                b = (Banknot) benzerKBanknot[0];
                if (b.Tur == "1")
                    return "Gecerli";
                else
                {
                    return "Gecersiz";
                }
            }
        }
        static void BasariOlcumu(List<Banknot> anaDizi)
        { //Anadiziyi türün 1 ise gecerli, gecerlinin son 100 nesnesini de TestSeti 'ne atıyoruz.
            
            List<Banknot> gecerli = anaDizi.Where(x => x.Tur == "1").ToList();
            List<Banknot> TestSeti = gecerli.GetRange(gecerli.Count - 100, 100);
            //Anadiziyi türün 0 ise gecersiz, gecersizin son 100 nesnesini de TestSeti2 'ye atıyoruz.

            List<Banknot> gecersiz = anaDizi.Where(x => x.Tur == "0").ToList();
            List<Banknot> TestSeti2 = gecersiz.GetRange(gecersiz.Count - 100, 100);
            //TestSeti2'i, TestSeti'ne ekliyoruz.

            TestSeti.AddRange(TestSeti2);
            int dogruEslesmeSayisi = 0;
            Console.WriteLine("k değerini tam sayı olarak giriniz");
            int k = Convert.ToInt32(Console.ReadLine());
            
            for (int i = 0; i < TestSeti.Count; i++)
            {//TestSetindekileri 200 değeri türbelileme'ye yollayarak algoritmamızın sonuçlarını Kontrol1'e atıyoruz
                string kontrol1 = TurBelirle(Karsilastir(TestSeti[i], anaDizi, k));
                if (kontrol1 == "Gecerli")
                {//Txt dosyasındaki türler 0 ve 1 olduğu için geçerli ve geçersize göre 0 ve 1 atadık
                    kontrol1 = "1";
                }
                else if (kontrol1 == "Gecersiz")
                {
                    kontrol1 = "0";
                }
                if (kontrol1 == TestSeti[i].Tur)
                {//karşılaştırıp Doğru eşleşme ise sayıyı arttırdık.
                    dogruEslesmeSayisi++;
                }
            }//doğru eşleşme yüzdesini yazdırdık.
            Console.WriteLine("Başarı Yüzdesi= %" + (dogruEslesmeSayisi/200.0)*100);
        }
        static void Listeleme(List<Banknot> anaDizi)
        {
            int sayac = 0;
            foreach(Banknot banknot in anaDizi)
            { //sayacı her banknot nesnesi için sıra olarak kullanıldı
                Console.Write(sayac + ")");
                Console.WriteLine(banknot.degerYazdir());
                sayac++;
            }
        }
    }

}
