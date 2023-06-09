using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFullStack.Entities
{
    public class Product
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int Price { get; set; }

        [Required]
        public string Gender { get; set; } = string.Empty;

        [Required]
        public string Image { get; set; } = string.Empty;

        public Product(int id, string name, string description, int price, string gender, string image)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Gender = gender;
            Image = image;
        }
    }
}