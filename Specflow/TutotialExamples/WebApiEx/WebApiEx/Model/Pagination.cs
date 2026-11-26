using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiEx.Model
{
    public abstract class Pagination
    {
        public int PageNumber { get; set; }
        public int RowCount { get; set; }
    }
}
