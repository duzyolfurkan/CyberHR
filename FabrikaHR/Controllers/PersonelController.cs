using FabrikaHR.Models;
using FabrikaHR.Models.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FabrikaHR.Controllers
{
    public class PersonelController : Controller
    {
        Context db = new Context();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AvansTalebiGir()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AvansTalebiGir(Avans avans)
        {
            avans.TalepTarihi = DateTime.Now;
            avans.OnayDurumu = "Beklemede";
            db.Avanses.Add(avans);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult AvanslariListele()
        {
            var avanslar = db.Avanses.ToList();
            return View(avanslar);
        }

        [HttpGet]
        public IActionResult HarcamaTalebiOlustur()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HarcamaTalebiOlustur(Harcama harcama)
        {
            harcama.TalepTarihi = DateTime.Now;
            harcama.OnayDurumu = "Beklemede";
            db.Harcamas.Add(harcama);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult HarcamalariListele(int id)
        {
            var harcamalar = db.Harcamas.ToList();
            return View(harcamalar);
        }
    }
}
