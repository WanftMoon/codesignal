using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeSignal.Arcade.TheCore
{
    public class SortingOutpost
    {
        /// <remarks>
        /// A noob programmer was given two simple tasks: sum and sort the elements of the given array
        ///         a = [a1, a2, ..., an]. He started with summing and did it easily, but decided to store the sum he found in some random position of the original array which was a bad idea.Now he needs to cope with the second task, sorting the original array a, and it's giving him trouble since he modified it.
        /// 
        /// 
        /// Given the array shuffled, consisting of elements a1, a2, ..., an, a1 + a2 + ... + an in random order, return the sorted array of original elements a1, a2, ..., an.
        /// 
        /// Example
        /// 
        /// For shuffled = [1, 12, 3, 6, 2], the output should be
        /// shuffledArray(shuffled) = [1, 2, 3, 6].
        /// 
        /// 1 + 3 + 6 + 2 = 12, which means that 1, 3, 6 and 2 are original elements of the array.
        /// 
        /// 
        /// For shuffled = [1, -3, -5, 7, 2], the output should be
        /// shuffledArray(shuffled) = [-5, -3, 2, 7].
        /// 
        /// Input / Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] array.integer shuffled
        /// 
        /// 
        /// Array of at least two integers. It is guaranteed that there is an index i such that shuffled[i] = shuffled[0] + ... + shuffled[i - 1] + shuffled[i + 1] + ... + shuffled[n].
        /// 
        /// 
        /// Guaranteed constraints:
        /// 2 ≤ shuffled.length ≤ 104,
        /// -5 · 104 ≤ shuffled[i] ≤ 5 · 104.
        /// 
        /// 
        /// [output] array.integer
        /// 
        /// A sorted array of shuffled.length - 1 elements.
        /// </remarks>
        public static int[] ShuffledArray(int[] shuffled)
        {
            for (int i = 0; i < shuffled.Length; i++)
            {
                var temp = shuffled.Where((_, index) => index != i);

                if (shuffled[i] == temp.Sum())
                    return (temp.OrderBy(x => x).ToArray());
            }

            return (shuffled);
        }

        /// <remarks>
        /// Some people are standing in a row in a park. There are trees between them which cannot be moved. Your task is to rearrange the people by their heights in a non-descending order without moving the trees. People can be very tall!
        /// 
        /// Example
        /// 
        /// For a = [-1, 150, 190, 170, -1, -1, 160, 180], the output should be
        /// sortByHeight(a) = [-1, 150, 160, 170, -1, -1, 180, 190].
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         array.integer a
        /// 
        /// If a[i] = -1, then the ith position is occupied by a tree.Otherwise a[i] is the height of a person standing in the ith position.
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ a.length ≤ 1000,
        /// -1 ≤ a[i] ≤ 1000.
        /// 
        /// [output] array.integer
        /// 
        /// Sorted array a with all the trees untouched.
        /// </remarks>
        public static int[] SortByHeight(int[] a)
        {
            List<int> lst = a.Where(x => x != -1).OrderBy(x => x).ToList();

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == -1)
                    lst.Insert(i, -1);
            }

            return lst.ToArray();
        }

        /// <remarks>
        /// Given an array of strings, sort them in the order of increasing lengths. If two strings have the same length, their relative order must be the same as in the initial array.
        /// 
        /// Example
        /// 
        /// For
        /// 
        /// inputArray = ["abc",
        ///               "",
        ///               "aaa",
        ///               "a",
        ///               "zz"]
        ///         the output should be
        /// 
        /// sortByLength(inputArray) = ["",
        ///                             "a",
        ///                             "zz",
        ///                             "abc",
        ///                             "aaa"]
        ///         Input/Output
        /// 
        ///         [execution time limit] 3 seconds(cs)
        /// 
        /// [input] array.string inputArray
        /// 
        /// A non-empty array of strings.
        /// 
        /// Guaranteed constraints:
        /// 3 ≤ inputArray.length ≤ 100,
        /// 0 ≤ inputArray[i].length ≤ 100.
        /// 
        /// [output] array.string
        /// </remarks>
        public static string[] SortByLength(string[] inputArray)
        {
            return inputArray.OrderBy(x => x.Length).ToArray();
        }

        /// <remarks>
        /// You are given n rectangular boxes, the ith box has the length lengthi, the width widthi and the height heighti. Your task is to check if it is possible to pack all boxes into one so that inside each box there is no more than one another box (which, in turn, can contain at most one another box, and so on). More formally, your task is to check whether there is such sequence of n different numbers pi (1 ≤ pi ≤ n) that for each 1 ≤ i < n the box number pi can be put into the box number pi+1.
        ///         A box can be put into another box if all sides of the first one are less than the respective ones of the second one.You can rotate each box as you wish, i.e.you can swap its length, width and height if necessary.
        /// 
        ///         Example
        /// 
        ///         For length = [1, 3, 2], width = [1, 3, 2], and height = [1, 3, 2], the output should be
        ///         boxesPacking(length, width, height) = true;
        ///         For length = [1, 1], width = [1, 1], and height = [1, 1], the output should be
        /// boxesPacking(length, width, height) = false;
        /// For length = [3, 1, 2], width = [3, 1, 2], and height = [3, 2, 1], the output should be
        /// boxesPacking(length, width, height) = false.
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         array.integer length
        /// 
        /// Array of positive integers.
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ length.length ≤ 104,
        /// 1 ≤ length[i] ≤ 2 · 104.
        /// 
        /// [input] array.integer width
        /// 
        /// Array of positive integers.
        /// 
        /// Guaranteed constraints:
        /// width.length = length.length,
        /// 1 ≤ width[i] ≤ 2 · 104.
        /// 
        /// [input] array.integer height
        /// 
        /// Array of positive integers.
        /// 
        /// Guaranteed constraints:
        /// height.length = length.length,
        /// 1 ≤ height[i] ≤ 2 · 104.
        /// 
        /// [output] boolean
        /// 
        /// true if it is possible to put all boxes into one, false otherwise.
        /// </remarks>
        public static bool BoxesPacking(int[] length, int[] width, int[] height)
        {
            var boxes = length.Select((x, i) => new
            {
                v = (long)x * (long)width[i] * (long)height[i],
                dim = new int[] { x, width[i], height[i] }.OrderBy(z => z).ToArray()
            }).OrderBy(x => x.v).ToArray();

            for (int i = 1; i < boxes.Length; i++)
            {
                if (boxes[i - 1].v == boxes[i].v ||
                    boxes[i - 1].dim[0] >= boxes[i].dim[0] || boxes[i - 1].dim[1] >= boxes[i].dim[1] || boxes[i - 1].dim[2] >= boxes[i].dim[2])
                    return (false);
            }

            return (true);
        }

        /// <remarks>
        /// You are given an array of integers a. A range sum query is defined by a pair of non-negative integers l and r (l <= r). The output to a range sum query on the given array a is the sum of all the elements of a that have indices from l to r, inclusive.
        /// 
        ///     You have the array a and a list of range sum queries q.Find an algorithm that can rearrange the array a in such a way that the total sum of all of the query outputs is maximized, and return this total sum.
        /// 
        ///    Example
        ///    
        /// 
        ///    For a = [9, 7, 2, 4, 4] and q = [[1, 3], [1, 4], [0, 2]], the output should be
        /// maximumSum(a, q) = 62.
        /// 
        /// You can get this sum if the array a is rearranged to be[2, 9, 7, 4, 4]. In that case, the first range sum query[1, 3] returns the sum 9 + 7 + 4 = 20, the second query[1, 4] returns the sum 9 + 7 + 4 + 4 = 24, and the third query [0, 2] returns the sum 2 + 9 + 7 = 18. The total sum will be 20 + 24 + 18 = 62.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] array.integer a
        /// 
        /// An initial array.
        /// 
        /// Guaranteed constraints:
        /// 2 ≤ a.length ≤ 10,
        /// 1 ≤ a[i] ≤ 10.
        /// 
        /// [input] array.array.integer q
        /// 
        /// An array of range sum queries, where each query is an array of two non-negative integers.
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ q.length ≤ 10,
        /// 0 ≤ q[i][0] ≤ q[i][1] < a.length.
        /// 
        /// [output] integer
        /// 
        /// Return the maximum possible total sum of the given range sum query outputs.
        /// </remarks>
        public static int MaximumSum(int[] a, int[][] q)
        {
            int[] mults = new int[a.Length];

            for (int i = 0; i < q.Length; i++)
            {
                for (int j = q[i][0]; j <= q[i][1]; j++)
                    mults[j]++;
            }

            Array.Sort(mults);

            return a.OrderBy(x => x).Select((x, i) => x * mults[i]).Sum();
        }



        /// <remarks>
        /// Given a rectangular matrix of integers, check if it is possible to rearrange its rows in such a way that all its columns become strictly increasing sequences (read from top to bottom).
        /// 
        /// Example
        /// 
        /// For
        /// 
        /// matrix = [[2, 7, 1], 
        ///           [0, 2, 0], 
        ///           [1, 3, 1]]
        /// the output should be
        /// rowsRearranging(matrix) = false;
        /// 
        /// For
        /// 
        /// matrix = [[6, 4],
        ///           [2, 2],
        ///           [4, 3]]
        /// the output should be
        /// rowsRearranging(matrix) = true.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         array.array.integer matrix
        /// 
        /// A 2-dimensional array of integers.
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ matrix.length ≤ 10,
        /// 1 ≤ matrix[0].length ≤ 10,
        /// -300 ≤ matrix[i][j] ≤ 300.
        /// 
        /// [output] boolean
        /// </remarks>
        public static bool RowsRearranging(int[][] matrix)
        {
            Array.Sort(matrix, (f, s) => f[0] > s[0] ? 1 : (f[0] == s[0] ? 0 : -1));

            for (int j = 0; j < matrix[0].Length; j++)
            {
                for (int i = 0; i < matrix.Length - 1; i++)
                {
                    if (matrix[i][j] >= matrix[i + 1][j])
                        return (false);

                }
            }

            return (true);
        }


        /// <remarks>
        /// Given an array of integers, sort its elements by the difference of their largest and smallest digits. In the case of a tie, that with the larger index in the array should come first.
        /// 
        /// Example
        /// 
        /// For a = [152, 23, 7, 887, 243], the output should be
        /// digitDifferenceSort(a) = [7, 887, 23, 243, 152].
        /// 
        /// Here are the differences of all the numbers:
        /// 
        /// 152: difference = 5 - 1 = 4;
        /// 23: difference = 3 - 2 = 1;
        /// 7: difference = 7 - 7 = 0;
        /// 887: difference = 8 - 7 = 1;
        /// 243: difference = 4 - 2 = 2.
        /// 23 and 887 have the same difference, but 887 goes after 23 in a, so in the sorted array it comes first.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] array.integer a
        /// 
        /// An array of integers.
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ sequence.length ≤ 104,
        /// 1 ≤ sequence[i] ≤ 105.
        /// 
        /// [output] array.integer
        /// 
        /// Array a sorted as described above.
        /// 
        /// 
        /// </remarks>
        public static int[] DigitDifferenceSort(int[] a)
        {
            Func<int, int> diff = (x) =>
            {
                int min = int.MaxValue;
                int max = int.MinValue;

                while (x > 0)
                {
                    int remainder = x % 10;

                    x /= 10;

                    Console.WriteLine(remainder);

                    min = Math.Min(remainder, min);
                    max = Math.Max(remainder, max);
                }

                return (max - min);
            };

            var vals = a.Select((p, i) => new { i, diff = diff.Invoke(p), p });

            return vals.OrderByDescending(x => x.i).OrderBy(x => x.diff).Select(x => x.p).ToArray();
        }


        /// <remarks>
        /// Let's call product(x) the product of x's digits. Given an array of integers a, calculate product(x) for each x in a, and return the number of distinct results you get.
        /// 
        ///  Example
        /// 
        ///  For a = [2, 8, 121, 42, 222, 23], the output should be
        /// uniqueDigitProducts(a) = 3.
        /// 
        /// Here are the products of the array's elements:
        /// 
        /// 2: product(2) = 2;
        /// 8: product(8) = 8;
        /// 121: product(121) = 1 * 2 * 1 = 2;
        /// 42: product(42) = 4 * 2 = 8;
        /// 222: product(222) = 2 * 2 * 2 = 8;
        /// 23: product(23) = 2 * 3 = 6.
        /// As you can see, there are only 3 different products: 2, 6 and 8.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         array.integer a
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ a.length ≤ 105,
        /// 1 ≤ a[i] ≤ 109.
        /// 
        /// [output]
        ///         integer
        /// 
        /// The number of different digit products in a.
        /// </remarks>
        public static int UniqueDigitProducts(int[] a)
        {
            Func<int, int> product = (x) => {

                int mul = 1;

                while (x > 0)
                {
                    mul *= x % 10;
                    x /= 10;
                }

                return (mul);
            };

            return a.Select(x => product(x)).Distinct().Count();
        }

    }
}
