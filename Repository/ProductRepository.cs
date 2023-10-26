using ModelClass;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IRepository
    {
        private readonly IMongoCollection<Product> _productCollection;

        public ProductRepository(IMongoDatabase mongoDatabase)
        {
            _productCollection = mongoDatabase.GetCollection<Product>("Products");
        }
        public async Task<List<Product>> GetAllAsync()
        {
            return await _productCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productCollection.Find(_ => _.ProductId == id.ToString()).FirstOrDefaultAsync();
        }

        public async Task CreateNewProductAsync(Product newProduct)
        {
            try
            {
               
                await _productCollection.InsertOneAsync(newProduct);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw;
            }

        }


    }
}
