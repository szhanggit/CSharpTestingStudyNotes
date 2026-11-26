using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EducationsMediaGroup;
using Moq;
using Xunit;
using TXCSample;

namespace TestProject1
{
    public class TXCSampleTest
    {
        private List<Employee> GetSampleEmployee()
        {
            List<Employee> output = new List<Employee>
            {
                new Employee{ Id = 1, Name="Homer", Department="IT" , Email="homer@edenred.com" },
                new Employee{ Id = 2, Name="Lam", Department="Finace", Email="lam@edenred.com" },
                new Employee{ Id = 3, Name="Knight", Department="Management", Email="knight@edenred.com" }
            };
            return output;
        }

        [Fact]
        public void GetEmployeeById_WhenValidIdProvided_ShouldReturnsEmployeeObject()
        {
            //Arrange
            //=======
            //STEP1 -> Creating mocking objects of external dependencies / services
            var mockExtEmployee = new Mock<IExternalEmployeeDataProvider>();
            var mockExtEmail = new Mock<IExternalEmailProvider>();

            int employeeID = 2;
            Employee expectedResult = GetSampleEmployee()[2];

            //STEP2 -> Setup mock for testing - Here we define behaviour of external service.
            mockExtEmployee.Setup(x => x.GetById(employeeID)).Returns(expectedResult);

            //STEP3 -> Creating object of class to be tested by passing mocked dependencies
            EmployeeService eService = new EmployeeService(mockExtEmployee.Object, mockExtEmail.Object);


            //Act
            //====
            //STEP4 -> test action
            Employee actualResult = eService.GetEmployeeById(employeeID);

            //Assert
            //========
            //STEP5 -> Assertion
            Assert.Equal<Employee>(expectedResult, actualResult);

            //STEP6 -> Verify GetById() methood call by mocking object
            mockExtEmployee.Verify(x => x.GetById(employeeID));
        }
    }
}
