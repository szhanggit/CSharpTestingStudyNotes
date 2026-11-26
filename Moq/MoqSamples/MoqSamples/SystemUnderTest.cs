using System;
using System.Collections.Generic;
using System.Text;

namespace MoqSamples
{
    public interface IUtility {
        string GetInitialValue();
        string PrefixString(string str);
        string ReverseString(string str);
        void Operation1(string str);
        void Operation2(string str);
        void Operation3(string str);
    }
    public interface ITarget { 
        string DoStuff(string str);
    }
    public class SystemUnderTest
    {
        private readonly IUtility _utility = null;
        private readonly ITarget _target = null;
        public SystemUnderTest(IUtility utility)
        {
            this._utility = utility;
        }

        public SystemUnderTest(IUtility utility, ITarget target)
        {
            this._utility = utility;
            this._target = target;
        }

        public void MethodToTest()
        {
            var str = _utility.GetInitialValue();

            str = _utility.PrefixString(str);
            str = _utility.ReverseString(str);

            _target.DoStuff(str);
        }

        public void MethodToTestV2()
        {
            _utility.Operation1("1111");
            _utility.Operation3("3333");
            _utility.Operation2("2222");
        }
    }
}
