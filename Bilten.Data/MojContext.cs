﻿using Bilten.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bilten.Data
{
    public class MojContext:DbContext
    {
        public MojContext(DbContextOptions<MojContext> options)
         : base(options)
        {
        }

        public DbSet<Kategorije> Kategorije { get; set; }
        public DbSet<Vrste> Vrste { get; set; }
        public DbSet<Mjere> Mjere { get; set; }
        public DbSet<Korisnici> Korisnici{ get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
        public DbSet<VrstaKorisnika> VrstaKorisnika { get; set; }
        public DbSet<OrganizacionaJedinica> OrganizacionaJedinica { get; set; }
        public DbSet<PodorganizacionaJedinica> PodorganizacionaJedinica { get; set; }
        public DbSet<Dogadjaj> Dogadjaj{ get; set; }
        public DbSet<DogadjajiMjere> DogadjajiMjere { get; set; }

        public DbSet<Vozila> Vozila { get; set; }

        public DbSet<Osoba> Osoba { get; set; }

        public DbSet<Marka> Marka { get; set; }

        public DbSet<ModelVozila> ModelVozila { get; set; }

        public DbSet<SaobracajDetalji> SaobracajDetalji { get; set; }


        public DbSet<VozilaSlike> VozilaSlike { get; set; }


        public DbSet<PotrageVozila> PotrageVozila { get; set; }

    }
}
