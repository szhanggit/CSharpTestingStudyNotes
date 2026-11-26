using System;
using System.Collections.Generic;
using System.Text;

namespace MoqSamples
{
    public class DataClass
    {
        public int Id { get; set; }
    }
    public interface IEnumerableClass : IEnumerable<DataClass>
    {
    }
}
