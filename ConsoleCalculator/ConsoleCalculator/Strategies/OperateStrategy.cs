using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    class OperateStrategy : IArithmeticStrategy
    {
        public List<string> Oparate(List<string> listOfOperands, int j)
        {
            double result = Convert.ToDouble(listOfOperands[j - 1]);
            double value = Convert.ToDouble(listOfOperands[j + 1]);

            switch (listOfOperands[j])
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

            listOfOperands[j] = result.ToString();
            listOfOperands[j - 1] = listOfOperands[j + 1] = null;

            listOfOperands = CacheEmptySlots(listOfOperands);

            return listOfOperands;
        }

        internal List<string> CacheEmptySlots(List<string> listOfOperands)
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
