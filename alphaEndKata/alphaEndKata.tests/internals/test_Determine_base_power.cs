using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using alphaEndKata;
using NUnit.Framework;

namespace CanUDoIt.internals
{
    [TestFixture]
    public class test_Determine_base_power
    {
        [Test]
        [TestCase(5, 0)]
        [TestCase(10, 0)]
        [TestCase(13, 1)]
        [TestCase(20, 1)]
        [TestCase(168, 1)]
        [TestCase(169, 2)]
        public void Calc_base_power(int n10, int basePower)
        {
            var sut = new Converter();
            Assert.AreEqual(basePower, sut.Determine_base_power(n10));
        }
    }
}