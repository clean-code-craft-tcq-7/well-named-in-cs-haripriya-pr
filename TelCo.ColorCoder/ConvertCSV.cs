using System;
using System.IO;
using System.Text;

namespace TelCo.ColorCoder
{
    internal class ConvertCSV
    {
        public static void CreateCsv(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8)) // false for overwrite, true for append
                {
                    writer.WriteLine(ReferenceManual.PrintHeaderCsv());
                    for (int idx = 1; idx <= Program.colorMapMajor.Length * Program.colorMapMinor.Length; idx++)
                    {
                        writer.WriteLine(ReferenceManual.PrintRowsCsv(idx, ColorConversion.GetColorFromPairNumber(idx)));
                    }
                }
                Console.WriteLine($"CSV file '{filePath}' created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
