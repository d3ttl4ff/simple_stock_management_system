namespace simple_stock_management_system.Models; 

public class StockLog {
    public char[] Id { get;}
    public string LogDataStockCode { get; set; }
    public string LogDataItemName { get; set; }
    public string LogDataType { get; set; }
    public string LogDataQuantityStats { get; set; }
    public int LogDataNewQuantity { get; set; }
    public string LogDataDate { get; set; }
    
    public StockLog(){}
    
    public StockLog(char[] id, string dataStockCode, string dataItemName, string logDataType, string logDataQuantityStats, int logDataNewQuantity, string logDataDate) {
        Id = id;
        LogDataStockCode = dataStockCode;
        LogDataItemName = dataItemName;
        LogDataType = logDataType;
        LogDataQuantityStats = logDataQuantityStats;
        LogDataNewQuantity = logDataNewQuantity;
        LogDataDate = logDataDate;
    }
}
