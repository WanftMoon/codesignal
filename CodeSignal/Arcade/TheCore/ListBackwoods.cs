using System;
namespace CodeSignal.Arcade.TheCore
{
    public class ListBackwoods
    {
        /// <remarks>
        /// Given a rectangular matrix and an integer column, return an array containing the elements of the columnth column of the given matrix (the leftmost column is the 0th one).
        /// 
        /// Example
        /// 
        /// For
        /// 
        /// matrix = [[1, 1, 1, 2], 
        ///           [0, 5, 0, 4], 
        ///           [2, 1, 3, 6]]
        /// and column = 2, the output should be
        /// extractMatrixColumn(matrix, column) = [1, 0, 3].
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         array.array.integer matrix
        /// 
        /// 2-dimensional array of integers representing a rectangular matrix.
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ matrix.length ≤ 500,
        /// 1 ≤ matrix[i].length ≤ 500,
        /// 0 ≤ matrix[i][j] ≤ 105.
        /// 
        /// [input] integer column
        /// 
        /// An integer not greater than the number of matrix columns.
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ column ≤ matrix[i].length - 1.
        /// 
        /// [output] array.integer
        ///
        /// matrix.Select(row => row[column]).ToArray()
        /// </remarks>
        public static int[] ExtractMatrixColumn(int[][] matrix, int column)
        {
            int[] col = new int[matrix.Length];

            for (int i = 0; i < matrix.Length; i++)
                col[i] = matrix[i][column];

            return (col);
        }

