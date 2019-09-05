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
    public class SupplierRepository
    {
        BusinessManagementDbContext db = new BusinessManagementDbContext();
        public bool Add(Supplier supplier)
        {
            int isExecuted = 0;

            db.Suppliers.Add(supplier);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }
        public bool Delete(Supplier supplier)
        {
            int isExecuted = 0;
            Supplier asupplier = db.Suppliers.FirstOrDefault(c => c.Id == supplier.Id);

            db.Suppliers.Remove(asupplier);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }


            return false;
        }
        public bool Update(Supplier supplier)
        {
            int isExecuted = 0;
            db.Entry(supplier).State = EntityState.Modified;
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }
            return false;
        }
        public List<Supplier> GetAll()
        {
            return db.Suppliers.ToList();
        }
        public Supplier GetByID(Supplier supplier)
        {
            Supplier acustomer = db.Suppliers.FirstOrDefault(c => c.Id == supplier.Id);
            return acustomer;
        }
        public bool IsExistSupplier(Supplier supplier)
        {
            var aSupplier = db.Suppliers.FirstOrDefault(c => c.Code == supplier.Code);
            if (aSupplier != null)
            {
                return true;
            }
            return false;
        }
    }
}
