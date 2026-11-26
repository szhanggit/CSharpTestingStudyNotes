using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiEx.Model
{
    public class BrandDto
    {
        public int? BrandId { get; set; }
        public string BrandName { get; set; }
        public int? BrandStatus { get; set; }
    }
}
