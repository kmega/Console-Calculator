using System;

namespace ConsoleCalculator
{
    internal class UserInterface
    {
        internal void ShowInstructions()
        {
        }

        protected internal string WriteOperation()
        {
            string userinput = Console.ReadLine();
            return userinput;
        }
    }
}