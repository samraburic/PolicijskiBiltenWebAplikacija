﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bilten.Web.Areas.AdministratorModul.ViewModels.Vrste
{
    public class VrsteIndexVM
    {
        public List<Row> Rows { get; set; }

        public class Row { 
        public int KategorijeId { get; set; }

        public string NazivKategorije { get; set; }
        }

    }
}
