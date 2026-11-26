using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiEx.Model
{
    public class ProductExternalPropertyModel
    {
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public string Description { get; set; }
        public int ProductExternalPropertyId { get; set; }
        public int ProductExternalPropertySetId { get; set; }
    }
}
