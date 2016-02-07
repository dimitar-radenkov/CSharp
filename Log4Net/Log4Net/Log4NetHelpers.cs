namespace Log4Net
{
    using System.Runtime.CompilerServices;

    public class Log4NetHelpers
    {
        public static log4net.ILog GetLogger([CallerFilePath]string filename = "")
        {
            return log4net.LogManager.GetLogger(filename);
        }
    }
}
