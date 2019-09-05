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
    public class PurchaseRepository
    {
        BusinessManagementDbContext db = new BusinessManagementDbContext();
        public bool InsertPurchaseProduct(Purchase purchase)
        {
            db.Purchases.Add(purchase);
            return db.SaveChanges() > 0;
        }
        public ProductViewModel LatestProduct(Product product)
        {
            ProductViewModel aProduct = new ProductViewModel();
            var products = db.PurchaseDetails.Where(c => c.ProductId == product.ProductId).ToList();
            if (products.Count > 0)
            {
                int count = 0;
                int latestList = products.Count;
                foreach (var pro in products)
                {
                    count++;
                    if (latestList == count)
                    {
                        aProduct.ProductId = pro.ProductId;
                        aProduct.PreviousCostPrice = pro.UnitPrice;
                        aProduct.PreviousMRP = pro.NewMRP;
                        aProduct.ExpireDate = pro.ExpireDate;
                    }
                }
            }
            return aProduct;
        }
        public List<PurchaseDetails> GetPurchaseProducts()
        {
            var purchases = db.PurchaseDetails.Include(c => c.Product).ToList();
            return purchases;
        }
        public List<PurchaseDetails> GetPurchaseProductsByExpireDate(ProductViewModel productViewModel)
        {
            var purchases = db.PurchaseDetails.Include(c => c.Product).Where(c=>c.ExpireDate>=productViewModel.StartDate && c.ExpireDate<=productViewModel.EndDate).ToList();
            return purchases;
        }
        //public int GetSalesProductQuantity(Product product)
        //{
        //    int salesQuantity = 0;
        //    var salesProducts = db.SalesDetails.Where(c => c.ProductId == product.ProductId).ToList();
        //    foreach(var aProduct in salesProducts)
        //    {
        //        salesQuantity += aProduct.Quantity;
        //    }
        //    return salesQuantity;
        //}
    }
}
