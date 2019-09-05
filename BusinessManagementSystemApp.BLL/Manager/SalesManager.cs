using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessManagementSystemApp.Repository.Repository;
using BusinessManagementSystemApp.Models.Models;
using BusinessManagementSystemApp.Models;


namespace BusinessManagementSystemApp.BLL.Manager
{
    public class SalesManager
    {
        SalesRepository _salesRepository = new SalesRepository();
        public bool Save(SalesDetails salesModel)
        {
            return _salesRepository.Save(salesModel);
        }
        public bool SaveSalesProduct(Sale sale)
        {
            return _salesRepository.SaveSalesProduct(sale);

        }

        public bool Update(SalesDetails salesModel)
        {
            return _salesRepository.Update(salesModel);
        }

        public bool Delete(Sale sale)
        {
            return _salesRepository.Delete(sale);
        }
        public SalesDetails FindById(SalesDetails salesModel)
        {
            return _salesRepository.FindById(salesModel);
        }
        public List<Sale> FindAll()
        {
            return _salesRepository.FindAll();
        }

        public bool Save(List<SalesDetails> salesModel)
        {
            return _salesRepository.Save(salesModel);
        }
        public CustomerModel GetCustLoyaltyPoints(int CustId)
        {
            return _salesRepository.GetCustLoyaltyPoints(CustId);
        }
        public Product ProductDetails(int ProId)
        {
            return _salesRepository.ProductDetails(ProId);
        }
        public List<SalesDetails> VoucherDetails(int voucherNo)
        {
            return _salesRepository.VoucherDetails(voucherNo);
        }
    }
}