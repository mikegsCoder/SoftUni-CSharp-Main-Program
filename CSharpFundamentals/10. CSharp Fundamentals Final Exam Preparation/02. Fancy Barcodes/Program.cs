using System;
using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string barcodePattern = @"@#+(?<barcode>[A-Z][A-Za-z0-9]{4,}[A-Z])@#+";
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var barcodeMatch = Regex.Match(input, barcodePattern);

                if (!barcodeMatch.Success)
                {
                    Console.WriteLine("Invalid barcode");
                }
                else
                {
                    string barcodeString = barcodeMatch.Groups["barcode"].Value;
                    string productGroup = string.Empty;

                    for (int j = 0; j < barcodeString.Length; j++)
                    {
                        if (Char.IsDigit(barcodeString[j]))
                        {
                            productGroup += barcodeString[j];
                        }
                    }
                    if (productGroup.Length == 0)
                    {
                        productGroup = "00";
                    }

                    Console.WriteLine($"Product group: {productGroup}");
                }
            }
        }
    }
}
