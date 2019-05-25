using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo(assemblyName: "CalculatorUnitTests")]

namespace ConsoleCalculator
{
    class Program
    {
        static void Main()
        {
            Calculator calculator = new Calculator();
            calculator.Start();
        }
    }
}
