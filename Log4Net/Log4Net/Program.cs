[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Log4Net
{
    class Program
    {
        private static readonly log4net.ILog logger = Log4NetHelpers.GetLogger();

        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello world");

            logger.Error("Error message", new System.OutOfMemoryException());

            return;
        }
    }
}
