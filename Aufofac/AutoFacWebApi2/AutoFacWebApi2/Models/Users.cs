using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoFacWebApi2.Models
{
    public class Users
    {
        public string Username { get; set; }

        public Users(string username)
        {
            this.Username = username;
        }
    }
}
