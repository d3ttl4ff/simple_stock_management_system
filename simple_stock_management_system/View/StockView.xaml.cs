using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using simple_stock_management_system.Models;
using simple_stock_management_system.ViewModels;

namespace simple_stock_management_system.View; 

public partial class StockView : Window {
    private MainView _cachedMainView;
    
    public StockView() {
        InitializeComponent();
        
        StockDatabaseModel stockDatabaseModel = new StockDatabaseModel();
        
        List<StockItem> stockItems = stockDatabaseModel.LoadStockLevelData();
        
        DataGrid.ItemsSource = stockItems;
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
        // MainView mainView = new MainView();
        // mainView.Opacity = 0;
        // mainView.Loaded += MainView_Loaded;
        // Visibility = Visibility.Hidden;
        // mainView.Show();
        
        if (_cachedMainView == null)
        {
            _cachedMainView = new MainView();
            _cachedMainView.Loaded += MainView_Loaded;
        }
        
        _cachedMainView.Opacity = 0;
        Visibility = Visibility.Hidden;
        _cachedMainView.Show();
        Close();
    }

    private void MainView_Loaded(object sender, RoutedEventArgs e) {
        MainView mainView = (MainView)sender;
        
        DoubleAnimation fadeInAnimation = new DoubleAnimation {
            From = 0,
            To = 1,
            Duration = new Duration(TimeSpan.FromSeconds(0.1))
        };
        
        mainView.BeginAnimation(OpacityProperty, fadeInAnimation);
    }
}

