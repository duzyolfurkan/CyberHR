using FabrikaHR.Models;
using FabrikaHR.Models.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Linq;
using System.Net.Mail;

namespace FabrikaHR.Controllers
{
    public class YoneticiController : Controller
    {
        //Veritabanı bağlantısı
        Context db = new Context();


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PersonelEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PersonelEkle(User user)
        {
            user.IseGirisTarihi = DateTime.Now;
            user.CalismaStatusu = "Aktif";
            user.KullaniciTipi = "Personel";
            user.MailAdresi = $"{user.PersonelAdi}.{user.PersonelSoyadi}@cyberhr.com.tr";

            db.Users.Add(user);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult PersonelleriListele()
        {
            var personelListesi = db.Users.ToList();
            return View(personelListesi);
        }

        public IActionResult PersonelSil(int id)
        {
            var secilenPersonel = db.Users.Find(id);
            db.Users.Remove(secilenPersonel);
            db.SaveChanges();
            return RedirectToAction("PersonelleriListele");
        }

        public IActionResult PersonelStatuDegistir(int id)
        {
            var secilenPersonel = db.Users.Find(id);

            if (secilenPersonel.CalismaStatusu == "Aktif")
            {
                secilenPersonel.CalismaStatusu = "Pasif";
                db.SaveChanges();
            }
            else if (secilenPersonel.CalismaStatusu == "Pasif")
            {
                secilenPersonel.CalismaStatusu = "Aktif";
                db.SaveChanges();
            }

            return RedirectToAction("PersonelleriListele");
        }

        public IActionResult PersonelGetir(int id)
        {
            var secilenPersonel = db.Users.Find(id);
            return View(secilenPersonel);
        }

        [HttpPost]
        public IActionResult PersonelGuncelle(User user)
        {
            var secilenPersonel = db.Users.Find(user.UserID);
            secilenPersonel.PersonelAdi = user.PersonelAdi;
            secilenPersonel.PersonelSoyadi = user.PersonelSoyadi;
            secilenPersonel.KullaniciAdi = user.KullaniciAdi;
            secilenPersonel.Sifre = user.Sifre;
            secilenPersonel.DogumTarihi = user.DogumTarihi;
            secilenPersonel.DogumYeri = user.DogumYeri;
            secilenPersonel.TelefonNumarasi = user.TelefonNumarasi;
            secilenPersonel.Adres = user.Adres;
            secilenPersonel.Departman = user.Departman;
            secilenPersonel.Iletisim = user.Iletisim;

            db.SaveChanges();
            return RedirectToAction("PersonelleriListele");
        }


        public IActionResult PersonelBilgileriniGonder(int id)
        {
            var secilenPersonel = db.Users.Find(id);

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp-mail.outlook.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("cyberhumanresources@outlook.com", "cyber1361*");

            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("cyberhumanresources@outlook.com", "CYBER HR");
            ePosta.To.Add(secilenPersonel.Iletisim);
            ePosta.Subject = "CYBER-HR Kullanıcı Bilgileriniz";
            ePosta.Body = $"Sayın {secilenPersonel.PersonelAdi} {secilenPersonel.PersonelSoyadi} CYBER-HR Kullanıcı Adınız: {secilenPersonel.KullaniciAdi}, şifreniz {secilenPersonel.Sifre}'dir.";

            smtp.Send(ePosta);

            return RedirectToAction("Index");
        }

        public IActionResult AvanslariListele()
        {
            var avanslar = db.Avanses.ToList();
            return View(avanslar);
        }

        public IActionResult AvansOnayla(int id)
        {
            var onaylanacakAvans = db.Avanses.Find(id);
            onaylanacakAvans.OnayDurumu = "Onaylandi";
            onaylanacakAvans.CevaplanmaTarihi = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("AvanslariListele");
        }

        public IActionResult AvansReddet(int id)
        {
            var reddedilecekAvans = db.Avanses.Find(id);
            reddedilecekAvans.OnayDurumu = "Reddedildi";
            reddedilecekAvans.CevaplanmaTarihi = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("AvanslariListele");

        }

        public IActionResult AvansBeklet(int id)
        {
            var bekletilecekAvans = db.Avanses.Find(id);
            bekletilecekAvans.OnayDurumu = "Beklemede";
            bekletilecekAvans.CevaplanmaTarihi = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("AvanslariListele");
        }

        public IActionResult HarcamalariListele()
        {
            var harcamalar = db.Harcamas.ToList();
            return View(harcamalar);
        }

        public IActionResult HarcamaOnayla(int id)
        {
            var onaylanacakHarcama = db.Harcamas.Find(id);
            onaylanacakHarcama.OnayDurumu = "Onaylandi";
            onaylanacakHarcama.CevaplanmaTarihi = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("HarcamalariListele");
        }

        public IActionResult HarcamaReddet(int id)
        {
            var reddedilecekHarcama = db.Harcamas.Find(id);
            reddedilecekHarcama.OnayDurumu = "Reddedildi";
            reddedilecekHarcama.CevaplanmaTarihi = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("HarcamalariListele");
        }

        public IActionResult HarcamaBeklet(int id)
        {
            var bekletilecekHarcama = db.Harcamas.Find(id);
            bekletilecekHarcama.OnayDurumu = "Beklemede";
            bekletilecekHarcama.CevaplanmaTarihi = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("HarcamalariListele");
        }

    }
}
