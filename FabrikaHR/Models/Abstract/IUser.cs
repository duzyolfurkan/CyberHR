using System;

namespace FabrikaHR.Models.Abstract
{
    public interface IUser
    {
        int UserID { get; set; }
        string KullaniciTipi { get; set; }
        string PersonelAdi { get; set; }
        string PersonelSoyadi { get; set; }
        string KullaniciAdi { get; set; }
        string Sifre { get; set; }
        string DogumTarihi { get; set; }
        string DogumYeri { get; set; }
        DateTime IseGirisTarihi { get; set; }
        byte[] Fotograf { get; set; }
        string MailAdresi { get; set; }
        string TelefonNumarasi { get; set; }
        string Iletisim { get; set; }
        string Adres { get; set; }
        string Departman { get; set; }
        string CalismaStatusu { get; set; }

    }
}
