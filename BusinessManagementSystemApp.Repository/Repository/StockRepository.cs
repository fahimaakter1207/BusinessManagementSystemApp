using BusinessManagementSystemApp.DatabaseContext.DatabaseContext;
using BusinessManagementSystemApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystemApp.Repository.Repository
{
    public class StockRepository
    {
        BusinessManagementDbContext db = new BusinessManagementDbContext();
        public List<Product> GetAll()
        {
            return db.Products.Include(p => p.Categories).ToList();
        }


        public PurchaseDetails PurchaseDetails(Product product, DateTime startDate, DateTime endDate)
        {
            var aProduct = db.PurchaseDetails.Include(c => c.Product).Where(c => c.Product.ProductName.ToLower() == product.ProductName.ToLower() && c.ExpireDate >= startDate && c.ExpireDate < endDate).FirstOrDefault();

            //var aProduct = db.PurchaseDetails.Include(c => c.Product).Where(c => c.Product.Name.ToLower() == product.ProductName.ToLower()).FirstOrDefault();
            return aProduct;
        }
        public PurchaseDetails AvailableQuantity(Product product)
        {

            var aProduct = db.PurchaseDetails.Include(c => c.Product).Where(c => c.Product.ProductName.ToLower() == product.ProductName.ToLower()).FirstOrDefault() ;
            return aProduct;
        }
    }
}
