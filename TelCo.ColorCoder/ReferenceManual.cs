using System;
using System.Linq;
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

        public static string PrintHeader(char joinBy = '|') {
            return (((joinBy == '|')?"| ": "") + ($"{AddExtraSpace(column1,maxColumn1)} {joinBy} {AddExtraSpace(column2, maxColumn2)} {joinBy} {AddExtraSpace(column3, maxColumn3)}") + ((joinBy == '|')? $" |\n| {string.Concat(Enumerable.Repeat("-",maxColumn1))} | {string.Concat(Enumerable.Repeat("-", maxColumn2))} | {string.Concat(Enumerable.Repeat("-", maxColumn3))} |" : ""));
        }

        public static string PrintRows(int pairNumber, ColorPair colorPair, char joinBy = '|')
        {
            return ((joinBy == '|'? "| " : "") + ($"{AddExtraSpace(pairNumber.ToString(), maxColumn1)} {joinBy} {AddExtraSpace(colorPair.majorColor.Name, maxColumn2)} {joinBy} {AddExtraSpace(colorPair.minorColor.Name, maxColumn3)}") +(joinBy == '|'? " |":""));
        }

        private static void FindMax()
        {
            maxColumn1 = ((colorMapMajor.Length * colorMapMinor.Length).ToString().Length > maxColumn1 ? (colorMapMajor.Length * colorMapMinor.Length).ToString().Length : maxColumn1);
            colorMapMajor.Select(x => x.Name).ToList().ForEach(x => maxColumn2 = x.Length > maxColumn2 ? x.Length : maxColumn2);
            colorMapMinor.Select(x => x.Name).ToList().ForEach(x => maxColumn3 = x.Length > maxColumn3 ? x.Length : maxColumn3);
        }

        public static void PrintReferenceManual()
        {
            FindMax();
            Console.WriteLine("Reference Manual:");
            Console.WriteLine(PrintHeader());
            for(int idx = 1; idx <= colorMapMajor.Length * colorMapMinor.Length; idx++)
            {
                Console.WriteLine(PrintRows(idx,ColorConversion.GetColorFromPairNumber(idx)));
            }
        }
    }
}