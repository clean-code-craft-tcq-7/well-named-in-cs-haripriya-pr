using System;
using System.Diagnostics;
using System.Drawing;

namespace TelCo.ColorCoder
{
    class Program
    {
        public static Color[] colorMapMajor; /// Array of Major colors
        public static Color[] colorMapMinor; /// Array of minor colors
        internal class ColorPair
        {
            internal Color majorColor;
            internal Color minorColor;
            public override string ToString()
            {
                return string.Format("MajorColor:{0}, MinorColor:{1}", majorColor.Name, minorColor.Name);
            }
        }
        
        static Program() /// Static constructor required to initialize static variable
        {
            colorMapMajor = new Color[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet };
            colorMapMinor = new Color[] { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };
        }

        private static void Main(string[] args) /// Test code for the class
        {
            TestColorCoder.TestsForColorCoder();
        }
    }
}
