using System.Collections.Generic;

namespace ConsoleCalculator
{
    interface IArithmeticStrategy
    {
        List<string> Operate(List<string> listOfOperands, int index);
    }
}
