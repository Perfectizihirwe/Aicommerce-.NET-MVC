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

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _aicontext.Orders.ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(string searchKey)
        {
            var collection = _aicontext.Products as IQueryable<Product>;

            if (!string.IsNullOrEmpty(searchKey))
            {
                searchKey = searchKey.ToLower().Trim();
                collection = collection.Where(c => c.Name.ToLower().Contains(searchKey));
            }

            var collectionToReturn = await collection.OrderBy(c => c.Name).ToListAsync();

            return collectionToReturn;
        }

        public async Task<Product?> GetSingleProductsAsync(int id)
        { 
          return await _aicontext.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public void AddProductsAsync(Product product)
        {
            _aicontext.Products.Add(product);
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await GetSingleProductsAsync(productId);
            if (product != null)
            {
            _aicontext?.Products.Remove(product);
                return;
            }
            throw new Exception("No product found");
        }

        public async Task EditProductAsync(int Id, Product product)
        {
            var productFromDb = await GetSingleProductsAsync(Id);
            if (productFromDb != null)
            {
                Console.WriteLine("------------------------------------------------");
                productFromDb.Price = product.Price;
                productFromDb.Description = product.Description;
                productFromDb.Name = product.Name;
                productFromDb.Gender = product.Gender;
            }
        }

        public void AddOrderAsync(Order order)
        {
            _aicontext.Orders.Add(order);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _aicontext.SaveChangesAsync() >= 0);
        }
    }
}