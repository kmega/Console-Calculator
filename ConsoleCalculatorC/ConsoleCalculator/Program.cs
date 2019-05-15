using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo(assemblyName: "CalculatorUnitTests")]

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            calculator.Start();
        }
    }
}
