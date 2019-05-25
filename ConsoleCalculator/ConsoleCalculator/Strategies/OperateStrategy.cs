using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    class OperateStrategy : IArithmeticStrategy
    {
        public List<string> Operate(List<string> listOfOperands, int index)
        {
            double result = Convert.ToDouble(listOfOperands[index - 1]);
            double value = Convert.ToDouble(listOfOperands[index + 1]);

            switch (listOfOperands[index])
            {
                case "+":
                    result += value;
                    break;
                case "-":
                    result -= value;
                    break;
                case "*":
                    result *= value;
                    break;
                case "/":
                    result /= value;
                    break;
            }

            listOfOperands[index] = result.ToString();
            listOfOperands[index - 1] = listOfOperands[index + 1] = null;

            listOfOperands = CacheNullSlots(listOfOperands);

            return listOfOperands;
        }

        internal List<string> CacheNullSlots(List<string> listOfOperands)
        {
            for (int i = 0; i < listOfOperands.Capacity; i++)
            {
                if (listOfOperands[i] == null)
                {
                    listOfOperands.RemoveAt(i);
                }
            }

            return listOfOperands;
        }
    }
}
