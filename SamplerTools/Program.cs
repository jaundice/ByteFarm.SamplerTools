using Avalonia;
using Avalonia.Logging.Serilog;

namespace ByteFarm.SamplerTools
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BuildAvaloniaApp().Start<MainWindow>();
        }

        public static AppBuilder BuildAvaloniaApp()
        {
            return AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToDebug();
        }
    }
}