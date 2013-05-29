using System.Data.Entity.ModelConfiguration;
using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.EntityFramework.Configurations
{
    public class RadniNalogCfg : EntityTypeConfiguration<RadniNalog>
    {
        public RadniNalogCfg()
        {
            ToTable("RadniNalozi");
            HasRequired(x => x.Rubrika).WithMany().WillCascadeOnDelete(false);
            Ignore(x => x.TipAktivnosti);
            //Map<RadniListNovinara>(x => x.Requires("TipAktivnosti").HasValue("NT"));
            //Map<RadniListUrednika>(x => x.Requires("TipAktivnosti").HasValue("UT")); //.ToTable("RadniNalozi");
        }
    }
}