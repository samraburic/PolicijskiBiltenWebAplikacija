using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bilten.Data.Models
{
    public class Osoba
    {
        [Key]
        public int Id { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public DateTime DatumRodjenja { get; set; }

        public string JMBG { get; set; }

        public string BrojLicneKarte { get; set; }

        public string MjestoRodjenja { get; set; }
        
    }
}
