using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeBrowser.ExternalDataProviders
{
    public interface IExternalEmailProvider
    {
        public bool SendEmail(string to, string toName, string message);
    }
}
