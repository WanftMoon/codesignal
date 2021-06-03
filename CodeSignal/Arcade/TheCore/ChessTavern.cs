using System;
using System.Linq;

namespace CodeSignal.Arcade.TheCore
{
    public class ChessTavern
    {
        /// <remarks>
        /// Given the positions of a white bishop and a black pawn on the standard chess board, determine whether the bishop can capture the pawn in one move.
        /// 
        /// The bishop has no restrictions in distance for each move, but is limited to diagonal movement.Check out the example below to see how it can move:
        /// 
        /// 
        /// 
        /// Example
        /// 
        /// For bishop = "a1" and pawn = "c3", the output should be
        /// bishopAndPawn(bishop, pawn) = true.
        /// 
        /// 
        /// 
        /// 
        /// For bishop = "h1" and pawn = "h3", the output should be
        /// bishopAndPawn(bishop, pawn) = false.
        /// 
        /// 
        /// 
        /// Input / Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] string bishop
        /// 
        /// 
        /// Coordinates of the white bishop in the chess notation.
        /// 
        /// Guaranteed constraints:
        /// bishop.length = 2,
        /// 'a' ≤ bishop[0] ≤ 'h',
        /// 1 ≤ bishop[1] ≤ 8.
        /// 
        /// 
        /// [input] string pawn
        /// 
        /// 
        /// Coordinates of the black pawn in the same notation.
        /// 
        /// Guaranteed constraints:
        /// pawn.length = 2,
        /// 'a' ≤ pawn[0] ≤ 'h',
        /// 1 ≤ pawn[1] ≤ 8.
        /// 
        /// 
        /// [output] boolean
        /// 
        /// true if the bishop can capture the pawn, false otherwise.
        /// </remarks>
        public static bool BishopAndPawn(string bishop, string pawn)
        {
            return Math.Abs(bishop[0] - pawn[0]) == Math.Abs(bishop[1] - pawn[1]);
        }


        /// <remarks>
        /// Given a position of a knight on the standard chessboard, find the number of different moves the knight can perform.
        /// 
        /// The knight can move to a square that is two squares horizontally and one square vertically, or two squares vertically and one square horizontally away from it.The complete move therefore looks like the letter L.Check out the image below to see all valid moves for a knight piece that is placed on one of the central squares.
        /// 
        /// 
        /// 
        /// Example
        /// 
        /// For cell = "a1", the output should be
        /// chessKnight(cell) = 2.
        /// 
        /// For cell = "c2", the output should be
        /// chessKnight(cell) = 6.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// string cell
        /// 
        /// String consisting of 2 letters - coordinates of the knight on an 8 × 8 chessboard in chess notation.
        /// 
        /// Guaranteed constraints:
        /// cell.length = 2,
        /// 'a' ≤ cell[0] ≤ 'h',
        /// 1 ≤ cell[1] ≤ 8.
        /// 
        /// [output] integer
        ///
        /// var results = new int[]{2, 3, 4, 6, 8};
        /// int dist1 = Math.Min(Math.Min(cell[0] - 'a', 'h' - cell[0]), 2);
        /// int dist2 = Math.Min(Math.Min(cell[1] - '1', '8' - cell[1]), 2);
        /// return results[dist1 + dist2];
        /// </remarks>
        public static int ChessKnight(string cell)
        {
            int[][] moves = {
                new int[] { -2, -1},
                new int[] { -2, 1 },
                new int[] { -1, 2 },
                new int[] { -1, -2 },
                new int[] { 1, 2 },
                new int[] { 1, -2 },
                new int[] { 2, 1 },
                new int[] { 2, -1 } };
            int count = 0;


            foreach (var mov in moves)
            {
                var dx = cell[0] + mov[0];
                var dy = cell[1] + mov[1];

                if ((dx >= 'a' && dx <= 'h') && (dy >= '1' && dy <= '8'))
                    count++;
            }

            return (count);
        }

