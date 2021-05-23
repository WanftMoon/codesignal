using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeSignal.Arcade.TheCore
{
    public class MirrorLake
    {


        /// <remarks>
        /// Given two strings a and b, both consisting only of lowercase English letters, your task is to calculate how many strings equal to a can be constructed using only letters from the string b? Each letter can be used only once and in one string only.
        /// 
        /// Example
        /// 
        /// For a = "abc" and b = "abccba", the output should be stringsConstruction(a, b) = 2.
        /// 
        /// We can construct 2 strings a = "abc" using only letters from the string b.
        /// 
        /// For a = "ab" and b = "abcbcb", the output should be stringsConstruction(a, b) = 1.
        /// 
        /// Input / Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] string a
        /// 
        /// String to construct, containing only lowercase English letters.
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ a.length ≤ 105.
        /// 
        /// [input] string b
        /// 
        /// String containing needed letters, containing only lowercase English letters.
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ b.length ≤ 105.
        /// 
        /// [output] integer
        /// 
        /// The number of strings a that can be constructed from the string b.
        /// a.Min(x => b.Count(p => p == x) / a.Count(p => p == x));
        /// </remarks>
        public static int StringsConstruction(string a, string b)
        {
            Dictionary<char, int> set = new Dictionary<char, int>();

            foreach (char c in a)
            {
                if (!set.ContainsKey(c))
                    set.Add(c, b.Count(p => p == c) / a.Count(p => p == c));
            }

            return set.Min(p => p.Value);
        }


        /// <remarks>
        /// A ciphertext alphabet is obtained from the plaintext alphabet by means of rearranging some characters. For example "bacdef...xyz" will be a simple ciphertext alphabet where a and b are rearranged.
        /// 
        /// A substitution cipher is a method of encoding where each letter of the plaintext alphabet is replaced with the corresponding(i.e.having the same index) letter of some ciphertext alphabet.
        /// 
        /// Given two strings, check whether it is possible to obtain them from each other using some (possibly, different) substitution ciphers.
        /// 
        /// Example
        /// 
        /// For string1 = "aacb" and string2 = "aabc", the output should be
        /// isSubstitutionCipher(string1, string2) = true.
        /// 
        /// Any ciphertext alphabet that starts with acb...would make this transformation possible.
        /// 
        /// 
        /// For string1 = "aa" and string2 = "bc", the output should be
        /// isSubstitutionCipher(string1, string2) = false.
        /// 
        /// Input / Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] string string1
        /// 
        /// 
        /// A string consisting of lowercase English characters.
        /// 
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ string1.length ≤ 10.
        /// 
        /// 
        /// [input] string string2
        /// 
        /// 
        /// A string consisting of lowercase English characters of the same length as string1.
        /// 
        /// Guaranteed constraints:
        /// string2.length = string1.length.
        /// 
        /// 
        /// [output] boolean
        /// </remarks>
        public static bool IsSubstitutionCipher(string string1, string string2)
        {
            return CheckCipher(string1, string2) && CheckCipher(string2, string1);
        }

        /// <summary>
        /// helper
        /// </summary>        
        public static bool CheckCipher(string s1, string s2)
        {
            Dictionary<char, char> map = new Dictionary<char, char>();

            for (int i = 0; i < s1.Length; i++)
            {
                if (!map.ContainsKey(s1[i]))
                    map.Add(s1[i], s2[i]);

                if (map[s1[i]] != s2[i])
                    return (false);
            }

            return (true);
        }


        /// <remarks>
        /// You are given two strings s and t of the same length, consisting of uppercase English letters. Your task is to find the minimum number of "replacement operations" needed to get some anagram of the string t from the string s. A replacement operation is performed by picking exactly one character from the string s and replacing it by some other character.
        /// 
        /// Example
        /// 
        /// For s = "AABAA" and t = "BBAAA", the output should be
        /// createAnagram(s, t) = 1;
        /// For s = "OVGHK" and t = "RPGUC", the output should be
        /// createAnagram(s, t) = 4.
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         string s
        /// 
        /// Guaranteed constraints:
        /// 5 ≤ s.length ≤ 35.
        /// 
        /// [input]
        ///         string t
        /// 
        /// Guaranteed constraints:
        /// t.length = s.length.
        /// 
        /// [output] integer
        /// 
        /// The minimum number of replacement operations needed to get an anagram of the string t from the string s.
        /// </remarks>
        public static int CreateAnagram(string s, string t)
        {
            foreach (char c in t)
            {
                int index = s.IndexOf((char)c);

                if (index > -1)
                    s = s.Remove(index, 1);
            }

            return s.Length;
        }

        /// <remarks>
        /// Given a string consisting of lowercase English letters, find the largest square number which can be obtained by reordering the string's characters and replacing them with any digits you need (leading zeros are not allowed) where same characters always map to the same digits and different characters always map to different digits.
        /// 
        /// If there is no solution, return -1.
        /// 
        /// Example
        /// 
        /// For s = "ab", the output should be
        /// constructSquare(s) = 81.
        /// The largest 2-digit square number with different digits is 81.
        /// For s = "zzz", the output should be
        /// constructSquare(s) = -1.
        /// There are no 3-digit square numbers with identical digits.
        /// For s = "aba", the output should be
        /// constructSquare(s) = 900.
        /// It can be obtained after reordering the initial string into "baa" and replacing "a" with 0 and "b" with 9.
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] string s
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ s.length< 10.
        /// 
        /// [output] integer
        /// </remarks>
        public static int ConstructSquare(string s)
        {
            int ceil = (int)Math.Pow(10.0, s.Length) - 1;
            int floor = (int)Math.Floor(Math.Sqrt(ceil));
            int[] pattern = s.GroupBy(c => c).Select(c => c.Count()).ToArray();
            int result = -1;

            Array.Sort(pattern);

            for (int i = floor; i * i >= floor; i--)
            {
                int[] candidate = (i * i).ToString().GroupBy(c => c).Select(c => c.Count()).ToArray();

                Array.Sort(candidate);

                if (pattern.SequenceEqual(candidate))
                {
                    result = i * i;
                    break;
                }
            }


            return (result);
        }

        /// <remarks>
        /// You are given an array of integers that you want distribute between several groups. The first group should contain numbers from 1 to 104, the second should contain those from 104 + 1 to 2 * 104, ..., the 100th one should contain numbers from 99 * 104 + 1 to 106 and so on.
        /// 
        /// All the numbers will then be written down in groups to the text file in such a way that:
        /// 
        /// the groups go one after another;
        ///         each non-empty group has a header which occupies one line;
        /// each number in a group occupies one line.
        /// Calculate how many lines the resulting text file will have.
        /// 
        /// Example
        /// 
        /// For a = [20000, 239, 10001, 999999, 10000, 20566, 29999], the output should be
        /// numbersGrouping(a) = 11.
        /// 
        /// The numbers can be divided into 4 groups:
        /// 
        /// 239 and 10000 go to the 1st group (1 ... 104);
        /// 10001 and 20000 go to the second 2nd(104 + 1 ... 2 * 104);
        /// 20566 and 29999 go to the 3rd group(2 * 104 + 1 ... 3 * 104);
        ///         groups from 4 to 99 are empty;
        /// 999999 goes to the 100th group(99 * 104 + 1 ... 106).
        /// Thus, there will be 4 groups(i.e.four headers) and 7 numbers, so the file will occupy 4 + 7 = 11 lines.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// array.integer a
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ a.length ≤ 105,
        /// 1 ≤ a[i] ≤ 109.
        /// 
        /// [output]
        /// integer
        /// 
        /// The number of lines needed to store the grouped numbers.
        /// </remarks>
        public static int NumbersGrouping(int[] a)
        {
            return a.GroupBy(p => (p - 1) / 10000).Count() + a.Length;
        }


        /// <remarks>
        /// Given a rectangular matrix containing only digits, calculate the number of different 2 × 2 squares in it.
        /// 
        /// Example
        /// 
        /// For
        /// 
        /// matrix = [[1, 2, 1],
        ///           [2, 2, 2],
        ///           [2, 2, 2],
        ///           [1, 2, 3],
        ///           [2, 2, 1]]
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
        ///
        /// </remarks>
        public static int DifferentSquares(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < m - 1; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    string key = $"({matrix[i][j]}, {matrix[i][j + 1]}), ({matrix[i + 1][j]}, {matrix[i + 1][j + 1]})";

                    if (!set.Contains(key))
                        set.Add(key);
                }
            }

            return set.Count();
        }


        /// <remarks>
        /// A step(x) operation works like this: it changes a number x into x - s(x), where s(x) is the sum of x's digits. You like applying functions to numbers, so given the number n, you decide to build a decreasing sequence of numbers: n, step(n), step(step(n)), etc., with 0 as the last element.
        /// 
        ///  Building a single sequence isn't enough for you, so you replace all elements of the sequence with the sums of their digits (s(x)). Now you're curious as to which number appears in the new sequence most often.If there are several answers, return the maximal one.
        /// 
        /// Example
        /// 
        /// For n = 88, the output should be
        /// mostFrequentDigitSum(n) = 9.
        /// 
        /// Here is the first sequence you built: 88, 72, 63, 54, 45, 36, 27, 18, 9, 0;
        /// And here is s(x) for each of its elements: 16, 9, 9, 9, 9, 9, 9, 9, 9, 0.
        /// As you can see, the most frequent number in the second sequence is 9.
        /// 
        /// For n = 8, the output should be
        /// mostFrequentDigitSum(n) = 8.
        /// 
        /// At first you built the following sequence: 8, 0
        /// s(x) for each of its elements is: 8, 0
        /// As you can see, the answer is 8 (it appears as often as 0, but is greater than it).
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         integer n
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ n ≤ 105.
        /// 
        /// [output]
        ///         integer
        /// 
        /// The most frequent number in the sequence s(n), s(step(n)), s(step(step(n))), etc.
        /// </remarks>
        public static int MostFrequentDigitSum(int n)
        {
            Dictionary<int, int> set = new Dictionary<int, int>();

            while (n > 0)
            {
                int digitSum = s(n);

                if (!set.ContainsKey(digitSum))
                    set.Add(digitSum, 1);
                else
                    set[digitSum]++;

                n = n - digitSum;
            }

            return set.Where(x => x.Value == set.Max(p => p.Value)).Max(x => x.Key);
        }


        /// <summary>
        /// helper
        /// </summary>        
        public static int s(int x)
        {
            int sum = 0;

            while (x > 0)
            {
                sum += x % 10;
                x /= 10;
            }

            return (sum);
        }

        /// <remarks>
        /// Let's call two integers A and B friends if each integer from the array divisors is either a divisor of both A and B or neither A nor B. If two integers are friends, they are said to be in the same clan. How many clans are the integers from 1 to k, inclusive, broken into?
        /// 
        /// Example
        /// 
        /// For divisors = [2, 3] and k = 6, the output should be
        /// numberOfClans(divisors, k) = 4.
        /// 
        /// The numbers 1 and 5 are friends and form a clan, 2 and 4 are friends and form a clan, and 3 and 6 do not have friends and each is a clan by itself.So the numbers 1 through 6 are broken into 4 clans.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] array.integer divisors
        /// 
        /// A non-empty array of positive integers.
        /// 
        /// Guaranteed constraints:
        /// 2 ≤ divisors.length< 10,
        /// 1 ≤ divisors[i] ≤ 10.
        /// 
        /// [input] integer k
        /// 
        /// A positive integer.
        /// 
        /// Guaranteed constraints:
        /// 5 ≤ k ≤ 10.
        /// 
        /// [output] integer
        /// </remarks>
        public int NumberOfClans(int[] divisors, int k)
        {
            HashSet<int> set = new HashSet<int>();

            for (int i = 1; i <= k; i++)
            {
                int key = 0;

                for (int j = 0; j < divisors.Length; j++)
                {
                    if (i % divisors[j] == 0)
                        key += 1 << j;
                }

                set.Add(key);
            }

            return set.Count;
        }

    }
}
