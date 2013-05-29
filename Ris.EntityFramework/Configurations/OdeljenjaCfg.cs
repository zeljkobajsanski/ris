using System.Data.Entity.ModelConfiguration;
using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.EntityFramework.Configurations
{
    public class OdeljenjaCfg : EntityTypeConfiguration<Odeljenje>
    {
        public OdeljenjaCfg()
        {
            ToTable("Odeljanja");
        }
    }
}