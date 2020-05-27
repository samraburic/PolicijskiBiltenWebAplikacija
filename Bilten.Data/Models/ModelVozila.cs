using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bilten.Data.Models
{
    public class ModelVozila
    {
        public int Id { get; set; }

        public string Naziv { get; set; }

        [ForeignKey(nameof(MarkaId))]
        public Marka Marka { get; set; }
        public int MarkaId { get; set; }
    }
}
