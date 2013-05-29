using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ris.Services;

namespace Rs.Dnevnik.Ris.UnitTests.Services
{
    [TestClass]
    public class Pop3ServiceFixtures
    {
        [TestMethod]
         public void PrimiEMail()
        {
            using (var pop3 = new OpenPopService())
            {
                pop3.Connect("pop.gmail.com", 995, true);
                pop3.Authenticate("dnevnikris@gmail.com", "dnevnik1302");
                var count = pop3.GetMessageCount();
                Assert.AreEqual(1, count);
                for (int i = 0; i < count; i++)
                {
                    var msg = pop3.GetMessage(i);
                    pop3.DeleteMessage(i);
                }    
            }
        }
    }
}