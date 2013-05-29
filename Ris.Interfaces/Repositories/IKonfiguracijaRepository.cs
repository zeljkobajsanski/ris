using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.Interfaces.Repositories
{
    public interface IKonfiguracijaRepository : IRepository
    {
        Konfiguracija VratiKonfiguraciju();
    }
}