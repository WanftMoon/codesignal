using System;
namespace CodeSignal.Arcade.TheCore
{
    public class CornerOf0sAnd1s
    {
        /// <remarks>
        /// In order to stop the Mad Coder evil genius you need to decipher the encrypted message he sent to his minions. The message contains several numbers that, when typed into a supercomputer, will launch a missile into the sky blocking out the sun, and making all the people on Earth grumpy and sad.
        /// 
        /// You figured out that some numbers have a modified single digit in their binary representation.More specifically, in the given number n the kth bit from the right was initially set to 0, but its current value might be different.It's now up to you to write a function that will change the kth bit of n back to 0.
        /// 
        /// Example
        /// 
        /// For n = 37 and k = 3, the output should be
        /// killKthBit(n, k) = 33.
        /// 
        /// 3710 = 1001012 ~> 1000012 = 3310.
        /// 
        /// For n = 37 and k = 4, the output should be
        /// killKthBit(n, k) = 37.
        /// 
        /// The 4th bit is 0 already(looks like the Mad Coder forgot to encrypt this number), so the answer is still 37.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         integer n
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ n ≤ 231 - 1.
        /// 
        /// [input]
        /// integer k
        /// 
        /// The 1-based index of the changed bit(counting from the right).
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ k ≤ 31.
        /// 
        /// [output] integer
        /// </remarks>
        public static int KillKthBit(int n, int k)
        {
            return n & ~(1 << (k - 1));
        }


        /// <remarks>
        /// You are given an array of up to four non-negative integers, each less than 256.
        /// 
        /// Your task is to pack these integers into one number M in the following way:
        /// 
        /// The first element of the array occupies the first 8 bits of M;
        /// The second element occupies next 8 bits, and so on.
        /// Return the obtained integer M.
        /// 
        /// Note: the phrase "first bits of M" refers to the least significant bits of M - the right-most bits of an integer.For further clarification see the following example.
        /// 
        /// Example
        /// 
        /// For a = [24, 85, 0], the output should be
        /// arrayPacking(a) = 21784.
        /// 
        /// An array[24, 85, 0] looks like[00011000, 01010101, 00000000] in binary.
        /// After packing these into one number we get 00000000 01010101 00011000 (spaces are placed for convenience), which equals to 21784.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// array.integer a
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ a.length ≤ 4,
        /// 0 ≤ a[i] < 256.
        /// 
        /// [output] integer
        /// 
        /// </remarks>
        public static int ArrayPacking(int[] a)
        {
            int M = 0;

            for (int i = 0; i < a.Length; i++)
            {
                M |= (a[i] << (8 * i));
            }

            return (M);
        }

        /// <remarks>
        /// You are given two numbers a and b where 0 ≤ a ≤ b. Imagine you construct an array of all the integers from a to b inclusive. You need to count the number of 1s in the binary representations of all the numbers in the array.
        /// 
        /// Example
        /// 
        /// For a = 2 and b = 7, the output should be
        /// rangeBitCount(a, b) = 11.
        /// 
        /// Given a = 2 and b = 7 the array is: [2, 3, 4, 5, 6, 7]. Converting the numbers to binary, we get[10, 11, 100, 101, 110, 111], which contains 1 + 2 + 1 + 2 + 2 + 3 = 11 1s.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         integer a
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ a ≤ b.
        /// 
        /// [input] integer b
        /// 
        /// Guaranteed constraints:
        /// a ≤ b ≤ 10.
        /// 
        /// [output] integer
        /// </remarks>
        public static int RangeBitCount(int a, int b)
        {
            int sum = 0;

            for (int i = a; i <= b; i++)
            {
                int number = i;

                while (number > 0)
                {
                    int remainder = number % 2;

                    number /= 2;

                    if (remainder == 1)
                        sum++;
                }
            }

            return (sum);
        }

    }
}
