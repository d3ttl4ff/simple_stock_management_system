namespace simple_stock_management_system.Models; 

public class UserModel {
    public string UserId { get; set; }
    public string UserUsername { get; set; }
    public string UserPassword { get; set; }
    public string UserName { get; set; }
    public string UserLastName { get; set; }
    public string UserEmail { get; set; }
    
    public UserModel(string userUsername, string userPassword) {
        UserUsername = userUsername;
        UserPassword = userPassword;
    }
}