namespace Task_Managment.Logger
{
    public class AppLogger<T> where T : class
    {
        private readonly ILogger<T> _logger;

        public AppLogger(ILogger<T> logger)
        {
            _logger = logger;
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation($"{DateTime.Now}: {message}");
        }

        public void LogWarning(string message)
        {
            _logger.LogWarning($"{DateTime.Now}: {message}");
        }

        public void LogError(string message, Exception ex = null)
        {
            if (ex != null)
                _logger.LogError(ex, $"{DateTime.Now}: {message}");
            else
                _logger.LogError($"{DateTime.Now}: {message}");
        }
    }
}
