using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    internal class ArithmeticLogicEngine
    {
        internal double ExecuteOperation(string operation)
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

            Tools tools = new Tools();
            listOfOperands = tools.CacheNullSlots(listOfOperands);

            return listOfOperands;
        }

        internal double OperateOnOperands(List<string> listOfOperands)
        {
            IArithmeticStrategy arithmeticStrategy;

            Tools tools = new Tools();
            string[,] arithmeticOrder = tools.GetArithmeticOrder();

            while (listOfOperands.Capacity != 1)
            {
                for (int i = 0; i < arithmeticOrder.GetLength(0); i++)
                {
                    switch (arithmeticOrder[i, 0])
                    {
                        case "(":
                            arithmeticStrategy = new BracketStrategy();
                            break;
                        default:
                            arithmeticStrategy = new OperateStrategy();
                            break;
                    }

                    listOfOperands = tools.CalculateSingleOperand(listOfOperands, arithmeticOrder, i, arithmeticStrategy);
                }
            }

            return Convert.ToDouble(listOfOperands[0]);
        }
    }
}