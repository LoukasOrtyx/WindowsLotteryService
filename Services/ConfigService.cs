using System.Configuration;

namespace WindowsLotteryService.Services
{
    public interface ConfigService
    {
        static string ReadSetting(string key)  
        {  
            try  
            {  
                var appSettings = ConfigurationManager.AppSettings;  
                string result = appSettings[key] ?? "Not Found";  
                return result;  
            }  
            catch (ConfigurationErrorsException)  
            {  
                return "Error reading app settings";
            }  
        }  
    }
}