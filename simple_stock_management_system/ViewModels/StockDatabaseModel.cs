using System;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using simple_stock_management_system.Models;
using simple_stock_management_system.Repositories;
using MySql.Data.MySqlClient;

namespace simple_stock_management_system.ViewModels; 

public class StockDatabaseModel : ViewModelBase {
    
    //Fields
    private char[] _itemId;
    private string _stockCode;
    private string _itemName;
    private int _itemQuantity;
    private DateTime _currentDate;
    
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
            _stockCode = value;
            OnPropertyChanged(nameof(StockCode));
        } 
    }
    
    public string ItemName {
        get => _itemName;
        set {
            _itemName = value;
            OnPropertyChanged(nameof(ItemName));
        } 
    }
    
    public int ItemQuantity {
        get => _itemQuantity;
        set {
            _itemQuantity = value;
            OnPropertyChanged(nameof(ItemQuantity));
        } 
    }
    
    public DateTime CurrentDate {
        get => _currentDate;
        set {
            _currentDate = value;
            OnPropertyChanged(nameof(CurrentDate));
        } 
    }
    
    //-> Commands
    public ICommand AddItemCommand { get; }
    
    //Constructor
    public StockDatabaseModel() {
        AddItemCommand = new ViewModelCommand(ExecuteAddItemCommand);
    }
    
    //Methods
    private void ExecuteAddItemCommand(object obj) {
        // Generate a UUID for the item
        ItemId = Guid.NewGuid().ToString("D").ToCharArray();
        
        // Retrieve values from properties
        char[] itemId = ItemId;
        string stockCode = StockCode;
        string itemName = ItemName;
        int itemQuantity = ItemQuantity;
        DateTime currentDate = CurrentDate;

        // Insert the values into your stock database
        InsertIntoStockDatabase(itemId, stockCode, itemName, itemQuantity, currentDate);

        // Optionally, you can clear the properties after insertion
        StockCode = "";
        ItemName = "";
        ItemQuantity = 0;
        CurrentDate = DateTime.Now;
        
    }

    private void InsertIntoStockDatabase(char[] itemId, string stockCode, string itemName, int itemQuantity, DateTime currentDate) {
        
        string connectionString = "server=localhost;user=root;database=main;port=3306;password=root";

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string insertQuery = "INSERT INTO stock (Id, StockCode, ItemName, Quantity, Date) VALUES (@item_id, @stock_code, @item_name, @item_quantity, @current_date)";

            using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@item_id", new string(itemId));
                command.Parameters.AddWithValue("@stock_code", stockCode);
                command.Parameters.AddWithValue("@item_name", itemName);
                command.Parameters.AddWithValue("@item_quantity", itemQuantity);
                command.Parameters.AddWithValue("@current_date", currentDate);

                command.ExecuteNonQuery();
            }
        }
    }

}
