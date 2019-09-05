using BusinessManagementSystemApp.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessManagementSystemApp.Models
{
    public class SalesSaveViewModel
    {
        public SalesSaveViewModel()
        {
            SalesDetailsList = new List<SalesDetails>();
        }
        [Required(ErrorMessage = "Please Enter Customer")]
        [DisplayName("Customer")]
        public int CustomerModelsId { get; set; }
        public CustomerModel CustomerModels { get; set; }
        [Required(ErrorMessage = "Please Enter Date")]
        public DateTime Date { get; set; }

        [DisplayName("Product")]
        public int ProductsId { get; set; }
        public Product Products { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Please Enter Unit Pprice")]
        [DisplayName("Unit Price")]
        public int UnitPrice { get; set; }
        [DisplayName("Total")]
        public float Total { get; set; }
        [DisplayName("Total")]
        public float SubTotal { get; set; }

        [DisplayName("Availabel Quantity")]
        public int AvQuantity { get; set; }
        [DisplayName("Loyality Points")]
        public float LoyalityPoints { get; set; }
        public float CustomerPayment { get; set; }
        public float Discount { get; set; }
        public string Comments { get; set; }
        public IEnumerable<SelectListItem> CustomerList { get; set; }
        public IEnumerable<SelectListItem> ProductList { get; set; }
        public List<Sale> SalesList { get; set; }
        public List<SalesDetails> SalesDetailsList { get; set; }

    }
}