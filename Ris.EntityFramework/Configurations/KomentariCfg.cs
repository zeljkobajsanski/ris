using System.Data.Entity.ModelConfiguration;
using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.EntityFramework.Configurations
{
    public class KomentariCfg : EntityTypeConfiguration<Komentar>
    {
        public KomentariCfg()
        {
            ToTable("Komentari");
            //HasRequired(x => x.Tekst).WithMany().WillCascadeOnDelete(false);
        }
    }
}