using Quartz;
using WindowsLotteryService.Services;

namespace WindowsLotteryService.Jobs
{  
    public class MegasenaJob : LotteryJob  
    {  
        public override async Task Execute(IJobExecutionContext context)
        {
            string megasenaData = await GetLoteryData("mega-sena");
            LogService.Log(megasenaData);
        }
    }  
}