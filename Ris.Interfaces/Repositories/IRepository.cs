using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.Interfaces.Repositories
{
    public interface IRepository
    {
        void Save();
        void Add<T>(T entity) where T : Entity;
        void Remove<T>(T entity) where T : Entity;
        void MarkUnchanged(Entity entity);
        bool AutoDetectChangesEnabled { get; set; }
    }
}