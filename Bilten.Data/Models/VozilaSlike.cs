using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bilten.Data.Models
{
    public class VozilaSlike
    {
        public int Id { get; set; }

        [ForeignKey(nameof(VoziloId))]
        public Vozila Vozila { get; set; }
        public int VoziloId { get; set; }
        public string SlikaPath { get; set; }

    }
}
