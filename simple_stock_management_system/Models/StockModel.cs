namespace simple_stock_management_system.Models; 

public class StockModel {
    public char[] Id { get;}
    public string StockCode { get;}
    public string ItemName { get;}
    public int ItemQuantity { get;}
    public string CurrentDate { get;}
    public string CustomNote { get;}
    public string UpdateStockCode { get;}
    public int NewUpdateItemQuantity { get;}
    public string RemoveStockCode { get;}
    
    
    // Constructors (overloaded)
    public StockModel(string newStockCode) {
        UpdateStockCode = newStockCode;
        RemoveStockCode = newStockCode;
    }
    
    public StockModel(string newStockCode, int newQuantity) {
        UpdateStockCode = newStockCode;
        NewUpdateItemQuantity = newQuantity;
    }

    public StockModel(char[] id, string stockCode, string itemName, int itemQuantity, string currentDate, string customNote) {
        Id = id;
        StockCode = stockCode;
        ItemName = itemName;
        ItemQuantity = itemQuantity;
        CurrentDate = currentDate;
        CustomNote = customNote;
    }
    
}
