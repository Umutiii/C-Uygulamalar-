﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimSistemiUygulamasi
{

    internal class Okul
    {
        public List<Ogrenci> Ogrenciler = new List<Ogrenci>();

        public void OgrenciEkle(
          int no,
          string ad,
          string soyad,
          DateTime dogumTarihi,
          CINSIYET cinsiyet,
          SUBE sube)
        {
            Ogrenci ogrenci = new Ogrenci();
            ogrenci.AdresEkle("-", "-", "-");
            ogrenci.No = no;
            ogrenci.Ad = ad;
            ogrenci.Soyad = soyad;
            ogrenci.DogumTarihi = dogumTarihi;
            ogrenci.Cinsiyet = cinsiyet;
            ogrenci.Sube = sube;
            this.Ogrenciler.Add(ogrenci);
        }

        public void NotEkle(int ogrenciNo, string ders, int not)
        {
            Ogrenci ogrenci = this.Ogrenciler.Where<Ogrenci>((Func<Ogrenci, bool>)(a => a.No == ogrenciNo)).FirstOrDefault<Ogrenci>();
            if (ogrenci == null)
                return;
            DersNotu dersNotu = new DersNotu(ders, (float)not);
            ogrenci.Notlar.Add(dersNotu);
        }

        public void AdresEkle(int no, string il, string ilce, string mahalle)
        {
            this.Ogrenciler.Where<Ogrenci>((Func<Ogrenci, bool>)(a => a.No == no)).FirstOrDefault<Ogrenci>()?.AdresEkle(il, ilce, mahalle);
        }

        public void KitapEkle(int no, string kitapAdi)
        {
            this.Ogrenciler.Where<Ogrenci>((Func<Ogrenci, bool>)(a => a.No == no)).FirstOrDefault<Ogrenci>()?.KitapEkle(kitapAdi);
        }

        public bool VarMi(int no)
        {
            return this.Ogrenciler.Where<Ogrenci>((Func<Ogrenci, bool>)(a => a.No == no)).FirstOrDefault<Ogrenci>() != null;
        }

        public string AdiSoyadiGetir(int no)
        {
            Ogrenci ogrenci = this.Ogrenciler.Where<Ogrenci>((Func<Ogrenci, bool>)(a => a.No == no)).FirstOrDefault<Ogrenci>();
            string str = "";
            if (ogrenci != null)
                str = ogrenci.Ad + " " + ogrenci.Soyad;
            return str;
        }

        public SUBE SubeGetir(int no)
        {
            Ogrenci ogrenci = this.Ogrenciler.Where<Ogrenci>((Func<Ogrenci, bool>)(a => a.No == no)).FirstOrDefault<Ogrenci>();
            return ogrenci != null ? ogrenci.Sube : SUBE.Empty;
        }

        public List<DersNotu> OgrenciNotlariGetir(int no)
        {
            Ogrenci ogrenci = this.Ogrenciler.Where<Ogrenci>((Func<Ogrenci, bool>)(a => a.No == no)).FirstOrDefault<Ogrenci>();
            return ogrenci != null ? ogrenci.Notlar.ToList<DersNotu>() : (List<DersNotu>)null;
        }

        public List<string> KitapListele(int no)
        {
            Ogrenci ogrenci = this.Ogrenciler.Where<Ogrenci>((Func<Ogrenci, bool>)(a => a.No == no)).FirstOrDefault<Ogrenci>();
            return ogrenci != null && ogrenci.Kitaplar != null ? ogrenci.Kitaplar.ToList<string>() : (List<string>)null;
        }

        public double OrtalamaGetir(int no)
        {
            Ogrenci ogrenci = this.Ogrenciler.Where<Ogrenci>((Func<Ogrenci, bool>)(a => a.No == no)).FirstOrDefault<Ogrenci>();
            return ogrenci != null ? ogrenci.Ortalama : 0.0;
        }

        public List<string> SonKitapGetir(int no)
        {
            Ogrenci ogrenci = this.Ogrenciler.Where<Ogrenci>((Func<Ogrenci, bool>)(a => a.No == no)).FirstOrDefault<Ogrenci>();
            if (ogrenci == null || ogrenci.Kitaplar == null)
                return (List<string>)null;
            List<string> list = ogrenci.Kitaplar.ToList<string>();
            list.Reverse();
            return list.Take<string>(1).ToList<string>();
        }

        public int NoOlustur(int no)
        {
            while (true)
            {
                if (this.VarMi(no))
                    ++no;
                else
                    break;
            }
            return no;
        }

        public void Guncelle(
          int no,
          string isim,
          string soyisim,
          DateTime dogumTarihi,
          CINSIYET cinsiyet,
          SUBE sube)
        {
            Ogrenci ogrenci = this.Ogrenciler.Where<Ogrenci>((Func<Ogrenci, bool>)(a => a.No == no)).FirstOrDefault<Ogrenci>();
            if (ogrenci == null)
                return;
            if (!string.IsNullOrEmpty(isim))
                ogrenci.Ad = isim;
            if (!string.IsNullOrEmpty(soyisim))
                ogrenci.Soyad = soyisim;
            if (dogumTarihi != DateTime.MinValue)
                ogrenci.DogumTarihi = dogumTarihi;
            if (cinsiyet != 0)
                ogrenci.Cinsiyet = cinsiyet;
            if (sube != 0)
                ogrenci.Sube = sube;
        }

        public void OgrenciSil(int no)
        {
            Ogrenci ogrenci = this.Ogrenciler.Where<Ogrenci>((Func<Ogrenci, bool>)(a => a.No == no)).FirstOrDefault<Ogrenci>();
            if (ogrenci == null)
                return;
            this.Ogrenciler.Remove(ogrenci);
        }
    }
}
