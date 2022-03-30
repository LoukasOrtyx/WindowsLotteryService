using Quartz;
using WindowsLotteryService.Services;

namespace WindowsLotteryService.Jobs
{  
    public class LotofacilJob : LotteryJob  
    {  
        public override async Task Execute(IJobExecutionContext context)
        {
            string lotofacilData = await GetLoteryData("lotofacil");
            LogService.Log(lotofacilData);
        }
    }  
}