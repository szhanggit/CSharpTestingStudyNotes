using System;
using System.Collections.Generic;
using System.Text;

namespace TXCSample
{
    public class Employee
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public string Department { get; set; } 
        public string Email { get; set; } 
    }
    public interface IEmployeeService
    {
        Employee GetEmployeeById(int employeeId);
    }
    public interface IExternalEmployeeDataProvider
    {
        Employee GetById(int employeeId);
    }
    public interface IExternalEmailProvider
    { 
    
    }
    public class EmployeeService : IEmployeeService
    {
        private IExternalEmployeeDataProvider _eData;
        private IExternalEmailProvider _emailProvider;

        //There are two external dependencies used in this class which can be simulated using Moq
        //IExternalEmployeeDataProvider brings data from external data source, it could be DB, API, File etc.
        //IExternalEmailProvider provides email sending functionality.
        public EmployeeService(IExternalEmployeeDataProvider data, IExternalEmailProvider emailProvider)
        {
            _eData = data;
            _emailProvider = emailProvider;
        }

        //This is method to be tested
        public Employee GetEmployeeById(int employeeId)
        {
            return _eData.GetById(employeeId);
        }
    }
}
