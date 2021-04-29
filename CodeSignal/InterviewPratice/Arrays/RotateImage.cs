using System;
namespace CodeSignal.InterviewPratice.Arrays
{
    public class RotateImage
    {

        /// <summary>
        /// question 3
        /// </summary>
        /// <remarks>
        /// Note: Try to solve this task in-place (with O(1) additional memory), since this is what you'll be asked to do during an interview.
        /// You are given an n x n 2D matrix that represents an image.Rotate the image by 90 degrees(clockwise).
        /// Example
        /// For
        /// a = [[1, 2, 3],
        /// [4, 5, 6],
        /// [7, 8, 9]]
        /// the output should be
        /// rotateImage(a) =
        /// [[7, 4, 1],
        /// [8, 5, 2],
        /// [9, 6, 3]]
        /// Input/Output
        /// [execution time limit] 3 seconds(cs)
        /// [input]
        /// array.array.integer a
        /// Guaranteed constraints:
        /// 1 ≤ a.length ≤ 100,
        /// a[i].length = a.length,
        /// 1 ≤ a[i][j] ≤ 104.
        /// [output] array.array.integer
        /// </remarks>
        public static int[][] Solve(int[][] a)
        {
            // Traverse each cycle
            for (int i = 0; i < a.Length / 2; i++)
            {
                for (int j = i; j < a.Length - i - 1; j++)
                {

                    // Swap elements of each cycle
                    // in clockwise direction
                    int temp = a[i][j];
                    a[i][j] = a[a.Length - 1 - j][i];
                    a[a.Length - 1 - j][i] = a[a.Length - 1 - i][a.Length - 1 - j];
                    a[a.Length - 1 - i][a.Length - 1 - j] = a[j][a.Length - 1 - i];
                    a[j][a.Length - 1 - i] = temp;
                }
            }

            return a;
        }

    }
}
