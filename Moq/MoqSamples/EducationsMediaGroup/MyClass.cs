using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationsMediaGroup
{
    public class MyClass : MyAbstractClass
    {
        private string _text;
        public override string Text
        {
            set { _text = value; }
            get { return _text; }
        }
        public override int Value { get; }
        public override string Property { get; set; }
        public override int GetRandomNumber()
        {
            return 1;
        }

        public override async Task<int> GetValueAsync()
        {
            return 1;
        }

        public override int Add(int a, int b)
        {
            return 23;
        }

        public override async Task<int> AddAsync(int a, int b)
        {
            return 23;
        }
    }
}
