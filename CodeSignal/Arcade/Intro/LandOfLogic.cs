using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeSignal.Arcade.Intro
{
    public class LandOfLogic
    {
        /// <remarks>
        /// Define a word as a sequence of consecutive English letters. Find the longest word from the given string.
        /// 
        /// Example
        /// 
        /// For text = "Ready, steady, go!", the output should be
        /// longestWord(text) = "steady".
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         string text
        /// 
        /// Guaranteed constraints:
        /// 4 ≤ text.length ≤ 50.
        /// 
        /// [output]
        /// string
        /// 
        /// The longest word from text.It's guaranteed that there is a unique output.
        /// </remarks>
        public static string LongestWord(string text)
        {
            var matches = Regex.Matches(text, "[a-zA-Z]+");

            return (matches.OrderBy(p => p.Value.Length).Last().Value);
        }

        /// <remarks>
        /// Check if the given string is a correct time representation of the 24-hour clock.
        /// 
        /// Example
        /// 
        /// For time = "13:58", the output should be
        /// validTime(time) = true;
        /// For time = "25:51", the output should be
        /// validTime(time) = false;
        /// For time = "02:76", the output should be
        /// validTime(time) = false.
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// string time
        /// 
        /// A string representing time in HH:MM format.It is guaranteed that the first two characters, as well as the last two characters, are digits.
        /// 
        /// [output] boolean
        /// 
        /// true if the given representation is correct, false otherwise.
        ///
        /// TimeSpan.TryParse(time, out dummyOutput);
        /// </remarks>
        public static bool ValidTime(string time)
        {
            string[] values = time.Split(':');

            return (int.Parse(values[0]) < 24 && int.Parse(values[1]) < 60);
        }

        /// <remarks>
        /// CodeMaster has just returned from shopping. He scanned the check of the items he bought and gave the resulting string to Ratiorg to figure out the total number of purchased items. Since Ratiorg is a bot he is definitely going to automate it, so he needs a program that sums up all the numbers which appear in the given input.

        /// Help Ratiorg by writing a function that returns the sum of numbers that appear in the given inputString.
        /// 
        /// Example
        /// 
        /// For inputString = "2 apples, 12 oranges", the output should be
        /// sumUpNumbers(inputString) = 14.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         string inputString
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ inputString.length ≤ 105.
        /// 
        /// [output] integer
        /// </remarks>
        public static int SumUpNumbers(string inputString)
        {
            var matches = Regex.Matches(inputString, "[0-9]+");

            return (matches.Sum(p => int.Parse(p.Value)));
        }


        /// <remarks>
        /// Given a rectangular matrix containing only digits, calculate the number of different 2 × 2 squares in it.
        /// 
        /// Example
        /// 
        /// For
        /// 
        /// matrix = [[1, 2, 1],
        /// [2, 2, 2],
        /// [2, 2, 2],
        /// [1, 2, 3],
        /// [2, 2, 1]]
        /// the output should be
        /// differentSquares(matrix) = 6.
        /// 
        /// Here are all 6 different 2 × 2 squares:
        /// 
        /// 1 2
        /// 2 2
        /// 2 1
        /// 2 2
        /// 2 2
        /// 2 2
        /// 2 2
        /// 1 2
        /// 2 2
        /// 2 3
        /// 2 3
        /// 2 1
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         array.array.integer matrix
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ matrix.length ≤ 100,
        /// 1 ≤ matrix[i].length ≤ 100,
        /// 0 ≤ matrix[i][j] ≤ 9.
        /// 
        /// [output]
        /// integer
        /// 
        /// The number of different 2 × 2 squares in matrix.
        /// </remarks>
        public static int DifferentSquares(int[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            HashSet<string> mat2x2 = new HashSet<string>();

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    string val = $"{matrix[i][j]}-{matrix[i + 1][j]}-{matrix[i][j + 1]}-{matrix[i + 1][j + 1]}";

                    if (!mat2x2.Contains(val))
                        mat2x2.Add(val);
                }
            }

            return (mat2x2.Count);
        }


        /// <remarks>
        /// Given an integer product, find the smallest positive (i.e. greater than 0) integer the product of whose digits is equal to product. If there is no such integer, return -1 instead.
        /// 
        /// Example
        /// 
        /// For product = 12, the output should be
        /// digitsProduct(product) = 26;
        /// For product = 19, the output should be
        /// digitsProduct(product) = -1.
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         integer product
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ product ≤ 600.
        /// 
        /// [output] integer
        ///
        /// </remarks>
        public static int DigitsProduct(int product)
        {
            if (product == 0)
                return 10;
            if (product < 10)
                return product;

            StringBuilder r = new StringBuilder();

            for (int i = 9; i > 1; i--)
            {
                while (product % i == 0)
                {
                    product /= i;

                    r.Insert(0, $"{i}");
                }
            }

            return product == 1 ? int.Parse(r.ToString()) : -1;
        }

    }
}
