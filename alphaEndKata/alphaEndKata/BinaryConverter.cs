using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace alphaEndKata
{
    public class BinaryConverter : AbstractConverter
    {
        public BinaryConverter() : base(2, new[] {'0', '1'})
        {}
    }
}