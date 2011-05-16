using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace alphaEndKata
{
    public class OctalConverter : AbstractConverter
    {
        public OctalConverter() : base(new[] { '0', '1', '2', '3', '4', '5', '6', '7' })
        { }
    }
}