using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using MySql.Data.MySqlClient;
using simple_stock_management_system.Repositories;
using simple_stock_management_system.Models;

namespace simple_stock_management_system.ViewModels; 

public class StockDatabaseModel : ViewModelBase {
    
    //Fields
    private char[] _itemId;
    private char[] _itemId2;
    private string _stockCode;
    private string _itemName;
    private int _itemQuantity;
    private string _customNote;

    private string _removeStockCode;
    private string _removeItemName;
    private int _removeItemQuantity;
    private string _removeCustomNote;
    
    private string _updateStockCode;
    private string _updateItemName;
    private int _updateItemQuantity;
    private int _newUpdateItemQuantity;
    
    private string _errorMessage;
    private string _successMessage;
    private string _removeErrorMessage;
    private string _removeSuccessMessage;
    private string _updateErrorMessage;
    private string _updateSuccessMessage;
    
    public int ErrorMessageOpacity { get; set; }

    //Properties
    public char[] ItemId {
        get => _itemId;
        set {
            _itemId = value;
            OnPropertyChanged(nameof(ItemId));
        } 
    }
    
    public char[] ItemId2 {
        get => _itemId2;
        set {
            _itemId2 = value;
            OnPropertyChanged(nameof(ItemId2));
        } 
    }
    
    public string StockCode {
        get => _stockCode;
        set {
            if (value.StartsWith("-") || value.StartsWith("_"))
            {
                ErrorMessage = "Error: Stock Code cannot start with a hyphen (-) or an underscore (_)";
                ShowErrorMessageWithFadeIn();
            }
            else if (Regex.IsMatch(value, "^[a-zA-Z0-9_-]*$"))
            {
                _stockCode = value.Replace(" ", "").ToUpper();
                OnPropertyChanged(nameof(StockCode));
                ErrorMessage = "";
            }
            else
            {
                ErrorMessage = "Error: Stock Code can only contain letters, numbers, spaces, hyphens, and underscores";
                ShowErrorMessageWithFadeIn();
            }
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
            else if (!value.Contains("~"))
            {
                _itemName = value;
                OnPropertyChanged(nameof(ItemName));
                ErrorMessage = "";
            }
            else
            {
                ErrorMessage = "Error: Item Name cannot contain a tilde (~)";
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

    public string RemoveStockCode {
        get => _removeStockCode;
        set {
            if (value.StartsWith("-") || value.StartsWith("_"))
            {
                RemoveErrorMessage = "Error: Stock Code cannot start with a hyphen (-) or an underscore (_)";
                ShowRemoveErrorMessageWithFadeIn();
            }
            else if (Regex.IsMatch(value, "^[a-zA-Z0-9_-]*$"))
            {
                _removeStockCode = value.Replace(" ", "").ToUpper();

                StockModel stockModel = new StockModel(value);
                if (GetDetailsFromDatabase(stockModel.RemoveStockCode)) {
                    GetDetailsFromDatabase(stockModel.RemoveStockCode);
                }
                else {
                    RemoveItemName = "";
                    RemoveItemQuantity = 0;
                    RemoveCustomNote = "";
                }
                
                OnPropertyChanged(nameof(RemoveStockCode));
                RemoveErrorMessage = "";
            }
            else
            {
                RemoveErrorMessage = "Error: Stock Code can only contain letters, numbers, spaces, hyphens, and underscores";
                ShowRemoveErrorMessageWithFadeIn();
            }
            OnPropertyChanged(nameof(RemoveStockCode));
        } 
    }

    public string RemoveItemName {
        get => _removeItemName;
        set {
            _removeItemName = value;
            OnPropertyChanged(nameof(RemoveItemName));
        } 
    }
    
    public int RemoveItemQuantity {
        get => _removeItemQuantity;
        set {
            _removeItemQuantity = value;
            OnPropertyChanged(nameof(RemoveItemQuantity));
        } 
    }
    
    public string RemoveCustomNote {
        get => _removeCustomNote;
        set {
            _removeCustomNote = value;
            OnPropertyChanged(nameof(RemoveCustomNote));
        } 
    }
    
    public string UpdateStockCode {
        get => _updateStockCode;
        set {
            if (value.StartsWith("-") || value.StartsWith("_"))
            {
                UpdateErrorMessage = "Error: Stock Code cannot start with a hyphen (-) or an underscore (_)";
                ShowUpdateErrorMessageWithFadeIn();
            }
            else if (Regex.IsMatch(value, "^[a-zA-Z0-9_-]*$"))
            {
                _updateStockCode = value.Replace(" ", "").ToUpper();
                
                // Get the item name and quantity from the database
                StockModel stockModel = new StockModel(value);
                
                if (GetQuantityFromDatabase(stockModel.UpdateStockCode)) {
                    GetQuantityFromDatabase(stockModel.UpdateStockCode);
                }
                else {
                    UpdateItemName = "";
                    UpdateItemQuantity = 0;
                }
                
                OnPropertyChanged(nameof(UpdateStockCode));
                UpdateErrorMessage = "";
            }
            else
            {
                UpdateErrorMessage = "Error: Stock Code can only contain letters, numbers, spaces, hyphens, and underscores";
                ShowUpdateErrorMessageWithFadeIn();
            }
        } 
    }
    
    public string UpdateItemName {
        get => _updateItemName;
        set {
            _updateItemName = value;
            OnPropertyChanged(nameof(UpdateItemName));
        } 
    }
    
    public int UpdateItemQuantity {
        get => _updateItemQuantity;
        set {
            _updateItemQuantity = value;
            OnPropertyChanged(nameof(UpdateItemQuantity));
        } 
    }
    
    public int NewUpdateItemQuantity {
        get => _newUpdateItemQuantity;
        set {
            _newUpdateItemQuantity = value;
            OnPropertyChanged(nameof(NewUpdateItemQuantity));
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
    
    public string RemoveErrorMessage {
        get => _removeErrorMessage;
        set {
            _removeErrorMessage = value;
            OnPropertyChanged(nameof(RemoveErrorMessage));
        }
    }
    
    public string RemoveSuccessMessage {
        get => _removeSuccessMessage;
        set {
            _removeSuccessMessage = value;
            OnPropertyChanged(nameof(RemoveSuccessMessage));
        }
    }
    
    public string UpdateErrorMessage {
        get => _updateErrorMessage;
        set {
            _updateErrorMessage = value;
            OnPropertyChanged(nameof(UpdateErrorMessage));
        }
    }
    
    public string UpdateSuccessMessage {
        get => _updateSuccessMessage;
        set {
            _updateSuccessMessage = value;
            OnPropertyChanged(nameof(UpdateSuccessMessage));
        }
    }

    //Commands
    public ICommand AddItemCommand { get; }
    public ICommand RemoveItemCommand { get; }
    public ICommand AddItemQuantityCommand { get; }
    public ICommand RemoveItemQuantityCommand { get; }
    
    //Constructor
    public StockDatabaseModel() {
        AddItemCommand = new ViewModelCommand(ExecuteAddItemCommand);
        RemoveItemCommand = new ViewModelCommand(ExecuteRemoveItemCommand);
        AddItemQuantityCommand = new ViewModelCommand(ExecuteAddQuantityCommand);
        RemoveItemQuantityCommand = new ViewModelCommand(ExecuteRemoveQuantityCommand);
    }
    
    //Methods
    //******************************** Add Item ********************************
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
            ItemId2 = Guid.NewGuid().ToString("D").ToCharArray();
        
            // Retrieve values from properties
            char[] itemId = ItemId;
            string stockCode = StockCode;
            string itemName = ItemName;
            int itemQuantity = ItemQuantity;
            string customNote = CustomNote;
            string currentDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            
            char[] itemId2 = ItemId2;
            string type = "Item added";
            string quantityStats = "Added " + itemQuantity + " item(s)";
            int newQuantity = itemQuantity;

            // Create a new stock model object with the retrieved values from the properties and insert the values into the stock table
            StockModel stockModel = new StockModel(itemId, stockCode, itemName, itemQuantity, currentDate, customNote);
            InsertIntoStockDatabase(stockModel.Id, stockModel.StockCode, stockModel.ItemName, stockModel.ItemQuantity, stockModel.CurrentDate, stockModel.CustomNote);
            
            // Create a new stock log object with the retrieved values from the properties and insert the values into the log table
            StockLog stockLog = new StockLog(itemId2, stockCode, itemName, type, quantityStats, newQuantity, currentDate);
            InsertIntoLogDatabase(stockLog.Id, stockLog.LogDataStockCode, stockLog.LogDataItemName, stockLog.LogDataType, stockLog.LogDataQuantityStats, stockLog.LogDataNewQuantity, stockLog.LogDataDate);

            // Clear the properties after inserting the values into the database
            StockCode = "";
            ItemName = "";
            ItemQuantity = 0;
            CustomNote = "";
            ErrorMessage =  "";
            SuccessMessage = "* Item added successfully";
            ShowSuccessMessageWithFadeIn();
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
    
    private void InsertIntoLogDatabase(char[] itemId, string stockCode, string itemName, string type, string quantityStats, int newQuantity, string currentDate) {

        using (ConcreteRepository repository = new ConcreteRepository()) {
            string connectionString = repository.GetConnectionString();
            
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery =
                    "INSERT INTO transaction_log (Id, StockCode, ItemName, Type, QuantityStats, NewQuantity, Date) VALUES (@item_id, @stock_code, @item_name, @type, @quantity_stats, @new_quantity, @current_date)";

                using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@item_id", new string(itemId));
                    command.Parameters.AddWithValue("@stock_code", stockCode);
                    command.Parameters.AddWithValue("@item_name", itemName);
                    command.Parameters.AddWithValue("@type", type);
                    command.Parameters.AddWithValue("@quantity_stats", quantityStats ?? "");
                    command.Parameters.AddWithValue("@new_quantity", newQuantity);
                    command.Parameters.AddWithValue("@current_date", currentDate);

                    command.ExecuteNonQuery();
                }
                
                connection.Close();
            }
        }
    }
    
    //******************************** Add Item ********************************
    
    //******************************** Remove Item ********************************
    private void ExecuteRemoveItemCommand(Object obj) {
        try {
            if (string.IsNullOrWhiteSpace(RemoveStockCode)) {
                RemoveErrorMessage = "Error: Stock Code cannot be empty";
                
                RemoveItemName = "";
                RemoveItemQuantity = 0;
                RemoveCustomNote = "";  
                
                ShowRemoveErrorMessageWithFadeIn();
                return;
            }
            RemoveErrorMessage = "";
            
            ItemId2 = Guid.NewGuid().ToString("D").ToCharArray();
            
            // Retrieve values from properties
            string removeStockCode = RemoveStockCode;
            
            char[] itemId2 = ItemId2;
            string itemName = RemoveItemName;
            string type = "Item deleted";
            string quantityStats = "-";
            int newQuantity = 0;
            string currentDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            
            // Create a new stock model object with the retrieved values from the properties
            StockModel stockModel = new StockModel(removeStockCode);
            
            // Create a new stock log object with the retrieved values from the properties and insert the values into the log table
            StockLog stockLog = new StockLog(itemId2, removeStockCode, itemName, type, quantityStats, newQuantity, currentDate);
            InsertIntoLogDatabase(stockLog.Id, stockLog.LogDataStockCode, stockLog.LogDataItemName, stockLog.LogDataType, stockLog.LogDataQuantityStats, stockLog.LogDataNewQuantity, stockLog.LogDataDate);
            
            RemoveItemFromDatabase(stockModel.RemoveStockCode);
        }
        catch (MySqlException e) {
            RemoveErrorMessage =  "Error: " + e.Message;
            ShowRemoveErrorMessageWithFadeIn();
        }
        catch (Exception e) {
            RemoveErrorMessage =  "Error: " + e.Message;
            ShowRemoveErrorMessageWithFadeIn();
        }
    }
    
    private bool GetDetailsFromDatabase(string stockCode) {
        bool isSuccessful = false;
        
        using (ConcreteRepository repository = new ConcreteRepository()) {
            string connectionString = repository.GetConnectionString();
            
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {   
                connection.Open();

                string query = "SELECT ItemName, Quantity, Note FROM stock WHERE StockCode = @stockCode";
                
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.Add(new MySqlParameter("@stockCode", MySqlDbType.VarChar) { Value = stockCode });

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read()) 
                            {
                                string itemName = reader.GetString("ItemName");
                                int itemQuantity = reader.GetInt32("Quantity");
                                string customNote = reader.GetString("Note");

                                RemoveItemName = itemName;
                                RemoveItemQuantity = itemQuantity;
                                RemoveCustomNote = customNote;
                                
                                RemoveErrorMessage = "";
                            }
                            
                            isSuccessful = true;
                        }
                    }
                }
                connection.Close();
            }
        }
        
