using MySql.Data.MySqlClient;

namespace simple_stock_management_system.Repositories {
    public abstract class RepositoryBase
    {
        private readonly string _connectionString = "server=localhost;user=root;database=main;port=3306;password=root";

        protected MySqlConnection GetConnection() 
        {
            return new MySqlConnection(_connectionString);
        }
    }
}

