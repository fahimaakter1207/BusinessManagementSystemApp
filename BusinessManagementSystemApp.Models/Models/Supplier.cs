using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystemApp.Models.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Code")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter Contact")]
        public int Contact { get; set; }
        [Required(ErrorMessage = "Please enter ContactPerson")]
        public int ContactPerson { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public List<Supplier> Suppliers { get; set; }
    }
}
