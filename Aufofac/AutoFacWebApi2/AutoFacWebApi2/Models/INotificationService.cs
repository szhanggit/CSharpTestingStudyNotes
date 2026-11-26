using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoFacWebApi2.Models
{
    public interface INotificationService
    {
        void notifyUsernameChanged(Users users);
    }
}
