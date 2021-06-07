using System;
using System.Collections.Generic;
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


        #region amazon checkmate

        /// <remarks>
        /// An amazon (also known as a queen + knight compound) is an imaginary chess piece that can move like a queen or a knight (or, equivalently, like a rook, bishop, or knight). The diagram below shows all squares which the amazon can attack from e4 (circles represent knight-like moves while crosses correspond to queen-like moves).
        /// 
        /// 
        /// 
        /// Recently, you've come across a diagram with only three pieces left on the board: a white amazon, the white king, and the black king. It's black's move. You don't have time to determine whether the game is over or not, but you'd like to figure it out in your head. Unfortunately, the diagram is smudged and you can't see the position of the black king, so you'll need to consider all possible positions.
        /// 
        /// Given the positions of the white pieces on a standard chessboard(using algebraic notation), your task is to determine the number of possible black king's positions such that:
        /// 
        /// it's checkmate (i.e. black's king is under the amazon's attack and it cannot make a valid move);
        /// it's check (i.e. black's king is under the amazon's attack but it can reach a safe square in one move);
        /// it's stalemate (i.e. black's king is on a safe square but it cannot make a valid move);
        /// black's king is on a safe square and it can make a valid move.
        /// Note that two kings cannot be placed on two adjacent squares(including two diagonally adjacent ones).
        /// 
        /// Example
        /// 
        /// For king = "d3" and amazon = "e4", the output should be
        /// amazonCheckmate(king, amazon) = [5, 21, 0, 29].
        /// 
        /// Red crosses correspond to the checkmate positions, orange pluses refer to check positions, and green circles denote safe squares.
        /// 
        /// For king = "a1" and amazon = "g5", the output should be
        /// amazonCheckmate(king, amazon) = [0, 29, 1, 29].
        /// 
        /// The stalemate position is marked by a blue square.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///     string king
        /// 
        /// The position of the white king, in chess notation.
        /// 
        /// Guaranteed constraints:
        /// king.length = 2,
        /// 'a' ≤ king[0] ≤ 'h',
        /// 1 ≤ king[1] ≤ 8.
        /// 
        /// [input] string amazon
        /// 
        /// The position of the white amazon, in the same notation.
        /// 
        /// Guaranteed constraints:
        /// amazon.length = 2,
        /// 'a' ≤ amazon[0] ≤ 'h',
        /// 1 ≤ amazon[1] ≤ 8,
        /// amazon ≠ king.
        /// 
        /// [output] array.integer
        /// 
        /// An array of four integers, each equal to the number of black's king positions corresponding to a specific situation. More specifically, the array should be of the form [checkmate positions, check positions, stalemate positions, safe positions].
        /// </remarks>
        public static int[] AmazonCheckmate(string king, string amazon)
        {
            //breaking all the moves
            List<string> kingMoves = KingMoves(king);
            List<string> amazonMoves = AmazonMoves(amazon, king, kingMoves);
            List<string> atkMoves = new List<string>();
            List<string> blackKingPos = BlackKingPositions(king, amazon, kingMoves);
            int[] result = new int[4];

            atkMoves.AddRange(kingMoves);
            atkMoves.AddRange(amazonMoves);

            foreach (var move in blackKingPos)
            {
                List<string> possibleMoves = KingMoves(move);

                possibleMoves.Add(move);
                possibleMoves = possibleMoves.Where(x => !atkMoves.Contains(x)).ToList();

                //checkmate
                if (possibleMoves.Count == 0)
                    result[0]++;
                else if (!possibleMoves.Contains(move) && possibleMoves.Count > 0)
                    result[1]++;
                else if (possibleMoves.Contains(move) && possibleMoves.Count == 1)
                    result[2]++;
                else if (possibleMoves.Contains(move) && possibleMoves.Count > 1)
                    result[3]++;
            }

            return result;
        }
        /// <summary>
        /// helper
        /// </summary>
        public static List<string> BlackKingPositions(string king, string amazon, List<string> kingMoves)
        {
            List<string> moves = new List<string>();

            for (char i = '1'; i <= '8'; i++)
            {
                for (char j = 'a'; j <= 'h'; j++)
                {
                    string pos = $"{j}{i}";

                    if (!king.Equals(pos) && !amazon.Equals(pos) && !kingMoves.Contains(pos))
                        moves.Add(pos);
                }
            }

            return (moves);
        }
        /// <summary>
        /// helper
        /// </summary>
        public static List<string> AmazonMoves(string amazon, string king, List<string> kingMoves)
        {
            List<string> moves = new List<string>();

            moves.AddRange(RookMoves(amazon, king, kingMoves));
            moves.AddRange(BishopMoves(amazon, king, kingMoves));
            moves.AddRange(KnightMoves(amazon, king, kingMoves));

            return moves;
        }
        /// <summary>
        /// helper
        /// </summary>
        public static List<string> KnightMoves(string amazon, string king, List<string> kingMoves)
        {
            int[][] moves = new int[][]{
                new int[] { 2, -1}, new int[] { 2,  1},
        new int[] { 1, -2},             new int[] {  1,  2},
        new int[] {-1, -2},             new int[] {  -1, 2},
                new int[] {-2, -1}, new int[] { -2, 1}};
            List<string> possibleMoves = new List<string>();

            for (int i = 0; i < moves.Length; i++)
            {
                int dx = amazon[1] + moves[i][0];
                int dy = amazon[0] + moves[i][1];
                string val = $"{(char)dy}{(char)dx}";

                if (IsInBounds(dx, dy) && !king.Equals(val) && !kingMoves.Contains(val))
                    possibleMoves.Add(val);
            }

            return possibleMoves;
        }
        /// <summary>
        /// helper
        /// </summary>
        public static List<string> BishopMoves(string amazon, string king, List<string> kingMoves)
        {
            List<string> moves = new List<string>();
            int x = amazon[1];
            int y = amazon[0];

            //left upper diag
            for (int i = x + 1, j = y - 1; j >= 'a' && i <= '8'; j--, i++)
            {
                string pos = $"{(char)j}{(char)i}";
                //king is blocking, abort
                if (pos.Equals(king)) break;
                //its inside the king range, avoid
                if (kingMoves.Contains(pos)) continue;

                moves.Add(pos);
            }

            //left lower diag
            for (int i = x - 1, j = y - 1; j >= 'a' && i >= '1'; j--, i--)
            {
                string pos = $"{(char)j}{(char)i}";
                //king is blocking, abort
                if (pos.Equals(king)) break;
                //its inside the king range, avoid
                if (kingMoves.Contains(pos)) continue;

                moves.Add(pos);
            }

            //right upper diag
            for (int i = x + 1, j = y + 1; j <= 'h' && i <= '8'; j++, i++)
            {
                string pos = $"{(char)j}{(char)i}";
                //king is blocking, abort
                if (pos.Equals(king)) break;
                //its inside the king range, avoid
                if (kingMoves.Contains(pos)) continue;

                moves.Add(pos);
            }

            //right lower diag
            for (int i = x - 1, j = y + 1; j <= 'h' && i >= '1'; j++, i--)
            {
                string pos = $"{(char)j}{(char)i}";
                //king is blocking, abort
                if (pos.Equals(king)) break;
                //its inside the king range, avoid
                if (kingMoves.Contains(pos)) continue;

                moves.Add(pos);
            }

            return moves;
        }
        /// <summary>
        /// helper
        /// </summary>
        public static List<string> RookMoves(string amazon, string king, List<string> kingMoves)
        {
            List<string> moves = new List<string>();
            int x = amazon[1];
            int y = amazon[0];

            //left
            for (int j = y - 1; j >= 'a'; j--)
            {
                string pos = $"{(char)j}{(char)x}";
                //king is blocking, abort
                if (pos.Equals(king)) break;
                //its inside the king range, avoid
                if (kingMoves.Contains(pos)) continue;

                moves.Add(pos);
            }

            //right
            for (int j = y + 1; j <= 'h'; j++)
            {
                string pos = $"{(char)j}{(char)x}";
                //king is blocking, abort
                if (pos.Equals(king)) break;
                //its inside the king range, avoid
                if (kingMoves.Contains(pos)) continue;

                moves.Add(pos);
            }

            //up
            for (int i = x + 1; i <= '8'; i++)
            {
                string pos = $"{(char)y}{(char)i}";
                //king is blocking, abort
                if (pos.Equals(king)) break;
                //its inside the king range, avoid
                if (kingMoves.Contains(pos)) continue;

                moves.Add(pos);
            }

            //down
            for (int i = x - 1; i >= '1'; i--)
            {
                string pos = $"{(char)y}{(char)i}";
                //king is blocking, abort
                if (pos.Equals(king)) break;
                //its inside the king range, avoid
                if (kingMoves.Contains(pos)) continue;

                moves.Add(pos);
            }

            return moves;
        }

        /// <summary>
        /// helper
        /// </summary>
        public static List<string> KingMoves(string king)
        {
            int[][] moves = new int[][]{
        new int[] {-1, -1}, new int[] {-1, 0}, new int[] { -1,  1},
        new int[] { 0, -1},                    new int[] {  0,  1},
        new int[] { 1, -1}, new int[] { 1, 0}, new int[] {  1,  1}};
            List<string> possibleMoves = new List<string>();

            for (int i = 0; i < moves.Length; i++)
            {
                int dx = king[1] + moves[i][0];
                int dy = king[0] + moves[i][1];

                if (IsInBounds(dx, dy))
                    possibleMoves.Add($"{(char)dy}{(char)dx}");
            }

            return possibleMoves;
        }

        /// <summary>
        /// helper
        /// </summary>
        public static bool IsInBounds(int x, int y)
        {
            if (x >= '1' && x <= '8' && y >= 'a' && y <= 'h')
                return true;

            return false;
        }


        #endregion


        /// <remarks>
        /// Pawn race is a game for two people, played on an ordinary 8 × 8 chessboard. The first player has a white pawn, the second one - a black pawn. Initially the pawns are placed somewhere on the board so that the 1st and the 8th rows are not occupied. Players take turns to make a move.
        /// 
        /// White pawn moves upwards, black one moves downwards.The following moves are allowed:
        /// 
        /// one-cell move on the same vertical in the allowed direction;
        /// two-cell move on the same vertical in the allowed direction, if the pawn is standing on the 2nd(for the white pawn) or the 7th(for the black pawn) row.Note that even with the two-cell move a pawn can't jump over the opponent's pawn;
        /// capture move one cell forward in the allowed direction and one cell to the left or to the right.
        /// 
        /// 
        /// The purpose of the game is to reach the the 1st row(for the black pawn) or the 8th row(for the white one), or to capture the opponent's pawn.
        /// 
        /// Given the initial positions and whose turn it is, determine who will win or declare it a draw(i.e.it is impossible for any player to win). Assume that the players play optimally.
        /// 
        /// Example
        /// 
        /// 
        /// For white = "e2", black = "e7", and toMove = 'w', the output should be
        /// pawnRace(white, black, toMove) = "draw";
        ///         For white = "e3", black = "d7", and toMove = 'b', the output should be
        /// pawnRace(white, black, toMove) = "black";
        /// For white = "a7", black = "h2", and toMove = 'w', the output should be
        /// pawnRace(white, black, toMove) = "white".
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         string white
        /// 
        /// Coordinates of the white pawn in the chess notation.
        /// 
        /// [input] string black
        /// 
        /// Position of the black pawn in the same notation.It is guaranteed that white ≠ black.
        /// 
        /// 
        /// [input] char toMove
        /// 
        /// 'w' if it is the first player's turn, 'b' otherwise.
        /// 
        /// [output] string
        /// 
        /// "white", "black" or "draw" depending on the result of the game.
        /// </remarks>
        public static string PawnRace(string white, string black, char toMove)
        {
            int colSpace = Math.Abs(white[0] - black[0]);
            char wPos = white[1];
            char bPos = black[1];

            //space between colums > 1 = no capture or white pos >= b
            if (colSpace > 1 || white[1] >= black[1])
            {
                wPos = white[1] == '2' && Math.Abs(white[1] - black[1]) > 3 ? '4' : (char)(white[1] + 1);
                bPos = black[1] == '7' && Math.Abs(white[1] - black[1]) > 3 ? '5' : (char)(black[1] - 1);
                int wDis = '8' - wPos;
                int bDis = bPos - '1';

                if (wDis < bDis)
                    return "white";
                else if (wDis > bDis)
                    return "black";
                else if (wDis == bDis)
                    return toMove == 'w' ? "white" : "black";
            }

            if (white[0] == black[0])
                return "draw";

            //check if we have a capture situation, otherwise move piece                
            if (toMove == 'w')
            {
                if (black.Equals($"{(char)white[0] + 1}{(char)wPos - 1}") || black.Equals($"{(char)white[0] + 1}{(char)wPos + 1}"))
                    return "white";

                wPos = white[1] == '2' && Math.Abs(wPos - bPos) > 3 ? '4' : (char)(white[1] + 1);
            }

            //check if we have a capture situation, otherwise move piece                
            if (toMove == 'b')
            {
                if (white.Equals($"{(char)black[0] + 1}{(char)bPos - 1}") || white.Equals($"{(char)black[0] + 1}{(char)bPos + 1}"))
                    return "white";

                bPos = black[1] == '7' && Math.Abs(wPos - bPos) > 3 ? '5' : (char)(black[1] - 1);
            }

            int xOff = Math.Abs(wPos - bPos);

            if (xOff % 2 == 0 && toMove == 'w')
                return "white";
            else if (xOff % 2 == 0 && toMove == 'b')
                return "black";
            else if (xOff % 2 == 1 && toMove == 'w')
                return "black";
            else
                return "white";
        }


    }
}