        return isSuccessful;
    }
    
    private void RemoveItemFromDatabase(string stockCode) {
        using (ConcreteRepository repository = new ConcreteRepository()) {
            string connectionString = repository.GetConnectionString();

            using (MySqlConnection connection = new MySqlConnection(connectionString)) {
                connection.Open();

                // Check if the stock code exists in the database
                string checkQuery = "SELECT COUNT(*) FROM stock WHERE StockCode = @stockCode";
                using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection)) {
                    checkCommand.Parameters.Add(new MySqlParameter("@stockCode", MySqlDbType.VarChar) { Value = stockCode });
                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (count == 0) {
                        RemoveErrorMessage = "Error: No entry found in the database for the given stock code";
                        ShowRemoveErrorMessageWithFadeIn();
                        return;
                    }

                    string deleteQuery = "DELETE FROM stock WHERE StockCode = @stockCode";
                    using (MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection)) {
                        deleteCommand.Parameters.Add(new MySqlParameter("@stockCode", MySqlDbType.VarChar) { Value = stockCode });
                        deleteCommand.ExecuteNonQuery();
                        
                        RemoveStockCode = "";
                        RemoveItemName = "";
                        RemoveItemQuantity = 0;
                        RemoveCustomNote = "";
                        RemoveErrorMessage = "";
                        
                        RemoveSuccessMessage = "* Item removed";
                        ShowRemoveSuccessMessageWithFadeIn();
                    }
                }
                connection.Close();
            }
        }
    }
    //******************************** Remove Item ********************************
    
    //******************************** Update Quantity ********************************
    private void ExecuteAddQuantityCommand(Object obj) {
        // Retrieve values from properties and create a new stock model object 
        string updateStockCode = UpdateStockCode;
        StockModel stockModel = new StockModel(updateStockCode);

        try {
            if (string.IsNullOrWhiteSpace(UpdateStockCode)) {
                UpdateErrorMessage = "Error: Stock Code cannot be empty";
                
                ShowUpdateErrorMessageWithFadeIn();
                return;
            }
            
            if (GetQuantityFromDatabase(stockModel.UpdateStockCode)) {
                
                ItemId2 = Guid.NewGuid().ToString("D").ToCharArray();
                
                // Retrieve values from properties
                int newUpdateItemQuantity = NewUpdateItemQuantity;
                
                char[] itemId2 = ItemId2;
                string itemName = UpdateItemName;
                string type = "Quantity added";
                string quantityStats = "Added " + newUpdateItemQuantity + " item(s)";
                int newQuantity = UpdateItemQuantity + newUpdateItemQuantity;
                string currentDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                
                // Create a new stock model object with the retrieved values from the properties and insert the values into the stock table
                StockModel updateStockModel = new StockModel(updateStockCode, newUpdateItemQuantity);
                AddQuantityInDatabase(updateStockModel.UpdateStockCode, updateStockModel.NewUpdateItemQuantity);
            
                // Create a new stock log object with the retrieved values from the properties and insert the values into the log table
                StockLog stockLog = new StockLog(itemId2, updateStockCode, itemName, type, quantityStats, newQuantity, currentDate);
                InsertIntoLogDatabase(stockLog.Id, stockLog.LogDataStockCode, stockLog.LogDataItemName, stockLog.LogDataType, stockLog.LogDataQuantityStats, stockLog.LogDataNewQuantity, stockLog.LogDataDate);
                
                UpdateItemName = "";
                UpdateItemQuantity = 0;
            }
            else {
                UpdateErrorMessage = "Error: No entry found in the database for the given stock code";
                ShowUpdateErrorMessageWithFadeIn();
                
                UpdateItemName = "";
                UpdateItemQuantity = 0;
            }
            
        }
        catch (MySqlException e) {
            UpdateErrorMessage =  "Error: " + e.Message;
            ShowUpdateErrorMessageWithFadeIn();
        }
        catch (Exception e) {
            UpdateErrorMessage = "Error: " + e.Message;
            ShowUpdateErrorMessageWithFadeIn();
        }
    }
    
    private void ExecuteRemoveQuantityCommand(Object obj) {
        string updateStockCode = UpdateStockCode;
        StockModel stockModel = new StockModel(updateStockCode);
        
        try {
            if (string.IsNullOrWhiteSpace(UpdateStockCode)) {
                UpdateErrorMessage = "Error: Stock Code cannot be empty";
                
                ShowUpdateErrorMessageWithFadeIn();
                return;
            }
            
            if (GetQuantityFromDatabase(stockModel.UpdateStockCode)) {
                
                ItemId2 = Guid.NewGuid().ToString("D").ToCharArray();
                
                // Retrieve values from properties
                int newUpdateItemQuantity = NewUpdateItemQuantity;
                
                char[] itemId2 = ItemId2;
                string itemName = UpdateItemName;
                string type = "Quantity removed";
                string quantityStats = "Removed " + newUpdateItemQuantity + " item(s)";
                int newQuantity = UpdateItemQuantity - newUpdateItemQuantity;
                string currentDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                
                // Create a new stock model object with the retrieved values from the properties and insert the values into the stock table
                StockModel updateStockModel = new StockModel(updateStockCode, newUpdateItemQuantity);
                RemoveQuantityInDatabase(updateStockModel.UpdateStockCode, updateStockModel.NewUpdateItemQuantity);
                
                // Create a new stock log object with the retrieved values from the properties and insert the values into the log table
                StockLog stockLog = new StockLog(itemId2, updateStockCode, itemName, type, quantityStats, newQuantity, currentDate);
                InsertIntoLogDatabase(stockLog.Id, stockLog.LogDataStockCode, stockLog.LogDataItemName, stockLog.LogDataType, stockLog.LogDataQuantityStats, stockLog.LogDataNewQuantity, stockLog.LogDataDate);
                
                if (newQuantity <= 0) {
                    RemoveItemFromDatabase(updateStockModel.UpdateStockCode);
                    
                    ItemId2 = Guid.NewGuid().ToString("D").ToCharArray();
                    
                    char[] itemId3 = ItemId2;
                    string itemName2 = UpdateItemName;
                    string type2 = "Item deleted";
                    string quantityStats2 = "-";
                    int newQuantity2 = 0;
                    string currentDate2 = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    
                    StockLog stockLog2 = new StockLog(itemId3, updateStockCode, itemName2, type2, quantityStats2, newQuantity2, currentDate2);
                    InsertIntoLogDatabase(stockLog2.Id, stockLog2.LogDataStockCode, stockLog2.LogDataItemName, stockLog2.LogDataType, stockLog2.LogDataQuantityStats, stockLog2.LogDataNewQuantity, stockLog2.LogDataDate);
                }
                
                UpdateItemName = "";
                UpdateItemQuantity = 0;
            }
            else {
                UpdateErrorMessage = "Error: No entry found in the database for the given stock code";
                ShowUpdateErrorMessageWithFadeIn();
                
                UpdateItemName = "";
                UpdateItemQuantity = 0;
            }
        }
        catch (MySqlException e) {
            UpdateErrorMessage =  "Error: " + e.Message;
            ShowUpdateErrorMessageWithFadeIn();
        }
        catch (Exception e) {
            UpdateErrorMessage = "Error: " + e.Message;
            ShowUpdateErrorMessageWithFadeIn();
        }
        
    }
    
    private void AddQuantityInDatabase(string updateStockCode, int newQuantity) {
        using (ConcreteRepository repository = new ConcreteRepository()) {
            string connectionString = repository.GetConnectionString();

            using (MySqlConnection connection = new MySqlConnection(connectionString)) {
                connection.Open();
                int newQty = UpdateItemQuantity + newQuantity;

                string query = "UPDATE stock SET Quantity = @newQuantity WHERE StockCode = @stockCode";
                
                using (MySqlCommand command = new MySqlCommand(query, connection)) {
                    command.Parameters.Add(new MySqlParameter("@stockCode", MySqlDbType.VarChar) { Value = updateStockCode }); 
                    command.Parameters.Add(new MySqlParameter("@newQuantity", MySqlDbType.Int32) { Value = newQty });
                    
                    command.ExecuteNonQuery();
                    
                    UpdateStockCode = "";
                    NewUpdateItemQuantity = 0;
                    
                    UpdateSuccessMessage = "* Quantity added";
                    ShowUpdateSuccessMessageWithFadeIn();
                }
                connection.Close();
            }
        }
    }

    private void RemoveQuantityInDatabase(string updateStockCode, int newQuantity) {
        using (ConcreteRepository repository = new ConcreteRepository()) {
            string connectionString = repository.GetConnectionString();

            using (MySqlConnection connection = new MySqlConnection(connectionString)) {
                connection.Open();
                
                int newQty = UpdateItemQuantity - newQuantity;
            
                string query = "UPDATE stock SET Quantity = @newQuantity WHERE StockCode = @stockCode";
            
                using (MySqlCommand command = new MySqlCommand(query, connection)) {
                    command.Parameters.Add(new MySqlParameter("@stockCode", MySqlDbType.VarChar) { Value = updateStockCode }); 
                    command.Parameters.Add(new MySqlParameter("@newQuantity", MySqlDbType.Int32) { Value = newQty });
                
                    command.ExecuteNonQuery();
                    
                    UpdateStockCode = "";
                    NewUpdateItemQuantity = 0;
                    
                    UpdateSuccessMessage = "* Quantity removed";
                    ShowUpdateSuccessMessageWithFadeIn();
                }
                
                connection.Close();
            }
        }
    }

    private bool GetQuantityFromDatabase(string stockCode) {
        bool isSuccessful = false;
        
        using (ConcreteRepository repository = new ConcreteRepository()) {
            string connectionString = repository.GetConnectionString();
            
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {   
                connection.Open();

                string query = "SELECT ItemName, Quantity FROM stock WHERE StockCode = @stockCode";
                
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.Add(new MySqlParameter("@stockCode", MySqlDbType.VarChar) { Value = stockCode });

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read()) 
                            {
                                string itemName = reader.GetString("ItemName");
                                int itemQuantity = reader.GetInt32("Quantity");

                                UpdateItemName = itemName;
                                UpdateItemQuantity = itemQuantity;
                                
                                UpdateErrorMessage = "";
                            }
                            
                            isSuccessful = true;
                        }
                    }
                }
                connection.Close();
            }
        }

        return isSuccessful;
    }
    //******************************** Update Quantity ********************************
    
    //******************************** Load Data ********************************
    public List<StockItem> LoadStockLevelData() {
        List<StockItem> stockItems = new List<StockItem>();
        
        using (ConcreteRepository repository = new ConcreteRepository()) {
            string connectionString = repository.GetConnectionString();

            using (MySqlConnection connection = new MySqlConnection(connectionString)) {
                connection.Open();

                string query = "SELECT * FROM stock";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    StockItem stockItem = new StockItem();
                    stockItem.DataStockCode = reader.GetString("StockCode");
                    stockItem.DataItemName = reader.GetString("ItemName");
                    stockItem.DataQuantity = reader.GetInt32("Quantity");
                    stockItem.DataDate = reader.GetString("Date");
                    stockItem.DataNote = reader.GetString("Note");

                    stockItems.Add(stockItem);
                }
                reader.Close();
            }
        }
        return stockItems;
    }
    
    public List<StockLog> LoadStockLogData() {
        List<StockLog> stockLogs = new List<StockLog>();
        
        using (ConcreteRepository repository = new ConcreteRepository()) {
            string connectionString = repository.GetConnectionString();

            using (MySqlConnection connection = new MySqlConnection(connectionString)) {
                connection.Open();

                string query = "SELECT * FROM transaction_log";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    StockLog stockLog = new StockLog();
                    stockLog.LogDataStockCode = reader.GetString("StockCode");
                    stockLog.LogDataItemName = reader.GetString("ItemName");
                    stockLog.LogDataType = reader.GetString("Type");
                    stockLog.LogDataQuantityStats = reader.GetString("QuantityStats");
                    stockLog.LogDataNewQuantity = reader.GetInt32("NewQuantity");
                    stockLog.LogDataDate = reader.GetString("Date");

                    stockLogs.Add(stockLog);
                }
                reader.Close();
            }
        }
        return stockLogs;
    } 
    
    //******************************** Load Data ********************************
    
    //******************************** Error message animation ********************************
    private void ShowErrorMessageWithFadeIn()
    {
        ShowErrorMessage("ErrorMessageBorder");
    }

    private void ShowRemoveErrorMessageWithFadeIn()
    {
        ShowErrorMessage("RemoveErrorMessageBorder");
    }
    
    private void ShowUpdateErrorMessageWithFadeIn()
    {
        ShowErrorMessage("UpdateErrorMessageBorder");
    }
    
    private void ShowErrorMessage(string borderName)
    {
        ErrorMessageOpacity = 0;

        if (Application.Current.MainWindow != null) {
            if (Application.Current.MainWindow.FindName(borderName) is Border border)
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
    
    private void ShowSuccessMessageWithFadeIn()
    {
        ShowSuccessMessage("SuccessMessageBorder");
    }
    
    private void ShowRemoveSuccessMessageWithFadeIn()
    {
        ShowSuccessMessage("RemoveSuccessMessageBorder");
    }
    
    private void ShowUpdateSuccessMessageWithFadeIn()
    {
        ShowSuccessMessage("UpdateSuccessMessageBorder");
    }
    
    private void ShowSuccessMessage(string borderName)
    {
        ErrorMessageOpacity = 0;

        if (Application.Current.MainWindow != null) {
            if (Application.Current.MainWindow.FindName(borderName) is Border border)
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
    //******************************** Error message animation ********************************
}
