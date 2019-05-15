using ConsoleCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicEngineTests
{
    [TestClass]
    public class LogicTests
    {
        
        [TestMethod]
        public void ShouldLeaveDigitsAndArithmeticSigns()
        {
            // For
            LogicEngine logicEngine = new LogicEngine();
            string operation = "1g+;1-/1]", expectedResult = "1+1-1";

            // Given
            string result = logicEngine.CheckOperation(operation);

            // Assert
            Assert.AreEqual(result, expectedResult);
        }
    }
}