        /// <remarks>
        /// Two two-dimensional arrays are isomorphic if they have the same number of rows and each pair of respective rows contains the same number of elements.
        /// 
        /// Given two two-dimensional arrays, check if they are isomorphic.
        /// 
        /// Example
        /// 
        /// For
        /// 
        /// array1 = [[1, 1, 1],
        ///           [0, 0]]
        /// and
        /// 
        /// array2 = [[2, 1, 1],
        ///           [2, 1]]
        /// the output should be
        /// areIsomorphic(array1, array2) = true;
        /// 
        /// For
        /// 
        /// array1 = [[2],
        ///           []]
        /// and
        /// 
        /// array2 = [[2]]
        /// the output should be
        /// areIsomorphic(array1, array2) = false.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         array.array.integer array1
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ array1.length ≤ 5,
        /// 0 ≤ array1[i].length ≤ 5,
        /// 0 ≤ array1[i][j] ≤ 50.
        /// 
        /// [input]
        ///         array.array.integer array2
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ array2.length ≤ 5,
        /// 0 ≤ array2[i].length ≤ 5,
        /// 0 ≤ array2[i][j] ≤ 50.
        /// 
        /// [output] boolean
        /// </remarks>
        public static bool AreIsomorphic(int[][] array1, int[][] array2)
        {
            bool isIso = true;

            if (array1.Length != array2.Length)
                return (false);

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i].Length != array2[i].Length)
                {
                    isIso = false;
                    break;
                }
            }

            return (isIso);
        }


        /// <remarks>
        /// The longest diagonals of a square matrix are defined as follows:
        /// 
        /// the first longest diagonal goes from the top left corner to the bottom right one;
        /// the second longest diagonal goes from the top right corner to the bottom left one.
        /// Given a square matrix, your task is to reverse the order of elements on both of its longest diagonals.
        /// 
        /// Example
        /// 
        /// For
        /// 
        /// matrix = [[1, 2, 3],
        ///           [4, 5, 6],
        ///           [7, 8, 9]]
        /// the output should be
        /// 
        /// reverseOnDiagonals(matrix) = [[9, 2, 7],
        ///                               [4, 5, 6],
        ///                               [3, 8, 1]]
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// array.array.integer matrix
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ matrix.length ≤ 100,
        /// matrix.length = matrix[i].length,
        /// 1 ≤ matrix[i][j] ≤ 105.
        /// 
        /// [output]
        ///         array.array.integer
        /// 
        /// Matrix with the order of elements on its longest diagonals reversed.
        /// </remarks>
        public static int[][] ReverseOnDiagonals(int[][] matrix)
        {
            int size = matrix.Length;

            for (int i = 0, j = 0; i < size / 2; i++, j++)
            {
                //swap first diag
                int a = matrix[i][j];

                matrix[i][j] = matrix[size - i - 1][size - j - 1];
                matrix[size - i - 1][size - j - 1] = a;

                //swap sec diag
                a = matrix[i][size - i - 1];
                matrix[i][size - i - 1] = matrix[size - i - 1][j];
                matrix[size - i - 1][j] = a;
            }

            return (matrix);
        }


        /// <remarks>
        /// The longest diagonals of a square matrix are defined as follows:
        /// 
        /// the first longest diagonal goes from the top left corner to the bottom right one;
        /// the second longest diagonal goes from the top right corner to the bottom left one.
        /// Given a square matrix, your task is to swap its longest diagonals by exchanging their elements at the corresponding positions.
        /// 
        /// Example
        /// 
        /// For
        /// 
        /// matrix = [[1, 2, 3],
        ///           [4, 5, 6],
        ///           [7, 8, 9]]
        /// the output should be
        /// 
        /// swapDiagonals(matrix) = [[3, 2, 1],
        ///                          [4, 5, 6],
        ///                          [9, 8, 7]]
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         array.array.integer matrix
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ matrix.length ≤ 100,
        /// matrix.length = matrix[i].length,
        /// 1 ≤ matrix[i][j] ≤ 105.
        /// 
        /// [output]
        ///         array.array.integer
        /// 
        /// Matrix with swapped diagonals.
        /// </remarks>
        public static int[][] SwapDiagonals(int[][] matrix)
        {
            int size = matrix.Length;

            for (int i = 0, j = 0; i < size; i++, j++)
            {
                int a = matrix[i][j];

                matrix[i][j] = matrix[i][size - i - 1];
                matrix[i][size - i - 1] = a;
            }

            return (matrix);
        }

        /// <remarks>
        /// Given a rectangular matrix and integers a and b, consider the union of the ath row and the bth (both 0-based) column of the matrix (i.e. all cells that belong either to the ath row or to the bth column, or to both). Return sum of all elements of that union.
        /// 
        /// Example
        /// 
        /// For
        /// 
        /// matrix = [[1, 1, 1, 1], 
        ///           [2, 2, 2, 2], 
        ///           [3, 3, 3, 3]]
        /// a = 1, and b = 3, the output should be
        /// crossingSum(matrix, a, b) = 12.
        /// 
        /// Here(2 + 2 + 2 + 2) + (1 + 3) = 12.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         array.array.integer matrix
        /// 
        /// 2-dimensional array of integers representing a rectangular matrix.
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ matrix.length ≤ 500,
        /// 1 ≤ matrix[0].length ≤ 500,
        /// 1 ≤ matrix[i][j] ≤ 105.
        /// 
        /// [input] integer a
        /// 
        /// A non-negative integer less than the number of matrix rows.
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ a<matrix.length.
        /// 
        /// [input] integer b
        /// 
        /// A non-negative integer less than the number of matrix columns.
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ b<matrix[i].length.
        /// 
        /// [output] integer
        /// </remarks>
        public static int CrossingSum(int[][] matrix, int a, int b)
        {
            int sum = 0;

            //column
            for (int i = 0; i < matrix.Length; i++)
                sum += matrix[i][b];

            //row
            for (int j = 0; j < matrix[a].Length; j++)
                sum += j != b ? matrix[a][j] : 0;

            return (sum);
        }

        /// <remarks>
        /// You are implementing a command-line version of the Paint app. Since the command line doesn't support colors, you are using different characters to represent pixels. Your current goal is to support rectangle x1 y1 x2 y2 operation, which draws a rectangle that has an upper left corner at (x1, y1) and a lower right corner at (x2, y2). Here the x-axis points from left to right, and the y-axis points from top to bottom.
        /// 
        /// Given the initial canvas state and the array that represents the coordinates of the two corners, return the canvas state after the operation is applied.For the details about how rectangles are painted, see the example.
        /// 
        /// Example
        /// 
        /// 
        /// For
        /// 
        /// canvas = [['a', 'a', 'a', 'a', 'a', 'a', 'a', 'a'],
        ///           ['a', 'a', 'a', 'a', 'a', 'a', 'a', 'a'],
        ///           ['a', 'a', 'a', 'a', 'a', 'a', 'a', 'a'],
        ///           ['b', 'b', 'b', 'b', 'b', 'b', 'b', 'b'],
        ///           ['b', 'b', 'b', 'b', 'b', 'b', 'b', 'b']]
        /// and rectangle = [1, 1, 4, 3], the output should be
        /// 
        /// drawRectangle(canvas, rectangle) = [['a', 'a', 'a', 'a', 'a', 'a', 'a', 'a'],
        ///                   					['a', '*', '-', '-', '*', 'a', 'a', 'a'],
        ///                   					['a', '|', 'a', 'a', '|', 'a', 'a', 'a'],
        ///                   					['b', '*', '-', '-', '*', 'b', 'b', 'b'],
        ///                   					['b', 'b', 'b', 'b', 'b', 'b', 'b', 'b']]
        /// Here is the rectangle, colored for illustration:
        /// 
        /// 
        /// [['a', 'a', 'a', 'a', 'a', 'a', 'a', 'a'],
        /// ['a', '*', '-', '-', '*', 'a', 'a', 'a'],
        /// ['a', '|', 'a', 'a', '|', 'a', 'a', 'a'],
        /// ['b', '*', '-', '-', '*', 'b', 'b', 'b'],
        /// ['b', 'b', 'b', 'b', 'b', 'b', 'b', 'b']]
        /// Note that rectangle sides are depicted as -s and |s, asterisks(*) stand for its corners and all of the other "pixels" remain the same.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input] array.array.char canvas
        /// 
        /// A non-empty rectangular matrix of characters.
        /// 
        /// Guaranteed constraints:
        /// 2 ≤ canvas.length ≤ 10,
        /// 2 ≤ canvas[0].length ≤ 10.
        /// 
        /// [input]
        ///         array.integer rectangle
        /// 
        /// Array of four integers - [x1, y1, x2, y2].
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ x1<x2<canvas[i].length,
        /// 0 ≤ y1<y2<canvas.length.
        /// 
        /// [output] array.array.char
        /// </remarks>
        public static char[][] DrawRectangle(char[][] canvas, int[] rectangle)
        {
            int x1 = rectangle[0], y1 = rectangle[1];
            int x2 = rectangle[2], y2 = rectangle[3];
            int dx = x2 - x1;
            int dy = y2 - y1;

            //draw columns
            for (int i = y1; i < y1 + dy; i++)
            {
                canvas[i][x1] = '|';
                canvas[i][x2] = '|';
            }

            //lines
            for (int j = x1; j < x1 + dx; j++)
            {
                canvas[y1][j] = '-';
                canvas[y2][j] = '-';
            }

            canvas[y1][x1] = '*';
            canvas[y2][x2] = '*';
            canvas[y1][x2] = '*';
            canvas[y2][x1] = '*';

            return (canvas);
        }


        /// <remarks>
        /// You are watching a volleyball tournament, but you missed the beginning of the very first game of your favorite team. Now you're curious about how the coach arranged the players on the field at the start of the game.
        /// 
        /// The team you favor plays in the following formation:
        /// 
        /// 0 3 0
        /// 4 0 2
        /// 0 6 0
        /// 5 0 1
        /// where positive numbers represent positions occupied by players.After the team gains the serve, its members rotate one position in a clockwise direction, so the player in position 2 moves to position 1, the player in position 3 moves to position 2, and so on, with the player in position 1 moving to position 6.
        /// 
        /// Here's how the players change their positions:
        /// 
        /// Given the current formation of the team and the number of times k it gained the serve, find the initial position of each player in it.
        /// 
        /// Example
        /// 
        /// For
        /// 
        /// formation = [["empty", "Player5", "empty"],
        ///              ["Player4", "empty",   "Player2"],
        ///              ["empty",   "Player3", "empty"],
        ///              ["Player6", "empty",   "Player1"]]
        /// and k = 2, the output should be
        /// 
        /// volleyballPositions(formation, k) = [
        ///     ["empty",   "Player1", "empty"],
        ///     ["Player2", "empty",   "Player3"],
        ///     ["empty",   "Player4", "empty"],
        ///     ["Player5", "empty",   "Player6"]
        /// ]
        /// For
        /// 
        /// formation = [["empty", "Alice", "empty"],
        ///              ["Bob", "empty", "Charlie"],
        ///              ["empty", "Dave", "empty"],
        ///              ["Eve", "empty", "Frank"]]
        /// and k = 6, the output should be
        /// 
        /// volleyballPositions(formation, k) = [
        ///     ["empty", "Alice", "empty"],
        ///     ["Bob",   "empty", "Charlie"],
        ///     ["empty", "Dave",  "empty"],
        ///     ["Eve",   "empty", "Frank"]
        /// ]
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input] array.array.string formation
        /// 
        /// Array of strings representing names of the players in the positions corresponding to those in the schema above.
        /// It is guaranteed that for each empty position the corresponding element of formation is "empty".
        /// It is also guaranteed that there is no player called "empty" in the team.
        /// 
        /// Guaranteed constraints:
        /// formation.length = 4,
        /// formation[i].length = 3.
        /// 
        /// [input] integer k
        /// 
        /// The number of times the team gained the serve.
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ k ≤ 109.
        /// 
        /// [output] array.array.string
        /// 
        /// Team arrangement at the start of the game.
        /// </remarks>
        public static string[][] VolleyballPositions(string[][] formation, int k)
        {
            for (int i = 0; i < k % 6; i++)
            {
                string temp = formation[0][1];

                formation[0][1] = formation[1][2];
                formation[1][2] = formation[3][2];
                formation[3][2] = formation[2][1];
                formation[2][1] = formation[3][0];
                formation[3][0] = formation[1][0];
                formation[1][0] = temp;
            }

            return (formation);
        }

        /// <remarks>
        /// Consider a (2k+1) × (2k+1) square subarray of an integer integers matrix. Let's call the union of the square's two longest diagonals, middle column and middle row a star. Given the coordinates of the star's center in the matrix and its width, rotate it 45 · t degrees clockwise preserving position of all matrix elements that do not belong to the star.
        /// 
        ///         Example
        /// 
        ///         For
        /// 
        /// matrix = [[1, 0, 0, 2, 0, 0, 3],
        ///           [0, 1, 0, 2, 0, 3, 0],
        ///           [0, 0, 1, 2, 3, 0, 0],
        ///           [8, 8, 8, 9, 4, 4, 4],
        ///           [0, 0, 7, 6, 5, 0, 0],
        ///           [0, 7, 0, 6, 0, 5, 0],
        ///           [7, 0, 0, 6, 0, 0, 5]]
        /// width = 7, center = [3, 3], and t = 1, the output should be
        /// 
        /// starRotation(matrix, width, center, t) = [[8, 0, 0, 1, 0, 0, 2],
        ///                                           [0, 8, 0, 1, 0, 2, 0],
        ///                                           [0, 0, 8, 1, 2, 0, 0],
        ///                                           [7, 7, 7, 9, 3, 3, 3],
        ///                                           [0, 0, 6, 5, 4, 0, 0],
        ///                                           [0, 6, 0, 5, 0, 4, 0],
        ///                                           [6, 0, 0, 5, 0, 0, 4]]
        /// For
        /// 
        /// matrix = [[1, 0, 0, 2, 0, 0, 3],
        ///           [0, 1, 0, 2, 0, 3, 0],
        ///           [0, 0, 1, 2, 3, 0, 0],
        ///           [8, 8, 8, 9, 4, 4, 4],
        ///           [0, 0, 7, 6, 5, 0, 0]]
        /// width = 3, center = [1, 5], and t = 81, the output should be
        /// 
        /// starRotation(matrix, width, center, t) = [[1, 0, 0, 2, 0, 0, 0],
        ///                                           [0, 1, 0, 2, 3, 3, 3],
        ///                                           [0, 0, 1, 2, 0, 0, 0],
        ///                                           [8, 8, 8, 9, 4, 4, 4],
        ///                                           [0, 0, 7, 6, 5, 0, 0]]
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         array.array.integer matrix
        /// 
        /// A two-dimensional array of integers.
        /// 
        /// Guaranteed constraints:
        /// 3 ≤ matrix.length ≤ 15,
        /// 3 ≤ matrix[i].length ≤ 15,
        /// matrix[i].length == matrix[j].length,
        /// 0 ≤ matrix[i][j] ≤ 99.
        /// 
        /// [input] integer width
        /// 
        /// An odd integer representing the star's width. It equals the length of the sides of the bounding square for the star.
        /// 
        /// Guaranteed constraints:
        /// 3 ≤ width ≤ min(matrix.length, matrix[i].length).
        /// 
        /// [input]
        ///         array.integer center
        /// 
        /// An array of two integers.
        /// 
        /// Guaranteed constraints:
        /// center.length = 2,
        /// (width - 1) / 2 ≤ center[0] < matrix.length - (width - 1) / 2,
        /// (width - 1) / 2 ≤ center[1] < matrix[i].length - (width - 1) / 2.
        /// 
        /// [input]
        ///         integer t
        /// 
        /// A non-negative integer denoting how many times the star should be rotated by 45 degrees.
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ t ≤ 109.
        /// 
        /// [output]
        ///         array.array.integer
        /// 
        /// An array with specified star rotated by 45 · t degrees.
        /// </remarks>
        public static int[][] StarRotation(int[][] matrix, int width, int[] center, int t)
        {
            int rowCenter = center[0];
            int colCenter = center[1];

            width /= 2;

            for (int j = 0; j < t % 8; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    int temp = matrix[rowCenter - width + i][colCenter - width + i];

                    matrix[rowCenter - width + i][colCenter - width + i] = matrix[rowCenter][colCenter - width + i];
                    matrix[rowCenter][colCenter - width + i] = matrix[rowCenter + width - i][colCenter - width + i];
                    matrix[rowCenter + width - i][colCenter - width + i] = matrix[rowCenter + width - i][colCenter];
                    matrix[rowCenter + width - i][colCenter] = matrix[rowCenter + width - i][colCenter + width - i];
                    matrix[rowCenter + width - i][colCenter + width - i] = matrix[rowCenter][colCenter + width - i];
                    matrix[rowCenter][colCenter + width - i] = matrix[rowCenter - width + i][colCenter + width - i];
                    matrix[rowCenter - width + i][colCenter + width - i] = matrix[rowCenter - width + i][colCenter];
                    matrix[rowCenter - width + i][colCenter] = temp;
                }
            }

            return matrix;
        }
    }
}
