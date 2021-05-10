using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeSignal.Arcade.Intro
{
    public class RainbowOfClarity
    {
        /// <remarks>
        /// Determine if the given character is a digit or not.
        /// 
        /// Example
        /// 
        /// For symbol = '0', the output should be
        /// isDigit(symbol) = true;
        /// For symbol = '-', the output should be
        /// isDigit(symbol) = false.
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// char symbol
        /// 
        /// A character which is either a digit or not.
        /// 
        /// Guaranteed constraints:
        /// Given symbol is from ASCII table.
        /// 
        /// [output] boolean
        /// 
        /// true if symbol is a digit, false otherwise.
        /// </remarks>
        public static bool IsDigit(char symbol)
        {
            return (char.IsDigit(symbol));
        }

        /// <remarks>
        /// Given a string, return its encoding defined as follows:
        /// 
        /// First, the string is divided into the least possible number of disjoint substrings consisting of identical characters
        /// or example, "aabbbc" is divided into["aa", "bbb", "c"]
        /// ext, each substring with length greater than one is replaced with a concatenation of its length and the repeating character
        /// or example, substring "bbb" is replaced by "3b"
        /// inally, all the new strings are concatenated together in the same order and a new string is returned.
        /// xample
        /// 
        /// or s = "aabbbc", the output should be
        /// ineEncoding(s) = "2a3bc".
        /// </remarks>
        public static string LineEncoding(string s)
        {
            List<Dictionary<char, int>> lst = new List<Dictionary<char, int>>();
            int index = 0;

            lst.Add(new Dictionary<char, int>());

            for (int i = 0; i < s.Length; i++)
            {
                var set = lst[index];

                if (set.ContainsKey(s[i]))
                    set[s[i]] += 1;
                else if (set.Keys.Count == 0)
                    set.Add(s[i], 1);
                else
                {
                    lst.Add(new Dictionary<char, int>());
                    index++;
                    set = lst[index];
                    set.Add(s[i], 1);
                }
            }

            StringBuilder sb = new StringBuilder();

            foreach (var item in lst)
            {
                var val = item.First();

                if (val.Value > 1)
                    sb.Append($"{val.Value}{val.Key}");
                else
                    sb.Append($"{val.Key}");
            }

            return (sb.ToString());
        }



        /// <remarks>
        /// Given a position of a knight on the standard chessboard, find the number of different moves the knight can perform.
        /// 
        /// The knight can move to a square that is two squares horizontally and one square vertically, or two squares vertically and one square horizontally away from it.The complete move therefore looks like the letter L.Check out the image below to see all valid moves for a knight piece that is placed on one of the central squares.
        /// 
        /// 
        /// 
        /// Example
        /// 
        /// For cell = "a1", the output should be
        /// chessKnight(cell) = 2.
        /// 
        /// For cell = "c2", the output should be
        /// chessKnight(cell) = 6.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// string cell
        /// 
        /// String consisting of 2 letters - coordinates of the knight on an 8 × 8 chessboard in chess notation.
        /// 
        /// Guaranteed constraints:
        /// cell.length = 2,
        /// 'a' ≤ cell[0] ≤ 'h',
        /// 1 ≤ cell[1] ≤ 8.
        /// 
        /// [output] integer
        ///
        /// var results = new int[]{2, 3, 4, 6, 8};
        /// int dist1 = Math.Min(Math.Min(cell[0] - 'a', 'h' - cell[0]), 2);
        /// int dist2 = Math.Min(Math.Min(cell[1] - '1', '8' - cell[1]), 2);
        /// return results[dist1 + dist2];
        /// </remarks>
        public static int ChessKnight(string cell)
        {
            int[][] moves = {
                new int[] { -2, -1},
                new int[] { -2, 1 },
                new int[] { -1, 2 },
                new int[] { -1, -2 },
                new int[] { 1, 2 },
                new int[] { 1, -2 },
                new int[] { 2, 1 },
                new int[] { 2, -1 } };
            int count = 0;


            foreach (var mov in moves)
            {
                var dx = cell[0] + mov[0];
                var dy = cell[1] + mov[1];

                if ((dx >= 'a' && dx <= 'h') && (dy >= '1' && dy <= '8'))
                    count++;
            }

            return (count);
        }



        /// <summary>
        /// Given some integer, find the maximal number you can obtain by deleting exactly one digit of the given number.
        /// 
        /// Example
        /// 
        /// For n = 152, the output should be
        /// deleteDigit(n) = 52;
        /// For n = 1001, the output should be
        /// deleteDigit(n) = 101.
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// integer n
        /// 
        /// Guaranteed constraints:
        /// 10 ≤ n ≤ 106.
        /// 
        /// [output] integer
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int deleteDigit(int n)
        {
            string s = $"{n}";

            return (s.ToString().Select((c, i) => int.Parse(s.Remove(i, 1))).Max());
        }


    }
}
