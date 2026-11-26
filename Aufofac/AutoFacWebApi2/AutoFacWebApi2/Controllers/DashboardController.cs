using AutoFacWebApi2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoFacWebApi2.Controllers
{
    /*
    https://localhost:44368/api/Dashboard/zyd
     */
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly INotificationService _notifyService;
        private readonly INotificationService2 _notifyService2;
        public DashboardController(INotificationService notifyService, INotificationService2 notifyService2)
        {
            _notifyService = notifyService;
            _notifyService2 = notifyService2;
        }
        [HttpPost("{name}")]
        public ActionResult<HelloMessage> GetMessage(string name)
        {
            // call container here...
            _notifyService.notifyUsernameChanged(new Users(name));
            _notifyService2.notifyUsernameChanged2(new Users(name));
            var result = new HelloMessage()
            {
                GivenName = name,
                ReturnMessage = "Dashboard@ Hello, Welcome to Texanite Digital"
            };

            return result;
        }
    }
}
