using Application.Interfaces.Context;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.TodoItem.Commands.NotifyAlertOnTime
{
    [DisallowConcurrentExecution]   
    public class ISendTotifyOnTimeService : IJob
    {
        private readonly IDataBaseContext DB;
        public ISendTotifyOnTimeService(IDataBaseContext dB)
        {
            DB = dB;
        }

        public Task Execute(IJobExecutionContext context)
        {
            var notifylist = DB.Carts.Where(p => p.HaveNofication == true &&
            p.NoficationDate != null && p.NoficationTime != null).ToList();

          return Task.CompletedTask;

        }
    }
    public class GetNoficationTime
    {
        public long CartId { get; set; }
        public DateTime NoficationTime { get; set; }
    }

    public class singeltonjobfactory : IJobFactory
    {
        readonly IServiceProvider SP;
        public singeltonjobfactory(IServiceProvider sP)
        {
            SP = sP;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return SP.GetRequiredService(bundle.JobDetail.JobType) as IJob;

        }

        public void ReturnJob(IJob job)
        {
        }
    }
    public class jobschedule
    {
        public Type jobtype { get; set; }
        public string CronExpression { get; set; }
        public jobschedule(Type jobtype, string cronExpression)
        {
            this.jobtype = jobtype;
            CronExpression = cronExpression;
        }
    }
 

}
