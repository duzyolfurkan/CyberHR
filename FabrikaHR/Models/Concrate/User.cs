using FabrikaHR.Models.Abstract;
using System;
using System.Collections.Generic;

namespace FabrikaHR.Models.Concrate
{
    public class User : IUser
    {
        public int UserID { get; set; }
        public string KullaniciTipi { get; set; }
        public string PersonelAdi { get; set; }
        public string PersonelSoyadi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string DogumTarihi { get; set; }
        public string DogumYeri { get; set; }
        public DateTime IseGirisTarihi { get; set; }
        public byte[] Fotograf { get; set; }
        public string MailAdresi { get; set; }
        public string TelefonNumarasi { get; set; }
        public string Adres { get; set; }
        public string Departman { get; set; }
        public string CalismaStatusu { get; set; }
        public string Iletisim { get; set; }

        //Avans tablosu ile bağlantı
        public List<Avans> Avanses { get; set; }

        //Harcama tablosu ile bağlantı
        public List<Harcama> Harcamas { get; set; }
    }
}
