using Catalog.API.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{

    public interface IProductRepository {

        Task<IReadOnlyCollection<Product>> GetProducts();
        Task<Product> GetProductByName(string name);
        Task<Product> GetProduct(string id);
        Task<IReadOnlyCollection<Product>> GetProductsByCategory(string categoryName);

        Task CreateProduct(Product product);

        Task<bool> UpdateProduct(Product product);

        Task<bool> DeleteProduct(string id);


    }
}