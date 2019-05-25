using ConsoleCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LogicEngineTests
{
    [TestClass]
    public class BracketStrategyTests
    {
        [TestMethod]
        public void ShouldResultInLogicalOutcomeInsideBrackets()
        {
            // For
            IArithmeticStrategy arithmeticStrategy = new BracketStrategy();

            List<string> listOfOperands = new List<string>()
            {
                "8", "/", "(", "4", "-", "2", ")", "*", "4"
            };

            List<string> expectedResult = new List<string>()
            {
                "8", "/", "2", "*", "4"
            };

            // Given
            List<string> result = arithmeticStrategy.Operate(listOfOperands, 0);

            // Assert
            CollectionAssert.AreEqual(expectedResult, result);
        }
    }
}