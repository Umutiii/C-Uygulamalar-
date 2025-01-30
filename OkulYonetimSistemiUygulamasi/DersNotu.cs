using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimSistemiUygulamasi
{
    internal class DersNotu
    {
        public string DersAdi;
        public float Not;
        public DersNotu(string ders, float not)
        {
            this.DersAdi = ders;
            this.Not = not;
        }
      
    }
}
