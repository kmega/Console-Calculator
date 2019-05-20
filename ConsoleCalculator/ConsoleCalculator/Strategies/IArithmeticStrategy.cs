using System.Collections.Generic;

namespace ConsoleCalculator
{
    interface IArithmeticStrategy
    {
        string Oparate(string operation, int index);
    }
}
