using System;
using Ninject;

namespace Ris.Services.IoC
{
    public class Container
    {
        private static readonly Container DefaultInstance = new Container();

        private readonly StandardKernel fKernel = new StandardKernel();

        public void Bind<T, T1>() where T1 : T
        {
            fKernel.Bind<T>().To<T1>();
        }

        public void Bind<T>(object to)
        {
            if (!(to is T)) return;
            fKernel.Bind<T>().ToConstant((T)to);
        }

        public T GetInstance<T>()
        {
            return fKernel.Get<T>();
        }

        public static Container Default
        {
            get { return DefaultInstance; }
        }
    }
}