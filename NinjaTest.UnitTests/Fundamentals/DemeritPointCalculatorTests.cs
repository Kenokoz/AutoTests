using NinjaTest.Fundamentals;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaTest.UnitTests
{
    [TestFixture]
    public class DemeritPointCalculatorTests
    {
        private DemeritPointCalculator demeritPoint; 

        [SetUp]
        public void SetUp()
        {
            demeritPoint = new DemeritPointCalculator();
        }

        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedIsOutOfRange_ThrowException(int speed)
        {
            Assert.That(() => demeritPoint.CalculateDemeritPoints(speed), Throws.Exception);
        }

        [Test]
        [TestCase(0,0)]
        [TestCase(64,0)]
        [TestCase(65,0)]
        [TestCase(66,0)]
        [TestCase(70,1)]
        [TestCase(75,2)]
        public void CalculateDemeritPoints_WhenCalled_ReturnDemeritPoint(int speed, int expectedResult)
        {
            var result = demeritPoint.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
