using System;
using System.Collections.Generic;
using System.Diagnostics;
using alphaEndKata;
using NUnit.Framework;

namespace CanUDoIt.internals
{
    [TestFixture]
    public class test_Assemble_converted_number_from_digits
    {
        [Test]
        public void Assemble_several_digits()
        {
            var sut = new Converter();

            Assert.AreEqual("xyz", sut.Assemble_converted_number_from_digits(new[] {'x', 'y', 'z'}));
        }
    }
}