using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

using System.ComponentModel;
using BusinessManagementSystemApp.Models.Models;

namespace MvcPosApp.Models
{
    public class CustomerVM
    {
        [Display(Name = "Customer Code")]
        public int CustCode { get; set; }
        [Required(ErrorMessage = "Please enter Name!")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Customer Name")]
        public string CustName { get; set; }
        [Required(ErrorMessage = "Please enter E-mail!")]
        [Display(Name = "Customer E-mail")]
        public string CustEmail { get; set; }

        [Required(ErrorMessage = "Please enter Address!")]
        [Display(Name = "Customer Address")]
        public string CustAddress { get; set; }

        [Required(ErrorMessage = "Please enter Contact Number!")]
        //[StringLength(14, MinimumLength = 6)]
        [Display(Name = "Customer Mobile")]
        public int CustContact { get; set; }
        [Display(Name = "Loyalty Points")]
        public int CustLoyaltyPoints { get; set; }
        [NotMapped]
        public virtual List<SalesDetails> SalesList { get; set; }

    }
}