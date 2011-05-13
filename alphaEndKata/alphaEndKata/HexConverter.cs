using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace alphaEndKata
{
    public class HexConverter : AbstractConverter
    {
        public HexConverter() : base(16, new[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f'})
        {}
    }
}