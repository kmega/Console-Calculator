using ConsoleCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LogicEngineTests
{
    [TestClass]
    public class OutcomeTests
    {
        [TestMethod]
        public void ShouldResultInLogicalOutcome01()
        {
            // For
            string operation = "6-3*2/2-3";
            double expectedResult = 0;

            // Given
            LogicEngine logicEngine = new LogicEngine();
            double result = logicEngine.MakeOperation(operation);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldResultInLogicalOutcome02()
        {
            // For
            string operation = "10+4*1-2*3-7";
            double expectedResult = 1;

            // Given
            LogicEngine logicEngine = new LogicEngine();
            double result = logicEngine.MakeOperation(operation);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldResultInLogicalOutcome03()
        {
            // For
            string operation = "5*(4-2)/2-2";
            double expectedResult = 3;

            // Given
            LogicEngine logicEngine = new LogicEngine();
            double result = logicEngine.MakeOperation(operation);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldResultInLogicalOutcome04()
        {
            // For
            string operation = "2*(6-(10-4/2)/2)-4";
            double expectedResult = 0;

            // Given
            LogicEngine logicEngine = new LogicEngine();
            double result = logicEngine.MakeOperation(operation);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void ShouldResultInLogicalOutcome05()
        {
            // For
            string operation = "5*(10-4/2+(100*5-50/5)+15*2)-31";
            double expectedResult = 2609;

            // Given
            LogicEngine logicEngine = new LogicEngine();
            double result = logicEngine.MakeOperation(operation);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldResultInLogicalOutcome06()
        {
            // For
            string operation = "10-5+2-3-1+2";
            double expectedResult = 5;

            // Given
            LogicEngine logicEngine = new LogicEngine();
            double result = logicEngine.MakeOperation(operation);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
