using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bilten.Web.Areas.OperaterModul.ViewModels.Vozila
{
    public class VozilaIndexVM
    {
        public List<Row> Rows { get; set; }

        public class Row
        {
            public int VoziloId { get; set; }

            public string Marka { get; set; }

            public string Model { get; set; }   

            public string Vlasnik { get; set; }

            public string BrojRegistarskeOznake { get; set; }

            public string Boja { get; set; }

            public string TipVozila { get; set; }

            public string Gorivo { get; set; }

            public string Kubikaza { get; set; }

            public int kWSnaga { get; set; }

            public int ksSnaga { get; set; }

            public string EmisioniStandard { get; set; }


            public DateTime GodinaProizvodnje { get; set; }

            

        }
    }
}
