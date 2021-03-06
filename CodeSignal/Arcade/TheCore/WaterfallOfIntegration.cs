using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeSignal.Arcade.TheCore
{
    public class WaterfallOfIntegration
    {
        /// <remarks>
        /// Sudoku is a number-placement puzzle. The objective is to fill a 9 × 9 grid with digits so that each column, each row, and each of the nine 3 × 3 sub-grids that compose the grid contains all of the digits from 1 to 9.
        /// 
        /// This algorithm should check if the given grid of numbers represents a correct solution to Sudoku.
        /// 
        /// Example
        /// 
        /// For
        /// grid = [[1, 3, 2, 5, 4, 6, 9, 8, 7],
        /// [4, 6, 5, 8, 7, 9, 3, 2, 1],
        /// [7, 9, 8, 2, 1, 3, 6, 5, 4],
        /// [9, 2, 1, 4, 3, 5, 8, 7, 6],
        /// [3, 5, 4, 7, 6, 8, 2, 1, 9],
        /// [6, 8, 7, 1, 9, 2, 5, 4, 3],
        /// [5, 7, 6, 9, 8, 1, 4, 3, 2],
        /// [2, 4, 3, 6, 5, 7, 1, 9, 8],
        /// [8, 1, 9, 3, 2, 4, 7, 6, 5]]
        /// the output should be
        /// sudoku(grid) = true;
        /// 
        /// For
        /// grid = [[1, 3, 2, 5, 4, 6, 9, 2, 7],
        /// [4, 6, 5, 8, 7, 9, 3, 8, 1],
        /// [7, 9, 8, 2, 1, 3, 6, 5, 4],
        /// [9, 2, 1, 4, 3, 5, 8, 7, 6],
        /// [3, 5, 4, 7, 6, 8, 2, 1, 9],
        /// [6, 8, 7, 1, 9, 2, 5, 4, 3],
        /// [5, 7, 6, 9, 8, 1, 4, 3, 2],
        /// [2, 4, 3, 6, 5, 7, 1, 9, 8],
        /// [8, 1, 9, 3, 2, 4, 7, 6, 5]]
        /// the output should be
        /// sudoku(grid) = false.
        /// 
        /// The output should be false: each of the nine 3 × 3 sub-grids should contain all of the digits from 1 to 9.
        /// These examples are represented on the image below.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] array.array.integer grid
        /// 
        /// A matrix representing 9 × 9 grid already filled with numbers from 1 to 9.
        /// 
        /// Guaranteed constraints:
        /// grid.length = 9,
        /// grid[i].length = 9,
        /// 1 ≤ grid[i][j] ≤ 9.
        /// 
        /// [output] boolean
        /// 
        /// true if the given grid represents a correct solution to Sudoku, false otherwise.
        /// </remarks>
        public static bool Sudoku(int[][] grid)
        {
            HashSet<int> set = new HashSet<int>();

            //check rows
            for (int i = 0; i < 9; i++)
            {
                set = new HashSet<int>();

                for (int j = 0; j < 9; j++)
                {
                    if (set.Contains(grid[i][j]))
                        return (false);
                    else
                        set.Add(grid[i][j]);
                }
            }

            //check columns
            for (int j = 0; j < 9; j++)
            {
                set = new HashSet<int>();

                for (int i = 0; i < 9; i++)
                {
                    if (set.Contains(grid[i][j]))
                        return (false);
                    else
                        set.Add(grid[i][j]);
                }
            }

            //check squares
            for (int i = 0; i < 9; i += 3)
            {
                for (int j = 0; j < 9; j += 3)
                {
                    set = new HashSet<int>();

                    for (int k = i; k < i + 3; k++)
                    {
                        for (int l = j; l < j + 3; l++)
                        {
                            if (set.Contains(grid[k][l]))
                                return (false);

                            else
                                set.Add(grid[k][l]);
                        }
                    }

                }
            }


            return (true);
        }


        /// <remarks>
        /// In the popular Minesweeper game you have a board with some mines and those cells that don't contain a mine have a number in it that indicates the total number of mines in the neighboring cells. Starting off with some arrangement of mines we want to create a Minesweeper game setup.
        /// 
        /// Example
        /// 
        /// For
        /// 
        /// matrix = [[true, false, false],
        ///           [false, true, false],
        ///           [false, false, false]]
        /// the output should be
        /// 
        /// minesweeper(matrix) = [[1, 2, 1],
        ///                        [2, 1, 1],
        ///                        [1, 1, 1]]
        /// Check out the image below for better understanding:
        /// 
        /// 
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// array.array.boolean matrix
        /// 
        /// A non-empty rectangular matrix consisting of boolean values - true if the corresponding cell contains a mine, false otherwise.
        /// 
        /// Guaranteed constraints:
        /// 2 ≤ matrix.length ≤ 100,
        /// 2 ≤ matrix[0].length ≤ 100.
        /// 
        /// [output]
        /// array.array.integer
        /// 
        /// Rectangular matrix of the same size as matrix each cell of which contains an integer equal to the number of mines in the neighboring cells.Two cells are called neighboring if they share at least one corner.
        /// </remarks>
        public static int[][] Minesweeper(bool[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            int[][] result = new int[rows][];
            int[] dx = { -1, 0, 1, -1, 1, -1, 0, 1 };
            int[] dy = { -1, -1, -1, 0, 0, 1, 1, 1 };

            for (int i = 0; i < rows; i++)
                result[i] = new int[cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i][j] = 0;

                    for (int k = 0; k < dx.Length; k++)
                    {
                        int neighboorX = i + dx[k];
                        int neighboorY = j + dy[k];

                        if (neighboorX >= 0 && neighboorY >= 0 &&
                            neighboorX < rows && neighboorY < cols &&
                            matrix[neighboorX][neighboorY])
                            result[i][j]++;
                    }
                }
            }

            return (result);
        }

        /// <remarks>
        /// Last night you partied a little too hard. Now there's a black and white photo of you that's about to go viral! You can't let this ruin your reputation, so you want to apply the box blur algorithm to the photo to hide its content.
        /// 
        /// The pixels in the input image are represented as integers.The algorithm distorts the input image in the following way: Every pixel x in the output image has a value equal to the average value of the pixel values from the 3 × 3 square that has its center at x, including x itself.All the pixels on the border of x are then removed.
        /// 
        /// Return the blurred image as an integer, with the fractions rounded down.
        /// 
        /// Example
        /// 
        /// 
        /// For
        /// 
        /// image = [[1, 1, 1],
        ///          [1, 7, 1],
        ///          [1, 1, 1]]
        /// the output should be boxBlur(image) = [[1]].
        /// 
        /// To get the value of the middle pixel in the input 3 × 3 square: (1 + 1 + 1 + 1 + 7 + 1 + 1 + 1 + 1) = 15 / 9 = 1.66666 = 1. The border pixels are cropped from the final result.
        /// 
        /// For
        /// 
        /// image = [[7, 4, 0, 1],
        ///          [5, 6, 2, 2],
        ///          [6, 10, 7, 8],
        ///          [1, 4, 2, 0]]
        /// the output should be
        /// 
        /// boxBlur(image) = [[5, 4], 
        ///                   [4, 4]]
        /// There are four 3 × 3 squares in the input image, so there should be four integers in the blurred output.To get the first value: (7 + 4 + 0 + 5 + 6 + 2 + 6 + 10 + 7) = 47 / 9 = 5.2222 = 5. The other three integers are obtained the same way, then the surrounding integers are cropped from the final result.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (java)
        /// 
        /// [input] array.array.integer image
        /// 
        /// 
        /// An image, stored as a rectangular matrix of non-negative integers.
        /// 
        /// 
        /// Guaranteed constraints:
        /// 3 ≤ image.length ≤ 100,
        /// 3 ≤ image[0].length ≤ 100,
        /// 0 ≤ image[i][j] ≤ 255.
        /// 
        /// 
        /// [output] array.array.integer
        /// 
        /// A blurred image represented as integers, obtained through the process in the description.
        /// </remarks>
        public static int[][] BoxBlur(int[][] image)
        {
            int rows = image.Length;
            int columns = image[0].Length;
            int[][] blur = new int[rows - 2][];

            for (int i = 0; i < rows - 2; i++)
                blur[i] = new int[columns - 2];

            for (int i = 0; i < rows - 2; i++)
            {
                for (int j = 0; j < columns - 2; j++)
                {
                    blur[i][j] = Avg(image, i, j);
                }
            }

            return (blur);
        }

        /// <summary>
        /// helper for boxblur
        /// </summary>        
        public static int Avg(int[][] box, int r, int c)
        {
            int sum = 0;

            for (int i = r; i < r + 3; i++)
            {
                for (int j = c; j < c + 3; j++)
                    sum += box[i][j];
            }

            return (sum / 9);
        }


        /// <remarks>
        /// 
        /// </remarks>
        public static int[][] ContoursShifting(int[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            int layers = (Math.Min(rows, cols) + 1) / 2;

            Console.WriteLine($"layers = {layers}");

            for (int l = 0; l < layers; l++)
            {
                int temp = matrix[l][l];
                int r = rows - 1 - l;
                int c = cols - 1 - l;

                Console.WriteLine($"l = {l}, r = {r}, c = {c}");

                //1 x n
                if (r == 0)
                {
                    temp = matrix[r][c];
                    //top row
                    for (int j = l; j < c; j++)
                        matrix[l][cols - 1 - j] = matrix[l][cols - 2 - j];

                    matrix[l][l] = temp;
                }
                else if (c == 0)
                {
                    temp = matrix[r][c];
                    //left column
                    for (int i = l; i < r; i++)
                        matrix[rows - 1 - i][l] = matrix[rows - 2 - i][l];

                    matrix[l][l] = temp;
                }
                else if (l % 2 == 0)
                {
                    //left column
                    for (int i = l; i < r; i++)
                        matrix[i][l] = matrix[i + 1][l];

                    //bottom row
                    for (int j = l; j < c; j++)
                        matrix[r][j] = matrix[r][j + 1];

                    //right column
                    for (int i = l; i < r; i++)
                        matrix[rows - 1 - i][c] = matrix[rows - 2 - i][c];

                    //top row
                    for (int j = l; j < c; j++)
                        matrix[l][cols - 1 - j] = matrix[l][cols - 2 - j];

                    matrix[l][l + 1] = temp;
                }
                else
                {
                    if (r == 1)
                    {
                        //top row
                        for (int j = l; j < c; j++)
                            matrix[l][j] = matrix[l][j + 1];

                        matrix[l][c] = temp;
                    }
                    else if (c == 1)
                    {
                        //left column
                        for (int i = l; i < r; i++)
                            matrix[i][l] = matrix[i + 1][l];

                        matrix[r][l] = temp;
                    }
                    else
                    {
                        //top row
                        for (int j = l; j < c; j++)
                            matrix[l][j] = matrix[l][j + 1];

                        //right column
                        for (int i = l; i < r; i++)
                            matrix[i][c] = matrix[i + 1][c];

                        //bottom row
                        for (int j = l; j < c; j++)
                            matrix[r][cols - 1 - j] = matrix[r][cols - 2 - j];

                        //left column
                        for (int i = l; i < r; i++)
                            matrix[rows - 1 - i][l] = matrix[rows - 2 - i][l];

                        matrix[l + 1][l] = temp;
                    }
                }
            }

            return (matrix);
        }


        /// <remarks>
        /// You have a rectangular white board with some black cells. The black cells create a connected black figure, i.e. it is possible to get from any black cell to any other one through connected adjacent (sharing a common side) black cells.
        /// 
        /// Find the perimeter of the black figure assuming that a single cell has unit length.
        /// 
        /// It's guaranteed that there is at least one black cell on the table.
        /// 
        /// Example
        /// 
        /// For
        /// 
        /// matrix = [[false, true,  true ],
        ///           [true,  true,  false],
        ///           [true,  false, false]]
        /// the output should be
        /// polygonPerimeter(matrix) = 12.
        /// 
        /// For
        /// 
        /// matrix = [[true, true, true],
        ///           [true, false, true],
        ///           [true, true, true]]
        /// the output should be
        /// polygonPerimeter(matrix) = 16.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         array.array.boolean matrix
        /// 
        /// A matrix of booleans representing the rectangular board where true means a black cell and false means a white one.
        /// 
        /// Guaranteed constraints:
        /// 2 ≤ matrix.length ≤ 5,
        /// 2 ≤ matrix[0].length ≤ 5.
        /// 
        /// [output] integer
        /// </remarks>
        public static int PolygonPerimeter(bool[][] matrix)
        {
            int[] dx = { 0, 1, 0, -1 };
            int[] dy = { -1, 0, 1, 0 };
            int sum = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == true)
                    {
                        Console.WriteLine($"matrix[{i}][{j}] = {matrix[i][j]}");

                        //check surrounds
                        for (int k = 0; k < dx.Length; k++)
                        {
                            int x = i + dx[k];
                            int y = j + dy[k];

                            if ((x >= matrix.Length || y >= matrix[i].Length) ||
                                (x < 0 || y < 0) ||
                                (x >= 0 && y >= 0 && x < matrix.Length && y < matrix[i].Length) && !matrix[x][y])
                                sum++;

                            Console.WriteLine($"x = {x}, y = {y}, sum = {sum}");
                        }
                    }
                }
            }

            return (sum);
        }

        /// <remarks>
        /// You are given a vertical box divided into equal columns. Someone dropped several stones from its top through the columns. Stones are falling straight down at a constant speed (equal for all stones) while possible (i.e. while they haven't reached the ground or they are not blocked by another motionless stone). Given the state of the box at some moment in time, find out which columns become motionless first.
        /// 
        ///         Example
        /// 
        ///         For
        /// 
        /// rows = ["#..##",
        ///         ".##.#",
        ///         ".#.##",
        ///         "....."]
        ///         the output should be gravitation(rows) = [1, 4].
        /// 
        /// Check out the image below for better understanding:
        /// 
        /// 
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input] array.string rows
        /// 
        /// A non-empty array of strings of equal length consisting only of #-s and .-s describing the box at a specific moment in time. Sharps represent stones, and dots represent empty cells. row[0] corresponds to the upper row. Last element of rows corresponds to the ground level.
        /// 
        /// Guaranteed constraints:
        /// 2 ≤ rows.length ≤ 100,
        /// 2 ≤ rows[i].length ≤ 100.
        /// 
        /// [output]
        ///         array.integer
        /// 
        /// A sorted array containing numbers of all columns(leftmost column's number is 0) in which movements will stop at the same second and earlier than in any other column. Assume that if there are no stones in a column then movement stops immediately, i.e. after 0 seconds.
        /// </remarks>
        public static int[] Gravitation(string[] rows)
        {
            int[] cols = new int[rows[0].Length];

            for (int j = 0; j < rows[0].Length; j++)
            {
                bool foundHash = false;
                int dots = 0;

                for (int i = 0; i < rows.Length; i++)
                {
                    if (rows[i][j] == '#' && !foundHash) foundHash = true;

                    if (foundHash && rows[i][j] == '.') dots++;
                }

                cols[j] = dots;
            }

            return cols.Select((p, index) => new { time = p, index })
                .Where(x => x.time == cols.Min())
                .Select(x => x.index)
                .ToArray();
        }

        /// <remarks>
        /// Court is in session. We got a group of witnesses who have all taken an oath to tell the truth. The prosecutor is pointing at the defendants one by one and asking each witnesses a simple question - "guilty or not?". The witnesses are allowed to respond in one of the following three ways:
        /// 
        /// I am sure he/she is guilty.
        /// I am sure he/she is innocent.
        /// I have no idea.
        /// The prosecutor has a hunch that one of the witnesses might not be telling the truth so she decides to cross-check all of their testimonies and see if the information gathered is consistent, i.e.there are no two witnesses A and B and a defendant C such that A says C is guilty while B says C is innocent.
        /// 
        /// Example
        /// 
        /// For
        /// 
        /// 
        /// evidences = [[0, 1, 0, 1],
        ///              [-1, 1, 0, 0],
        ///              [-1, 0, 0, 1]]
        /// the output should be
        /// isInformationConsistent(evidences) = true;
        /// 
        /// For
        /// 
        /// evidences = [[1, 0],
        ///              [-1, 0],
        ///              [1, 1],
        ///              [1, 1]]
        /// the output should be
        /// isInformationConsistent(evidences) = false.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         array.array.integer evidences
        /// 
        /// 2-dimensional array of integers representing the set of testimonials.evidences[i][j] is the testimonial of the ith witness on the jth defendant. -1 means "innocent", 0 means "no idea", and 1 means "guilty".
        /// 
        /// 
        /// Guaranteed constraints:
        /// 2 ≤ evidences.length ≤ 5,
        /// 2 ≤ evidences[0].length ≤ 10,
        /// evidences[i].length = evidences[j].length,
        /// -1 ≤ evidences[i][j] ≤ 1.
        /// 
        /// 
        /// [output] boolean
        /// 
        /// true if the evidence is consistent, false otherwise.
        /// </remarks>
        public static bool IsInformationConsistent(int[][] evidences)
        {
            for (int j = 0; j < evidences[0].Length; j++)
            {
                bool guilt = false;
                bool innocent = false;

                for (int i = 0; i < evidences.Length; i++)
                {
                    if (evidences[i][j] == -1)
                        innocent = true;
                    else if (evidences[i][j] == 1)
                        guilt = true;

                    if (guilt && innocent)
                        return (false);
                }
            }

            return (true);
        }

        /// <remarks>
        /// A nonogram is also known as Paint by Numbers and Japanese Crossword. The aim in this puzzle is to color the grid into black and white squares. At the top of each column, and at the side of each row, there are sets of one or more numbers which describe the runs of black squares in that row/column in exact order. For example, if you see 10 1 along some column/row, this indicates that there will be a run of exactly ten black squares, followed by one or more white squares, followed by a single black square. The cells along the edges of the grid can also be white.
        /// 
        /// You are given a square nonogram of size size.Its grid is given as a square matrix nonogramField of size(size + 1) / 2 + size, where the first(size + 1) / 2 cells of each row and and each column define the numbers for the corresponding row/column, and the rest size × size cells define the the grid itself.
        /// 
        /// Determine if the given nonogram has been solved correctly.
        /// 
        /// Note: here / means integer division.
        /// 
        /// Example
        /// 
        /// For size = 5 and
        /// 
        /// nonogramField = [["-", "-", "-", "-", "-", "-", "-", "-"],
        /// 
        ///                  ["-", "-", "-", "2", "2", "1", "-", "1"],
        /// 
        ///                  ["-", "-", "-", "2", "1", "1", "3", "3"],
        /// 
        ///                  ["-", "3", "1", "#", "#", "#", ".", "#"],
        /// 
        ///                  ["-", "-", "2", "#", "#", ".", ".", "."],
        /// 
        ///                  ["-", "-", "2", ".", ".", ".", "#", "#"],
        /// 
        ///                  ["-", "1", "2", "#", ".", ".", "#", "#"],
        /// 
        ///                  ["-", "-", "5", "#", "#", "#", "#", "#"]]
        /// the output should be correctNonogram(size, nonogramField) = true;
        /// 
        /// For size = 5 and
        /// 
        /// nonogramField = [["-", "-", "-", "-", "-", "-", "-", "-"],
        ///                  ["-", "-", "-", "-", "-", "1", "-", "-"],
        ///                  ["-", "-", "-", "3", "3", "2", "5", "5"],
        ///                  ["-", "-", "3", ".", ".", ".", "#", "#"],
        ///                  ["-", "2", "2", "#", "#", "#", "#", "#"],
        ///                  ["-", "-", "5", "#", "#", "#", "#", "#"],
        ///                  ["-", "-", "5", "#", "#", "#", "#", "#"],
        ///                  ["-", "-", "2", ".", ".", ".", "#", "#"]]
        /// the output should be correctNonogram(size, nonogramField) = false.
        /// 
        /// There are three mistakes in the nonogram:
        /// 
        /// In the 5th(1-based) row there are numbers["-", "2", "2"], so there should be two runs of 2 black squares separated by at least one white square.However, there is only one run of 5 black squares.
        /// In the 6th column there are numbers["-", "1", "2"], so there should be a run of exactly 1 black square, followed by one or more white squares, followed by another 2 black squares. However, there is a single run of 3 black squares not separated by white ones.
        /// Finally, in the 4th row there are numbers["-", "-", "3"], so there should be a single run of exactly 3 black squares. However, there is just a 2-square run in that row.
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] integer size
        /// 
        /// A positive integer, the size of the grid.
        /// 
        /// Guaranteed constraints:
        /// 5 ≤ size ≤ 10.
        /// 
        /// 
        /// [input] array.array.string nonogramField
        /// 
        /// 
        /// A square matrix of strings of size (size + 1) / 2 + size defining the puzzle field.
        /// The first(size + 1) / 2 cells of each row and each column define the numbers for this row/column.If there is no number in the cell, its value is "-".
        /// The remaining size × size cells define the grid, where string "#" denotes black cells and string "." denotes white ones.
        /// 
        /// Guaranteed constraints:
        /// 8 ≤ nonogramField.length ≤ 15,
        /// nonogramField[i].length = nonogramField.length.
        /// 
        /// [output] boolean
        /// 
        /// true if the given nonogram is solved correctly and false otherwise.
        /// </remarks>
        public static bool correctNonogram(int size, string[][] nonogramField)
        {
            int n = (size + 1) / 2;

            //check lines
            for (int i = n; i < nonogramField.Length; i++)
            {
                var runs = nonogramField[i].Take(n).Where(c => c != "-").Select(x => int.Parse(x));
                var hashes = string.Concat(nonogramField[i].Skip(n)).Split(".").Select(x => x.Length).Where(x => x != 0);

                if (!runs.SequenceEqual(hashes))
                    return (false);
            }

            //check columns
            for (int j = n; j < nonogramField[0].Length; j++)
            {
                var col = nonogramField.Select(r => r[j]);
                var runs = col.Take(n).Where(c => c != "-").Select(x => int.Parse(x));
                var hashes = string.Concat(col.Skip(n)).Split(".").Select(x => x.Length).Where(x => x != 0);

                if (!runs.SequenceEqual(hashes))
                    return (false);
            }


            return (true);
        }
    }
}
