using System;

namespace RefOut
{
    class Program
    {
        static void Main(string[] args)
        {
            // Out and Ref are pass by reference - usually we pass data to methods by value - params are by value
            int OutsideVar = 20;
            SomeFunction(OutsideVar);

            Console.WriteLine("normal pass " + OutsideVar + " nothing affected OutsideVar");

            int OutsideVarRef = 20;
            SomeFunctionRef(ref OutsideVarRef);

            Console.WriteLine("Ref pass " + OutsideVarRef + " SomeFunctionRef affected OutsideVarRef - 2 WAY because the function also got the 20 value. IN and OUT modif.");

            int OutsideVarOut = 20;
            SomeFunctionOut(out OutsideVarOut);

            Console.WriteLine("Out pass " + OutsideVarOut + " SomeFunctionOut affected OutsideVarOut - 1 WAY because the function did not get the 20 value. But changed OUT the outside var.");
        }

        static void SomeFunction(int InsideVar)
        {
            InsideVar = InsideVar + 10;
        }

        static void SomeFunctionRef(ref int InsideVar)
        {
            InsideVar = InsideVar + 10;
        }

        static void SomeFunctionOut(out int InsideVar)
        {
            InsideVar = 0;
            InsideVar = InsideVar + 10;
        }
    }
}
