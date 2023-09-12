using System;
using System.Windows;
using System.Windows.Media.Animation;
using simple_stock_management_system.View;

namespace simple_stock_management_system
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // protected void ApplicationStart(object sender, StartupEventArgs e) {
        //     var loginView = new LoginView();
        //     loginView.Show();
        //
        //     loginView.IsVisibleChanged += (s, ev) => {
        //         if (loginView.IsVisible == false && loginView.IsLoaded) {
        //             var mainView = new MainView();
        //             mainView.Show();
        //             loginView.Close();
        //         }
        //     };
        // }
        
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            var loginView = new LoginView();
            loginView.Show();

            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (!loginView.IsVisible && loginView.IsLoaded)
                {
                    var mainView = new MainView {
                        Opacity = 0
                    };
                    mainView.Show();

                    //Animation to fade in the MainView
                    var fadeInAnimation = new DoubleAnimation
                    {
                        From = 0,
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.2)
                    };

                    mainView.BeginAnimation(UIElement.OpacityProperty, fadeInAnimation);

                    loginView.Close();
                }
            };
        }
        
    }
}
