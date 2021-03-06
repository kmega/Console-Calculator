﻿using System.Collections.Generic;

namespace ConsoleCalculator
{
    class BracketStrategy : IArithmeticStrategy
    {
        public List<string> Operate(List<string> listOfOperands, int index)
        {
            List<string> bracketOperands = new List<string>();

            int openingBracketIndex = FindLastOpeningBracket(listOfOperands);
            int closingBracketIndex = FindFirstClosingBracket(listOfOperands, openingBracketIndex);

            for (int i = openingBracketIndex + 1; i < closingBracketIndex; i++)
            {
                bracketOperands.Add(listOfOperands[i]);
            }

            Tools tools = new Tools();
            string[,] arithmeticOrder = tools.GetArithmeticOrder();

            while (bracketOperands.Capacity != 1)
            {
                for (int i = 0; i < arithmeticOrder.GetLength(0); i++)
                {
                    tools.CalculateSingleOperand(bracketOperands, arithmeticOrder, i, new OperateStrategy());
                }
            }

            listOfOperands = RemoveOperatedBrackets(listOfOperands, bracketOperands, openingBracketIndex, closingBracketIndex);

            return listOfOperands;
        }

        private int FindLastOpeningBracket(List<string> listOfOperands)
        {
            int bracketIndex = 0;

            for (int i = 0; i < listOfOperands.Capacity; i++)
            {
                try
                {
                    if (listOfOperands[i] == "(")
                    {
                        bracketIndex = i;
                    }
                }
                catch
                {
                    continue;
                }
            }

            return bracketIndex;
        }

        private int FindFirstClosingBracket(List<string> listOfOperands, int openingBracketIndex)
        {
            for (int i = 0; i < listOfOperands.Capacity; i++)
            {
                if (listOfOperands[i] == ")")
                {
                    return i;
                }
            }

            return openingBracketIndex;
        }

        private List<string> RemoveOperatedBrackets(List<string> listOfOperands, List<string> bracketOperands, int openingBracketIndex, int closingBracketIndex)
        {
            listOfOperands.RemoveRange(openingBracketIndex + 1, closingBracketIndex - openingBracketIndex);

            listOfOperands[openingBracketIndex] = bracketOperands[0];

            return listOfOperands;
        }
    }
}
