using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController()
        {

        }

        [HttpGet("GetProductBrand")]
        public async Task<IActionResult> Get([FromQuery] GetProductBrandQuery query, CancellationToken cancellationToken)
        {
            BrandDto _brandDto = new BrandDto { 
             BrandId = 1,
             BrandName = "Ali",
             BrandStatus = 0
            };
            Response<BrandDto> _response = new Response<BrandDto> { Success = true, Message = "success", Data = _brandDto }; 
            return Ok(_response);
        }

        [HttpPost]
        [Route("ExternalProperty")]
        public async Task<IActionResult> Post([FromBody] CreateExternalPropertyListCommand create, CancellationToken cancellationToken)
        {
            Response<int> _response = ProductServices.Model.Response.Success("success", 1);
            return Ok(_response);
        }

        [Route("Price")]
        [HttpPut]
        public async Task<IActionResult> Put(UpdateTxProductPriceCommand command, CancellationToken cancellationToken)
        {
            var result = new Response<int>()
            {
                Success = true,
                Message = "0000",
                Data = 1
            };
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
