using DigikalaDataAccess.Entity;
using System.Collections.Generic;

namespace DigikalaRepository.Products
{
    public interface IProductRepository
    {
        void Create(Product product);
        List<Product> GetAll();
        Product GetById(int id);
        void Delete(int id);
        void Edit(Product product);
    }
}
