using FabrikaHR.Models;
using FabrikaHR.Models.Concrate;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FabrikaHR.Controllers
{
    public class LoginController : Controller
    {
        //Veritanabı bağlantısı
        Context db = new Context();

        [HttpGet]
        public IActionResult GirisYap()
        {
            return View();
        }

        public async Task<IActionResult> GirisYap(User user)
        {
                var girisYapanKullaniciBilgisi = db.Users.Where(x => x.KullaniciAdi == user.KullaniciAdi && x.Sifre == user.Sifre).FirstOrDefault();
                ViewBag.adSoyad = $"{girisYapanKullaniciBilgisi.PersonelAdi} {girisYapanKullaniciBilgisi.PersonelSoyadi}";


            if (girisYapanKullaniciBilgisi != null && girisYapanKullaniciBilgisi.KullaniciTipi == "Personel")
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.KullaniciAdi)
                };

                    var userIdentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Personel");
                }

            if (girisYapanKullaniciBilgisi != null && girisYapanKullaniciBilgisi.KullaniciTipi == "Yönetici")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.KullaniciAdi)
                };

                var userIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Yonetici");
            }

            return View();
        }
    }
}
