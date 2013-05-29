using System.Data.Entity.ModelConfiguration;
using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.EntityFramework.Configurations
{
    public class KorisnickiNaloziCfg : EntityTypeConfiguration<KorisnickiNalog>
    {
        public KorisnickiNaloziCfg()
        {
            ToTable("KorisnickiNalozi");
            Ignore(x => x.LozinkaPlain);
        }
    }
}