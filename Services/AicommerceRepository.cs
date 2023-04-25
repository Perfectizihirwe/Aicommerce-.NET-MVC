using Microsoft.EntityFrameworkCore;
using NetFullStack.Context;
using NetFullStack.Entities;

namespace NetFullStack.Services
{
    public class AicommerceRepository : IAicommerceRepository
    {
        private readonly AicommerceContext _aicontext;
        public AicommerceRepository(AicommerceContext context)
        {
            _aicontext = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _aicontext.Products.ToListAsync();
        }

        public void AddProductsAsync(Product product)
        {
            _aicontext.Products.Add(product);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _aicontext.SaveChangesAsync() >= 0);
        }
    }
}