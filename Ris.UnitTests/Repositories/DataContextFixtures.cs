using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rs.Dnevnik.Ris.EntityFramework.Configurations;
using Rs.Dnevnik.Ris.EntityFramework.Repositories;

namespace Rs.Dnevnik.Ris.UnitTests.Repositories
{
    [TestClass]
    public class DataContextFixtures
    {
        [ClassInitialize]
        public static void ClassInit(TestContext ctx)
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        [TestMethod]
         public void CreateDatabase()
         {
             using (var rf = new RepositoryFactory())
             {
                 rf.NovinskeKuceRepository.NovinskeKuce();
             }
         }
    }
}