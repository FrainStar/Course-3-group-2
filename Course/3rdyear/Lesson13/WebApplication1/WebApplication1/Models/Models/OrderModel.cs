
using System.ComponentModel.DataAnnotations;


namespace WebApplication1.Models.Models
{
    public class OrderModel
    {

        // public OrderModel()
        // {
        //     Id = 0; 
        //     UserId = 0;
        //     User = new UserModel();
        // }
        //
        // public OrderModel(int userId, List<int> products)
        // {
        //     UserId = userId;
        //     Products = products;
        //     User = new UserModel();
        // }

        public OrderModel(int userId, List<int> products)
        {
            UserId = userId;
            Products = products;
        }
        
        [Key]
        public int Id { get; set; }
        public int UserId { get; set;  }
        // public UserModel User { get; set; }
        public List<int> Products { get; set; }

    }
}

