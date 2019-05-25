using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    class Tools
    {
        internal List<string> CacheNullSlots(List<string> listOfOperands)
        {
            for (int i = 0; i < listOfOperands.Capacity; i++)
            {
                try
                {
                    if (listOfOperands[i] == null)
                    {
                        listOfOperands.RemoveAt(i);
                    }
                }
                catch
                {
                    continue;
                }

                listOfOperands.TrimExcess();
            }

            return listOfOperands;
        }

        internal string[,] GetArithmeticOrder()
        {
            string[,] arithmeticOrder = { { "(", null }, { "/", "*" }, { "-", "+" } };

            return arithmeticOrder;
        }

        internal List<string> CalculateSingleOperand(List<string> listOfOperands, string[,] arithmeticOrder, int i, IArithmeticStrategy arithmeticStrategy)
        {
            int holder;

            for (int j = 0; j < listOfOperands.Capacity; j++)
            {
                try
                {
                    if (arithmeticOrder[i, 0] == listOfOperands[j] || arithmeticOrder[i, 1] == listOfOperands[j])
                    {
                        holder = j;
                        j = 0;

                        listOfOperands = arithmeticStrategy.Operate(listOfOperands, holder);
                    }
                }
                catch
                {
                    continue;
                }

                listOfOperands.TrimExcess();
            }

            return listOfOperands;
        }
    }
}
