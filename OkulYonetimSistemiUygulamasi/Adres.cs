using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimSistemiUygulamasi
{
    internal class Adres
    {
        public string Il;
        public string Ilce;
        public string Mahalle;

        public Adres(string il, string ilce, string mahalle)
        {
            Il = il;
            Ilce = ilce;
            Mahalle = mahalle;
        }

        public override string ToString()
        {
            return $"{Mahalle}, {Ilce}, {Il}";
        }
    }
}
