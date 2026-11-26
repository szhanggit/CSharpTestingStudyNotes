using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices.Model
{
    public class TenantDetail
    {
        public string TenantName { get; set; }
        public string Country { get; set; }
        public string TimeZone { get; set; }
        public string TimeFormat { get; set; }
        public decimal CompanyTaxRate { get; set; }
        public string EffectivityDate { get; set; }
        public string Language { get; set; }
    }
}
