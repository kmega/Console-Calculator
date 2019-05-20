using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    class OperateStrategy : IArithmeticStrategy
    {
        public string Oparate(string operation, int index)
        {
            List<string> listOfOperands = ConvertToOperandList(operation);

            double result = Convert.ToDouble(operation[index - 1]);
            double value = Convert.ToDouble(operation[index + 1]);

            switch (operation[index])
            {
                case '+':
                    result += value;
                    break;
                case '-':
                    result -= value;
                    break;
                case '*':
                    result *= value;
                    break;
                case '/':
                    result /= value;
                    break;
            }

            operand[index] = result.ToString();
            operand[index - 1] = operand[index + 1] = null;

            operand = CacheNullSlots(operand);

            return operand;
        }

        private List<string> ConvertToOperandList(string operation)
        {
            List<string> listOfOperands = new List<string>();
            string holder = "";

            for (int i = 0; i < operation.Length; i++)
            {
                try
                {
                    Convert.ToDouble(operation[i]);
                }
                catch
                {

                }
            }

            return listOfOperands;
        }

        internal List<string> CacheNullSlots(List<string> operand)
        {
            for (int i = 0; i < operand.Capacity; i++)
            {
                if (operand[i] == null)
                {
                    operand.RemoveAt(i);
                }
            }

            return operand;
        }
    }
}
