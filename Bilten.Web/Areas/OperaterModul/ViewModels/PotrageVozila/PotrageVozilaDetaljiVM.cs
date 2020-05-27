using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bilten.Web.Areas.OperaterModul.ViewModels.PotrageVozila
{
    public class PotrageVozilaDetaljiVM
    {
        public DateTime DatumPrijave { get; set; }

        public string Prijavitelj { get; set; }

        public string Opis { get; set; }

        public string Lokacija { get; set; }

        public string Napomena { get; set; }

        public bool? Aktivna { get; set; }

        public bool? Obustavljena { get; set; }

        public string Vlasnik { get; set; }

        public string Vozilo { get; set; }

        public string BrRegOznake { get; set; }
    }
}
