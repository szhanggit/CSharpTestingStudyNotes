using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoFacWebApi2.Models
{
    public class NotifyService2 : INotificationService2
    {
        public void notifyUsernameChanged2(Users users)
        {
            string changedUsername = users.Username;

            Console.WriteLine("Username has changed to ... ");
            Console.WriteLine(changedUsername);
        }
    }
}
