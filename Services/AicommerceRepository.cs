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

        public async Task AddProductsAsync()
        {

        }

        public void SaveChangesAsync()
        {

        }
    }
}