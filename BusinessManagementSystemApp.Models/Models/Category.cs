using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystemApp.Models.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Please enter category name.")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Please enter category code.")]
        public string CategoryCode { get; set; }
        public string IsActive { get; set; }
        public DateTime Date { get; set; }
        //public List<Product> Products { get; set; }
    }
}
