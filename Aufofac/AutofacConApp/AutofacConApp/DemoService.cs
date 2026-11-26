using System;
using System.Collections.Generic;
using System.Text;

namespace AutofacConApp
{
    public class DemoService : IDemoService
    {
        public void Display()
        {
            Console.WriteLine("Hello World!");
        }
    }
}
