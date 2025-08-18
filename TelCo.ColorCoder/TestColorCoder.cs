using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using static TelCo.ColorCoder.Program;

namespace TelCo.ColorCoder
{
    internal class TestColorCoder
    {
        public static void TestColorFromPairNumber(int pairNumber, ColorPair resultColorPair)
        {
            ColorPair colorPair = ColorConversion.GetColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber, colorPair);
            Debug.Assert(colorPair.majorColor == resultColorPair.majorColor);
            Debug.Assert(colorPair.minorColor == resultColorPair.minorColor);
        }

        public static void TestPairNumberFromColor(ColorPair colorPair, int resultPairNumber)
        {
            int pairNumber = ColorConversion.GetPairNumberFromColor(colorPair);
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}\n", colorPair, pairNumber);
            Debug.Assert(pairNumber == resultPairNumber);
        }

        public static void TestsForColorCoder()
        {
            TestColorFromPairNumber(4, new ColorPair { majorColor = Color.White, minorColor = Color.Brown });
            TestColorFromPairNumber(5, new ColorPair { majorColor = Color.White, minorColor = Color.SlateGray });
            TestColorFromPairNumber(23, new ColorPair { majorColor = Color.Violet, minorColor = Color.Green });
            TestPairNumberFromColor(new ColorPair { majorColor = Color.Yellow, minorColor = Color.Green }, 18);
            TestPairNumberFromColor(new ColorPair { majorColor = Color.Red, minorColor = Color.Blue }, 6);
        }
    }
}
