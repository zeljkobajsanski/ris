using System.Data.Entity.ModelConfiguration;
using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.EntityFramework.Configurations
{
    public class RadniciCfg : EntityTypeConfiguration<Radnik>
    {
        public RadniciCfg()
        {
            ToTable("Radnici");
            Ignore(x => x.SortOrder);
            HasMany(x => x.UlogeRadnika).WithMany().Map(x => x.ToTable("Radnici_Uloge"));
        }
    }
}