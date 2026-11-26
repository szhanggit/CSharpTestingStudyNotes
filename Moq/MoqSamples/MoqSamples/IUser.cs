using System;
using System.Collections.Generic;
using System.Text;

namespace MoqSamples
{
    public interface IUser
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
        int Gender { get; set; }
    }
}
