
using System.ComponentModel.DataAnnotations;


namespace WebApplication1.Models.Models
{
    
    public class UserModel
    {

        public UserModel() {}
        
        public UserModel(string username, string password, List<OrderModel> orders)
        {
            Username = username;
            Password = password;
            Orders = orders;
        }
        
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<OrderModel> Orders { get; set; }
        
        
    }
}
