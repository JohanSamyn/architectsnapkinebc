using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using alphaEndKata;
using NUnit.Framework;

namespace CanUDoIt.internals
{
    [TestFixture]
    public class test_Map_factor_to_targetSystem
    {
        [Test]
        [TestCase(0, '0')]
        [TestCase(12, 'z')]
        [TestCase(9, '9')]
        public void Map_digit(int factor, char digitOfTargetSystem)
        {
            var sut = new Converter();
            Assert.AreEqual(digitOfTargetSystem, sut.Map_factor_to_targetSystem(factor));
        }
    }
}