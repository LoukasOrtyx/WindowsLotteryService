using Quartz;  
using Quartz.Impl;
using WindowsLotteryService.Jobs;

namespace WindowsLotteryService  
{  
  public class QuartzScheduler  
    {  
        private string TriggerId {get; set;}
        private string TriggerGroup {get; set;}
        private Type JobType {get; set;}

        public QuartzScheduler(string triggerId, string triggerGroup, Type jobType)
        {
            this.TriggerId = triggerId;
            this.TriggerGroup = triggerGroup;
            this.JobType = jobType;
        }

        public async void Start(string cronSchedule)  
        {  
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();  
            await scheduler.Start();
            IJobDetail job = JobBuilder.Create(this.JobType).Build();  
            ITrigger trigger = TriggerBuilder.Create()   
                .WithIdentity(this.TriggerId, this.TriggerGroup)  
                .WithCronSchedule(cronSchedule)
                .Build();  
                
            await scheduler.ScheduleJob(job, trigger);  
        }  
  
    }  
}  