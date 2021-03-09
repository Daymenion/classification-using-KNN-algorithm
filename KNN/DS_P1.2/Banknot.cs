using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_P1._2
{
    class Banknot
    {
        private double varyansDegeri;
        private double carpiklikDegeri;
        private double basiklikDegeri;
        private double entropiDegeri;
        private string tur;
        public Banknot()
        {
            this.varyansDegeri = 0.0;
            this.carpiklikDegeri = 0.0;
            this.basiklikDegeri = 0.0;
            this.entropiDegeri = 0.0;
            this.tur = "";
        }

        public Banknot(double varyansDegeri, double carpiklikDegeri, double basiklikDegeri, double entropiDegeri, string tur)
        {
            this.varyansDegeri = varyansDegeri;
            this.carpiklikDegeri = carpiklikDegeri;
            this.basiklikDegeri = basiklikDegeri;
            this.entropiDegeri = entropiDegeri;
            this.tur = tur;
        }
        //Get ve set methodları olusturuldu
        public double VaryansDegeri { get => varyansDegeri; set => varyansDegeri = value; }
        public double CarpiklikDegeri { get => carpiklikDegeri; set => carpiklikDegeri = value; }
        public double BasiklikDegeri { get => basiklikDegeri; set => basiklikDegeri = value; }
        public double EntropiDegeri { get => entropiDegeri; set => entropiDegeri = value; }
        public string Tur { get => tur; set => tur = value; }

        public string degerYazdir()
        {//Bu methodumuz Nesnelerimizi stringe dönüştürüyor ve Stringi dönüyor.
            string deger = String.Format("{0:0.#0}   {1:0.#0}   {2:0.#0}   {3:0.#0}   {4}", varyansDegeri, carpiklikDegeri, basiklikDegeri, entropiDegeri, tur);
            return deger;
        }
            
    }

}
