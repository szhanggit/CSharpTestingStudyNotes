using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiEx.Model
{
    public class GetClientListQuery : Pagination
    {
        public string SearchKeyword { get; set; }
        public int ClientId { get; set; }
    }
}
