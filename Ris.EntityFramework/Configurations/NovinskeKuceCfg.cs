using System.Data.Entity.ModelConfiguration;
using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.EntityFramework.Configurations
{
    public class NovinskeKuceCfg : EntityTypeConfiguration<NovinskaKuca>
    {
        public NovinskeKuceCfg()
        {
            ToTable("NovinskeKuce");
        }
    }
}