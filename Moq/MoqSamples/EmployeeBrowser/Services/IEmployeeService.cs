using EmployeeBrowser.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeBrowser.Services
{
    interface IEmployeeService
    {
        public Employee GetEmployeeById(int employeeId);

        public List<Employee> GetAllEmployee();
    }
}
