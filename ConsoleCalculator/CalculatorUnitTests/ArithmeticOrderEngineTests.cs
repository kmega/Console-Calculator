using ConsoleCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LogicEngineTests
{
    [TestClass]
    public class ArithmeticOrderEngineTests
    {
        [TestMethod]
        public void ShouldLeaveDigitsAndArithmeticSigns()
        {
            // For
            List<string> expectedResult = new List<string>()
            {
                "2", "+", "10", "-", "300"
            };
            string operation = "2gi+;10-A|30p0^@]";

            // Given
            ArithmeticLogicEngine arithmeticLogicEngine = new ArithmeticLogicEngine();
            List<string> result = arithmeticLogicEngine.ChangeToOperands(operation);

            // Assert
            CollectionAssert.AreEqual(expectedResult, result);
        }
    }
}