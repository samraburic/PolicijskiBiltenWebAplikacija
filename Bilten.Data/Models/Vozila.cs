using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bilten.Data.Models
{
    public class Vozila
    {
        [Key]
        public int Id { get; set; }

        public string BrojRegistarskeOznake { get; set; }

        public string Boja { get; set; }

        public string TipVozila { get; set; }

        public string Gorivo { get; set; }

        public string Kubikaza { get; set; }

        public int kWSnaga { get; set; }

        public int ksSnaga { get; set; }

        public string EmisioniStandard { get; set; }


        public DateTime GodinaProizvodnje { get; set; }

        [ForeignKey(nameof(MarkaId))]
        public Marka Marka{ get; set; }
        public int MarkaId { get; set; }


        [ForeignKey(nameof(ModelId))]
        public ModelVozila Model { get; set; }
        public int ModelId { get; set; }

        [ForeignKey(nameof(OsobaId))]
        public Osoba Osoba { get; set; }
        public int OsobaId { get; set; }
    }
}
