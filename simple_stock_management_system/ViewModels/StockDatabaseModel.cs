﻿using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using MySql.Data.MySqlClient;
using simple_stock_management_system.Repositories;

namespace simple_stock_management_system.ViewModels; 

public class StockDatabaseModel : ViewModelBase {
    
    //Fields
    private char[] _itemId;
    private string _stockCode;
    private string _itemName;
    private int _itemQuantity;
    string _customNote;
    private string _errorMessage;
    private string _successMessage;
    
    public int ErrorMessageOpacity { get; set; }

    //Properties
    public char[] ItemId {
        get => _itemId;
        set {
            _itemId = value;
            OnPropertyChanged(nameof(ItemId));
        } 
    }
    
    public string StockCode {
        get => _stockCode;
        set {
            _stockCode = value.Replace(" ", "").ToUpper();
            OnPropertyChanged(nameof(StockCode));
        } 
    }
    
    public string ItemName {
        get => _itemName;
        set {
            if (value.StartsWith("-") || value.StartsWith("_"))
            {
                ErrorMessage = "Error: Item Name cannot start with a hyphen (-) or an underscore (_)";
                ShowErrorMessageWithFadeIn();
            }
            else if (Regex.IsMatch(value, "^[a-zA-Z0-9_-]*$"))
            {
                _itemName = value;
                OnPropertyChanged(nameof(ItemName));
            }
            else
            {
                ErrorMessage = "Error: Item Name can only contain letters, numbers, spaces, hyphens, and underscores";
                ShowErrorMessageWithFadeIn();
            }
        } 
    }
    
    public int ItemQuantity {
        get => _itemQuantity;
        set {
            _itemQuantity = value;
            OnPropertyChanged(nameof(ItemQuantity));
        } 
    }
    
    public string CustomNote {
        get => _customNote;
        set {
            _customNote = value;
            OnPropertyChanged(nameof(CustomNote));
        } 
    }
    
    public string ErrorMessage {
        get => _errorMessage;
        set {
            _errorMessage = value;
            OnPropertyChanged(nameof(ErrorMessage));
        }
    }
    
    public string SuccessMessage {
        get => _successMessage;
        set {
            _successMessage = value;
            OnPropertyChanged(nameof(SuccessMessage));
        }
    }

    //Commands
    public ICommand AddItemCommand { get; }
    
    //Constructor
    public StockDatabaseModel() {
        AddItemCommand = new ViewModelCommand(ExecuteAddItemCommand);
    }
    
