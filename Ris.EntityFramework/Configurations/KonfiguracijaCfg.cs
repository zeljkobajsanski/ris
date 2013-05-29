using System.Data.Entity.ModelConfiguration;
using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.EntityFramework.Configurations
{
    public class KonfiguracijaCfg : EntityTypeConfiguration<Konfiguracija>
    {
        public KonfiguracijaCfg()
        {
            ToTable("Konfiguracija");
        }
    }
}