using System;
using System.Collections.Generic;
using System.Text;

namespace Initial
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void SayHello()
        {
            Console.WriteLine($"Hello {FirstName} {LastName}");
        }
    }
}