        /// <remarks>
        /// In the Land Of Chess, bishops don't really like each other. In fact, when two bishops happen to stand on the same diagonal, they immediately rush towards the opposite ends of that same diagonal.
        /// 
        ///  Given the initial positions(in chess notation) of two bishops, bishop1 and bishop2, calculate their future positions.Keep in mind that bishops won't move unless they see each other along the same diagonal.
        /// 
        /// 
        /// Example
        /// 
        /// For bishop1 = "d7" and bishop2 = "f5", the output should be
        /// bishopDiagonal(bishop1, bishop2) = ["c8", "h3"].
        /// 
        /// 
        /// 
        /// 
        /// For bishop1 = "d8" and bishop2 = "b5", the output should be
        /// bishopDiagonal(bishop1, bishop2) = ["b5", "d8"].
        /// 
        /// 
        /// The bishops don't belong to the same diagonal, so they don't move.
        /// 
        /// 
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] string bishop1
        /// 
        /// 
        /// Coordinates of the first bishop in chess notation.
        /// 
        /// 
        /// Guaranteed constraints:
        /// bishop1.length = 2,
        /// 'a' ≤ bishop1[0] ≤ 'h',
        /// 1 ≤ bishop1[1] ≤ 8.
        /// 
        /// 
        /// [input] string bishop2
        /// 
        /// 
        /// Coordinates of the second bishop in the same notation.
        /// 
        /// Guaranteed constraints:
        /// bishop2.length = 2,
        /// 'a' ≤ bishop2[0] ≤ 'h',
        /// 1 ≤ bishop2[1] ≤ 8.
        /// 
        /// 
        /// [output] array.string
        /// 
        /// Coordinates of the bishops in lexicographical order after they check the diagonals they stand on.
        /// </remarks>
        public static string[] bishopDiagonal(string bishop1, string bishop2)
        {
            if (Math.Abs(bishop1[0] - bishop2[0]) == Math.Abs(bishop1[1] - bishop2[1]))
            {
                int dx = bishop1[0] < bishop2[0] ? -1 : 1;
                int dy = bishop1[1] < bishop2[1] ? -1 : 1;
                //bishop 1
                while (true)
                {
                    int x = bishop1[0] + dx;
                    int y = bishop1[1] + dy;

                    if (x < 'a' || x > 'h' || y < '1' || y > '8')
                        break;

                    bishop1 = $"{(char)x}{(char)y}";
                }
                //invert for bishop 2
                dx *= -1;
                dy *= -1;

                while (true)
                {
                    int x = bishop2[0] + dx;
                    int y = bishop2[1] + dy;

                    if (x < 'a' || x > 'h' || y < '1' || y > '8')
                        break;

                    bishop2 = $"{(char)x}{(char)y}";
                }
            }

            return new string[] { bishop1, bishop2 }.OrderBy(x => x).ToArray();
        }

        /// <remarks>
        /// Imagine a standard chess board with only two white and two black knights placed in their standard starting positions: the white knights on b1 and g1; the black knights on b8 and g8.
        /// There are two players: one plays for white, the other for black.During each move, the player picks one of his knights and moves it to an unoccupied square according to standard chess rules.Thus, a knight on d5 can move to any of the following squares: b6, c7, e7, f6, f4, e3, c3, and b4, as long as it is not occupied by either a friendly or an enemy knight.
        /// The players take turns in making moves, starting with the white player.Given the configuration p of the knights after an unspecified number of moves, determine whose turn it is.
        /// Example
        /// 
        /// For p = "b1;g1;b8;g8", the output should be
        /// whoseTurn(p) = true.
        /// 
        /// The configuration corresponds to the initial state of the game. Thus, it's white's turn.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] string p
        /// 
        /// 
        /// The positions of the four knights, starting with white knights, separated by a semicolon, in the chess notation.
        /// 
        /// Guaranteed constraints:
        /// p.length = 11.
        /// 
        /// 
        /// [output] boolean
        /// 
        /// true if white is to move, false otherwise.
        /// </remarks>
        public static bool WhoseTurn(string p)
        {
            string ori = "b1;g1;b8;g8";
            int w = p[0] - ori[0] + p[1] - ori[1] + p[3] - ori[3] + p[4] - ori[4];
            int b = p[6] - ori[6] + p[7] - ori[7] + p[9] - ori[9] + p[10] - ori[10];

            return (w - b) % 2 == 0;
        }

