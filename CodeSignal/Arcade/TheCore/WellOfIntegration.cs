using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodeSignal.Arcade.TheCore
{
    public class WellOfIntegration
    {
        /// <remarks>
        /// A boy is walking a long way from school to his home. To make the walk more fun he decides to add up all the numbers of the houses that he passes by during his walk. Unfortunately, not all of the houses have numbers written on them, and on top of that the boy is regularly taking turns to change streets, so the numbers don't appear to him in any particular order.
        ///
        ///At some point during the walk the boy encounters a house with number 0 written on it, which surprises him so much that he stops adding numbers to his total right after seeing that house.
        ///
        ///For the given sequence of houses determine the sum that the boy will get.It is guaranteed that there will always be at least one 0 house on the path.
        ///
        ///
        ///Example
        ///
        ///For inputArray = [5, 1, 2, 3, 0, 1, 5, 0, 2], the output should be
        ///houseNumbersSum(inputArray) = 11.
        ///
        ///
        ///The answer was obtained as 5 + 1 + 2 + 3 = 11.
        ///
        ///
        ///Input/Output
        ///
        ///[execution time limit] 3 seconds (cs)
        ///
        ///[input] array.integer inputArray
        ///
        ///
        ///Guaranteed constraints:
        /// 5 ≤ inputArray.length ≤ 10,
        ///0 ≤ inputArray[i] ≤ 10.
        ///
        ///
        ///[output] integer
        /// </remarks>
        public static int HouseNumbersSum(int[] inputArray)
        {
            return inputArray.TakeWhile(p => p != 0).Sum();
        }

        /// <remarks>
        /// Given an array of strings, return another array containing all of its longest strings.
        /// 
        /// Example
        /// 
        /// For inputArray = ["aba", "aa", "ad", "vcd", "aba"], the output should be
        /// allLongestStrings(inputArray) = ["aba", "vcd", "aba"].
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input] array.string inputArray
        /// 
        /// A non-empty array.
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ inputArray.length ≤ 10,
        /// 1 ≤ inputArray[i].length ≤ 10.
        /// 
        /// [output] array.string
        /// 
        /// Array of the longest strings, stored in the same order as in the inputArray.
        /// </remarks>
        public static string[] AllLongestStrings(string[] inputArray)
        {
            return inputArray.Where(p => p.Length == inputArray.Max(x => x.Length)).ToArray();
        }


        /// <remarks>
        /// There are some people and cats in a house. You are given the number of legs they have all together. Your task is to return an array containing every possible number of people that could be in the house sorted in ascending order. It's guaranteed that each person has 2 legs and each cat has 4 legs.
        /// 
        /// Example
        /// 
        /// For legs = 6, the output should be
        /// houseOfCats(legs) = [1, 3].
        /// 
        /// There could be either 1 cat and 1 person(4 + 2 = 6) or 3 people(2 * 3 = 6).
        /// 
        /// For legs = 2, the output should be
        /// houseOfCats(legs) = [1].
        /// 
        /// There can be only 1 person.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         integer legs
        /// 
        /// The total number of legs in the house.It's guaranteed,that this number is even.
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ legs< 50.
        /// 
        /// [output] array.integer
        /// 
        /// Every possible number of people that can be in the house.
        /// </remarks>
        public static int[] HouseOfCats(int legs)
        {
            List<int> lst = new List<int>();

            while (legs >= 0)
            {
                lst.Add(legs / 2);
                legs -= 4;
            }

            lst.Reverse();

            return lst.ToArray();
        }


        /// <remarks>
        /// Check whether the given string is a subsequence of the plaintext alphabet.
        /// 
        /// Example
        /// 
        /// For s = "effg", the output should be
        /// alphabetSubsequence(s) = false;
        /// For s = "cdce", the output should be
        /// alphabetSubsequence(s) = false;
        /// For s = "ace", the output should be
        /// alphabetSubsequence(s) = true;
        /// For s = "bxz", the output should be
        /// alphabetSubsequence(s) = true.
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// string s
        /// 
        /// Guaranteed constraints:
        /// 2 ≤ s.length ≤ 15.
        /// 
        /// [output] boolean
        /// 
        /// true if the given string is a subsequence of the alphabet, false otherwise.
        /// </remarks>
        public static bool AlphabetSubsequence(string s)
        {
            char[] array = s.Distinct().ToArray();

            Array.Sort(array);

            return Enumerable.SequenceEqual(array, s.ToArray());
        }

        /// <remarks>
        /// You find yourself in Bananaland trying to buy a banana. You are super rich so you have an unlimited supply of banana-coins, but you are trying to use as few coins as possible.
        /// 
        ///    The coin values available in Bananaland are stored in a sorted array coins.coins[0] = 1, and for each i (0 < i<coins.length) coins[i] is divisible by coins[i - 1]. Find the minimal number of banana-coins you'll have to spend to buy a banana given the banana's price.
        /// 
        /// Example
        /// 
        /// 
        /// For coins = [1, 2, 10] and price = 28, the output should be
        /// minimalNumberOfCoins(coins, price) = 6.
        /// 
        /// 
        /// You have to use 10 twice, and 2 four times.
        /// 
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] array.integer coins
        /// 
        /// 
        /// The coin values available in Bananaland.
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ coins.length ≤ 5,
        /// 1 ≤ coins[i] ≤ 120.
        /// 
        /// 
        /// [input] integer price
        /// 
        /// 
        /// A positive integer representing the price of the banana.
        /// 
        /// Guaranteed constraints:
        /// 8 ≤ price ≤ 250.
        ///
        ///
        ///[output] integer
        ///
        ///The minimal number of coins you can use to buy the banana.
        /// </remarks>
        public static int MinimalNumberOfCoins(int[] coins, int price)
        {
            int count = 0;

            for (int i = coins.Length - 1; i >= 0; i--)
            {
                count += price / coins[i];
                price %= coins[i];
            }

            return (count);
        }

        /// <remarks>
        /// Given a rectangular matrix of characters, add a border of asterisks(*) to it.
        /// 
        ///         Example
        /// 
        ///         For
        /// 
        /// picture = ["abc",
        ///            "ded"]
        ///         the output should be
        /// 
        /// addBorder(picture) = ["*****",
        ///                       "*abc*",
        ///                       "*ded*",
        ///                       "*****"]
        ///         Input/Output
        /// 
        ///         [execution time limit] 3 seconds(cs)
        /// 
        /// [input] array.string picture
        /// 
        /// A non-empty array of non-empty equal-length strings.
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ picture.length ≤ 100,
        /// 1 ≤ picture[i].length ≤ 100.
        /// 
        /// [output] array.string
        /// 
        /// The same matrix of characters, framed with a border of asterisks of width 1.
        /// </remarks>
        public static string[] AddBorder(string[] picture)
        {
            List<string> lst = new List<string>();
            int size = picture[0].Length;
            //top frame
            lst.Add(new string('*', size + 2));

            for (int i = 0; i < picture.Length; i++)
            {
                //add begin frame                
                lst.Add($"*{picture[i]}*");
            }

            //bottom frame
            lst.Add(new string('*', size + 2));

            return (lst.ToArray());
        }

        /// <remarks>
        /// N candles are placed in a row, some of them are initially lit. For each candle from the 1st to the Nth the following algorithm is applied: if the observed candle is lit then states of this candle and all candles before it are changed to the opposite. Which candles will remain lit after applying the algorithm to all candles in the order they are placed in the line?
        /// 
        ///  Example
        /// 
        ///  For a = [1, 1, 1, 1, 1], the output should be
        /// switchLights(a) = [0, 1, 0, 1, 0].
        /// 
        /// Check out the image below for better understanding:
        /// 
        /// For a = [0, 0], the output should be
        /// switchLights(a) = [0, 0].
        /// 
        /// The candles are not initially lit, so their states are not altered by the algorithm.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] array.integer a
        /// 
        /// Initial situation - array of zeros and ones of length N, 1 means that the corresponding candle is lit.
        /// 
        /// Guaranteed constraints:
        /// 2 ≤ a.length ≤ 5000.
        /// 
        /// [output] array.integer
        /// 
        /// Situation after applying the algorithm - array in the same format as input with the same length.
        /// 
        /// </remarks>
        public static int[] SwitchLights(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == 1)
                {
                    for (int j = 0; j <= i; j++)
                        a[j] = a[j] == 1 ? 0 : 1;
                }
            }

            return (a);
        }

        /// <remarks>
        /// Timed Reading is an educational tool used in many schools to improve and advance reading skills. A young elementary student has just finished his very first timed reading exercise. Unfortunately he's not a very good reader yet, so whenever he encountered a word longer than maxLength, he simply skipped it and read on.
        /// 
        ///  Help the teacher figure out how many words the boy has read by calculating the number of words in the text he has read, no longer than maxLength.
        ///  Formally, a word is a substring consisting of English letters, such that characters to the left of the leftmost letter and to the right of the rightmost letter are not letters.
        /// 
        ///  Example
        /// 
        ///  For maxLength = 4 and
        ///  text = "The Fox asked the stork, 'How is the soup?'",
        ///  the output should be
        ///  timedReading(maxLength, text) = 7.
        ///  
        /// 
        ///  The boy has read the following words: "The", "Fox", "the", "How", "is", "the", "soup".
        /// 
        /// 
        ///  Input/Output
        /// 
        ///  [execution time limit] 3 seconds (cs)
        /// 
        ///  [input] integer maxLength
        /// 
        ///  A positive integer, the maximum length of the word the boy can read.
        /// 
        /// 
        ///  Guaranteed constraints:
        /// 1 ≤ maxLength ≤ 10.
        /// 
        /// 
        /// [input] string text
        /// 
        /// 
        /// A non-empty string of English letters and punctuation marks.
        /// 
        /// Guaranteed constraints:
        /// 3 ≤ text.length ≤ 110.
        ///
        ///
        ///[output] integer
        ///
        ///The number of words the boy has read.
        /// </remarks>
        public static int timedReading(int maxLength, string text)
        {
            return Regex.Matches(text, "[\\w]+").Count(w => w.Length <= maxLength);
        }


        /// <summary>
        /// Elections are in progress!
        /// Given an array of the numbers of votes given to each of the candidates so far, and an integer k equal to the number of voters who haven't cast their vote yet, find the number of candidates who still have a chance to win the election.
        /// 
        /// The winner of the election must secure strictly more votes than any other candidate.If two or more candidates receive the same (maximum) number of votes, assume there is no winner at all.
        /// 
        /// Example
        /// 
        /// For votes = [2, 3, 5, 2] and k = 3, the output should be
        /// electionsWinners(votes, k) = 2.
        /// 
        /// The first candidate got 2 votes.Even if all of the remaining 3 candidates vote for him, he will still have only 5 votes, i.e.the same number as the third candidate, so there will be no winner.
        /// The second candidate can win if all the remaining candidates vote for him (3 + 3 = 6 > 5).
        /// The third candidate can win even if none of the remaining candidates vote for him.For example, if each of the remaining voters cast their votes for each of his opponents, he will still be the winner(the votes array will thus be [3, 4, 5, 3]).
        /// The last candidate can't win no matter what (for the same reason as the first candidate).
        /// Thus, only 2 candidates can win(the second and the third), which is the answer.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] array.integer votes        /// 
        /// 
        /// A non-empty array of non-negative integers. Its ith element denotes the number of votes cast for the ith candidate.
        /// 
        /// Guaranteed constraints:
        /// 4 ≤ votes.length ≤ 105,
        /// 0 ≤ votes[i] ≤ 104.
        /// 
        /// [input] integer k
        /// 
        /// The number of voters who haven't cast their vote yet.
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ k ≤ 105.
        /// 
        /// [output] integer
        public static int ElectionsWinners(int[] votes, int k)
        {
            int max = votes.Max();
            int winners = votes.Where(p => p == max).Count();

            if (k == 0 && winners == 1)
                return (winners);

            winners = 0;

            for (int i = 0; i < votes.Length; i++)
            {
                if (votes[i] + k > max)
                    winners++;
            }

            return (winners);
        }


        /// <remarks>
        /// Given a positive integer number and a certain length, we need to modify the given number to have a specified length. We are allowed to do that either by cutting out leading digits (if the number needs to be shortened) or by adding 0s in front of the original number.
        /// 
        /// Example
        /// 
        /// For number = 1234 and width = 2, the output should be
        /// integerToStringOfFixedWidth(number, width) = "34";
        /// For number = 1234 and width = 4, the output should be
        /// integerToStringOfFixedWidth(number, width) = "1234";
        /// For number = 1234 and width = 5, the output should be
        /// integerToStringOfFixedWidth(number, width) = "01234".
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// integer number
        /// 
        /// A non-negative integer.
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ number ≤ 109.
        /// 
        /// [input] integer width
        /// 
        /// A positive integer representing the desired length.
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ width ≤ 50.
        /// 
        /// [output] string
        /// 
        /// The modified version of number as described above.
        /// </remarks>
        public static string IntegerToStringOfFixedWidth(int number, int width)
        {
            string str = number.ToString();

            if (str.Length >= width)
                return str.Substring(str.Length - width);

            return new string('0', width - str.Length) + str;
        }


        /// <remarks>
        /// Two arrays are called similar if one can be obtained from another by swapping at most one pair of elements in one of the arrays.

        /// Given two arrays a and b, check whether they are similar.
        /// 
        /// Example
        /// 
        /// 
        /// For a = [1, 2, 3] and b = [1, 2, 3], the output should be
        /// areSimilar(a, b) = true.
        /// 
        /// 
        /// The arrays are equal, no need to swap any elements.
        /// 
        /// 
        /// For a = [1, 2, 3] and b = [2, 1, 3], the output should be
        /// areSimilar(a, b) = true.
        /// 
        /// 
        /// We can obtain b from a by swapping 2 and 1 in b.
        /// 
        /// For a = [1, 2, 2] and b = [2, 1, 1], the output should be
        /// areSimilar(a, b) = false.
        /// 
        /// 
        /// Any swap of any two elements either in a or in b won't make a and b equal.
        /// 
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] array.integer a
        /// 
        /// 
        /// Array of integers.
        /// 
        /// Guaranteed constraints:
        /// 3 ≤ a.length ≤ 105,
        /// 1 ≤ a[i] ≤ 1000.
        /// 
        /// 
        /// [input] array.integer b
        /// 
        /// 
        /// Array of integers of the same length as a.
        /// 
        /// Guaranteed constraints:
        /// b.length = a.length,
        /// 1 ≤ b[i] ≤ 1000.
        /// 
        /// 
        /// [output] boolean
        /// 
        /// true if a and b are similar, false otherwise.
        ///
        /// ranked solution:
        ///  var diffs = A.Select((_, i) => i).Where(_ => A[_] != B[_]).ToArray();
        /// return diffs.Length == 0 || diffs.Length == 2 && A[diffs[0]] == B[diffs[1]] && B[diffs[0]] == A[diffs[1]];
        /// </remarks>
        public static bool AreSimilar(int[] a, int[] b)
        {
            List<int> diff = new List<int>();

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    diff.Add(i);
            }

            if (diff.Count() == 0) return (true);
            if (diff.Count() != 2) return (false);

            int id1 = diff[0];
            int id2 = diff[1];

            if (a[id1] == b[id2] && a[id2] == b[id1]) return true;

            return (false);
        }


        /// <remarks>
        /// 
        /// </remarks>
        public static bool AdaNumber(string line)
        {
            string alphaLower = "0123456789abcdef";

            //to lower and remove _
            line = line.ToLower().Replace("_", "");
            //check for #
            if (line.Contains('#'))
            {
                //split the string
                var items = line.Split("#");
                int bas = 0;
                bool containsBase = int.TryParse(items[0], out bas);

                Console.WriteLine(items.Length);

                //check if contains 2 hashtags 
                //the last one must be at the end
                //should have 2 items
                //the base should be between 2-16
                if (line.Count(x => x == '#') != 2 ||
                line[line.Length - 1] != '#' ||
                items.Length != 3 ||
                !containsBase ||
                !(bas >= 2 && bas <= 16))
                    return false;

                //create pattern
                string pattern = alphaLower.Substring(0, bas);

                Console.WriteLine(pattern);

                return Regex.IsMatch(items[1], $"^[{pattern}]+$");
            }
            else
            {
                //check for simple integer
                return Regex.IsMatch(line, "^[0-9]+$");
            }
        }


        /// <remarks>
        /// You have a long strip of paper with integers written on it in a single line from left to right. You wish to cut the paper into exactly three pieces such that each piece contains at least one integer and the sum of the integers in each piece is the same. You cannot cut through a number, i.e. each initial number will unambiguously belong to one of the pieces after cutting. How many ways can you do it?
        /// 
        /// It is guaranteed that the sum of all elements in the array is divisible by 3.
        /// 
        /// Example
        /// 
        /// For a = [0, -1, 0, -1, 0, -1], the output should be
        /// threeSplit(a) = 4.
        /// 
        /// Here are all possible ways:
        /// 
        /// [0, -1]
        /// [0, -1]
        /// [0, -1]
        /// [0, -1]
        /// [0, -1, 0]
        /// [-1]
        /// [0, -1, 0]
        /// [-1, 0]
        /// [-1]
        /// [0, -1, 0]
        /// [-1]
        /// [0, -1]
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// array.integer a
        /// 
        /// Guaranteed constraints:
        /// 5 ≤ a.length ≤ 104,
        /// -108 ≤ a[i] ≤ 108.
        /// 
        /// [output]
        /// integer
        /// 
        /// It's guaranteed that for the given test cases the answer always fits signed 32-bit integer type.
        /// </remarks>
        public static int ThreeSplit(int[] a)
        {
            long floor = a.Sum(x => (long)x) / 3;
            int length = a.Length;
            long sumA = 0;
            int ways = 0;

            for (int i = 0; i < length; i++)
            {
                sumA += a[i];

                if (sumA == floor)
                {
                    long sumB = 0;

                    for (int j = i + 1; j < length; j++)
                    {
                        sumB += a[j];

                        if (sumB == floor && j < length - 1)
                            ways++;
                    }
                }
            }

            return (ways);
        }


    }
}
