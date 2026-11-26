using System;
using System.Collections.Generic;
using System.Text;

namespace EducationsMediaGroup
{
    public class Person
    {
        public Person(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
        public string Name { get; }
        public virtual void Greet() => Console.WriteLine($"Hello, I'm {Name}.");
    }
}
