using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace CustomApp
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        public MainActivity()
        {
            Microsoft.Maui.Handlers.ButtonHandler.Mapper.AppendToMapping("CustomBackground", (handler, view) =>
            {
                if (view is CustomButton)
                {
                    handler.PlatformView.SetBackgroundColor(Colors.Green.ToPlatform());
                    handler.PlatformView.SetTextColor(Android.Graphics.Color.Black);
                    handler.PlatformView.SetOnTouchListener(new ButtonAnimationListener(handler.PlatformView));

                }
            });
        }
        public class ButtonAnimationListener : Java.Lang.Object, Android.Views.View.IOnTouchListener
        {
            private readonly Android.Views.View _button;

            public ButtonAnimationListener(Android.Views.View button)
            {
                _button = button;
            }

            public bool OnTouch(Android.Views.View v, MotionEvent e)
            {
                switch (e.Action)
                {
                    case MotionEventActions.Down:
                        _button.Animate()
                            .ScaleX(1.5f) 
                            .ScaleY(1.5f)
                            .Rotation(15f) 
                            .SetDuration(100) 
                            .Start();
                        break;

                    case MotionEventActions.Up:
                    case MotionEventActions.Cancel:
                        
                        _button.Animate()
                            .ScaleX(1f) 
                            .ScaleY(1f)
                            .Rotation(0f) 
                            .SetDuration(100)
                            .Start();
                        break;
                }
                return false;
            }
        }

    }

}
