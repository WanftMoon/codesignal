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

        /// <remarks>
        /// You are given an array of desired filenames in the order of their creation. Since two files cannot have equal names,
        /// the one which comes later will have an addition to its name in a form of (k), where k is the smallest positive integer such that the obtained name is not used yet.        /// 
        /// Return an array of names that will be given to the files.
        /// 
        /// Example
        /// 
        /// For names = ["doc", "doc", "image", "doc(1)", "doc"], the output should be
        /// fileNaming(names) = ["doc", "doc(1)", "image", "doc(1)(1)", "doc(2)"].
        /// 
        /// Input / Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] array.string names
        /// 
        /// 
        /// Guaranteed constraints:
        /// 5 ≤ names.length ≤ 1000,
        /// 1 ≤ names[i].length ≤ 15.
        /// 
        /// 
        /// [output] array.string
        /// </remarks>
        public static string[] FileNaming(string[] names)
        {
            Dictionary<string, int> set = new Dictionary<string, int>();

            for (int i = 0; i < names.Length; i++)
            {
                if (set.ContainsKey(names[i]))
                {
                    string key = names[i];
                    int count = set[names[i]];
                    string rename = $"{names[i]}({count})";

                    //check while not avaiable
                    while (set.ContainsKey(rename)) { rename = $"{names[i]}({++count})"; }

                    names[i] = rename;
                    set.Add(names[i], 1);
                    set[key] += 1;
                }
                else
                    set.Add(names[i], 1);
            }

            return (names);
        }

        /// <remarks>
        /// You are taking part in an Escape Room challenge designed specifically for programmers. In your efforts to find a clue, you've found a binary code written on the wall behind a vase, and realized that it must be an encrypted message. After some thought, your first guess is that each consecutive 8 bits of the code stand for the character with the corresponding extended ASCII code.
        /// 
        /// Assuming that your hunch is correct, decode the message.
        /// 
        /// Example
        /// 
        /// For code = "010010000110010101101100011011000110111100100001", the output should be
        /// messageFromBinaryCode(code) = "Hello!".
        /// 
        /// The first 8 characters of the code are 01001000, which is 72 in the binary numeral system. 72 stands for H in the ASCII-table, so the first letter is H.
        /// Other letters can be obtained in the same manner.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] string code
        /// 
        /// A string, the encrypted message consisting of characters '0' and '1'.
        /// 
        /// Guaranteed constraints:
        /// 0 < code.length< 800.
        /// 
        /// [output] string
        /// 
        /// The decrypted message.
        ///
        /// </remarks>
        public static string MessageFromBinaryCode(string code)
        {
            List<byte> lst = new List<byte>();

            for (int i = 0; i < code.Length; i += 8)
            {
                string t = code.Substring(i, 8);

                lst.Add(Convert.ToByte(t, 2));
            }

            return (Encoding.ASCII.GetString(lst.ToArray()));
        }


        /// <remarks>
        /// Construct a square matrix with a size N × N containing integers from 1 to N * N in a spiral order, starting from top-left and in clockwise direction.
        /// 
        /// Example
        /// 
        /// For n = 3, the output should be
        /// 
        /// spiralNumbers(n) = [[1, 2, 3],
        /// [8, 9, 4],
        /// [7, 6, 5]]
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// integer n
        /// 
        /// Matrix size, a positive integer.
        /// 
        /// Guaranteed constraints:
        /// 3 ≤ n ≤ 100.
        /// 
        /// [output] array.array.integer
        /// </remarks>
        public static int[][] SpiralNumbers(int n)
        {
            int[][] matrix = new int[n][];

            for (int j = 0; j < n; j++)
                matrix[j] = new int[n];


            int k = 0, l = 0, step = 1, m = n;
            /* k - starting row index
            m - ending row index
            l - starting column index
            n - ending column index
            */

            while (k < m && l < n)
            {
                // Print the first row
                // from the remaining rows
                for (int i = l; i < n; ++i)
                {
                    matrix[k][i] = step++;
                }
                k++;

                // Print the last column from the
                // remaining columns
                for (int i = k; i < m; ++i)
                {
                    matrix[i][n - 1] = step++;
                }
                n--;

                // Print the last row from
                // the remaining rows
                if (k < m)
                {
                    for (int i = n - 1; i >= l; --i)
                    {
                        matrix[m - 1][i] = step++;
                    }
                    m--;
                }

                // Print the first column from
                // the remaining columns
                if (l < n)
                {
                    for (int i = m - 1; i >= k; --i)
                    {
                        matrix[i][l] = step++;
                    }
                    l++;
                }
            }
            return (matrix);
        }


        /// <remarks>
        /// Sudoku is a number-placement puzzle. The objective is to fill a 9 × 9 grid with digits so that each column, each row, and each of the nine 3 × 3 sub-grids that compose the grid contains all of the digits from 1 to 9.
        /// 
        /// This algorithm should check if the given grid of numbers represents a correct solution to Sudoku.
        /// 
        /// Example
        /// 
        /// For
        /// grid = [[1, 3, 2, 5, 4, 6, 9, 8, 7],
        /// [4, 6, 5, 8, 7, 9, 3, 2, 1],
        /// [7, 9, 8, 2, 1, 3, 6, 5, 4],
        /// [9, 2, 1, 4, 3, 5, 8, 7, 6],
        /// [3, 5, 4, 7, 6, 8, 2, 1, 9],
        /// [6, 8, 7, 1, 9, 2, 5, 4, 3],
        /// [5, 7, 6, 9, 8, 1, 4, 3, 2],
        /// [2, 4, 3, 6, 5, 7, 1, 9, 8],
        /// [8, 1, 9, 3, 2, 4, 7, 6, 5]]
        /// the output should be
        /// sudoku(grid) = true;
        /// 
        /// For
        /// grid = [[1, 3, 2, 5, 4, 6, 9, 2, 7],
        /// [4, 6, 5, 8, 7, 9, 3, 8, 1],
        /// [7, 9, 8, 2, 1, 3, 6, 5, 4],
        /// [9, 2, 1, 4, 3, 5, 8, 7, 6],
        /// [3, 5, 4, 7, 6, 8, 2, 1, 9],
        /// [6, 8, 7, 1, 9, 2, 5, 4, 3],
        /// [5, 7, 6, 9, 8, 1, 4, 3, 2],
        /// [2, 4, 3, 6, 5, 7, 1, 9, 8],
        /// [8, 1, 9, 3, 2, 4, 7, 6, 5]]
        /// the output should be
        /// sudoku(grid) = false.
        /// 
        /// The output should be false: each of the nine 3 × 3 sub-grids should contain all of the digits from 1 to 9.
        /// These examples are represented on the image below.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] array.array.integer grid
        /// 
        /// A matrix representing 9 × 9 grid already filled with numbers from 1 to 9.
        /// 
        /// Guaranteed constraints:
        /// grid.length = 9,
        /// grid[i].length = 9,
        /// 1 ≤ grid[i][j] ≤ 9.
        /// 
        /// [output] boolean
        /// 
        /// true if the given grid represents a correct solution to Sudoku, false otherwise.
        /// </remarks>
        public static bool Sudoku(int[][] grid)
        {
            HashSet<int> set = new HashSet<int>();

            //check rows
            for (int i = 0; i < 9; i++)
            {
                set = new HashSet<int>();

                for (int j = 0; j < 9; j++)
                {
                    if (set.Contains(grid[i][j]))
                        return (false);
                    else
                        set.Add(grid[i][j]);
                }
            }

            //check columns
            for (int j = 0; j < 9; j++)
            {
                set = new HashSet<int>();

                for (int i = 0; i < 9; i++)
                {
                    if (set.Contains(grid[i][j]))
                        return (false);
                    else
                        set.Add(grid[i][j]);
                }
            }

            //check squares
            for (int i = 0; i < 9; i += 3)
            {
                for (int j = 0; j < 9; j += 3)
                {
                    set = new HashSet<int>();

                    for (int k = i; k < i + 3; k++)
                    {
                        for (int l = j; l < j + 3; l++)
                        {
                            if (set.Contains(grid[k][l]))
                                return (false);

                            else
                                set.Add(grid[k][l]);
                        }
                    }

                }
            }


            return (true);
        }


    }
}
