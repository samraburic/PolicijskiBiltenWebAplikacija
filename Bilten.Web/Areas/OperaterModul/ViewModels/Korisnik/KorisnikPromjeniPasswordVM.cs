﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bilten.Web.Areas.OperaterModul.ViewModels.Korisnik
{
    public class KorisnikPromjeniPasswordVM
    {
        public int KorisnikId { get; set; }

        public int KorisnickiNalogId { get; set; }
        public string StariPass { get; set; }
        public string NoviPass { get; set; }
        public string NoviPassProvjera { get; set; }
    }
}
