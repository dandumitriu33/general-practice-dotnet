using System;

namespace Initial
{
    class Program
    {
        static void Main(string[] args)
        {
            // type resolved at runtime
            // used when in connection with other components from other languages for example
            dynamic testDynamic = "";
            var testVar = 2.1;

            testVar = 1.1;
            //testDynamic.SayHi(); // error at runtime

            testDynamic = 1;
            testDynamic = testDynamic + 2.1;

            Console.WriteLine(testDynamic);

            dynamic newTestDynamic = new Person();
            var newTestVar = new Person();

            newTestDynamic.FirstName = "John";
            newTestDynamic.LastName = "Smith";
            //newTestDynamic.Email = "jsmith@email.com"; // error at runtime - binder exception

            newTestVar.FirstName = "Mike";
            newTestVar.LastName = "Doe";

            newTestDynamic.SayHello();
            newTestVar.SayHello();

            newTestDynamic = "Hi there Jim Jones";
            Console.WriteLine(newTestDynamic);

            Console.WriteLine(GetMessage());

            // must use var
            var myCustomer = new { FirstName = "John", Email = "john@email.com" };
            Console.WriteLine($"Hello {myCustomer.FirstName}, your email is: {myCustomer.Email}");
        }

        static dynamic GetMessage()
        {
            return "This is a test returning a dynamic result.";
        }
    }
}
