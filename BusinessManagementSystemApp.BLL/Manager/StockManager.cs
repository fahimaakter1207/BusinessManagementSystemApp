using BusinessManagementSystemApp.Models.Models;
using BusinessManagementSystemApp.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessManagementSystemApp.Models;

namespace BusinessManagementSystemApp.BLL.Manager
{
    public class StockManager
    {
        StockRepository _stockRepository = new StockRepository();

        public List<Product> GetAll()
        {
            return _stockRepository.GetAll();
        }
    }
}
