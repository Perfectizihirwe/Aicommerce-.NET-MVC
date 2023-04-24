using NetFullStack.Entities;

namespace NetFullStack.Services
{
    public interface IAicommerceRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        Task AddProductsAsync();

        void SaveChangesAsync();
    }
}