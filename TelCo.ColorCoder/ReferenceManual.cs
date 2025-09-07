using System;
using System.Linq;
using System.Runtime.CompilerServices;
using static TelCo.ColorCoder.Program;
namespace TelCo.ColorCoder
{
    internal class ReferenceManual
    {
        private static readonly string column1 = "Pair Number", column2 = "Major Color", column3 = "Minor Color";
        private static int maxColumn1 = column1.Length, maxColumn2 = column2.Length, maxColumn3 = column3.Length;
        private static string AddExtraSpace(string value, int maxLength)
        {
            string valueWithSpace = value;
            for (int i = 0; i < maxLength - value.Length; i++)
            {
                valueWithSpace = valueWithSpace + " ";
            }
            return valueWithSpace;
        }
        public static string PrintHeaderDisplay(){
            return ($"Reference Manual\n|{AddExtraSpace(column1, maxColumn1)} | {AddExtraSpace(column2, maxColumn2)} | {AddExtraSpace(column3, maxColumn3)} |\n| {string.Concat(Enumerable.Repeat("-", maxColumn1))} | {string.Concat(Enumerable.Repeat("-", maxColumn2))} | {string.Concat(Enumerable.Repeat("-", maxColumn3))} |");
        }
        public static string PrintRowsDisplay(int pairNumber, ColorPair colorPair)
        {
            return ($"| {AddExtraSpace(pairNumber.ToString(), maxColumn1)} | {AddExtraSpace(colorPair.majorColor.Name, maxColumn2)} | {AddExtraSpace(colorPair.minorColor.Name, maxColumn3)} |");
        }
        public static string PrintHeaderCsv()
        {
            return ($"{AddExtraSpace(column1, maxColumn1)},{AddExtraSpace(column2, maxColumn2)},{AddExtraSpace(column3, maxColumn3)}");
        }
        public static string PrintRowsCsv(int pairNumber, ColorPair colorPair)
        {
            return ($"{AddExtraSpace(pairNumber.ToString(), maxColumn1)},{AddExtraSpace(colorPair.majorColor.Name, maxColumn2)},{AddExtraSpace(colorPair.minorColor.Name, maxColumn3)}");
        }
        private static void FindMax()
        {
            maxColumn1 = ((colorMapMajor.Length * colorMapMinor.Length).ToString().Length > maxColumn1 ? (colorMapMajor.Length * colorMapMinor.Length).ToString().Length : maxColumn1);
            colorMapMajor.Select(x => x.Name).ToList().ForEach(x => maxColumn2 = x.Length > maxColumn2 ? x.Length : maxColumn2);
            colorMapMinor.Select(x => x.Name).ToList().ForEach(x => maxColumn3 = x.Length > maxColumn3 ? x.Length : maxColumn3);
        }
        public static void PrintReferenceManual(Func<string> header, Func<int,ColorPair,string> rows){
            FindMax();
            Console.WriteLine(header());
            for(int idx = 1; idx <= colorMapMajor.Length * colorMapMinor.Length; idx++)
            {
                Console.WriteLine(rows(idx, ColorConversion.GetColorFromPairNumber(idx)));
            }
        }
    }
}