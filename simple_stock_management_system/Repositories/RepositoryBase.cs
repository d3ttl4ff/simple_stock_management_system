using System;
using MySql.Data.MySqlClient;

namespace simple_stock_management_system.Repositories {
    public abstract class RepositoryBase : IDisposable
    {
        protected readonly string ConnectionString = "server=localhost;user=root;database=main;port=3306;password=root";
        private readonly MySqlConnection _connection;

        protected RepositoryBase()
        {
            _connection = new MySqlConnection(ConnectionString);
        }

        protected MySqlConnection GetConnection() 
        {
            return _connection;
        }

        public void Dispose() {
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
    }
}

