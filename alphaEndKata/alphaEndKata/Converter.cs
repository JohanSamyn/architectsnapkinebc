using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace alphaEndKata
{
    public class Converter : AbstractConverter
    {
        public Converter() : base(new[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'x', 'y', 'z'})
        {}
    }
}