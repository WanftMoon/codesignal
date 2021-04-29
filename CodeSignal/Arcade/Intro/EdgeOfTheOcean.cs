using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeSignal.Arcade.Intro
{
    public class EdgeOfTheOcean
    {
        /// <remarks>
        /// Given an array of integers, find the pair of adjacent elements that has the largest product and return that product.
        /// Example
        /// For inputArray = [3, 6, -2, -5, 7, 3], the output should be
        /// adjacentElementsProduct(inputArray) = 21.
        /// 7 and 3 produce the largest product.
        /// Input/Output
        /// [execution time limit] 3 seconds (cs)
        /// [input] array.integer inputArray
        /// An array of integers containing at least two elements.
        /// Guaranteed constraints:
        /// 2 ≤ inputArray.length ≤ 10,
        /// -1000 ≤ inputArray[i] ≤ 1000.
        /// [output] integer
        /// The largest product of adjacent elements.
        /// </remarks>
        public static int AdjacentElementsProduct(int[] inputArray)
        {
            int max = inputArray[0] * inputArray[1];

            for (int i = 1; i < inputArray.Length - 1; i++)
            {
                int temp = inputArray[i] * inputArray[i + 1];

                if (temp > max)
                    max = temp;
            }

            return (max);
        }

        /// <remarks>
        /// Below we will define an n-interesting polygon. Your task is to find the area of a polygon for a given n.

        /// A 1-interesting polygon is just a square with a side of length 1. An n-interesting polygon is obtained by taking the n - 1-interesting polygon and appending 1-interesting polygons to its rim, side by side.You can see the 1-, 2-, 3- and 4-interesting polygons in the picture below.



        /// Example

        /// For n = 2, the output should be
        /// shapeArea(n) = 5;
        /// For n = 3, the output should be
        /// shapeArea(n) = 13.
        /// Input/Output
        /// [execution time limit] 3 seconds(cs)
        /// [input]
        /// integer n
        /// Guaranteed constraints:
        /// 1 ≤ n< 104.
        /// [output] integer
        /// The area of the n-interesting polygon.
        /// </remarks>
        public static int ShapeArea(int n)
        {
            return (n * n + (n - 1) * (n - 1));
        }

        /// <remarks>
        /// Ratiorg got statues of different sizes as a present from CodeMaster for his birthday, each statue having an non-negative integer size. Since he likes to make things perfect, he wants to arrange them from smallest to largest so that each statue will be bigger than the previous one exactly by 1. He may need some additional statues to be able to accomplish that. Help him figure out the minimum number of additional statues needed.
        /// Example
        /// For statues = [6, 2, 3, 8], the output should be
        /// makeArrayConsecutive2(statues) = 3.
        /// Ratiorg needs statues of sizes 4, 5 and 7.
        /// Input/Output
        /// [execution time limit] 3 seconds(cs)
        /// [input]
        /// array.integer statues
        /// An array of distinct non-negative integers.
        /// Guaranteed constraints:
        /// 1 ≤ statues.length ≤ 10,
        /// 0 ≤ statues[i] ≤ 20.
        /// [output] integer
        /// The minimal number of statues that need to be added to existing statues such that it contains every integer size from an interval [L, R] (for some L, R) and no other sizes.        /// 
        /// </remarks>
        public static int MakeArrayConsecutive2(int[] statues)
        {
            //this solutions lets you know each missing size
            // if you dont want to know you can do (Max - Min - Length + 1) to get only the count
            var ordered = statues.OrderBy(p => p).ToArray();
            var set = new HashSet<int>();

            for (int i = 0; i < ordered.Count() - 1; i++)
            {
                int current = ordered[i];
                int next = ordered[i + 1];

                //check missing
                for (int j = current + 1; j < next; j++)
                    set.Add(j);
            }

            return (set.Count());
        }

        /// <remarks>
        /// Given a sequence of integers as an array, determine whether it is possible to obtain a strictly increasing sequence by removing no more than one element from the array.
        /// Note: sequence a0, a1, ..., an is considered to be a strictly increasing if a0<a1< ... < an.Sequence containing only one element is also considered to be strictly increasing.
        /// 
        /// Example
        ///  
        /// For sequence = [1, 3, 2, 1], the output should be
        /// almostIncreasingSequence(sequence) = false.
        /// 
        /// There is no one element in this array that can be removed in order to get a strictly increasing sequence.
        /// 
        /// For sequence = [1, 3, 2], the output should be
        /// almostIncreasingSequence(sequence) = true.
        /// 
        /// You can remove 3 from the array to get the strictly increasing sequence[1, 2]. Alternately, you can remove 2 to get the strictly increasing sequence[1, 3].
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         array.integer sequence
        /// 
        /// Guaranteed constraints:
        /// 2 ≤ sequence.length ≤ 105,
        /// -105 ≤ sequence[i] ≤ 105.
        /// 
        /// [output]
        ///         boolean
        /// 
        /// Return true if it is possible to remove one element from the array in order to get a strictly increasing sequence, otherwise return false.
        /// </remarks>
        public static bool AlmostIncreasingSequence(int[] sequence)
        {
            //check issues           
            int count = 0;

            //first pass - count the occurrence of unordered elements
            for (int i = 0; i < sequence.Length - 1; i++)
            {
                //found a ofender
                if (sequence[i] >= sequence[i + 1])
                {
                    count++;

                    //check the imediate gap
                    if (i > 0 && (i + 2) < sequence.Length && (sequence[i - 1] >= sequence[i + 1]) && (sequence[i] >= sequence[i + 2]))
                        count++;
                }

                if (count > 1)
                    break;
            }

            return (count <= 1);
        }

        /// <remarks>
        /// After becoming famous, the CodeBots decided to move into a new building together. Each of the rooms has a different cost, and some of them are free, but there's a rumour that all the free rooms are haunted! Since the CodeBots are quite superstitious, they refuse to stay in any of the free rooms, or any of the rooms below any of the free rooms.
        /// Given matrix, a rectangular matrix of integers, where each value represents the cost of the room, your task is to return the total sum of all rooms that are suitable for the CodeBots(ie: add up all the values that don't appear below a 0).
        /// Example
        /// For
        /// matrix = [[0, 1, 1, 2],
        /// [0, 5, 0, 0],
        /// [2, 0, 3, 3]]
        /// the output should be
        /// matrixElementsSum(matrix) = 9.
        /// example 1
        /// There are several haunted rooms, so we'll disregard them as well as any rooms beneath them. Thus, the answer is 1 + 5 + 1 + 2 = 9.
        /// For
        /// 
        ///         matrix = [[1, 1, 1, 0],
        ///           [0, 5, 0, 1],
        ///           [2, 1, 3, 10]]
        /// the output should be
        /// matrixElementsSum(matrix) = 9.
        /// 
        /// example 2
        /// 
        /// Note that the free room in the final column makes the full column unsuitable for bots(not just the room directly beneath it). Thus, the answer is 1 + 1 + 1 + 5 + 1 = 9.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         array.array.integer matrix
        /// 
        /// A 2-dimensional array of integers representing the cost of each room in the building.A value of 0 indicates that the room is haunted.
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ matrix.length ≤ 5,
        /// 1 ≤ matrix[i].length ≤ 5,
        /// 0 ≤ matrix[i][j] ≤ 10.
        /// 
        /// [output] integer
        /// 
        /// The total price of all the rooms that are suitable for the CodeBots to live in.
        /// </remarks>
        public static int matrixElementsSum(int[][] matrix)
        {
            int sum = 0;
            int colSize = matrix[0].Length;
            int rowSize = matrix.Length;

            for (int col = 0; col < colSize; col++)
            {
                for (int row = 0; row < rowSize; row++)
                {
                    //check for ghost 
                    int element = matrix[row][col];

                    if (element == 0)
                        break;
                    else
                        sum += element;
                }
            }

            return (sum);
        }


    }
}
