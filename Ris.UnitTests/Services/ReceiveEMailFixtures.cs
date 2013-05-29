using System.Net.Mail;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ris.Services.IoC;
using Ris.Services.Quartz;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Interfaces.Repositories;
using Rs.Dnevnik.Ris.Interfaces.Services;

namespace Rs.Dnevnik.Ris.UnitTests.Services
{
    [TestClass]
    public class ReceiveEMailFixtures
    {
        [TestMethod]
        public void ReceiveEmail()
        {
            // Arrange
            var container = new Container();
            var repositoryFactoryMock = new Mock<IRepositoryFactory>();
            var konfiguracijaRepository = new Mock<IKonfiguracijaRepository>();
            var pop3Mock = new Mock<IPop3Service>();
            var agencijeRepository = new Mock<IAgencijeRepository>();
            var agencijskeVestiRepository = new Mock<IAgencijskeVestiRepository>();

            var konfiguracija = new Konfiguracija
            {
                DownloadInterval = 1, Server = "server", Port = 995, Ssl = true, Username = "dnevnikris@gmail.com", Password = "dnevnik1302"
            };
            var agencija = new Agencija {ID = 1};
            repositoryFactoryMock.SetupGet(x => x.KonfiguracijaRepository).Returns(konfiguracijaRepository.Object);
            repositoryFactoryMock.SetupGet(x => x.AgencijeRepository).Returns(agencijeRepository.Object);
            repositoryFactoryMock.SetupGet(x => x.AgencijskeVestiRepository).Returns(agencijskeVestiRepository.Object);
            konfiguracijaRepository.Setup(x => x.VratiKonfiguraciju()).Returns(konfiguracija);
            pop3Mock.Setup(x => x.GetMessageCount()).Returns(1);
            var mail = new MailMessage
            {
                From = new MailAddress("slanje@tanjug.rs"),
                Subject = "Test",
                Body = "Test body"
            };
            pop3Mock.Setup(x => x.GetMessage(0)).Returns(mail);
            agencijeRepository.Setup(x => x.VratiAgencijuSaEmailom(It.Is<string>(s => s.Equals(mail.From.Address)))).Returns(agencija);
            
            
           
            
            container.Bind<IRepositoryFactory>(repositoryFactoryMock.Object);
            container.Bind<ISchedulerService, SchedulerService>();
            Container.Default.Bind<IPop3Service>(pop3Mock.Object);
            Container.Default.Bind<IRepositoryFactory>(repositoryFactoryMock.Object);

            // Act
            container.GetInstance<ISchedulerService>().Run();
            Thread.Sleep(2000);

            // Assert
            pop3Mock.Verify(x => x.Connect(konfiguracija.Server, konfiguracija.Port, konfiguracija.Ssl));
            pop3Mock.Verify(x => x.Authenticate(konfiguracija.Username, konfiguracija.Password));
            pop3Mock.Verify(x => x.GetMessage(0));
            agencijskeVestiRepository.Verify(x => x.Add(It.Is<AgencijskaVest>(a => a.AgencijaID == agencija.ID && a.Subject == mail.Subject && a.Body == mail.Body)));
            agencijskeVestiRepository.Verify(x => x.Save());
            pop3Mock.Verify(x => x.DeleteMessage(0));
        }
    }
}