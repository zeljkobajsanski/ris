using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ris.Services;
using Ris.Services.IoC;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Interfaces.Repositories;
using Rs.Dnevnik.Ris.Interfaces.Services;

namespace Rs.Dnevnik.Ris.UnitTests.Services
{
    [TestClass]
    public class TextKonvertorFixtures
    {
        private Container fContainer;

        [TestInitialize]
        public void TestInit()
        {
            fContainer = new Container();

        }

        [TestMethod]
        public void KonvertujTekst()
        {
            // Arrange
            var sabloni = new List<Konverzija>
            {
                new Konverzija {Sablon = "š", KonverovaniString = "ss"},
                new Konverzija {Sablon = "Š", KonverovaniString = "SS"},
                new Konverzija {Sablon = "č", KonverovaniString = "cc"},
                new Konverzija {Sablon = "Č", KonverovaniString = "CC"},
            };
            var konverzijaRepoistory = new Mock<IKonverzijaRepository>();
            konverzijaRepoistory.Setup(x => x.VratiSabloneKonverzije()).Returns(sabloni);
            var repositoryFactory = new Mock<IRepositoryFactory>();
            repositoryFactory.SetupGet(x => x.KonverzijaRepository).Returns(konverzijaRepoistory.Object);
            var container = new Container();
            container.Bind<IRepositoryFactory>(repositoryFactory.Object);
            container.Bind<ITextKonvertor, TextKonvertor>();

            // Act
            var konvertovano = container.GetInstance<ITextKonvertor>().Konvertuj("Odšteta dss pašteta");
            Assert.AreEqual("Odssteta dss passteta", konvertovano);
        }
         
    }
}