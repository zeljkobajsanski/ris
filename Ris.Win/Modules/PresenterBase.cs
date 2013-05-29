using Rs.Dnevnik.Ris.Interfaces.Repositories;
using Rs.Dnevnik.Ris.Win.IoC;
using Ninject;

namespace Rs.Dnevnik.Ris.Win.Modules
{
    public class PresenterBase
    {
        protected IRepositoryFactory RepositoryFactory = Container.GetKernel().Get<IRepositoryFactory>();

        public virtual void OnLoad()
        {
        }

        public virtual bool Sacuvaj()
        {
            return false;
        }

        public virtual void Novi() {}

        public virtual void Osvezi() {}

        public virtual void Otvori() {}

        public virtual void Stampaj()
        {
        }

        public virtual void OnClose()
        {
            RepositoryFactory.Dispose();
        }
    }
}