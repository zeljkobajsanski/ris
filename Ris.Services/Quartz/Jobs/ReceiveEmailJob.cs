using System;
using OpenPop.Pop3;
using Quartz;
using Ris.Services.IoC;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Interfaces.Repositories;
using Rs.Dnevnik.Ris.Interfaces.Services;

namespace Ris.Services.Quartz.Jobs
{
    public class ReceiveEmailJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                using (var rf = Container.Default.GetInstance<IRepositoryFactory>())
                {
                    using (var client = Container.Default.GetInstance<IPop3Service>())
                    {
                        var cfg = rf.KonfiguracijaRepository.VratiKonfiguraciju();
                        client.Connect(cfg.Server, cfg.Port, cfg.Ssl);
                        client.Authenticate(cfg.Username, cfg.Password);
                        var count = client.GetMessageCount();
                        for (int i = 0; i <= count; i++)
                        {
                            var msg = client.GetMessage(i);
                            if (msg == null) continue;
                            var from = msg.From.Address;
                            var agencija = rf.AgencijeRepository.VratiAgencijuSaEmailom(from);
                            var agencijskaVest = new AgencijskaVest
                            {
                                DatumPrijema = DateTime.Now,
                                Subject = msg.Subject
                            };
                            if (agencija != null)
                            {
                                agencijskaVest.AgencijaID = agencija.ID;
                                agencijskaVest.Body = msg.Body;
                            }
                            if (agencija == null)
                            {
                                continue;
                            }

                            rf.AgencijskeVestiRepository.Add(agencijskaVest);
                            rf.AgencijskeVestiRepository.Save();
                            client.DeleteMessage(i);
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}