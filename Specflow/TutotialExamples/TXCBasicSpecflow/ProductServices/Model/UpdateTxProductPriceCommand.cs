using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices.Model
{
    public class UpdateTxProductPriceCommand
    {
        public int ProductId { get; set; }

        public int FaceValue { get; set; }
        public int FaceValueWithTax { get; set; }
        public decimal? SellingPricePrepaid { get; set; }
        public decimal? SellingPricePrepaidWithTax { get; set; }
        public decimal? SellingPricePostpaid { get; set; }
        public decimal? SellingPricePostpaidWithTax { get; set; }

        public decimal? Cost { get; set; }
        public decimal? CostWithTax { get; set; }
        public int? Balance { get; set; }

        public decimal? CustomerFeePrepaid { get; set; }
        public decimal? CustomerFeePostpaid { get; set; }
        public decimal? MerchantFee { get; set; }
        public decimal? MerchantFeeWithTax { get; set; }
        public decimal? CustomerFeePrepaidWithTax { get; set; }
        public decimal? CustomerFeePostpaidWithTax { get; set; }

        public decimal? DefaultSellingPrice { get; set; }
        public decimal? DefaultProductCost { get; set; }
    }
}
