using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    internal class LogicEngine
    {
        internal double MakeOperation(string operation)
        {
            List<string> listOfOperands = ChangeToOperands(operation);

            double result = OperateOnOperands(listOfOperands);

            return result;
        }

        internal List<string> ChangeToOperands(string operation)
        {
            List<string> listOfOperands = new List<string>();
            string holder = null;

            for (int i = 0; i < operation.Length; i++)
            {
                try
                {
                    Convert.ToDouble(operation[i].ToString());
                    holder += operation[i];
                }
                catch
                {
                    switch (operation[i])
                    {
                        case '(':
                        case ')':
                        case '+':
                        case '-':
                        case '*':
                        case '/':
                            listOfOperands.Add(holder);
                            holder = null;
                            listOfOperands.Add(operation[i].ToString());
                            break;
                        default:
                            continue;
                    }
                }
            }

            listOfOperands.Add(holder);

            listOfOperands = CacheNullSlots(listOfOperands);

            return listOfOperands;
        }

        private List<string> CacheNullSlots(List<string> listOfOperands)
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

        internal double OperateOnOperands(List<string> listOfOperands)
        {
            IArithmeticStrategy arithmeticStrategy;

            string[] arithmeticOrder = { "(", "/", "*", "-", "+" };

            while (listOfOperands.Capacity != 1)
            {
                for (int i = 0; i < arithmeticOrder.Length; i++)
                {
                    switch (arithmeticOrder[i])
                    {
                        case "(":
                            arithmeticStrategy = new BracketStrategy();
                            break;
                        default:
                            arithmeticStrategy = new OperateStrategy();
                            break;
                    }

                    for (int j = 0; j < listOfOperands.Capacity; j++)
                    {
                        try
                        {
                            if (arithmeticOrder[i] == listOfOperands[j])
                            {
                                listOfOperands = arithmeticStrategy.Oparate(listOfOperands, j);
                            }
                        }
                        catch
                        {
                            continue;
                        }

                        listOfOperands.TrimExcess();
                    }
                }
            }

            return Convert.ToDouble(listOfOperands[0]);
        }
    }
}