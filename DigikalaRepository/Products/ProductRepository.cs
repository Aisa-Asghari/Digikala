using System;
using System.Collections.Generic;
using System.Linq;
using DigikalaDataAccess.Context;
using DigikalaDataAccess.Entity;

namespace DigikalaRepository.Products
{
    class ProductRepository : IProductRepository
    {
        public void Create(Product product)
        {
            using (var db = new DigikalaDB())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new DigikalaDB())
            {
                var item = db.Products.Where(x => x.ID == id).FirstOrDefault();
                db.Remove<Product>(item);
                db.SaveChanges();
            }
        }

        public void Edit(Product product)
        {
            using (var db = new DigikalaDB())
            {
                var item = db.Products.First(x => x.ID == product.ID);
                item.ProductName = product.ProductName;
                item.ProductPrice = product.ProductPrice;
                item.ProductURL = product.ProductURL;
                db.SaveChanges();
            }
        }

        public List<Product> GetAll()
        {
            using (var db = new DigikalaDB())
            {
                return db.Products.ToList();
            }
        }

        public Product GetById(int id)
        {
            using (var db = new DigikalaDB())
            {
                return db.Products.Where(x => x.ID == id).FirstOrDefault();
            }
        }
    }
}
