using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bilten.Data;
using Bilten.Data.Models;
using Bilten.Web.Areas.OperaterModul.ViewModels.VozilaSlike;
using Bilten.Web.Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bilten.Web.Areas.OperaterModul.Controllers
{
    [Area("OperaterModul")]
    public class VozilaSlikeController : Controller
    {

        private MojContext _context;
        private readonly IHostingEnvironment he;

        public VozilaSlikeController(MojContext context, IHostingEnvironment e)
        {
            _context = context;
            he = e;
        }

        public IActionResult Index(int voziloId)
        {
            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            Korisnici k = _context.Korisnici.Where(x => x.KorisnickiNalogId == korisnik.Id).FirstOrDefault();
            if (korisnik == null || k.VrstaKorisnikaId != 2)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa!";
                return Redirect("/Autentifikacija/Index");
            }

            List<VozilaSlike> vozilaSlike = _context.VozilaSlike.Where(x => x.VoziloId == voziloId).ToList();


            return View(vozilaSlike);
        }

        public IActionResult Dodaj(int voziloId)
        {
            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            Korisnici k = _context.Korisnici.Where(x => x.KorisnickiNalogId == korisnik.Id).FirstOrDefault();
            if (korisnik == null || k.VrstaKorisnikaId != 2)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa!";
                return Redirect("/Autentifikacija/Index");
            }

            VozilaSlikeDodajVM model = _context.Vozila.Where(x=>x.Id == voziloId).Select(x => new VozilaSlikeDodajVM
            {
                VoziloId = voziloId

            }).FirstOrDefault();


            return View(model);

        }

        public IActionResult Snimi(int voziloId,  IFormFile SlikaVozila)
        {
            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            Korisnici k = _context.Korisnici.Where(x => x.KorisnickiNalogId == korisnik.Id).FirstOrDefault();
            if (korisnik == null || k.VrstaKorisnikaId != 2)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa!";
                return Redirect("/Autentifikacija/Index");
            }

            VozilaSlike novi = new VozilaSlike();
            novi.VoziloId = voziloId;
            

            string uniqueFileName = null;
            if (SlikaVozila != null)
            {
                string uploadsFolder = Path.Combine(he.WebRootPath, "Vozila");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + SlikaVozila.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                SlikaVozila.CopyTo(new FileStream(filePath, FileMode.Create));

                novi.SlikaPath = uniqueFileName;
            }


            _context.VozilaSlike.Add(novi);
            _context.SaveChanges();


            return Redirect("/OperaterModul/Vozila/Detalji?=" + voziloId);

        }



    }
}