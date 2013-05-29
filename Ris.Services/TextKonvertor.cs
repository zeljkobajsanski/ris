using System.Text.RegularExpressions;
using Rs.Dnevnik.Ris.Interfaces.Repositories;
using Rs.Dnevnik.Ris.Interfaces.Services;

namespace Ris.Services
{
    public class TextKonvertor : ITextKonvertor
    {
        private readonly IRepositoryFactory fRepositoryFactory;

        public TextKonvertor(IRepositoryFactory fRepositoryFactory)
        {
            this.fRepositoryFactory = fRepositoryFactory;
        }

        public string Konvertuj(string tekst)
        {
            if (string.IsNullOrEmpty(tekst)) return tekst;
            var sabloni = fRepositoryFactory.KonverzijaRepository.VratiSabloneKonverzije();
            foreach (var sablon in sabloni)
            {
                tekst = tekst.Replace(sablon.Sablon, sablon.KonverovaniString);
            }
            return tekst;
        }
    }
}