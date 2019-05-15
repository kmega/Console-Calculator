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
            string holder = "";

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
                        case '+':
                        case '-':
                        case '*':
                        case '/':
                            listOfOperands.Add(holder);
                            holder = "";
                            listOfOperands.Add(operation[i].ToString());
                            break;
                        default:
                            continue;
                    }
                }
            }

            listOfOperands.Add(holder);

            return listOfOperands;
        }

        internal double OperateOnOperands(List<string> listOfOperands)
        {
            double resultHolder = 0, firstValue, secondValue;

            for (int i = 1; i < listOfOperands.Capacity - 5; i += 2)
            {
                firstValue = Convert.ToDouble(listOfOperands[i - 1]);
                secondValue = Convert.ToDouble(listOfOperands[i + 1]);
                switch (listOfOperands[i])
                {
                    case "+":
                        resultHolder = firstValue + secondValue;
                        break;
                    case "-":
                        resultHolder = firstValue - secondValue;
                        break;
                    case "*":
                        resultHolder = firstValue * secondValue;
                        break;
                    case "/":
                        resultHolder = firstValue / secondValue;
                        break;
                }

                listOfOperands[i + 1] = resultHolder.ToString();
            }

            return resultHolder;
        }
    }
}