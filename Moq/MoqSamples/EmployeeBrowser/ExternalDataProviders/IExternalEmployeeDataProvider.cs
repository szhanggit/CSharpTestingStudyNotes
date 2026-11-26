using EmployeeBrowser.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeBrowser.ExternalDataProviders
{
    public interface IExternalEmployeeDataProvider
    {
        public Employee GetById(int Id);

        public List<Employee> GetAll();
    }
}
