using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoFacWebApi.Services
{
    public class CommentsService : ICommentsService
    {
        public string GetComments()
        {
            return "This is a static data.";
        }
    }
}
