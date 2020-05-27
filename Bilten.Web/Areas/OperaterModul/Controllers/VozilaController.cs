using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bilten.Data;
using Bilten.Data.Models;
using Bilten.Web.Areas.OperaterModul.ViewModels.Vozila;
using Bilten.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bilten.Web.Areas.OperaterModul.Controllers
{
    [Area("OperaterModul")]
    public class VozilaController : Controller
    {

        private readonly MojContext _context;

        public VozilaController(MojContext db)
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

            VozilaIndexVM model = new VozilaIndexVM()
            {
                Rows = _context.Vozila.Select(x => new VozilaIndexVM.Row
                {
                    VoziloId = x.Id,
                    Marka = x.Marka.Naziv,
                    Model = x.Model.Naziv,
                    BrojRegistarskeOznake = x.BrojRegistarskeOznake,
                    GodinaProizvodnje = x.GodinaProizvodnje,
                    Gorivo = x.Gorivo,
                    Boja = x.Boja,
                    EmisioniStandard = x.EmisioniStandard,
                    Vlasnik = x.Osoba.Ime + " " + x.Osoba.Prezime
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

            VozilaDodajVM model = _context.Vozila.Select(x => new VozilaDodajVM
            {
                MarkaId = x.MarkaId,
                Marka = _context.Marka.Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Naziv
                }).ToList(),

                Osoba = _context.Osoba.Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Ime + " " + s.Prezime
                }).ToList(),

                Model = _context.ModelVozila.Select(z => new SelectListItem
                {
                    Value = z.Id.ToString(),
                    Text = z.Naziv
                }).ToList()

            }).FirstOrDefault();

            return View(model);
        }

        public IActionResult Snimi(int markaId, int modelId, int osobaId, DateTime godinaProizvodnje,
            string brRegOznake, string boja, string tipVozila, string gorivo, 
            string kubikaza, int kWSnaga, int ksSnaga, string emisionStandard)
        {
            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            Korisnici k = _context.Korisnici.Where(x => x.KorisnickiNalogId == korisnik.Id).FirstOrDefault();
            if (korisnik == null || k.VrstaKorisnikaId != 2)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa!";
                return Redirect("/Autentifikacija/Index");
            }

            Vozila novi = new Vozila();
            novi.MarkaId = markaId;
            novi.ModelId = modelId;
            novi.OsobaId = osobaId;
            novi.GodinaProizvodnje = godinaProizvodnje;
            novi.BrojRegistarskeOznake = brRegOznake;
            novi.Boja = boja;
            novi.TipVozila = tipVozila;
            novi.Gorivo = gorivo;
            novi.Kubikaza = kubikaza;
            novi.kWSnaga = kWSnaga;
            novi.ksSnaga = ksSnaga;
            novi.EmisioniStandard = emisionStandard;

           
            _context.Vozila.Add(novi);
            _context.SaveChanges();

            

            return Redirect("/OperaterModul/Vozila/Index");

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

            VozilaDetaljiVM model = _context.Vozila.Where(x => x.Id == id).Select(x => new VozilaDetaljiVM
            {
                Marka = x.Marka.Naziv,
                ModelVozila = x.Model.Naziv,
                BrojRegistarskeOznake = x.BrojRegistarskeOznake,
                Boja = x.Boja,
                GodinaProizvodnje = x.GodinaProizvodnje, //Samo godina
                TipVozila = x.TipVozila,
                Gorivo = x.Gorivo,
                Kubikaza = x.Kubikaza,
                kWSnaga = x.kWSnaga,
                ksSnaga = x.ksSnaga,
                EmisioniStandard = x.EmisioniStandard,
                Vlasnik = x.Osoba.Ime + " " + x.Osoba.Prezime


            }).FirstOrDefault();

            return View(model);

        }

    }
}