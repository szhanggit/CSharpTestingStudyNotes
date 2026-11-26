using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoFacWebApi2.Models
{
    public class UsersService
    {
        private INotificationService _notificationService;
        public UsersService(INotificationService notificationService)
        {
            this._notificationService = notificationService;
        }

        public void ChangeUsername(Users users, string newUsername)
        {
            users.Username = newUsername;
            _notificationService.notifyUsernameChanged(users);
        }
    }
}
