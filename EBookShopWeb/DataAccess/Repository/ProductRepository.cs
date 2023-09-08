using DataAccess.Repository.IRepository;
using EBookShopWeb.DataAccess;
using EBookShopWeb.Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            var productToUpdate=_db.Products.FirstOrDefault(x => x.Id == product.Id);
            if (productToUpdate != null )
            {
                productToUpdate.Title = product.Title;
                productToUpdate.Description = product.Description;
                productToUpdate.CategoryId = product.CategoryId;
                productToUpdate.Price = product.Price;
                productToUpdate.ListPrice = product.ListPrice;
                productToUpdate.Price50= product.Price50;
                productToUpdate.ISBN = product.ISBN;
                productToUpdate.Author= product.Author;
                productToUpdate.Price100= product.Price100;
                if (product.ImageUrl !=null)
                {
                    productToUpdate.ImageUrl = product.ImageUrl;
                }
                
            }
            /*_db.Products.Update(product)*/;
        }
    }
}
