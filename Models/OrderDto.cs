using System.ComponentModel.DataAnnotations;

namespace NetFullStack.Models
{
    public class OrderDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public int Total { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public int PhoneNumber { get; set; }

    }
}