using System.Collections.Generic;
using System.Net;
using MySql.Data.MySqlClient;
using simple_stock_management_system.Models;

namespace simple_stock_management_system.Repositories {
    public class UserRepository : RepositoryBase, IUserRepository {
        
        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (MySqlConnection connection = GetConnection())
                using (var command = new MySqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM user WHERE username = ? AND password = ?";
                    command.Parameters.Add("@username", MySqlDbType.VarChar).Value = credential.UserName;
                    command.Parameters.Add("@password", MySqlDbType.VarChar).Value = credential.Password;
                    validUser = command.ExecuteScalar() == null ? false : true;
                }
            return validUser;
        }
        
        public void Add(UserModel userModel) {
            throw new System.NotImplementedException();
        }

        public void Edit(UserModel userModel) {
            throw new System.NotImplementedException();
        }

        public void Remove(int id) {
            throw new System.NotImplementedException();
        }

        public UserModel GetById(int id) {
            throw new System.NotImplementedException();
        }

        public UserModel GetByUsername(string username) {
            throw new System.NotImplementedException();
        }

        public IEnumerable<UserModel> GetByAll() {
            throw new System.NotImplementedException();
        }
    }
}
