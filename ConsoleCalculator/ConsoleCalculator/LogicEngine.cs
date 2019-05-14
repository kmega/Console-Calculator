using System;

namespace ConsoleCalculator
{
    internal class LogicEngine
    {
        internal double MakeOperation(string operation)
        {
            operation = CheckOperation(operation);

            double result = ExecuteOperation(operation);

            return result;
        }

        internal string CheckOperation(string operation)
        {
            string newOperation = "";

            for (int i = 0; i < operation.Length; i++)
            {
                try
                {
                    Convert.ToInt32(operation[i].ToString());
                    newOperation += operation[i];
                }
                catch
                {
                    switch (operation[i])
                    {
                        case '+':
                        case '-':
                        case '*':
                        case ':':
                            newOperation += operation[i];
                            break;
                        default:
                            continue;
                    }
                }
            }

            return newOperation;
        }

        internal double ExecuteOperation(string operation)
        {
            throw new NotImplementedException();
        }
    }
}