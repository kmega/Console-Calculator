using System.Collections.Generic;

namespace ConsoleCalculator
{
    class BracketStrategy :  IArithmeticStrategy
    {
        public List<string> Oparate(List<string> listOfOperands, int j)
        {
            List<string> bracketOperands = new List<string>();

            for (int i = j; i < listOfOperands.Capacity; i++)
            {
                if (listOfOperands[i] == ")")
                {
                    for (int k = j + 1; k < i; k++)
                    {
                        bracketOperands.Add(listOfOperands[k]);
                    }

                    IArithmeticStrategy arithmeticStrategy;

                    string[] arithmeticOrder = { "(", "*", "/", "+", "-" };

                    while (bracketOperands.Capacity != 1)
                    {
                        for (int l = 0; l < arithmeticOrder.Length; l++)
                        {
                            switch (arithmeticOrder[l])
                            {
                                case "(":
                                    arithmeticStrategy = new BracketStrategy();
                                    break;
                                default:
                                    arithmeticStrategy = new OperateStrategy();
                                    break;
                            }

                            for (int m = 0; m < bracketOperands.Capacity; m++)
                            {
                                bracketOperands.TrimExcess();

                                try
                                {
                                    if (arithmeticOrder[l] == bracketOperands[m])
                                    {
                                        bracketOperands = arithmeticStrategy.Oparate(bracketOperands, m);
                                    }
                                }
                                catch
                                {
                                    continue;
                                }
                            }
                        }
                    }
                }
            }

            listOfOperands = RemoveBrackets(listOfOperands, bracketOperands);

            return listOfOperands;
        }

        private List<string> RemoveBrackets(List<string> listOfOperands, List<string> bracketOperands)
        {
            for (int i = 0; i < listOfOperands.Capacity; i++)
            {
                if (listOfOperands[i] == "(")
                {
                    for (int j = i; j < listOfOperands.Capacity; j++)
                    {
                        if (listOfOperands[j] == ")")
                        {
                            listOfOperands.RemoveAt(j);
                            listOfOperands.RemoveAt(j - 1);
                            break;
                        }
                        else
                        {
                            listOfOperands.RemoveAt(j);
                        }
                    }

                    listOfOperands[i] = bracketOperands[0];
                }
            }

            return listOfOperands;
        }
    }
}
