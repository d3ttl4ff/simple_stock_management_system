using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using simple_stock_management_system.ViewModels;

namespace simple_stock_management_system.View; 

public partial class DashboardView : Window {
    
    public DashboardView() {
        InitializeComponent();
    }

    private void Window_MouseDown(object sender, MouseButtonEventArgs e) {
        if (e.LeftButton == MouseButtonState.Pressed) {
            DragMove();
        }
    }

    private void btnMinimize_Click(object sender, RoutedEventArgs e) {
        WindowState = WindowState.Minimized;
    }
    
    private void btnClose_Click(object sender, RoutedEventArgs e) {
        Application.Current.Shutdown();
    }

    private void BtnHome_OnClick(object sender, RoutedEventArgs e) {
        MainView mainView = new MainView();
        mainView.Opacity = 0;
        mainView.Loaded += MainView_Loaded;
        Visibility = Visibility.Hidden;
        mainView.Show();
    }

    private void MainView_Loaded(object sender, RoutedEventArgs e) {
        MainView mainView = (MainView)sender;
        
        DoubleAnimation fadeInAnimation = new DoubleAnimation {
            From = 0,
            To = 1,
            Duration = new Duration(TimeSpan.FromSeconds(0.2))
        };
        
        mainView.BeginAnimation(OpacityProperty, fadeInAnimation);
    }
}

