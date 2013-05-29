using System.Data;
using System.Data.Entity.Infrastructure;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Interfaces.Repositories;

namespace Rs.Dnevnik.Ris.EntityFramework.Repositories
{
    public abstract class RepositoryBase : IRepository
    {
        protected DataContext DataContext;

        protected RepositoryBase() : this(new DataContext())
        {
        }

        protected RepositoryBase(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public bool AutoDetectChangesEnabled
        {
            get { return DataContext.Configuration.AutoDetectChangesEnabled; }
            set { DataContext.Configuration.AutoDetectChangesEnabled = value; }
        }


        public void Save()
        {
            DataContext.SaveChanges();
        }

        public abstract void Add<T>(T entity) where T : Entity;
        
        public void Remove<T>(T entity) where T : Entity
        {
            if (entity.ID == 0) return;
            DataContext.Entry(entity).State = EntityState.Deleted;
        }

        public void MarkUnchanged(Entity entity)
        {
            DataContext.Entry(entity).State = EntityState.Unchanged;
        }
    }
}