﻿using System.Data.Entity.ModelConfiguration;
using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.EntityFramework.Configurations
{
    public class TipTekstaCfg : EntityTypeConfiguration<TipTeksta>
    {
        public TipTekstaCfg()
        {
            ToTable("TipoviTekstova");
        }
    }
}