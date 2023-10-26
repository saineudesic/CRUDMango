using ModelClass;
namespace Repository
{
    public interface IRepository
    {
        Task<List<Product>> GetAllAsync();

        Task<Product> GetByIdAsync(int id);
        Task CreateNewProductAsync(Product newPeople);

    }
}