using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationsMediaGroup
{
    public abstract class MyAbstractClass
    {
        public abstract string Text { get; set; }
        public abstract int Value { get; }
        public abstract string Property { get; set; }
        public abstract int GetRandomNumber();
        public abstract Task<int> GetValueAsync();
        public abstract int Add(int a, int b);
        public abstract Task<int> AddAsync(int a, int b);
    }
}
