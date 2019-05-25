using System.Collections.Generic;

namespace ConsoleCalculator
{
    class NothingToOparateStrategy : IArithmeticStrategy
    {
        public List<string> Operate(List<string> listOfOperands, int index)
        {
            throw new System.NotImplementedException();
        }
    }
}
