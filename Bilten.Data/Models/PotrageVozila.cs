using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bilten.Data.Models
{
    public class PotrageVozila
    {
        [Key]
        public int Id { get; set; }

        public DateTime DatumPrijave { get; set; }

        public string Prijavitelj { get; set; }

        public string Opis { get; set; }

        public string Lokacija { get; set; }

        public bool? Aktivna { get; set; }

        public bool? Obustavljena { get; set; }

        public string Napomena { get; set; }

        [ForeignKey(nameof(VoziloId))]
        public Vozila Vozila { get; set; }
        public int VoziloId { get; set; }
    }
}
