using EmployeeBrowser.ExternalDataProviders;
using EmployeeBrowser.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeBrowser.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IExternalEmployeeDataProvider _eData;
        private IExternalEmailProvider _emailProvider;

        //There are two external dependencies used in this class which can be simulated using Moq
        public EmployeeService(IExternalEmployeeDataProvider data, IExternalEmailProvider emailProvider)
        {
            _eData = data;
            _emailProvider = emailProvider;
        }

        public List<Employee> GetAllEmployee()
        {
            return _eData.GetAll();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return _eData.GetById(employeeId);
        }

        public bool SendEmail(int employeeId, string message)
        {
            Employee emp = this.GetEmployeeById(employeeId);
            return _emailProvider.SendEmail(emp.Email, emp.Name, message);
        }
    }
}
