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

    
    public class CustomerRepository
    {
        BusinessManagementDbContext db = new BusinessManagementDbContext();
        public bool Insert(CustomerModel customerModel)
        {
            int isExecuted = 0;
            db.CustomerModels.Add(customerModel);
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }
        public CustomerModel FindById(CustomerModel customerModel)
        {
            CustomerModel aCustomer = db.CustomerModels.FirstOrDefault(c => c.Id == customerModel.Id);
            return aCustomer;
        }
        public bool Update(CustomerModel customerModel)
        {
            int isExecuted = 0;

            db.Entry(customerModel).State = EntityState.Modified;
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }
            return false;
        }
        public bool Delete(CustomerModel customerModel)
        {
            int isExecuted = 0;
            CustomerModel aCustomerModel = db.CustomerModels.FirstOrDefault(c => c.Id == customerModel.Id);

            db.CustomerModels.Remove(aCustomerModel);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }
            return false;
        }
        public List<CustomerModel> FindAll()
        {
            return db.CustomerModels.ToList();
        }

        public CustomerModel IsExist(int CustCode)
        {
            CustomerModel aCustomer = db.CustomerModels.FirstOrDefault(c => c.CustCode == CustCode);
            return aCustomer;
        }

    }
}