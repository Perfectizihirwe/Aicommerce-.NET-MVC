using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFullStack.Entities
{
    public class Order
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        public int ProductId { get; set; }

        [Required]
        public int Total { get; set; }

        [Required]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public int PhoneNumber { get; set; }

        public Order(int id, int productId, string firstName,string productName, string lastName, int phoneNumber, int total, string address)
        {
            Id = id;
            ProductId = productId;
            ProductName = productName;
            PhoneNumber = phoneNumber;
            Total = total;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }
    }
}