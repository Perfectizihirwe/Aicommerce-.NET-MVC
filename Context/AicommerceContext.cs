using Microsoft.EntityFrameworkCore;
using NetFullStack.Entities;

namespace NetFullStack.Context
{
    public class AicommerceContext : DbContext
    {
        public DbSet<Product> Products {get; set;} = null!;

        public DbSet<Order> Orders { get; set;} = null!;
        public AicommerceContext(DbContextOptions<AicommerceContext> options) : base(options)
        {

        }
    }
}