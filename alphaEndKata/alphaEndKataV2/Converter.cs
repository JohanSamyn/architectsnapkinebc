using System.Collections.Generic;
using System.Diagnostics;

namespace CanUDoIt
{
    public class Converter : AbstractConverter
    {
        public Converter() : base(new[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'x', 'y', 'z'}){}
    }

    public class BinaryConverter : AbstractConverter
    {
        public BinaryConverter() : base(new[] { '0', '1' }) { }
    }

    public class OctalConverter : AbstractConverter
    {
        public OctalConverter() : base(new[] { '0', '1', '2', '3', '4', '5', '6', '7' }) { }
    }

    public class HexConverter : AbstractConverter
    {
        public HexConverter() : base(new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' }) { }
    }
}