using EmployeeBrowser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeBrowser.ExternalDataProviders
{
    public class ExternalEmployeeDataProvider : IExternalEmployeeDataProvider
    {
        private List<Employee> _employees;

        public ExternalEmployeeDataProvider()
        {
            _employees = new List<Employee>
            {
                new Employee{ Id = 1, Name="Master Yoda", Department="IT", Email="yoda@starwars.com" },
                new Employee{ Id = 2, Name="Anaken Skywalker", Department="Finace", Email="aniken@starwars.com" },
                new Employee{ Id = 3, Name="Darth Vader", Department="IT", Email="darth@starwars.com" },
                new Employee{ Id = 4, Name="Dr. Strange", Department="Management", Email="drstrange@avengers.com" },
                new Employee{ Id = 5, Name="Bruce Wyne", Department="IT", Email="batman@justiceleague.com" },
                new Employee{ Id = 6, Name="Tony Stark", Department="IT", Email="ironman@avengers.com" },
                new Employee{ Id = 7, Name="Steve Rogers", Department="Management", Email="captain@avengers.com" },
                new Employee{ Id = 8, Name="Ms. Romanov", Department="HR", Email="blackwidow@avengers.com" },
                new Employee{ Id = 9, Name="I am groot", Department="Finace", Email="groot@avengers.com" },
                new Employee{ Id = 10, Name="Star lord", Department="HR", Email="star@avengers.com" }
            };
        }

        public List<Employee> GetAll()
        {
            return _employees;
        }

        public Employee GetById(int Id)
        {
            return _employees.FirstOrDefault(e => e.Id == Id);
        }
    }
}
