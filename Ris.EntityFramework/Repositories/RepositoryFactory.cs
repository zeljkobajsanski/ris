using Rs.Dnevnik.Ris.EntityFramework.Configurations;
using Rs.Dnevnik.Ris.Interfaces.Repositories;

namespace Rs.Dnevnik.Ris.EntityFramework.Repositories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly DataContext fDataContext = new DataContext();

        private readonly NovinskeKuceRepository fNovinskeKuceRepository;
        
        private readonly SektoriRepository fSektoriRepository;

        private readonly OdeljenjaRepository fOdeljenjaRepository;

        private readonly RadniciRepository fRadniciRepository;

        private readonly PublikacijeRepository fPublikacijeRepository;

        private readonly RubrikeRepository fRubrikeRepository;

        private readonly OceneRepository fOceneRepository;

        private readonly TipoviTekstaRepository fTipoviTekstaRepository;

        private readonly RadniNaloziRepository fRadniNaloziRepository;

        private readonly AgencijskeVestiRepository fAgencijskeVestiRepository;

        private readonly AgencijeRepository fAgencijeRepository;

        private readonly KonfiguracijaRepository fKonfiguracijaRepository;

        private readonly KonverzijaRepository fKonverzijaRepository;

        private readonly MaterijalRepository fMaterijalRepository;

        private readonly TekstoviRepository fTekstoviRepository;

        private readonly GrupeMaterijalaRepository fGrupeMaterijalaRepository;

        private readonly KorisnickiNaloziRepository fKorisnickiNaloziRepository;

        private readonly UlogeRadnikaRepository fUlogeRadnikaRepository;

        public RepositoryFactory()
        {
            fNovinskeKuceRepository = new NovinskeKuceRepository(fDataContext);
            fSektoriRepository = new SektoriRepository(fDataContext);
            fOdeljenjaRepository = new OdeljenjaRepository(fDataContext);
            fRadniciRepository = new RadniciRepository(fDataContext);
            fPublikacijeRepository = new PublikacijeRepository(fDataContext);
            fRubrikeRepository = new RubrikeRepository(fDataContext);
            fOceneRepository = new OceneRepository(fDataContext);
            fTipoviTekstaRepository = new TipoviTekstaRepository(fDataContext);
            fRadniNaloziRepository = new RadniNaloziRepository(fDataContext);
            fAgencijskeVestiRepository = new AgencijskeVestiRepository(fDataContext);
            fAgencijeRepository = new AgencijeRepository(fDataContext);
            fKonfiguracijaRepository = new KonfiguracijaRepository(fDataContext);
            fKonverzijaRepository = new KonverzijaRepository(fDataContext);
            fMaterijalRepository = new MaterijalRepository(fDataContext);
            fTekstoviRepository = new TekstoviRepository(fDataContext);
            fGrupeMaterijalaRepository = new GrupeMaterijalaRepository(fDataContext);
            fKorisnickiNaloziRepository = new KorisnickiNaloziRepository(fDataContext);
            fUlogeRadnikaRepository = new UlogeRadnikaRepository(fDataContext);
        }

        public INovinskeKuceRepository NovinskeKuceRepository { get { return fNovinskeKuceRepository; } }

        public ISektoriRepository SektoriRepository { get { return fSektoriRepository; } }

        public IOdeljenjaRepository OdeljenjaRepository { get { return fOdeljenjaRepository; } }

        public IRadniciRepository RadniciRepository { get { return fRadniciRepository; } }

        public IPublikacijeRepository PublikacijeRepository { get { return fPublikacijeRepository; } }

        public IRubrikeRepository RubrikeRepository { get { return fRubrikeRepository; } }

        public ITipoviTekstovaRepository TipoviTekstovaRepository { get { return fTipoviTekstaRepository; } }

        public IOceneRepository OceneRepository { get { return fOceneRepository; } }

        public IRadniNaloziRepository RadniNaloziRepository { get { return fRadniNaloziRepository; } }

        public IAgencijskeVestiRepository AgencijskeVestiRepository { get { return fAgencijskeVestiRepository; } }

        public IAgencijeRepository AgencijeRepository { get { return fAgencijeRepository; } }

        public IKonfiguracijaRepository KonfiguracijaRepository { get { return fKonfiguracijaRepository; } }

        public IKonverzijaRepository KonverzijaRepository { get { return fKonverzijaRepository; } }

        public IMaterijalRepository MaterijalRepository { get { return fMaterijalRepository; } }

        public ITekstoviRepository TekstoviRepository { get { return fTekstoviRepository; } }

        public IGrupeMaterijalaRepository GrupeMaterijalaRepository { get { return fGrupeMaterijalaRepository; } }

        public IKorisnickiNaloziRepository KorisnickiNaloziRepository { get { return fKorisnickiNaloziRepository; } }

        public IUlogeRadnikaRepository UlogeRadnikaRepository { get { return fUlogeRadnikaRepository; } }

        public void Dispose()
        {
            fDataContext.Dispose();
        }
    }
}