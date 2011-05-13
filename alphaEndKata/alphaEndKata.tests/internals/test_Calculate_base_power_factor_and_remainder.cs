using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using alphaEndKata;
using NUnit.Framework;

namespace CanUDoIt.internals
{
    [TestFixture]
    public class test_Calculate_base_power_factor_and_remainder
    {
        [Test]
        [TestCase(5, 0, 5, 0)]
        [TestCase(10, 0, 10, 0)]
        [TestCase(13, 1, 1, 0)]
        [TestCase(20, 1, 1, 7)]
        [TestCase(130, 1, 10, 0)]
        public void Calculate(int n10, int basePower, int factor, int remainder)
        {
            var sut = new Converter();
            var t = sut.Calculate_base_power_factor_and_remainder(n10, basePower);

            Assert.AreEqual(factor, t.Item1, "wrong factor");
            Assert.AreEqual(remainder, t.Item2, "wrong rem");
        }
    }
}