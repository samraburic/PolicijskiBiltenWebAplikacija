using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bilten.Web.Areas.OperaterModul.ViewModels.PotrageVozila
{
    public class PotrageVozilaDodajVM
    {
        public DateTime DatumPrijave { get; set; }

        public string Prijavitelj { get; set; }

        public string Opis { get; set; }

        public string Lokacija { get; set; }

        public bool? Aktivna { get; set; }

        public bool? Obustavljena { get; set; }

        public List<SelectListItem> vozila { get; set; }
    }
}
