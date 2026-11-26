using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices.Model
{
    public class CreateExternalPropertyListCommand
    {
        [Required(ErrorMessage = "ProductId required")]
        public int ProductId { get; set; }
        public List<ProductExternalPropertyModel> ProductExternalPropertyList { get; set; }
    }
}
