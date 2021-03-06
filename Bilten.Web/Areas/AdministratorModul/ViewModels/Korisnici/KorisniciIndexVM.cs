﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bilten.Web.Areas.AdministratorModul.ViewModels.Korisnici
{
    public class KorisniciIndexVM
    {
        public List<Row> Rows { get; set; }

        public class Row
        {
            public int KorisnikId { get; set; }

            public int KorisnickiNalogId { get; set; }

            public string ImePrezime { get; set; }

            public int JMBG { get; set; }

            public string email { get; set; }

            public string username { get; set; }

            public string vrstaZaposlenika { get; set; }

            public string password { get; set; }
        }
    }
}
