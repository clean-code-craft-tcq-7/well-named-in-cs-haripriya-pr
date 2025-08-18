using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using static TelCo.ColorCoder.Program;

namespace TelCo.ColorCoder
{
    internal class TestColorCoder
    {
        private static void TestColorFromPairNumber(int pairNumber, ColorPair resultColorPair)
        {
            ColorPair colorPair = ColorConversion.GetColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber, colorPair);
            Debug.Assert(colorPair.majorColor == resultColorPair.majorColor);
            Debug.Assert(colorPair.minorColor == resultColorPair.minorColor);
        }

        private static void TestPairNumberFromColor(ColorPair colorPair, int resultPairNumber)
        {
            int pairNumber = ColorConversion.GetPairNumberFromColor(colorPair);
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}\n", colorPair, pairNumber);
            Debug.Assert(pairNumber == resultPairNumber);
        }

        private static void TestReferenceManual()
        {
            Debug.Assert(ReferenceManual.PrintHeader() == $"| Pair Number | Major Color | Minor Color |\n| {string.Concat(Enumerable.Repeat("-",11))} | {string.Concat(Enumerable.Repeat("-", 11))} | {string.Concat(Enumerable.Repeat("-", 11))} |");
            Debug.Assert(ReferenceManual.PrintRows(1, ColorConversion.GetColorFromPairNumber(1)) == "| 1           | White       | Blue        |");
            ReferenceManual.PrintReferenceManual();
        }

        public static void TestsForColorCoder()
        {
            TestColorFromPairNumber(4, new ColorPair { majorColor = Color.White, minorColor = Color.Brown });
            TestColorFromPairNumber(5, new ColorPair { majorColor = Color.White, minorColor = Color.SlateGray });
            TestColorFromPairNumber(23, new ColorPair { majorColor = Color.Violet, minorColor = Color.Green });
            TestPairNumberFromColor(new ColorPair { majorColor = Color.Yellow, minorColor = Color.Green }, 18);
            TestPairNumberFromColor(new ColorPair { majorColor = Color.Red, minorColor = Color.Blue }, 6);
            TestReferenceManual();
        }
    }
}
