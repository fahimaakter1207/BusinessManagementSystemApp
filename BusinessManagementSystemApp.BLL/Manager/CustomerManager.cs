using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessManagementSystemApp.Models;
using BusinessManagementSystemApp.Repository.Repository;
using BusinessManagementSystemApp.Models.Models;

namespace BusinessManagementSystemApp.BLL.Manager
{
    
    public class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();
        public bool Insert(CustomerModel customerModel)
        {
            return _customerRepository.Insert(customerModel);
        }

        public bool Update(CustomerModel customerModel)
        {
            return _customerRepository.Update(customerModel);
        }

        public bool Delete(CustomerModel customerModel)
        {
            return _customerRepository.Delete(customerModel);
        }
        public CustomerModel FindById(CustomerModel customerModel)
        {
            return _customerRepository.FindById(customerModel);
        }
        public List<CustomerModel> FindAll()
        {
            return _customerRepository.FindAll();
        }

        public CustomerModel IsExist(int CustCode)
        {
            return _customerRepository.IsExist(CustCode);
        }
    }
}