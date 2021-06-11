using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodeSignal.Arcade.TheCore
{
    public class SecretArchives
    {
        /// <remarks>
        /// During your most recent trip to Codelandia you decided to buy a brand new CodePlayer, a music player that (allegedly) can work with any possible media format. As it turns out, this isn't true: the player can't read lyrics written in the LRC format. It can, however, read the SubRip format, so now you want to translate all the lyrics you have from LRC to SubRip.
        /// 
        /// Since you are a pro programmer(no noob would ever get to Codelandia!), you're happy to implement a function that, given lrcLyrics and songLength, returns the lyrics in SubRip format.
        /// 
        /// Example
        /// 
        /// For
        /// 
        /// lrcLyrics = ["[00:12.00] Happy birthday dear coder,",
        ///              "[00:17.20] Happy birthday to you!"]
        ///         and songLength = "00:00:20", the output should be
        /// 
        ///         lrc2subRip(lrcLyrics, songLength) = [
        ///           "1",
        ///           "00:00:12,000 --> 00:00:17,200",
        ///           "Happy birthday dear coder,",
        ///           "",
        ///           "2",
        ///           "00:00:17,200 --> 00:00:20,000",
        ///           "Happy birthday to you!"
        /// ]
        ///         Input/Output
        /// 
        ///         [execution time limit] 3 seconds(cs)
        /// 
        /// [input] array.string lrcLyrics
        /// 
        /// Lyrics in LRC format.Each string has the format [MM: SS.xx] <song_line>, (note the whitespace character after the time) where:
        /// 
        /// MM:SS.xx is the lyrics time (it is guaranteed that the elements of lrcLyrics are sorted in ascending order of this time);
        /// 0 ≤ int (xx) ≤ 99;
        /// 0 ≤ int (SS) ≤ 59;
        /// 0 ≤ int (MM) ≤ 99;
        /// <song_line> is the corresponding lyrics line.
        /// Guaranteed constraints:
        /// 1 ≤ lrcLyrics.length ≤ 50,
        /// 1 ≤ lrcLyrics[i].length ≤ 100.
        /// 
        /// [input] string songLength
        /// 
        /// The length of the song in the format "HH:MM:SS". It is guaranteed that it is greater than the last time in lrcLyrics.
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ int(HH) ≤ 2,
        /// 0 ≤ int(MM) ≤ 59,
        /// 0 ≤ int(SS) ≤ 59.
        /// 
        /// [output] array.string
        /// 
        /// The given lyrics in the SubRip format.For each line in the lrcLyrics, three new lines should be generated:
        /// 
        /// the first line is the 1-based lyrics line number;
        ///         the second line should be in the format HH1:MM1:SS1,xxx1 --> HH2:MM2:SS2,xxx2, where:
        /// HH1:MM1:SS1,xxx1 the time the row starts;
        ///         HH2:MM2:SS2,xxx2 when the next lyrics should appear, or the length of the song if it's the last lyrics line;
        /// the last line is the lyrics text itself.
        /// Each pair of consecutive three-lines groups should be separated by a single empty string.
        /// </remarks>
        public static string[] Lrc2subRip(string[] lrcLyrics, string songLength)
        {
            Func<string[], string, TimeSpan[]> GetTimes = (string[] arr, string duration) => {
                TimeSpan[] times = new TimeSpan[arr.Length + 1];

                string[] comps = songLength.Split(':');
                int h = int.Parse(comps[0]);
                int m = int.Parse(comps[1]);
                int s = int.Parse(comps[2]);
                TimeSpan span = new TimeSpan(0, h, m, s, 0);

                times[times.Length - 1] = span;

                for (int i = 0; i < arr.Length; i++)
                {
                    comps = arr[i][1..arr[i].IndexOf(']')].Replace('.', ':').Split(':');
                    m = int.Parse(comps[0]);
                    s = int.Parse(comps[1]);
                    int ms = int.Parse(comps[2]) * 10;
                    span = new TimeSpan(0, m / 60, m % 60, s, ms);

                    times[i] = span;
                }

                return (times);
            };


            string[] lrc = new string[lrcLyrics.Length * 3 + lrcLyrics.Length - 1];
            TimeSpan[] times = GetTimes(lrcLyrics, songLength);

            for (int i = 0; i < lrcLyrics.Length; i++)
            {
                lrc[i * 4 + 0] = $"{i + 1}";
                lrc[i * 4 + 1] = $"{times[i]:hh\\:mm\\:ss\\,fff} --> {times[i + 1]:hh\\:mm\\:ss\\,fff}";
                lrc[i * 4 + 2] = lrcLyrics[i][(lrcLyrics[i].IndexOf(']') + 1)..].TrimStart();

                if (i != lrcLyrics.Length - 1)
                    lrc[i * 4 + 3] = "";
            }

            return (lrc);
        }


        /// <remarks>
        /// HTML tables allow web developers to arrange data into rows and columns of cells. They are created using the <table> tag. Its content consists of one or more rows denoted by the <tr> tag. Further, the content of each row comprises one or more cells denoted by the <td> tag, and content within the <td> tags is what site visitors see in the table. For this task assume that tags have no attributes in contrast to real world HTML.
        /// 
        ///  Some tables contain the<th> tag.This tag defines header cells, which shouldn't be counted as regular cells.
        /// 
        /// 
        ///  You are given a rectangular HTML table.Extract the content of the cell with coordinates (row, column).
        /// 
        /// 
        ///  If you are not familiar with HTML, check out this note.
        /// 
        ///  Example
        /// 
        ///  For table = "<table><tr><td>1</td><td>TWO</td></tr><tr><td>three</td><td>FoUr4</td></tr></table>", row = 0, and column = 1, the output should be
        ///  htmlTable(table, row, column) = "TWO".
        ///  
        /// 
        ///  < table >
        ///  
        ///   < tr >
        ///  
        ///    < td > 1 </ td >
        ///  
        ///    < td > TWO </ td >
        ///  
        ///   </ tr >
        ///  
        ///   < tr >
        ///  
        ///    < td > three </ td >
        ///  
        ///    < td > FoUr4 </ td >
        ///  
        ///   </ tr >
        ///  </ table >
        ///  corresponds to:
        /// 
        /// 1	TWO
        ///         three   FoUr4
        ///         For table = "<table><tr><td>1</td><td>TWO</td></tr></table>", row = 1, and column = 0, the output should be
        ///         htmlTable(table, row, column) = "No such cell".
        ///         
        /// 
        ///         < table >
        ///         
        ///          < tr >
        ///         
        ///           < td > 1 </ td >
        ///         
        ///           < td > TWO </ td >
        ///         
        ///          </ tr >
        ///         </ table >
        ///         corresponds to:
        /// 
        /// 1	TWO
        ///         Input/Output
        /// 
        ///         [execution time limit] 3 seconds (cs)
        /// 
        ///         [input] string table
        ///         
        /// 
        ///         A syntactically correct representation of a rectangular HTML table with at least one cell. Each of its cells contains only letters and/or digits.
        /// 
        /// 
        ///         Guaranteed constraints:
        /// 35 ≤ table.length ≤ 1600.
        /// 
        /// 
        ///         [input] integer row
        ///         
        /// 
        ///         A non-negative integer representing 0-based index of the desired row (rows are numbered from top to bottom).
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ row ≤ 10.
        /// 
        /// [input]
        ///         integer column
        /// 
        /// A non-negative integer representing 0-based index of the desired column(columns are numbered from left to right).
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ column ≤ 10.
        /// 
        /// [output]
        ///         string
        /// 
        /// The content of the cell with coordinates(row, column) or the string "No such cell" if there is no cell with those coordinates in the table.
        /// </remarks>
        public static string HtmlTable(string table, int row, int column)
        {
            string[] trs = Regex.Matches(table, @"(?<=<tr>).*?(?=</tr>)").Cast<Match>().Select(match => match.Value).ToArray();
            List<List<string>> tb = new List<List<string>>();

            for (int i = 0; i < trs.Length; i++)
            {
                string[] tds = Regex.Matches(trs[i], @"(?<=<td>).*?(?=</td>)").Cast<Match>().Select(match => match.Value).ToArray();
                var r = new List<string>();

                for (int j = 0; j < tds.Length; j++)
                    r.Add(tds[j]);

                tb.Add(r);
            }

            return (row > tb.Count - 1 || column > tb[row].Count - 1 ? "No such cell" : tb[row][column]);
        }




        /// <remarks>
        /// John has always had trouble remembering chess game positions. To help himself with remembering, he decided to store game positions in strings. He came up with the following position notation:
        /// 
        /// The notation is built for the current game position row by row from top to bottom, with '/' separating each row notation;
        /// Within each row, the contents of each square are described from the leftmost column to the rightmost;
        /// Each piece is identified by a single letter taken from the standard English names('P' = pawn, 'N' = knight, 'B' = bishop, 'R' = rook, 'Q' = queen, 'K' = king);
        /// White pieces are designated using upper-case letters("PNBRQK") while black pieces use lowercase("pnbrqk");
        ///     Empty squares are noted using digits 1 through 8 (the number of empty squares from the last piece);
        /// Empty lines are noted as "8".
        /// For example, for the initial position(shown in the picture below) the notation will look like this:
        /// 
        /// "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR"
        /// 
        /// 
        /// 
        /// After the white pawn moves from e2 to e4, the notation will be as follows:
        /// 
        /// "rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR"
        /// 
        /// 
        /// John has written down some positions using his notation, and now he wants to rotate the board 90 degrees clockwise and see what notation for the new board would look like.Help him with this task.
        /// 
        /// Example
        /// 
        /// For notation = "rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR", the output should be
        /// chessNotation(notation) = "RP4pr/NP4pn/BP4pb/QP4pq/K2P2pk/BP4pb/NP4pn/RP4pr".
        /// 
        /// 
        /// The notation corresponds to the initial position with one move made (white pawn from e2 to e4).
        /// After rotating the board, it will look like this:
        /// 
        /// 
        /// 
        /// So, the notation of the new position is "RP4pr/NP4pn/BP4pb/QP4pq/K2P2pk/BP4pb/NP4pn/RP4pr".
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///     string notation
        /// 
        /// Game position in John's notation. It is guaranteed that notation is correct, but not guaranteed that it represents a valid game position.
        /// 
        /// Guaranteed constraints:
        /// 15 ≤ notation.length ≤ 71.
        /// 
        /// [output]
        ///     string
        /// 
        /// Notation for the position of the game board, rotated 90 degrees clockwise.
        /// </remarks>
        public static string ChessNotation(string notation)
        {
            Func<string, char[][]> GetBoard = (string n) =>
            {
                char[][] board = new char[8][];
                string[] lines = n.Split('/');
                char current;

                for (int i = 0; i < 8; i++)
                {
                    string line = lines[i];
                    Queue<char> q = new Queue<char>(line.ToArray());
                    board[i] = new char[8];

                    current = q.Dequeue();

                    for (int j = 0; j < 8; j++)
                    {
                        if (!char.IsDigit(current))
                        {
                            board[i][j] = current;

                            if (q.Count > 0) current = q.Dequeue();
                        }
                        else
                        {
                            board[i][j] = '0';
                            current = (char)(current - 1);

                            if (current == '0' && q.Count > 0) current = q.Dequeue();
                        }
                    }
                }

                return (board);
            };

            Func<char[][], char[][]> RotateBoard = (char[][] board) =>
            {
                // Traverse each cycle
                for (int i = 0; i < board.Length / 2; i++)
                {
                    for (int j = i; j < board.Length - i - 1; j++)
                    {

                        // Swap elements of each cycle
                        // in clockwise direction
                        char temp = board[i][j];
                        board[i][j] = board[board.Length - 1 - j][i];
                        board[board.Length - 1 - j][i] = board[board.Length - 1 - i][board.Length - 1 - j];
                        board[board.Length - 1 - i][board.Length - 1 - j] = board[j][board.Length - 1 - i];
                        board[j][board.Length - 1 - i] = temp;
                    }
                }

                return board;
            };

            char[][] board = GetBoard(notation);
            // Print(board);
            board = RotateBoard(board);
            // Console.WriteLine();
            // Print(board);
            string result = "";

            for (int i = 0; i < board.Length; i++)
            {
                int zeroes = 0;

                for (int j = 0; j < board.Length; j++)
                {
                    if (board[i][j] == '0') zeroes++;
                    else
                    {
                        if (zeroes > 0)
                            result += $"{(char)(zeroes + '0')}";

                        result += $"{board[i][j]}";
                        zeroes = 0;
                    }

                    if (j == board.Length - 1 && zeroes > 0)
                        result += $"{(char)(zeroes + '0')}";
                }

                if (i < board.Length - 1)
                    result += "/";
            }


            return result;
        }


        /// <remarks>
        /// You are writing a spreadsheet application for an ancient operating system. The system runs on a computer so old that it can only display ASCII graphics. Currently you are stuck with implementing the cells joining algorithm.
        /// 
        /// You are given a table in ASCII graphics, where the following characters are used for borders: +, -, |. The rows can have different heights and the columns can have different widths.Each cell has an area greater than 1 (excluding the borders) and can contain any ASCII characters excluding +, - and |.
        /// 
        /// The algorithm you want to implement should merge the cells within a given rectangular part of the table into a single cell by removing the borders between them(i.e.replace them with space characters (' ') and replace redundant +s with correct border symbols). The cells to join are represented by the coordinates of the cells at the extreme bottom-left and top-right of the area.
        /// 
        /// Example
        /// For
        /// 
        /// table = ["+----+--+-----+----+",
        ///        "|abcd|56|!@#$%|qwer|",
        ///        "|1234|78|^&=()|tyui|",
        ///        "+----+--+-----+----+",
        ///        "|zxcv|90|77777|stop|",
        ///        "+----+--+-----+----+",
        ///        "|asdf|~~|ghjkl|100$|",
        ///        "+----+--+-----+----+"]
        /// and coords = [[2, 0], [1, 1]], the output should be
        /// 
        /// cellsJoining(table, coords) = ["+----+--+-----+----+",
        ///                                "|abcd|56|!@#$%|qwer|",
        ///                                "|1234|78|^&=()|tyui|",
        ///                                "+----+--+-----+----+",
        ///                                "|zxcv 90|77777|stop|",
        ///                                "|       +-----+----+",
        ///                                "|asdf ~~|ghjkl|100$|",
        ///                                "+-------+-----+----+"]
        ///         Input/Output
        /// 
        ///         [execution time limit] 3 seconds(cs)
        /// 
        /// [input] array.string table
        /// 
        /// A table in ASCII graphics. '|' and '-' characters represent borders, and '+' characters represent their intersection. It is guaranteed that there are no joined cells in the table. It's also guaranteed that the table occupies the entire rectangular array, i.e. its outer borders occupy the leftmost and the rightmost columns of the array as well as its topmost and bottommost rows.
        /// 
        /// Guaranteed constraints:
        /// 3 ≤ table.length ≤ 25,
        /// 3 ≤ table[i].length ≤ 80,
        /// table[i].length = table[j].length.
        /// 
        /// [input] array.array.integer coords
        /// 
        /// coords[0] contains 0-based row and column indices (given in that exact order) of the extreme bottom left cell in the area to join, and coords[1] contains indices of the extreme top right cell of that region.
        /// 
        /// It's guaranteed that there are at least two cells to be joined, and that cells with the given indices do exist in the table.
        /// 
        /// The rows are numbered from top to bottom while the columns are numbered from left to right.
        /// 
        /// Guaranteed constraints:
        /// coords.length = 2,
        /// coords[i].length = 2,
        /// 0 ≤ coords[1][0] ≤ coords[0][0] < 10,
        /// 0 ≤ coords[0][1] ≤ coords[1][1] ≤ 25.
        /// 
        /// [output] array.string
        /// 
        /// Table with cells in given region joined into one.
        /// </remarks>
        public static string[] CellsJoining(string[] table, int[][] coords)
        {
            List<int> rows = new List<int>();
            List<int> cols = new List<int>();

            //find the row range
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i][0] == '+') rows.Add(i);
            }
            //find the column range
            for (int j = 0; j < table[0].Length; j++)
            {
                if (table[0][j] == '+') cols.Add(j);
            }

            int rStart = rows[Math.Min(coords[0][0], coords[1][0])];
            int rEnd = rows[Math.Max(coords[0][0], coords[1][0]) + 1];
            int cStart = cols[Math.Min(coords[0][1], coords[1][1])];
            int cEnd = cols[Math.Max(coords[0][1], coords[1][1]) + 1];

            Console.WriteLine($"{rStart} {rEnd}");
            Console.WriteLine($"{cStart} {cEnd}");

            //replace content
            for (int i = rStart + 1; i < rEnd; i++)
            {
                var line = table[i].ToArray();

                for (int j = cStart + 1; j < cEnd; j++)
                {
                    if (line[j] == '-' || line[j] == '|' || line[j] == '+') line[j] = ' ';
                }

                if (cStart == 0) line[cStart] = '|';
                if (cEnd == line.Length - 1) line[cEnd] = '|';

                table[i] = string.Concat(line);
            }

            var topLine = table[rStart].ToArray();
            var bottomLine = table[rEnd].ToArray();

            //borders top and bottom
            for (int j = cStart + 1; j < cEnd; j++)
            {
                if (rStart == 0) topLine[j] = '-';
                if (rEnd == table.Length - 1) bottomLine[j] = '-';
            }

            table[rStart] = string.Concat(topLine);
            table[rEnd] = string.Concat(bottomLine);

            return table;
        }


    }
}
