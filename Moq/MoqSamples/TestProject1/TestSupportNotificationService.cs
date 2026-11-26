using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using SupportNotificationService;
using Xunit;

namespace TestProject1
{
    public class TestSupportNotificationService
    {
        [Fact]
        public void TestMakeAList()
        {
            var mock = new Mock<GetPropValueDel>();
            mock.Setup(p => p(It.IsAny<object>(), It.IsAny<string>())).Returns("AKJUD8789734");
            Mock<ICommonMethod> _cmService = new Mock<ICommonMethod>();
            _cmService.SetupSequence(x => x.GetPropValue(It.IsAny<object>(), It.IsAny<string>()))
            .Returns("AKJUD8789734")
            .Returns("00001")
            .Returns("AKJUD8789745")
            .Returns("00001");
        }

        [Fact]
        public void Test1()
        {
            Mock<IParamListService> _plService = new Mock<IParamListService>();
            _plService.SetupSequence(x => x.getData<int>(It.IsAny<string>())).Returns(0);
            GetDataDel<int> getListDel = _plService.Object.getData<int>;

        }

        [Fact]
        public void Test2()
        {
            Mock<IParamListService> _plService = new Mock<IParamListService>();
            _plService.SetupSequence(x => x.getData<List<Account>>(It.IsAny<string>()))
                .Returns(new List<Account> {
                    new Account { AccountNumber = "EKJH2341", ProgramCode = "00001"},
                    new Account { AccountNumber = "EKJH9874", ProgramCode = "00001"}
                });
            GetDataDel<List<Account>> getListDel = _plService.Object.getData<List<Account>>;
        }
    }
}
