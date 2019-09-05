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
    public class SalesRepository
    {
        BusinessManagementDbContext db = new BusinessManagementDbContext();
        public bool Save(SalesDetails salesModel)
        {
            int isExecuted = 0;
            db.SalesDetails.Add(salesModel);
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }
        public bool SaveSalesProduct(Sale sale)
        {
            db.Sales.Add(sale);
            return db.SaveChanges() > 0;

        }

        public bool Save(List<SalesDetails> salesAdd)
        {
            int isExecuted = 0;

            db.SalesDetails.AddRange(salesAdd);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }
        public SalesDetails FindById(SalesDetails salesModel)
        {
            SalesDetails aSales = db.SalesDetails.FirstOrDefault(c => c.Id == salesModel.Id);
            return aSales;
        }
        public bool Update(SalesDetails salesModel)
        {
            int isExecuted = 0;

            db.Entry(salesModel).State = EntityState.Modified;
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }
            return false;
        }
        public bool Delete(Sale sale)
        {
            int isExecuted = 0;
            Sale aSales = db.Sales.FirstOrDefault(c => c.Id == sale.Id);

            db.Sales.Remove(aSales);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }
            return false;
        }
        public List<Sale> FindAll()
        {
            return db.Sales.Include(c=>c.CustomerModels).ToList();
        }
        public CustomerModel GetCustLoyaltyPoints(int CustId)
        {
            CustomerModel aCustomer = db.CustomerModels.FirstOrDefault(c => c.Id == CustId);
            return aCustomer;
        }
        public Product ProductDetails(int ProId)
        {
            Product aProduct = db.Products.FirstOrDefault(c => c.ProductId== ProId);
            return aProduct;
        }
        public List<SalesDetails> VoucherDetails(int voucherNo)
        {
            
            var  salesDetialsList = db.SalesDetails.Include(c=>c.Products).ToList();
            ////var salesDetialsList = from cust in db.SalesDetails
            ////                   where cust.SaleId == voucherNo
            ////                   select cust;

            salesDetialsList = salesDetialsList.Where(c => c.SaleId == voucherNo).ToList();
            //salesDetialsList = salesDetialsList.Where(c => c.SaleId == voucherNo).ToList();
            return salesDetialsList;
        }
    }
}