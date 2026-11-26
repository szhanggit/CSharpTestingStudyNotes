using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiEx.Model;

namespace WebApiEx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpGet("GetClients")]
        public async Task<IActionResult> Get([FromQuery] GetClientListQuery query, CancellationToken cancellation)
        {
            ClientDto _brandDto = new ClientDto
            {
                ClientId = 1,
                ClientName = "asfsdf",
                IdentityCode = "0000012"
            };
            Response<ClientDto> _response = new Response<ClientDto> { Success = true, Message = "success", Data = _brandDto };
            return Ok(_response);
        }

        [HttpPost("CreateClient")]
        public async Task<Response<int>> Post([FromForm] CreateTxClientRequest query, CancellationToken cancellationToken)
        {
            return WebApiEx.Model.Response.Success("success", 1);
        }
    }
}