    //Methods
    private void ExecuteAddItemCommand(object obj) {

        try {
            if (ItemQuantity <= 0 || !Regex.IsMatch(ItemQuantity.ToString(), "^[0-9]+$")) {
                ErrorMessage = "Error: Item Quantity can only be a positive integer";
                ShowErrorMessageWithFadeIn();
                return;
            }
            
            if (!Regex.IsMatch(StockCode, "^[a-zA-Z0-9-]+$")) {
                ErrorMessage = "Error: Stock Code can only contain letters, numbers, and '-'";
                ShowErrorMessageWithFadeIn();
                return;
            }
            
            if (string.IsNullOrWhiteSpace(StockCode) || string.IsNullOrWhiteSpace(ItemName)) {
                if (string.IsNullOrWhiteSpace(StockCode)) {
                    ErrorMessage = "Error: Stock Code cannot be empty";
                }
                else if (string.IsNullOrWhiteSpace(ItemName)) {
                    ErrorMessage = "Error: Item Name cannot be empty";
                }
                
                ShowErrorMessageWithFadeIn();
                return;
            }
            
            // Generate a UUID for the item
            ItemId = Guid.NewGuid().ToString("D").ToCharArray();
        
            // Retrieve values from properties
            char[] itemId = ItemId;
            string stockCode = StockCode;
            string itemName = ItemName;
            int itemQuantity = ItemQuantity;
            string customNote = CustomNote;
            string currentDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            
            using (ConcreteRepository repository = new ConcreteRepository())
            {
                string connectionString = repository.GetConnectionString();
                
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                }
            }

            // Insert the values into the stock database
            InsertIntoStockDatabase(itemId, stockCode, itemName, itemQuantity, currentDate, customNote);

            // Clear the properties after inserting the values into the database
            StockCode = "";
            ItemName = "";
            ItemQuantity = 0;
            CustomNote = "";
            ErrorMessage =  "";
            SuccessMessage = "* Item added successfully";
            ShowSucessMessageWithFadeIn();
        }
        catch (MySqlException e) {
            ErrorMessage =  "Error: " + e.Message;
            ShowErrorMessageWithFadeIn();
        }
        catch (FormatException e) {
            ErrorMessage =  "Error: " + e.Message;
            ShowErrorMessageWithFadeIn();
        }
        catch (ArgumentNullException e) {
            ErrorMessage =  "Error: " + e.Message;
            ShowErrorMessageWithFadeIn();
        }
        catch (OverflowException e) {
            ErrorMessage =  "Error: " + e.Message;
            ShowErrorMessageWithFadeIn();
        }
        catch (OutOfMemoryException e) {
            ErrorMessage =  "Error: " + e.Message;
            ShowErrorMessageWithFadeIn();
        }
        catch (Exception e) {
            ErrorMessage = "Error: " + e.Message;
            ShowErrorMessageWithFadeIn();
        }
        
    }

    private void InsertIntoStockDatabase(char[] itemId, string stockCode, string itemName, int itemQuantity, string currentDate, string customNote) {

        using (ConcreteRepository repository = new ConcreteRepository()) {
            string connectionString = repository.GetConnectionString();
            
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery =
                    "INSERT INTO stock (Id, StockCode, ItemName, Quantity, Date, Note) VALUES (@item_id, @stock_code, @item_name, @item_quantity, @current_date, @custom_note)";

                using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@item_id", new string(itemId));
                    command.Parameters.AddWithValue("@stock_code", stockCode);
                    command.Parameters.AddWithValue("@item_name", itemName);
                    command.Parameters.AddWithValue("@item_quantity", itemQuantity);
                    command.Parameters.AddWithValue("@current_date", currentDate);
                    command.Parameters.AddWithValue("@custom_note", customNote ?? "");

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
    
    //Error message fade in animation
    private void ShowErrorMessageWithFadeIn()
    {
        ErrorMessageOpacity = 0;

        if (Application.Current.MainWindow != null) {
            if (Application.Current.MainWindow.FindName("ErrorMessageBorder") is Border border)
            {
                var fadeInAnimation = new DoubleAnimation
                {
                    From = 0,
                    To = 1,
                    Duration = TimeSpan.FromSeconds(0.1)
                };

                border.BeginAnimation(UIElement.OpacityProperty, fadeInAnimation);
            }
        }
    }
    
    private void ShowSucessMessageWithFadeIn()
    {
        ErrorMessageOpacity = 0;

        if (Application.Current.MainWindow != null) {
            if (Application.Current.MainWindow.FindName("SuccessMessageBorder") is Border border)
            {
                var fadeInAnimation = new DoubleAnimation
                {
                    From = 0,
                    To = 1,
                    Duration = TimeSpan.FromSeconds(0.1)
                };

                border.BeginAnimation(UIElement.OpacityProperty, fadeInAnimation);
                
                var timer = new DispatcherTimer
                {
                    Interval = TimeSpan.FromSeconds(2)
                };

                timer.Tick += (_, _) =>
                {
                    var fadeOutAnimation = new DoubleAnimation
                    {
                        From = 1,
                        To = 0,
                        Duration = TimeSpan.FromSeconds(0.3)
                    };

                    border.BeginAnimation(UIElement.OpacityProperty, fadeOutAnimation);
                    
                    timer.Stop();
                };
                
                timer.Start();
            }
        }
    }
}
