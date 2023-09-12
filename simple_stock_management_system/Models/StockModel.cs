using System;

namespace simple_stock_management_system.Models; 

public class StockModel {
    public string Id { get; set; }
    public string StockCode { get; set; }
    public string ItemName { get; set; }
    public int ItemQuantity { get; set; }
    public DateTime CurrentDate { get; set; }
}
