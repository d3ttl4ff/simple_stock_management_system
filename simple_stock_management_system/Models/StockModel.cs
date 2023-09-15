using System;

namespace simple_stock_management_system.Models; 

public class StockModel {
    public char[] Id { get; set; }
    public string StockCode { get; set; }
    public string ItemName { get; set; }
    public int ItemQuantity { get; set; }
    public string CurrentDate { get; set; }
    public string CustomNote { get; set; }

    public StockModel(char[] id, string stockCode, string itemName, int itemQuantity, string currentDate, string customNote) {
        Id = id;
        StockCode = stockCode;
        ItemName = itemName;
        ItemQuantity = itemQuantity;
        CurrentDate = currentDate;
        CustomNote = customNote;
    }
    
}
