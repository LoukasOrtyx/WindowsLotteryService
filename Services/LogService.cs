namespace WindowsLotteryService.Services
{
    public interface LogService
    {
    private static string _logFileLocation = ConfigService.ReadSetting("OutputPath") + 
    "lotteryServiceLog.txt";

        static void Log(string logMessage)
        {
            string? directoryName = Path.GetDirectoryName(_logFileLocation);
            directoryName = (directoryName == null)? string.Empty : directoryName;
            Directory.CreateDirectory(directoryName);
            File.AppendAllText(_logFileLocation, DateTime.UtcNow.ToString() + 
                " : " + logMessage + Environment.NewLine);
        }
    }
}