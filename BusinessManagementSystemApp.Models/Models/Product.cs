using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystemApp.Models.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int ReorderLevel { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public List<Category> Categories { get; set; }
        [NotMapped]
        public List<Product> Products { get; set; }
        [NotMapped]
        public string CategoryName { get; set; }
        [NotMapped]
        public IEnumerable<Category> CategoryList { get; set; }
        public int AvailableQuantity { get; set; }
        public decimal CurrentMRP { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
