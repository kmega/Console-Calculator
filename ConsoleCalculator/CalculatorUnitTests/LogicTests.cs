using ConsoleCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LogicEngineTests
{
    [TestClass]
    public class LogicTests
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
            LogicEngine logicEngine = new LogicEngine();
            List<string> result = logicEngine.ChangeToOperands(operation);

            // Assert
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldResultInLogicalOutcome01()
        {
            // For
            List<string> listOfOperands = new List<string>()
            {
                "100", "-", "47", "*", "4", "/", "2", "-", "5"
            };

            double expectedResult = 1;

            // Given
            LogicEngine logicEngine = new LogicEngine();
            double result = logicEngine.OperateOnOperands(listOfOperands);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldResultInLogicalOutcome02()
        {
            // For
            List<string> listOfOperands = new List<string>()
            {
                "123", "+", "14", "*", "8", "-", "7", "*", "2", "-", "4"
            };

            double expectedResult = 217;

            // Given
            LogicEngine logicEngine = new LogicEngine();
            double result = logicEngine.OperateOnOperands(listOfOperands);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldResultInLogicalOutcome03()
        {
            // For
            List<string> listOfOperands = new List<string>()
            {
                "5", "*", "(", "4", "-", "2", ")", "/", "2", "-", "2"
            };

            double expectedResult = 3;

            // Given
            LogicEngine logicEngine = new LogicEngine();
            double result = logicEngine.OperateOnOperands(listOfOperands);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldResultInLogicalOutcome04()
        {
            // For
            List<string> listOfOperands = new List<string>()
            {
                "2", "*", "(", "6", "-", "(", "10", "-", "4", "/", "2", ")", "/", "2", ")", "-", "5"
            };

            double expectedResult = -7;

            // Given
            LogicEngine logicEngine = new LogicEngine();
            double result = logicEngine.OperateOnOperands(listOfOperands);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
