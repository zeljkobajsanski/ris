using System;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using Ris.Services.Quartz.Jobs;
using Rs.Dnevnik.Ris.Interfaces.Repositories;
using Rs.Dnevnik.Ris.Interfaces.Services;

namespace Ris.Services.Quartz
{
    public class SchedulerService : ISchedulerService
    {
        private readonly IRepositoryFactory fRepositoryFactory;

        public SchedulerService(IRepositoryFactory fRepositoryFactory)
        {
            this.fRepositoryFactory = fRepositoryFactory;
        }

        public void Run()
        {
            using (fRepositoryFactory)
            {
                var schf = new StdSchedulerFactory();
                var sch = schf.GetScheduler();
                var interval = fRepositoryFactory.KonfiguracijaRepository.VratiKonfiguraciju().DownloadInterval;
                sch.ScheduleJob(new JobDetailImpl("ReceiveEmailJob", 
                    null, 
                    typeof(ReceiveEmailJob)), 
                    new SimpleTriggerImpl("EMailTrigger", null, DateTime.UtcNow, 
                    null, 
                    SimpleTriggerImpl.RepeatIndefinitely, 
                    TimeSpan.FromMinutes(interval)));
                sch.Start();    
            }
        } 
    }
}