using System;
namespace CodeSignal.Arcade.TheCore
{
    public class IntroGates
    {
        /// <remarks>
        /// Given
        ///  You are given a two-digit integer n.Return the sum of its digits.
        /// 
        /// Example
        /// 
        /// 
        /// Example 1
        /// For n = 29, the output should be addTwoDigits(n) = 11.
        /// 
        /// Example 2
        /// For n = 48, the output should be addTwoDigits(n) = 12.
        /// 
        /// Input / Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] integer n
        /// 
        /// A positive two-digit integer.
        /// 
        /// 
        /// Guaranteed constraints:
        /// 10 ≤ n ≤ 99.
        /// 
        /// 
        /// [output] integer
        /// 
        /// The sum of the first and second digits of n.
        /// </remarks>
        public static int AddTwoDigits(int n)
        {
            return (n / 10 + n % 10);
        }

        /// <remarks>
        /// Given an integer n, return the largest number that contains exactly n digits.
        /// Example
        /// 
        /// For n = 2, the output should be
        /// largestNumber(n) = 99.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         integer n
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ n ≤ 9.
        /// 
        /// [output]
        ///         integer
        /// 
        /// The largest integer of length n.
        /// 
        /// (int)(Math.Pow(10.0,(double)n)-1)
        /// </remarks>
        public static int LargestNumber(int n)
        {
            int number = 0;

            for (int i = 0; i < n; i++)
                number += 9 * (int)Math.Pow(10.0, (double)i);

            return (number);
        }


    }
}