        /// <remarks>
        /// In ChessLand there is a small but proud chess bishop with a recurring dream. In the dream the bishop finds itself on an n × m chessboard with mirrors along each edge, and it is not a bishop but a ray of light. This ray of light moves only along diagonals (the bishop can't imagine any other types of moves even in its dreams), it never stops, and once it reaches an edge or a corner of the chessboard it reflects from it and moves on.
        /// 
        /// Given the initial position and the direction of the ray, find its position after k steps where a step means either moving from one cell to the neighboring one or reflecting from a corner of the board.
        /// 
        /// Example
        /// 
        /// 
        /// For boardSize = [3, 7], initPosition = [1, 2],
        /// initDirection = [-1, 1], and k = 13, the output should be
        /// chessBishopDream(boardSize, initPosition, initDirection, k) = [0, 1].
        /// 
        /// Here is the bishop's path:
        /// 
        /// 
        /// [1, 2] -> [0, 3] -(reflection from the top edge)-> [0, 4] -> 
        /// [1, 5] -> [2, 6] -(reflection from the bottom right corner)-> [2, 6] ->
        /// [1, 5] -> [0, 4] -(reflection from the top edge)-> [0, 3] ->
        /// [1, 2] -> [2, 1] -(reflection from the bottom edge)-> [2, 0] -(reflection from the left edge)->
        /// [1, 0] -> [0, 1]
        /// 
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         array.integer boardSize
        /// 
        /// An array of two integers, the number of rows and columns, respectively. Rows are numbered by integers from 0 to boardSize[0] - 1, columns are numbered by integers from 0 to boardSize[1] - 1 (both inclusive).
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ boardSize[i] ≤ 20.
        /// 
        /// [input]
        ///         array.integer initPosition
        /// 
        /// An array of two integers, indices of the row and the column where the bishop initially stands, respectively.
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ initPosition[i] < boardSize[i].
        /// 
        /// [input]
        ///         array.integer initDirection
        /// 
        /// An array of two integers representing the initial direction of the bishop.If it stands in (a, b), the next cell he'll move to is (a + initDirection[0], b + initDirection[1]) or whichever it'll reflect to in case it runs into a mirror immediately.
        /// 
        /// Guaranteed constraints:
        /// initDirection[i] ∈ { -1, 1}.
        /// 
        /// [input]
        ///         integer k
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ k ≤ 109.
        /// 
        /// [output]
        ///         array.integer
        /// 
        /// The position of the bishop after k steps.
        /// </remarks>
        public static int[] ChessBishopDream(int[] boardSize, int[] initPosition, int[] initDirection, int k)
        {
            int n = boardSize[0] - 1;
            int m = boardSize[1] - 1;

            //theres a cycle for x
            for (int i = 0; i < k % (boardSize[0] * 2); i++)
            {
                int x = initPosition[0] + initDirection[0];

                if (x < 0 || x > n)
                    initDirection[0] *= -1;
                else
                    initPosition[0] = x;
            }

            //and a cycle for y
            for (int i = 0; i < k % (boardSize[1] * 2); i++)
            {
                int y = initPosition[1] + initDirection[1];

                if (y < 0 || y > m)
                    initDirection[1] *= -1;
                else
                    initPosition[1] = y;
            }


            return initPosition;
        }


        /// <remarks>
        /// Consider a bishop, a knight and a rook on an n × m chessboard. They are said to form a triangle if each piece attacks exactly one other piece and is attacked by exactly one piece. Calculate the number of ways to choose positions of the pieces to form a triangle.
        ///  Note that the bishop attacks pieces sharing the common diagonal with it; the rook attacks in horizontal and vertical directions; and, finally, the knight attacks squares which are two squares horizontally and one square vertically, or two squares vertically and one square horizontally away from its position.
        ///  Example
        /// 
        ///  For n = 2 and m = 3, the output should be
        ///  chessTriangle(n, m) = 8.
        /// 
        ///  Input / Output
        /// 
        ///  [execution time limit] 3 seconds (cs)
        /// 
        ///  [input] integer n
        /// 
        ///  Guaranteed constraints:
        /// 1 ≤ n ≤ 40.
        /// 
        /// 
        /// [input] integer m
        /// 
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ m ≤ 40,
        /// 3 ≤ n · m.
        /// 
        /// 
        /// [output] integer
        /// </remarks>
        public static int ChessTriangle(int n, int m)
        {
            int count = 0;
            int[][] triangles = {
                new int[]{2,3},
                new int[]{3,2},
                new int[]{3,3},
                new int[]{3,3},
                new int[]{2,4},
                new int[]{4,2},
                new int[]{3,4},
                new int[]{4,3}
            };

            foreach (var triangle in triangles)
            {
                if (triangle[0] <= n && triangle[1] <= m)
                    count += (n + 1 - triangle[0]) * (m + 1 - triangle[1]);
            }

            return (8 * count);
        }


    }
}
