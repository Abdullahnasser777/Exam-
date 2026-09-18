using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System_01
{
    internal class Check
    {
        #region This Class IS Designed To Perform Validation On User Inputs

        #region String Validation
        public static string ReadNonEmptyString(string Taest)
        {
            string input;
            do
            {
                Console.WriteLine(Taest);
                input = Console.ReadLine()!;
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }
        
        #endregion

        #region Decimal Validation
        public static decimal ReadPositiveDecimal(string Taest)
        {
            decimal value;
            while (true)
            {
                Console.WriteLine(Taest);
                string? input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine(" Input Cannot Be Empty");
                    continue;
                }

                if (decimal.TryParse(input, out value))
                {
                    if (value > 0)
                    {
                        return value;
                    }
                    Console.WriteLine("Invalid Input Please Enter A  Number...");
                }

                else
                {
                    Console.WriteLine("Invalid Input Please A Valid Number...");
                }
            }
        }
        #endregion

        #region Integer Validation
        public static int ReadPositveInt(string Taest)
        {
            int value;
            while (true)
            {
                Console.WriteLine(Taest);
                string? input = Console.ReadLine();
                if (int.TryParse(input, out value) && value > 0)
                {
                    return value;
                }
                Console.WriteLine("Invalid Input Please Enter A  Number...");
            }
        }

        #endregion

        #endregion
    }
}
