using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessManagementSystemApp.Models.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerModelsId { get; set; }
        public CustomerModel CustomerModels { get; set; }
        public float CustomerPayment { get; set; }
        public string Comments { get; set; }
        public List<SalesDetails> SalesDetailsList { get; set; }
    }
}