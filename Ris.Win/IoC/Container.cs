using Ninject;
using Rs.Dnevnik.Ris.EntityFramework.Repositories;
using Rs.Dnevnik.Ris.Interfaces.Repositories;
using Rs.Dnevnik.Ris.Win.Modules.IzvestajRadnihNalog;
using Rs.Dnevnik.Ris.Win.Modules.Odeljenja;
using Rs.Dnevnik.Ris.Win.Modules.RadniNalog;
using Rs.Dnevnik.Ris.Win.Modules.Radnici;
using Rs.Dnevnik.Ris.Win.Modules.Rubrike;

namespace Rs.Dnevnik.Ris.Win.IoC
{
    public class Container
    {
        private static readonly StandardKernel Kernel = new StandardKernel();

        static Container()
        {
            Kernel.Bind<IRepositoryFactory>().To<RepositoryFactory>();
            Kernel.Bind<IView>().To<View>();
            Kernel.Bind<IIzvestajPoDatumuView>().To<IzvestajPoDatumuView>();
            Kernel.Bind<IIzvestajPoRadnicimaView>().To<IzvestajPoRadnicimaView>();
            Kernel.Bind<IRadniciView>().To<RadniciView>();
            Kernel.Bind<IRubrikeView>().To<RubrikeView>();
            Kernel.Bind<IOdeljenjaView>().To<OdeljenjaView>();
        }

        public static StandardKernel GetKernel()
        {
            return Kernel;
        }
    }
}