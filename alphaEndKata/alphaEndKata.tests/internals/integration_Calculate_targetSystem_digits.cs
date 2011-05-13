using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using alphaEndKata;
using NUnit.Framework;

namespace CanUDoIt.internals
{
    [TestFixture]
    public class integration_Calculate_targetSystem_digits
    {
        [Test]
        [TestCase(5, 0, new[] { '5' })]
        [TestCase(13, 1, new[] { '1', '0' })]
        public void Calculate(int n10, int basePower, char[] digits)
        {
            var sut = new Converter();
            Assert.AreEqual(digits, sut.Calculate_targetSystem_digits(n10, basePower).ToArray());
        }
    }
}