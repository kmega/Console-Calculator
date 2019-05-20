using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    internal class ArithmeticOrderEngine
    {
        internal double MakeOperation(string operation)
        {
            double result = Operate(operation);

            return result;
        }

        internal double Operate(string operation)
        {
            IArithmeticStrategy arithmeticStrategy;
            char[,] arithmeticOrder = { { '/', '*' }, { '-', '+' } };

            for (int i = 0; i < arithmeticOrder.Rank; i++)
            {
                for (int j = 0; j < arithmeticOrder.GetLength(i); j++)
                {
                    switch (arithmeticOrder[i, j])
                    {
                        case '(':
                            arithmeticStrategy = new BracketStrategy();
                            break;
                        default:
                            arithmeticStrategy = new OperateStrategy();
                            break;
                    }

                    for (int k = 0; k < operation.Length; k++)
                    {
                        if (arithmeticOrder[i, j] == operation[k])
                        {
                            operation = arithmeticStrategy.Oparate(operation, k);
                        }
                    }
                }                
            }

            for (int i = 0; i < arithmeticOrder.Length; i++)
            {

            }

            return Convert.ToDouble(operation);
        }
    }
}