using System;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media.Animation;

namespace simple_stock_management_system.View {
    public partial class MainView : Window {
        public MainView() {
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

        private void btnDashboard_Click(object sender, RoutedEventArgs e) {
            DashboardView dashboardView = new DashboardView();
            dashboardView.Opacity = 0;
            dashboardView.Loaded += DashboardView_Loaded;
            Visibility = Visibility.Hidden;
            dashboardView.Show();
        }

        private void DashboardView_Loaded(object sender, RoutedEventArgs e) {
            DashboardView dashboardView = (DashboardView)sender;

            DoubleAnimation fadeInAnimation = new DoubleAnimation {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(0.2))
            };
            
            dashboardView.BeginAnimation(OpacityProperty, fadeInAnimation);
        }
        
    }
}

