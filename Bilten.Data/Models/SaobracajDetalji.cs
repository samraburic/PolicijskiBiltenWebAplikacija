using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bilten.Data.Models
{
    public class SaobracajDetalji
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(DogadjajId))]
        public Dogadjaj Dogadjaj { get; set; }
        public int DogadjajId { get; set; }

        [ForeignKey(nameof(VoziloId))]
        public Vozila Vozila { get; set; }
        public int VoziloId { get; set; }
    }
}
