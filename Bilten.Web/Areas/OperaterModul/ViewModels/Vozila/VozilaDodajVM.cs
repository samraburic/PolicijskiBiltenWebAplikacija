using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bilten.Web.Areas.OperaterModul.ViewModels.Vozila
{
    public class VozilaDodajVM
    {
        public string BrojRegistarskeOznake { get; set; }

        public string Boja { get; set; }

        public string TipVozila { get; set; }

        public string Gorivo { get; set; }

        public string Kubikaza { get; set; }

        public int kWSnaga { get; set; }

        public int ksSnaga { get; set; }

        public string EmisioniStandard { get; set; }


        public DateTime GodinaProizvodnje { get; set; }

        public List<SelectListItem> Marka { get; set; }
        public int MarkaId { get; set; }

        public List<SelectListItem> Model { get; set; }
        public int ModelId { get; set; }

        public List<SelectListItem> Osoba { get; set; }
        public int OsobaId { get; set; }
    }
}
