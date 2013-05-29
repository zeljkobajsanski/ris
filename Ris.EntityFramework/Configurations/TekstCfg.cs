using System.Data.Entity.ModelConfiguration;
using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.EntityFramework.Configurations
{
    public class TekstCfg : EntityTypeConfiguration<Tekst>
    {
        public TekstCfg()
        {
            ToTable("Tekstovi");
            HasMany(x => x.Materijali).WithMany().Map(m => m.ToTable("MaterijaliTekstova"));
            HasRequired(x => x.Rubrika).WithMany().WillCascadeOnDelete(false);
            HasMany(x => x.Komentari).WithRequired(x => x.Tekst).WillCascadeOnDelete(false);
            HasMany(x => x.ArhiviraniTekstovi).WithRequired(x => x.Tekst).WillCascadeOnDelete(false);
            Ignore(x => x.BrojKomentara);
        }
    }
}