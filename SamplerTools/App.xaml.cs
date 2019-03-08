using Avalonia;
using Avalonia.Markup.Xaml;

namespace ByteFarm.SamplerTools
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
   }
}