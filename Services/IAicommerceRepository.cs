using NetFullStack.Entities;

namespace NetFullStack.Services
{
    public interface IAicommerceRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<IEnumerable<Product>> SearchProductsAsync(string searchKey);

        Task<Product?> GetSingleProductsAsync(int id);

        void AddProductsAsync(Product product);

        Task EditProductAsync(int Id, Product product);

        Task DeleteProductAsync(int productId);

        Task<bool> SaveChangesAsync();
    }
}