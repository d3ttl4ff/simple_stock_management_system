using System;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media.Animation;

namespace simple_stock_management_system.View {
    public partial class MainView : Window {
        private DashboardView _cachedDashboardView;
        private LogView _cachedLogView;
        private StockView _cachedStockView;
        
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
            // DashboardView dashboardView = new DashboardView();
            // dashboardView.Opacity = 0;
            // dashboardView.Loaded += DashboardView_Loaded;
            // Visibility = Visibility.Hidden;
            // Close();
            // dashboardView.Show();
            
            if (_cachedDashboardView == null)
            {
                _cachedDashboardView = new DashboardView();
                _cachedDashboardView.Loaded += DashboardView_Loaded;
            }

            _cachedDashboardView.Opacity = 0;
            Visibility = Visibility.Hidden;
            Close();
            _cachedDashboardView.Show();
        }

        private void btnLog_Click(object sender, RoutedEventArgs e) {
            LogView logView = new LogView();
            logView.Opacity = 0;
            logView.Loaded += LogView_Loaded;
            Visibility = Visibility.Hidden;
            logView.Show();
            
            // if (_cachedLogView == null)
            // {
            //     _cachedLogView = new LogView();
            //     _cachedLogView.Loaded += LogView_Loaded;
            // }
            //
            // _cachedLogView.Opacity = 0;
            // Visibility = Visibility.Hidden;
            // Close();
            // _cachedLogView.Show();
        }

        private void btnStock_Click(object sender, RoutedEventArgs e) {
            StockView stockView = new StockView();
            stockView.Opacity = 0;
            stockView.Loaded += StockView_Loaded;
            Visibility = Visibility.Hidden;
            stockView.Show();
            
            // if (_cachedStockView == null)
            // {
            //     _cachedStockView = new StockView();
            //     _cachedStockView.Loaded += StockView_Loaded;
            // }
            //
            // _cachedStockView.Opacity = 0;
            // Visibility = Visibility.Hidden;
            // Close();
            // _cachedStockView.Show();
        }
        
        //------------------------------------ animation for fade in 
        private void DashboardView_Loaded(object sender, RoutedEventArgs e) {
            DashboardView dashboardView = (DashboardView)sender;

            DoubleAnimation fadeInAnimation = new DoubleAnimation {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(0.1))
            };
            
            dashboardView.BeginAnimation(OpacityProperty, fadeInAnimation);
        }
        
        private void LogView_Loaded(object sender, RoutedEventArgs e) {
            LogView logView = (LogView)sender;

            DoubleAnimation fadeInAnimation = new DoubleAnimation {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(0.1))
            };
            
            logView.BeginAnimation(OpacityProperty, fadeInAnimation);
        }

        private void StockView_Loaded(object sender, RoutedEventArgs e) {
            StockView stockView = (StockView)sender;
            
            DoubleAnimation fadeInAnimation = new DoubleAnimation {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(0.1))
            };
            
            stockView.BeginAnimation(OpacityProperty, fadeInAnimation);
        }
        //------------------------------------ animation for fade in 
        
    }
}

