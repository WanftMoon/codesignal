using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeSignal.Arcade.Intro
{
    public class DivingDeeper
    {

        /// <remarks>
        /// Given array of integers, remove each kth element from it.
        /// 
        ///         Example
        /// 
        ///         For inputArray = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10] and k = 3, the output should be
        ///         extractEachKth(inputArray, k) = [1, 2, 4, 5, 7, 8, 10].
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         array.integer inputArray
        /// 
        /// Guaranteed constraints:
        /// 5 ≤ inputArray.length ≤ 15,
        /// -20 ≤ inputArray[i] ≤ 20.
        /// 
        /// [input]
        ///         integer k
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ k ≤ 10.
        /// 
        /// [output]
        ///         array.integer
        /// 
        /// inputArray without elements k - 1, 2k - 1, 3k - 1 etc.
        /// </remarks>
        public static int[] ExtractEachKth(int[] inputArray, int k)
        {
            return (inputArray.Where((_, i) => (i + 1) % k != 0).ToArray());
        }

        /// <remarks>
        /// Find the leftmost digit that occurs in a given string.
        /// 
        /// Example
        /// 
        /// For inputString = "var_1__Int", the output should be
        /// firstDigit(inputString) = '1';
        /// For inputString = "q2q-q", the output should be
        /// firstDigit(inputString) = '2';
        /// For inputString = "0ss", the output should be
        /// firstDigit(inputString) = '0'.
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// string inputString
        /// 
        /// A string containing at least one digit.
        /// 
        /// Guaranteed constraints:
        /// 3 ≤ inputString.length ≤ 10.
        /// 
        /// [output] char
        /// inputString.First(char.IsDigit);
        /// </remarks>
        public static char FirstDigit(string inputString)
        {
            for (int i = 0; i < inputString.Length; i++)
            {
                if (char.IsDigit(inputString[i]))
                    return (inputString[i]);
            }

            return ('0');
        }


        /// <remarks>
        /// Given a string, find the number of different characters in it.
        /// 
        /// Example
        /// 
        /// For s = "cabca", the output should be
        /// differentSymbolsNaive(s) = 3.
        /// 
        /// There are 3 different characters a, b and c.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// string s
        /// 
        /// A string of lowercase English letters.
        /// 
        /// Guaranteed constraints:
        /// 3 ≤ s.length ≤ 1000.
        /// 
        /// [output] integer
        ///
        /// s.Distinct().Count()
        /// </remarks>
        public static int DifferentSymbolsNaive(string s)
        {
            Dictionary<char, int> set = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (set.ContainsKey(s[i]))
                    set[s[i]] += 1;
                else
                    set.Add(s[i], 0);
            }

            return (set.Keys.Count);
        }


        /// <remarks>
        /// Given array of integers, find the maximal possible sum of some of its k consecutive elements.
        /// 
        ///  Example
        /// 
        ///  For inputArray = [2, 3, 5, 1, 6] and k = 2, the output should be
        ///  arrayMaxConsecutiveSum(inputArray, k) = 8.
        /// All possible sums of 2 consecutive elements are:
        /// 
        /// 2 + 3 = 5;
        /// 3 + 5 = 8;
        /// 5 + 1 = 6;
        /// 1 + 6 = 7.
        /// Thus, the answer is 8.
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// array.integer inputArray
        /// 
        /// Array of positive integers.
        /// 
        /// Guaranteed constraints:
        /// 3 ≤ inputArray.length ≤ 105,
        /// 1 ≤ inputArray[i] ≤ 1000.
        /// 
        /// [input] integer k
        /// 
        /// An integer (not greater than the length of inputArray).
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ k ≤ inputArray.length.
        /// 
        /// [output] integer
        /// 
        /// The maximal possible sum.
        /// </remarks>
        public int ArrayMaxConsecutiveSum(int[] inputArray, int k)
        {
            int maxSum = inputArray.Take(k).Sum();
            int windowSum = maxSum;

            for (int i = 0 + k; i < inputArray.Length; i++)
            {
                windowSum += inputArray[i] - inputArray[i - k];
                maxSum = Math.Max(windowSum, maxSum);
            }

            return (maxSum);
        }

    }
}
