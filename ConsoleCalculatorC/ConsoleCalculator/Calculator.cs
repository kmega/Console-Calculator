using System;

namespace ConsoleCalculator
{
    internal class Calculator
    {
        internal void Start()
        {
            UserInterface userInterface = new UserInterface();
            userInterface.ShowInstructions();

            string operation = WriteOperation();

            LogicEngine logicEngine = new LogicEngine();
            double result = logicEngine.MakeOperation(operation);

            Console.WriteLine(result);
        }

        private string WriteOperation()
        {
            string userInput = Console.ReadLine();
            return userInput;
        }
    }
}