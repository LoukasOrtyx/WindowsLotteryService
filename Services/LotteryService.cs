using Newtonsoft.Json;
using WindowsLotteryService.Jobs;

namespace WindowsLotteryService.Services
{
    public class LotteryService
    {
        private void LogLottery()
        {
            QuartzScheduler megaScheduler = new QuartzScheduler(
                "megasenaId", 
                "lotteryGroup",
                new MegasenaJob().GetType());
                megaScheduler.Start(ConfigService.ReadSetting("MegaSenaQuartzCron"));

            QuartzScheduler lotoScheduler = new QuartzScheduler(
                "lotosenaId", 
                "lotteryGroup",
                new LotofacilJob().GetType());
                lotoScheduler.Start(ConfigService.ReadSetting("LotofacilQuartzCron"));
        }

        public void OnStart()
        {
            Task.Run(() => LogLottery());
        }

        public void OnStop()
        {
            Environment.Exit(1);
        }
    }
}