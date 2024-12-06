using Microsoft.Maui.Platform;

namespace CustomApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

#if __ANDROID__
            Microsoft.Maui.Handlers.ButtonHandler.Mapper.AppendToMapping("CustomBackground", (handler, view) =>
            {
                if (view is Button button)
                {
                    handler.PlatformView.SetBackgroundColor(Colors.Red.ToPlatform());
                }
            });
#endif
        }
    }
}
