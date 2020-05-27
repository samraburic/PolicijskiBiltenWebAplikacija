using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bilten.Web.Areas.OperaterModul.ViewModels.PotrageVozila
{
    public class PotrageVozilaIndexVM
    {
        public List<Row> Rows { get; set; }

        public class Row
        {
            public int Id { get; set; }

            public DateTime DatumPrijave { get; set; }

            public string Prijavitelj { get; set; }

            public string Opis { get; set; }

            public string Lokacija { get; set; }

            public bool? Aktivna { get; set; }

            public bool? Obustavljena { get; set; }

            public string Vozilo { get; set; }

        }
    }
}
