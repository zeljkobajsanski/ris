using System.Data.Entity.ModelConfiguration;
using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.EntityFramework.Configurations
{
    public class AgencijeCfg : EntityTypeConfiguration<Agencija>
    {
        public AgencijeCfg()
        {
            ToTable("Agencije");
        }
    }
}