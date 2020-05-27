using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bilten.Web.Areas.OperaterModul.ViewModels.VozilaSlike
{
    public class VozilaSlikeDodajVM
    {
        public int VoziloId { get; set; }

        public IFormFile SlikaVozila { get; set; }
    }
}
