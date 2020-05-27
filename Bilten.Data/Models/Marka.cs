using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bilten.Data.Models
{
    public class Marka
    {
        [Key]
        public int Id { get; set; }

        public string Naziv { get; set; }
    }
}
