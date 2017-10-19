using System;

namespace SalaryFinanceHomework.StarSystemCore
{
    [Serializable]
    public class SpaceCoordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public SpaceCoordinate(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            // example: 123.123.99.1 X & 098.098.11.1 Y & 456.456.99.9 Z
            return $"{X.ToString(@"000\.000\.00\.0")} X & {Y.ToString(@"###\.###\.##\.#0")} Y & {Z.ToString(@"###\.###\.##\.#0")} Z";

//            return $"{X.ToString(@"###\.###\.##\.#0")} X & {Y.ToString(@"###\.###\.##\.#0")} Y & {Z.ToString(@"###\.###\.##\.#0")} Z";
        }
    }
}
