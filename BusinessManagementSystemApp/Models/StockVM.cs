using BusinessManagementSystemApp.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessManagementSystemApp.Models
{
    public class StockVM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }

        [DataType(DataType.Date)]
        public DateTime StratDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExpireDate { get; set; }
        public int Quantity { get; set; }
        public int ReorderLevel { get; set; }
        public string Code { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> ProductList { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
    }
}