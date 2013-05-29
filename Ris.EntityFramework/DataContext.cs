using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.EntityFramework.Configurations;

namespace Rs.Dnevnik.Ris.EntityFramework
{
    public class DataContext : DbContext
    {
        public DataContext() : base("produkcija")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new NovinskeKuceCfg());
            modelBuilder.Configurations.Add(new SektoriCfg());
            modelBuilder.Configurations.Add(new OdeljenjaCfg());
            modelBuilder.Configurations.Add(new RadniciCfg());
            modelBuilder.Configurations.Add(new PublikacijeCfg());
            modelBuilder.Configurations.Add(new RubrikeCfg());
            modelBuilder.Configurations.Add(new OcenaCfg());
            modelBuilder.Configurations.Add(new TipTekstaCfg());
            modelBuilder.Configurations.Add(new RadniNalogCfg());
            modelBuilder.Configurations.Add(new AgencijeCfg());
            modelBuilder.Configurations.Add(new AgencijskeVestiCfg());
            modelBuilder.Configurations.Add(new KonfiguracijaCfg());
            modelBuilder.Entity<RadniListNovinara>().Map(x => x.Requires("TipAktivnosti").HasValue("NT"));
            modelBuilder.Entity<RadniListUrednika>().Map(x => x.Requires("TipAktivnosti").HasValue("UT"));
            modelBuilder.Entity<Konverzija>().ToTable("Konverzija");
            var materijalInfo = modelBuilder.Entity<MaterijalInfo>();
            materijalInfo.ToTable("MaterijalInfo");
            var materijal = modelBuilder.Entity<Materijal>();
            materijal.ToTable("Materijali");
            modelBuilder.Configurations.Add(new TekstCfg());
            modelBuilder.Entity<GrupaMaterijala>().ToTable("GrupeMaterijala");
            modelBuilder.Configurations.Add(new KorisnickiNaloziCfg());
            modelBuilder.Configurations.Add(new UlogeRadnikaCfg());
            modelBuilder.Configurations.Add(new KomentariCfg());
            modelBuilder.Entity<ArhiviranTekst>().ToTable("ArhivaTekstova");
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<NovinskaKuca> NovinskeKuce { get; set; }
        public DbSet<Sektor> Sektori { get; set; }
        public DbSet<Odeljenje> Odeljanja { get; set; }
        public DbSet<Radnik> Radnici { get; set; }
        public DbSet<Publikacija> Publikacije { get; set; }
        public DbSet<Rubrika> Rubrike { get; set; }
        public DbSet<Ocena> Ocene { get; set; }
        public DbSet<TipTeksta> TipoviTeksta { get; set; }
        public DbSet<RadniNalog> RadniNalozi { get; set; }
        public DbSet<Agencija> Agencije { get; set; }
        public DbSet<AgencijskaVest> AgencijskeVesti { get; set; }
        public DbSet<Konfiguracija> Konfiguracija { get; set; }
        public DbSet<Konverzija> Konverzija { get; set; }
        public DbSet<MaterijalInfo> MaterijalInfo { get; set; }
        public DbSet<Materijal> Materijali { get; set; }
        public DbSet<Tekst> Tekstovi { get; set; }
        public DbSet<GrupaMaterijala> GrupeMaterijala { get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalozi { get; set; }
        public DbSet<UlogaRadnika> UlogeRadnika { get; set; }
    }
}