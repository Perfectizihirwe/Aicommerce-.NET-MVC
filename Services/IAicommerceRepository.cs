using NetFullStack.Entities;

namespace NetFullStack.Services
{
    public interface IAicommerceRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        void AddProductsAsync(Product product);

        Task<bool> SaveChangesAsync();
    }
}