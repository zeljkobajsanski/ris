using System.Data.Entity;
using Rs.Dnevnik.Ris.EntityFramework.Configurations;
using Rs.Dnevnik.Ris.Interfaces;

namespace Rs.Dnevnik.Ris.EntityFramework
{
    public class Bootstrapper : IBootstrapper
    {
        public void Start()
        {
            Database.SetInitializer(new DatabaseInitializer());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());
        }
    }
}