using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystemApp.Models.Models
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Please insert category name")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Please insert category code")]
        public string CategoryCode { get; set; }
        public string IsActive { get; set; }
        public DateTime Date { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
        public string ActionType { get; set; }
        public string SearchText { get; set; }
    }
}
