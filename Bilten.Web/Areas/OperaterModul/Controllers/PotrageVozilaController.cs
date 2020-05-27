using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bilten.Data;
using Bilten.Data.Models;
using Bilten.Web.Areas.OperaterModul.ViewModels.PotrageVozila;
using Bilten.Web.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Bilten.Web.Areas.OperaterModul.Controllers
{
    [Area("OperaterModul")]
    public class PotrageVozilaController : Controller
    {

        private readonly MojContext _context;

        public PotrageVozilaController(MojContext db)
        {
            _context = db;
        }

        public IActionResult Index()
        {
            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            Korisnici k = _context.Korisnici.Where(x => x.KorisnickiNalogId == korisnik.Id).FirstOrDefault();
            if (korisnik == null || k.VrstaKorisnikaId != 2)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa!";
                return Redirect("/Autentifikacija/Index");
            }

            PotrageVozilaIndexVM model = new PotrageVozilaIndexVM()
            {
                Rows = _context.PotrageVozila.Select(x => new PotrageVozilaIndexVM.Row
                {
                    Id = x.Id,
                    DatumPrijave = x.DatumPrijave,
                    Lokacija = x.Lokacija,
                    Prijavitelj = x.Prijavitelj,
                    Opis = x.Opis,
                    Vozilo = x.Vozila.Marka.Naziv + " " + x.Vozila.Model.Naziv,
                    Aktivna = x.Aktivna,
                    Obustavljena = x.Obustavljena
                    
                }).ToList()
            };

            return View(model);
        }

        public IActionResult Dodaj()
        {
            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            Korisnici k = _context.Korisnici.Where(x => x.KorisnickiNalogId == korisnik.Id).FirstOrDefault();
            if (korisnik == null || k.VrstaKorisnikaId != 2)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa!";
                return Redirect("/Autentifikacija/Index");
            }

            PotrageVozilaDodajVM model = new PotrageVozilaDodajVM();

            model.vozila = _context.Vozila.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Marka.Naziv + " " + x.Model.Naziv + " - " + x.BrojRegistarskeOznake
            }).ToList();

            return View(model);
        }

        public IActionResult Snimi(DateTime datumprijave, string prijavitelj, string lokacija, string opis, int voziloId)
        {
            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            Korisnici k = _context.Korisnici.Where(x => x.KorisnickiNalogId == korisnik.Id).FirstOrDefault();
            if (korisnik == null || k.VrstaKorisnikaId != 2)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa!";
                return Redirect("/Autentifikacija/Index");
            }

            PotrageVozila novi = new PotrageVozila();

            novi.DatumPrijave = datumprijave;
            novi.Lokacija = lokacija;
            novi.Opis = opis;
            novi.Prijavitelj = prijavitelj;
            novi.VoziloId = voziloId;
            novi.Aktivna = true;
            novi.Obustavljena = false;

            _context.PotrageVozila.Add(novi);
            _context.SaveChanges();

            return Redirect("/OperaterModul/PotrageVozila/Index");
        }

        public IActionResult Detalji(int id)
        {
            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            Korisnici k = _context.Korisnici.Where(x => x.KorisnickiNalogId == korisnik.Id).FirstOrDefault();
            if (korisnik == null || k.VrstaKorisnikaId != 2)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa!";
                return Redirect("/Autentifikacija/Index");
            }

            PotrageVozilaDetaljiVM model = _context.PotrageVozila.Where(x => x.Id == id).Select(x => new PotrageVozilaDetaljiVM
            {
                Prijavitelj = x.Prijavitelj,
                DatumPrijave = x.DatumPrijave,
                Opis = x.Opis,
                BrRegOznake = x.Vozila.BrojRegistarskeOznake,
                Vozilo = x.Vozila.Marka.Naziv + " " + x.Vozila.Model.Naziv,
                Vlasnik = x.Vozila.Osoba.Ime + " " + x.Vozila.Osoba.Prezime,
                Lokacija = x.Lokacija,
                Napomena = x.Napomena,
                Aktivna = x.Aktivna,
                Obustavljena = x.Obustavljena
                

            }).FirstOrDefault();

            return View(model);

        }

        public IActionResult Uredi(int id)
        {
            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            Korisnici k = _context.Korisnici.Where(x => x.KorisnickiNalogId == korisnik.Id).FirstOrDefault();
            if (korisnik == null || k.VrstaKorisnikaId != 2)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa!";
                return Redirect("/Autentifikacija/Index");
            }

            PotrageVozilaUrediVM model = _context.PotrageVozila.Where(x => x.Id == id).Select(x => new PotrageVozilaUrediVM()
            {
                Id = x.Id,
                Aktivna = x.Aktivna,
                DatumPrijave = x.DatumPrijave,
                Lokacija = x.Lokacija,
                Obustavljena = x.Obustavljena,
                Opis = x.Opis,
                Prijavitelj = x.Prijavitelj,
                VoziloId = x.VoziloId,
                Vozilo = x.Vozila.Marka.Naziv + " " + x.Vozila.Model.Naziv + " - " + x.Vozila.BrojRegistarskeOznake
            }).FirstOrDefault();

            model.vozila = _context.Vozila.Where(x=>x.Id != model.VoziloId).Select(a => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Marka.Naziv + " " + a.Model.Naziv + " - " + a.BrojRegistarskeOznake
            }).ToList();

            return View(model);
        }
    }
}