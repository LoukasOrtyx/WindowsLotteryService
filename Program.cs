using Topshelf;
using WindowsLotteryService.Services;

namespace WindowsLotteryService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(hostConfig => 
                    {
                        hostConfig.Service<LotteryService>(serviceConfig =>
                        {
                            serviceConfig.ConstructUsing(() => new LotteryService());
                            serviceConfig.WhenStarted(service => service.OnStart());
                            serviceConfig.WhenStopped(service => service.OnStop());
                        });

                        hostConfig.SetServiceName("LotteryService");
                        hostConfig.SetDisplayName("Lottery Service");
                        hostConfig.SetDescription("Gets the drawn lottery numbers of a given game.");

                        hostConfig.RunAsLocalSystem();
                        hostConfig.StartAutomatically();

                        hostConfig.EnableServiceRecovery(r => 
                        {
                            r.RestartService(1);
                            r.OnCrashOnly();
                        });
                    }
                );
        }
    }
}