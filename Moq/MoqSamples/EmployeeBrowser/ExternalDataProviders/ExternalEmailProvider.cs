using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeBrowser.ExternalDataProviders
{
    public class ExternalEmailProvider : IExternalEmailProvider
    {
        public bool SendEmail(string to, string toName, string message)
        {
            bool result;
            try
            {
                Console.WriteLine($"Sending email to {toName}<{to}>...");
                throw new Exception("Error, Development of Email sending is still in progress!");
            }
            catch (Exception Ex)
            {
                Console.WriteLine($"Error Messahe - {Ex.Message}");
                result = false;
            }
            return result;
        }
    }
}
