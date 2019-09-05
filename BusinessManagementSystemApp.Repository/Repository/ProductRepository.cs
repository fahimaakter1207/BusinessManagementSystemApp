using BusinessManagementSystemApp.DatabaseContext.DatabaseContext;
using BusinessManagementSystemApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BusinessManagementSystemApp.Repository.Repository
{
    public class ProductRepository
    {
        BusinessManagementDbContext db = new BusinessManagementDbContext();
        public bool SaveProduct(Product product)
        {
            db.Products.Add(product);
            return db.SaveChanges() > 0;
        }
        public List<Product> GetProducts()
        {
            return db.Products.Include(c=>c.Category).Where(c => c.IsActive == "True").ToList();
        }

        public List<Product> SearchProducts(ProductViewModel productViewModel)
        {
            var products = db.Products.Include(c => c.Category).Where(c => c.ProductName.ToLower().Contains(productViewModel.SearchText.ToLower()) && c.IsActive == "True" || c.ProductCode.ToLower().Contains(productViewModel.SearchText.ToLower()) && c.IsActive == "True" || c.Category.CategoryName.ToLower().Contains(productViewModel.SearchText.ToLower()) && c.IsActive == "True").ToList();
            return products;
        }
        public Product GetProductById(Product product)
        {
            return db.Products.Include(c=>c.Category).Where(c => c.ProductId == product.ProductId && c.IsActive == "True").FirstOrDefault();
        }
        public bool UpdateProduct(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool DeleteProduct(Product product)
        {
            db.Products.Remove(product);
            return db.SaveChanges() > 0;
        }
        public bool IsExistProduct(ProductViewModel productViewModel)
        {
            if (productViewModel.ActionType == "Insert")
            {
                var aProduct = db.Products.Where(c => c.ProductName.ToLower() == productViewModel.ProductName.ToLower() && c.IsActive == "True").FirstOrDefault();
                if (aProduct!= null)
                {
                    return true;
                }
            }
            if (productViewModel.ActionType == "Update")
            {
                var aProduct = db.Products.Where(c => c.ProductName.ToLower() == productViewModel.ProductName.ToLower() && c.IsActive == "True").FirstOrDefault();
                if (aProduct != null)
                {
                    if (aProduct.ProductId == productViewModel.ProductId)
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public List<Product> GetProductsWithCatagory(Product product)
        {
            var products = db.Products.Include(c => c.Category).Where(c => c.Category.CategoryName.ToLower().Contains(product.CategoryName.ToLower()) || c.ProductName.ToLower().Contains(product.ProductName.ToLower())).ToList();
            return products;
        }
        public List<Product> GetAll()
        {
            return db.Products.Include(p => p.Category).ToList();
        }
    }
}
