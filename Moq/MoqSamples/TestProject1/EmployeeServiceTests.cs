using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using EmployeeBrowser.ExternalDataProviders;
using EmployeeBrowser.Model;
using EmployeeBrowser.Services;

namespace TestProject1
{
    public class EmployeeServiceTests
    {
        private Mock<IExternalEmployeeDataProvider> _globalMockExtEmployee;
        private Mock<IExternalEmailProvider> _globalMockExtEmail;

        public EmployeeServiceTests()
        {
            _globalMockExtEmployee = new Mock<IExternalEmployeeDataProvider>();
            _globalMockExtEmail = new Mock<IExternalEmailProvider>();
        }

        [Fact]
        public void GetEmployeeById_WhenValidIdProvided_ShouldReturnsEmployeeObject()
        {
            //Arrange
            //=======
            int employeeID = 2;
            Employee expectedResult = GetSampleEmployee()[2];

            //STEP1 -> Creating mocking objects of external dependencies / services
            var mockExtEmployee = new Mock<IExternalEmployeeDataProvider>();
            var mockExtEmail = new Mock<IExternalEmailProvider>();

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

            //STEP6 -> Verify GetById() methood call by mock
            mockExtEmployee.Verify(x => x.GetById(employeeID));
        }

        [Fact(DisplayName = "TestGetEmpById with incorrect id")]
        public void GetEmployeeById_InValidIdProvided_ReturnsEmployee()
        {
            //Arrange
            //=======
            int employeeID = 2;

            //STEP1 -> Creating mocking objects of external dependencies / services
            var mockExtEmployee = new Mock<IExternalEmployeeDataProvider>();
            var mockExtEmail = new Mock<IExternalEmailProvider>();

            //STEP2 -> Setup mock for testing - Here we define behaviour of external service.
            mockExtEmployee.Setup(x => x.GetById(It.IsAny<int>())).Returns((Employee)null);

            //STEP3 -> Creating object of class to be tested by passing mocked dependencies
            EmployeeService eService = new EmployeeService(mockExtEmployee.Object, mockExtEmail.Object);


            //Act
            //====
            //STEP4 -> test action
            Employee actualResult = eService.GetEmployeeById(employeeID);

            //Assert
            //========
            //STEP5 -> Assertion
            Assert.Null(actualResult);

            //STEP6 -> Verify GetById() methood call by mock
            mockExtEmployee.Verify(x => x.GetById(2));
        }

        [Fact]
        public void GetAllEmployees_WhenCalled_ShouldReturnAllEmployees()
        {
            //Arrange
            //=======
            //STEP1 -> Creating mocking objects of external dependencies / services
            //Check test class constructor

            //STEP2 -> Setup mock for testing - Here we define behaviour of external service.
            _globalMockExtEmployee.Setup(x => x.GetAll()).Returns(this.GetSampleEmployee());
            List<Employee> expectedResult = this.GetSampleEmployee();

            //STEP3 -> Creating object of class to be tested by passing mocked dependencies
            EmployeeService eService = new EmployeeService(_globalMockExtEmployee.Object, null);

            //Act
            //====
            //STEP4 -> test action
            List<Employee> actualResult = eService.GetAllEmployee();

            //Assert
            //========
            //STEP5 -> Assertion
            Assert.Equal(expectedResult.Count, actualResult.Count);
            Assert.Equal(expectedResult.ToArray()[0].Email, actualResult.ToArray()[0].Email);

            //STEP6 -> Verify GetById() methood call by mock
            _globalMockExtEmployee.Verify(x => x.GetAll());
        }


        //This is a suporing method used in mocking. It generates and provides mock data for unit testing.
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
    }
}
