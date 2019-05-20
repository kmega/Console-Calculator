using System.Collections.Generic;

namespace ConsoleCalculator
{
    interface IArithmeticStrategy
    {
        List<string> Oparate(List<string> listOfOperands, int index);
    }
}
