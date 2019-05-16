using System;

namespace ConsoleCalculator
{
    internal class Calculator
    {
        internal void Start()
        {
            UserInterface userinterface = new UserInterface();
            userinterface.ShowInstructions();

            string operation = WriteOperation();

            LogicEngine logicEngine = new LogicEngine();
            double result = logicEngine.MakeOperation(operation);

            Console.WriteLine(result);
        }

        private string WriteOperation()
        {
            string userinput = Console.ReadLine();
            return userinput;
        }
    }
}