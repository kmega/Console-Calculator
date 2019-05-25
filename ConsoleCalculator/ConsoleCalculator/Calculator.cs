using System;

namespace ConsoleCalculator
{
    internal class Calculator
    {
        internal void Start()
        {
            UserInterface userInterface = new UserInterface();

            userInterface.ShowInstructions();
            string operation = userInterface.WriteOperation();

            ArithmeticLogicEngine arithmeticLogicEngine = new ArithmeticLogicEngine();
            double result = arithmeticLogicEngine.ExecuteOperation(operation);

            Console.WriteLine(result);
        }
    }
}