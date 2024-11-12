

using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Models
{
    public class ProductModel
    {
        public ProductModel(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }

        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
        public int Cost { get; set; }
        
        
    }
}

