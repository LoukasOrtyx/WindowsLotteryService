using Newtonsoft.Json;
using Quartz;
using WindowsLotteryService.Services;

namespace WindowsLotteryService.Jobs
{
    public abstract class LotteryJob : IJob
    {
        protected static HttpClient client = new HttpClient();

        public abstract Task Execute(IJobExecutionContext context);

        protected async Task<string> GetLoteryData(string gameType)
        {
            string lotteryUrl = ConfigService.ReadSetting("LotteryApiUrl");
            string numberConcurso = ConfigService.ReadSetting("NumberConcurso");
            string requestUri = $"{lotteryUrl}/{gameType}/{numberConcurso}";
            string logMessage = "";
            try
            {
                HttpResponseMessage response = await client.GetAsync(requestUri);
                response.EnsureSuccessStatusCode();
                string payload = await response.Content.ReadAsStringAsync();
                dynamic? json = JsonConvert.DeserializeObject(payload);
                
                logMessage = "A "
                            + json?["loteria"]
                            + " do concurso de número "
                            + json?["concurso"]
                            + " sorteou as dezenas: "
                            + string.Join(", ", json?["dezenas"])
                            + ".";

                
            }
            catch (HttpRequestException error)
            {
                LogService.Log($"Exceção HTTP ao tentar consultar jogo da {gameType}");
                throw error;
            }

            return logMessage;
        }
    }
}