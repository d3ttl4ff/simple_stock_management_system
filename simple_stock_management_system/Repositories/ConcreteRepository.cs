namespace simple_stock_management_system.Repositories; 

public class ConcreteRepository : RepositoryBase {
    
    public ConcreteRepository() : base() {}
    
    public string GetConnectionString()
    {
        return ConnectionString;
    }
}
