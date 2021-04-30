using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeSignal.Arcade.Intro
{
    public class SmoothSailing
    {
        /// <remarks>
        /// Given an array of strings, return another array containing all of its longest strings.
        /// Example
        /// For inputArray = ["aba", "aa", "ad", "vcd", "aba"], the output should be
        /// allLongestStrings(inputArray) = ["aba", "vcd", "aba"].
        /// Input/Output
        /// [execution time limit] 3 seconds(cs)
        /// [input] array.string inputArray
        /// A non-empty array.
        /// Guaranteed constraints:
        /// 1 ≤ inputArray.length ≤ 10,
        /// 1 ≤ inputArray[i].length ≤ 10.
        /// [output] array.string
        /// Array of the longest strings, stored in the same order as in the inputArray.
        /// </remarks>
        public static string[] AllLongestStrings(string[] inputArray)
        {
            /*
             * iterative
             * 
             * Dictionary<int, List<string>> set = new Dictionary<int, List<string>>();
    
                for (int i = 0; i < inputArray.Length; i++)
                {
                    string str = inputArray[i];
                    int size = str.Length;
                    List<string> lst = null;
        
                    if (set.ContainsKey(size))
                        lst = set[size];
                    else 
                        lst = new List<string>();
            
                    lst.Add(str);
                    set[size] = lst;
                }
    
                int maxSize = set.Keys.Max();
    
                return (set[maxSize].ToArray());
             */

            int size = inputArray.Max(p => p.Length);

            return (inputArray.Where(p => p.Length == size).ToArray());
        }

        /// <remarks>
        /// Given two strings, find the number of common characters between them.
        /// Example
        /// For s1 = "aabcc" and s2 = "adcaa", the output should be
        /// commonCharacterCount(s1, s2) = 3.
        /// Strings have 3 common characters - 2 "a"s and 1 "c".
        /// Input/Output
        /// [execution time limit] 3 seconds(cs)
        /// [input]
        /// string s1
        /// A string consisting of lowercase English letters.
        /// Guaranteed constraints:
        /// 1 ≤ s1.length< 15.
        /// [input] string s2
        /// A string consisting of lowercase English letters.
        /// Guaranteed constraints:
        /// 1 ≤ s2.length< 15.
        /// [output] integer
        /// </remarks>
        public static int CommonCharacterCount(string s1, string s2)
        {
            /*Dictionary<char, int> set1 = new Dictionary<char, int>();
            Dictionary<char, int> set2 = new Dictionary<char, int>();

            //loop 1
            for (int i = 0; i < s1.Length; i++)
            {
                char val = s1[i];

                if (set1.ContainsKey(val))
                    set1[val] += 1;
                else
                    set1.Add(val, 1);
            }

            //loop 2
            for (int i = 0; i < s2.Length; i++)
            {
                char val = s2[i];

                if (set2.ContainsKey(val))
                    set2[val] += 1;
                else
                    set2.Add(val, 1);
            }

            int count = 0;
            //get the keys on 1
            foreach (var key in set1.Keys)
            {
                //match
                if (set2.ContainsKey(key))
                {
                    count += Math.Min(set1[key], set2[key]);
                }
            }

            return (count);*/


            return s1.Distinct()
                    .Sum(p1 => Math.Min(s1.Count(l => l == p1), s2.Count(l => l == p1)));
        }


        /// <remarks>
        /// Ticket numbers usually consist of an even number of digits. A ticket number is considered lucky if the sum of the first half of the digits is equal to the sum of the second half.
        /// Given a ticket number n, determine if it's lucky or not.
        /// Example
        /// For n = 1230, the output should be
        /// isLucky(n) = true;
        /// For n = 239017, the output should be
        /// isLucky(n) = false.
        /// Input/Output
        /// [execution time limit] 3 seconds(cs)
        /// [input]
        /// integer n
        ///         A ticket number represented as a positive integer with an even number of digits.
        /// 
        /// Guaranteed constraints:
        /// 10 ≤ n< 106.
        /// 
        /// [output] boolean
        /// 
        /// true if n is a lucky ticket number, false otherwise.
        /// </remarks>
        public static bool isLucky(int n)
        {
            string ticket = n.ToString();
            int size = ticket.Length / 2;
            int sumFirstHalf = ticket.Substring(0, size).Sum(p => (int)char.GetNumericValue(p));
            int sumSecondHalf = ticket.Substring(size, size).Sum(p => (int)char.GetNumericValue(p));

            return (sumFirstHalf == sumSecondHalf);
        }

    }
}
