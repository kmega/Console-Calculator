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
            string[] arithmeticOrder = { "*", "/", "+", "-" };
            double result = 0, value;

            while (listOfOperands.Capacity != 1)
            {
                for (int i = 0; i < arithmeticOrder.Length; i++)
                {
                    for (int j = 0; j < listOfOperands.Capacity; j++)
                    {
                        listOfOperands.TrimExcess();

                        try
                        {
                            if (arithmeticOrder[i] == listOfOperands[j])
                            {
                                result = Convert.ToDouble(listOfOperands[j - 1]);
                                value = Convert.ToDouble(listOfOperands[j + 1]);

                                switch (arithmeticOrder[i])
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
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
            }

            return result;
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