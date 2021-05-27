using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeSignal.Arcade.TheCore
{
    public class SpringOfIntegration
    {

        /// <remarks>
        /// Given an array of 2k integers (for some integer k), perform the following operations until the array contains only one element:
        /// 
        /// On the 1st, 3rd, 5th, etc.iterations(1-based) replace each pair of consecutive elements with their sum;
        /// On the 2nd, 4th, 6th, etc.iterations replace each pair of consecutive elements with their product.
        /// After the algorithm has finished, there will be a single element left in the array. Return that element.
        /// 
        /// Example
        /// 
        /// For inputArray = [1, 2, 3, 4, 5, 6, 7, 8], the output should be
        /// arrayConversion(inputArray) = 186.
        /// 
        /// 
        /// We have [1, 2, 3, 4, 5, 6, 7, 8] -> [3, 7, 11, 15] -> [21, 165] -> [186], so the answer is 186.
        /// 
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] array.integer inputArray
        /// 
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ inputArray.length ≤ 27,
        /// -100 ≤ inputArray[i] ≤ 100.
        /// 
        /// 
        /// [output] integer
        /// </remarks>
        public static int arrayConversion(int[] inputArray)
        {
            List<int> lst = new List<int>(inputArray);
            int iteraction = 1;

            while (lst.Count > 1)
            {
                List<int> tempList = new List<int>();

                for (int i = 1; i < lst.Count; i += 2)
                {
                    if (iteraction % 2 == 1)
                        tempList.Add(lst[i] + lst[i - 1]);
                    else
                        tempList.Add(lst[i] * lst[i - 1]);
                }

                iteraction++;
                lst = tempList;
            }

            return (lst[0]);
        }

        /// <remarks>
        /// Given array of integers, for each position i, search among the previous positions for the last (from the left) position that contains a smaller value. Store this value at position i in the answer. If no such value can be found, store -1 instead.
        /// 
        /// Example
        /// 
        /// For items = [3, 5, 2, 4, 5], the output should be
        /// arrayPreviousLess(items) = [-1, 3, -1, 2, 4].
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         array.integer items
        /// 
        /// Non-empty array of positive integers.
        /// 
        /// Guaranteed constraints:
        /// 3 ≤ items.length ≤ 15,
        /// 1 ≤ items[i] ≤ 200.
        /// 
        /// [output]
        /// array.integer
        /// 
        /// Array containing answer values computed as described above.
        /// </remarks>
        public static int[] arrayPreviousLess(int[] items)
        {
            int[] posLess = new int[items.Length];

            for (int i = 0; i < items.Length; i++)
            {
                int less = -1;

                for (int j = i; j >= 0; j--)
                {
                    if (items[i] > items[j])
                    {
                        less = items[j];
                        break;
                    }
                }

                posLess[i] = less;
            }

            return (posLess);
        }

        /// <remarks>
        /// Yesterday you found some shoes in the back of your closet. Each shoe is described by two values:
        /// 
        /// type indicates if it's a left or a right shoe;
        /// size is the size of the shoe.
        /// Your task is to check whether it is possible to pair the shoes you found in such a way that each pair consists of a right and a left shoe of an equal size.
        /// 
        /// Example
        /// 
        /// For
        /// 
        /// shoes = [[0, 21],
        ///          [1, 23],
        ///          [1, 21],
        ///          [0, 23]]
        /// the output should be
        /// pairOfShoes(shoes) = true;
        /// 
        /// For
        /// 
        /// shoes = [[0, 21],
        ///          [1, 23],
        ///          [1, 21],
        ///          [1, 23]]
        /// the output should be
        /// pairOfShoes(shoes) = false.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// array.array.integer shoes
        /// 
        /// Array of shoes.Each shoe is given in the format[type, size], where type is either 0 or 1 for left and right respectively, and size is a positive integer.
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ shoes.length ≤ 200,
        /// 1 ≤ shoes[i][1] ≤ 100.
        /// 
        /// [output] boolean
        /// 
        /// true if it is possible to pair the shoes, false otherwise.
        /// </remarks>
        public static bool pairOfShoes(int[][] shoes)
        {
            Dictionary<int, int> set = new Dictionary<int, int>();

            for (int i = 0; i < shoes.Length; i++)
            {
                if (!set.ContainsKey(shoes[i][1]))
                    set.Add(shoes[i][1], 0);

                set[shoes[i][1]] += shoes[i][0] == 1 ? -1 : +1;

                Console.WriteLine($"{set[shoes[i][1]]} {shoes[i][0]} {shoes[i][1]}");
            }

            return (!set.Values.Where(x => x != 0).Any());
        }

        /// <remarks>
        /// Miss X has only two combs in her possession, both of which are old and miss a tooth or two. She also has many purses of different length, in which she carries the combs. The only way they fit is horizontally and without overlapping. Given teeth' positions on both combs, find the minimum length of the purse she needs to take them with her.
        /// 
        /// It is guaranteed that there is at least one tooth at each end of the comb.
        /// It is also guaranteed that the total length of two strings is smaller than 32.
        /// Note, that the combs can not be rotated/reversed.
        /// 
        /// Example
        /// 
        /// For comb1 = "*..*" and comb2 = "*.*", the output should be
        /// combs(comb1, comb2) = 5.        /// 
        /// 
        /// Although it is possible to place the combs like on the first picture, the best way to do this is either picture 2 or picture 3.
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] string comb1
        /// 
        /// 
        /// A comb is represented as a string. If there is an asterisk ('*') in the ith position, there is a tooth there.Otherwise there is a dot('.'), which means there is a missing tooth on the comb.
        /// 
        ///       Guaranteed constraints:
        /// 3 ≤ comb1.length ≤ 8.
        /// 
        /// 
        /// [input] string comb2
        /// 
        /// 
        /// The second comb is represented in the same way as the first one.
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ comb2.length ≤ 5.
        /// 
        /// 
        /// [output] integer
        /// 
        /// The minimum length of a purse Miss X needs.
        /// 
        /// 
        /// </remarks>
        public static int Combs(string comb1, string comb2)
        {
            int minA = Min(comb1, comb2);
            int minB = Min(comb2, comb1);

            return Math.Min(minA, minB);
        }

        /// <summary>
        /// helper
        /// </summary>        
        public static int Min(string comb1, string comb2)
        {
            int total = comb1.Length + comb2.Length;
            int k = total - comb2.Length;
            int min = total;
            int minAbs = Math.Max(comb1.Length, comb2.Length);

            for (int i = 0; i <= comb2.Length; i++)
            {
                bool best = true;

                for (int j = 0; j < comb1.Length; j++)
                {
                    int l = i + j;

                    if (l >= k && comb1[j] == '*' && comb2[l - k] == '*')
                    {
                        best = false;
                        break;
                    }
                }

                if (best)
                    min = Math.Max(minAbs, Math.Min(min, total - i));
            }

            return min;
        }


        /// <remarks>
        /// Define crossover operation over two equal-length strings A and B as follows:
        /// the result of that operation is a string of the same length as the input strings
        /// result[i] is either A[i] or B[i], chosen at random
        /// Given array of strings inputArray and a string result, find for how many pairs of strings from inputArray the result of the crossover operation over them may be equal to result.
        /// 
        /// Note that (A, B) and (B, A) are the same pair.Also note that the pair cannot include the same element of the array twice (however, if there are two equal elements in the array, they can form a pair).
        /// 
        /// Example
        /// 
        /// For inputArray = ["abc", "aaa", "aba", "bab"] and result = "bbb", the output should be
        /// stringsCrossover(inputArray, result) = 2.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input] array.string inputArray
        /// 
        /// A non-empty array of equal-length strings.
        /// 
        /// Guaranteed constraints:
        /// 2 ≤ inputArray.length ≤ 10,
        /// 1 ≤ inputArray[i].length ≤ 10.
        /// 
        /// [input] string result
        /// 
        /// A string of the same length as each of the inputArray elements.
        /// 
        /// Guaranteed constraints:
        /// result.length = inputArray[i].length.
        /// 
        /// [output] integer
        /// </remarks>
        public static int StringsCrossover(string[] inputArray, string result)
        {
            int matches = 0;

            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                for (int j = i + 1; j < inputArray.Length; j++)
                {
                    bool isMatch = true;

                    for (int k = 0; k < result.Length; k++)
                    {
                        if (inputArray[i][k] != result[k] && inputArray[j][k] != result[k])
                        {
                            isMatch = false;
                            break;
                        }
                    }

                    if (isMatch)
                        matches++;
                }
            }


            return (matches);
        }

        /// <remarks>
        /// You're given a substring s of some cyclic string. What's the length of the smallest possible string that can be concatenated to itself many times to obtain this cyclic string?
        /// 
        /// Example
        /// 
        /// For s = "cabca", the output should be
        /// cyclicString(s) = 3.
        /// 
        /// "cabca" is a substring of a cycle string "abcabcabcabc..." that can be obtained by concatenating "abc" to itself.Thus, the answer is 3.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] string s
        /// 
        /// Guaranteed constraints:
        /// 3 ≤ s.length ≤ 15.
        /// 
        /// [output] integer
        /// </remarks>
        public static int CyclicString(string s)
        {
            int index = 0;

            while (s.IndexOf(s[++index..]) != 0) ;

            return (index);
        }


        /// <remarks>
        /// Consider a string containing only letters and whitespaces. It is allowed to replace some (possibly, none) whitespaces with newline symbols to obtain a multiline text. Call a multiline text beautiful if and only if each of its lines (i.e. substrings delimited by a newline character) contains an equal number of characters (only letters and whitespaces should be taken into account when counting the total while newline characters shouldn't). Call the length of the line the text width.
        /// 
        /// Given a string and some integers l and r(l ≤ r), check if it's possible to obtain a beautiful text from the string with a text width that's within the range[l, r].
        /// 
        /// Example
        /// 
        /// For inputString = "Look at this example of a correct text", l = 5, and r = 15, the output should be
        /// beautifulText(inputString, l, r) = true.
        /// 
        /// We can replace 13th and 26th characters with '\n', and obtain the following multiline text of width 12:
        /// 
        /// Look at this
        /// example of a
        /// correct text
        /// For inputString = "abc def ghi", l = 4, and r = 10, the output should be
        /// beautifulText(inputString, l, r) = false.
        /// 
        /// There are two ways to obtain a text with lines of equal length from this input, one has width = 3 and another has width = 11(this is a one - liner).Both of these values are not within our bounds.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] string inputString
        /// 
        /// Guaranteed constraints:
        /// 10 ≤ inputString.length ≤ 40.
        /// 
        /// [input] integer l
        /// 
        /// A positive integer.
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ l ≤ r.
        /// 
        /// [input] integer r
        /// 
        /// A positive integer.
        /// 
        /// Guaranteed constraints:
        /// l ≤ r ≤ 15.
        /// 
        /// [output] boolean
        /// </remarks>
        public static bool BeautifulText(string inputString, int l, int r)
        {
            for (int i = l; i <= r; i++)
            {
                int width = i;

                for (int j = i; j < inputString.Length; j += i + 1)
                {
                    if (inputString[j] != ' ')
                        break;

                    //summing + 1 because we removed the space     
                    width += i + 1;

                    if (width == inputString.Length)
                        return (true);
                }
            }

            return (false);
        }

    }
}
