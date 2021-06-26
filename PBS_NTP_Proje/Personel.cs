using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBS_NTP_Proje
{
    class Personel
    {
        int sicil;
        string ad;
        string soyad;
        string cinsiyet;
        DateTime dogTar;
        string dogYeri;

        public int SICIL
        {
            get { return sicil; }
            set { sicil = value; }
        }
        public string AD
        {
            get { return ad; }
            set { ad = value; }
        }
        public string SOYAD
        {
            get { return soyad; }
            set { soyad = value; }
        }
        public string CINSIYET
        {
            get { return cinsiyet; }
            set { cinsiyet = value; }
        }
        public DateTime DOGTAR
        {
            get { return dogTar; }
            set { dogTar = value; }
        }
        public string DOGYERI
        {
            get { return dogYeri; }
            set { dogYeri = value; }
        }
    }
}
