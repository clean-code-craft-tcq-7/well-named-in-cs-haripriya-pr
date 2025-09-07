using System;
using static TelCo.ColorCoder.Program;

namespace TelCo.ColorCoder
{
    internal class ColorConversion
    {
        public static ColorPair GetColorFromPairNumber(int pairNumber)/// Given a pair number function returns the major and minor colors in that order
        {
            int minorSize = colorMapMinor.Length, majorSize = colorMapMajor.Length;
            if (pairNumber < 1 || pairNumber > minorSize * majorSize) // The function supports only 1 based index. Pair numbers valid are from 1 to 25
                throw new ArgumentOutOfRangeException(string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
            int zeroBasedPairNumber = pairNumber - 1;
            int majorIndex = zeroBasedPairNumber / minorSize;
            int minorIndex = zeroBasedPairNumber % minorSize;
            ColorPair pair = new ColorPair(){
                majorColor = colorMapMajor[majorIndex],
                minorColor = colorMapMinor[minorIndex]
            };
            return pair;
        }

        public static int GetPairNumberFromColor(ColorPair pair) /// Given the two colors the function returns the pair number corresponding to them
        {
            int majorIndex = -1, minorIndex = -1;
            for (int i = 0; i < colorMapMajor.Length; i++)
            {
                if (colorMapMajor[i] == pair.majorColor)
                {
                    majorIndex = i;
                    break;
                }
            }
            for (int i = 0; i < colorMapMinor.Length; i++)
            {
                if (colorMapMinor[i] == pair.minorColor)
                {
                    minorIndex = i;
                    break;
                }
            }
            if (majorIndex == -1 || minorIndex == -1)
                throw new ArgumentException(string.Format("Unknown Colors: {0}", pair.ToString()));
            return (majorIndex * colorMapMinor.Length) + (minorIndex + 1); // (Note: +1 in compute is because pair number is 1 based, not zero)
        }
    }
}
