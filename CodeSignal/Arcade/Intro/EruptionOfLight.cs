using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodeSignal.Arcade.Intro
{
    public class EruptionOfLight
    {
        /// <remarks>
        /// A string is said to be beautiful if each letter in the string appears at most as many times as the previous letter in the alphabet within the string; ie: b occurs no more times than a; c occurs no more times than b; etc. Note that letter a has no previous letter.
        /// Given a string, check whether it is beautiful.
        /// 
        /// Example
        /// 
        /// For inputString = "bbbaacdafe", the output should be isBeautifulString(inputString) = true.
        /// 
        /// This string contains 3 as, 3 bs, 1 c, 1 d, 1 e, and 1 f(and 0 of every other letter), so since there aren't any letters that appear more frequently than the previous letter, this string qualifies as beautiful.
        /// 
        /// For inputString = "aabbb", the output should be isBeautifulString(inputString) = false.
        /// 
        /// Since there are more bs than as, this string is not beautiful.
        /// 
        /// For inputString = "bbc", the output should be isBeautifulString(inputString) = false.
        /// 
        /// Although there are more bs than cs, this string is not beautiful because there are no as, so therefore there are more bs than as.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] string inputString
        /// 
        /// A string of lowercase English letters.
        /// 
        /// Guaranteed constraints:
        /// 3 ≤ inputString.length ≤ 50.
        /// 
        /// [output] boolean
        /// 
        /// Return true if the string is beautiful, false otherwise.
        /// </remarks>
        public static bool IsBeautifulString(string inputString)
        {
            int previousCount = int.MaxValue;
            int inputDistinct = inputString.Distinct().Count();
            int index = 0;

            for (char i = 'a'; i <= 'z'; i++)
            {
                if (++index > inputDistinct)
                    break;

                int currentCount = inputString.Where(p => p == i).Count();

                if (currentCount == 0 || currentCount > previousCount)
                    return (false);

                previousCount = currentCount;
            }

            return (true);
        }

        /// <remarks>
        /// An email address such as "John.Smith@example.com" is made up of a local part ("John.Smith"), an "@" symbol, then a domain part ("example.com").
        /// 
        ///   The domain name part of an email address may only consist of letters, digits, hyphens and dots.The local part, however, also allows a lot of different special characters.Here you can look at several examples of correct and incorrect email addresses.
        /// 
        /// 
        ///  Given a valid email address, find its domain part.
        /// 
        /// 
        ///  Example
        /// 
        ///  For address = "prettyandsimple@example.com", the output should be
        ///  findEmailDomain(address) = "example.com";
        ///   For address = "fully-qualified-domain@codesignal.com", the output should be
        ///   findEmailDomain(address) = "codesignal.com".
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// string address
        /// 
        /// Guaranteed constraints:
        /// 10 ≤ address.length ≤ 50.
        /// 
        /// [output] string
        /// 
        /// </remarks>
        string FindEmailDomain(string address)
        {
            return (address.Substring(address.LastIndexOf('@') + 1));
        }

        /// <remarks>
        /// Given a string, find the shortest possible string which can be achieved by adding characters to the end of initial string to make it a palindrome.
        /// 
        ///  Example
        /// 
        ///  For st = "abcdc", the output should be
        /// buildPalindrome(st) = "abcdcba".
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///  string st
        /// 
        /// A string consisting of lowercase English letters.
        /// 
        /// Guaranteed constraints:
        /// 3 ≤ st.length ≤ 10.
        /// 
        /// [output] string
        /// 
        /// </remarks>
        string BuildPalindrome(string st)
        {
            for (int i = 0; i < st.Length; i++)
            {
                string temp = st.Substring(0, i);
                string possiblePal = st + string.Concat(temp.Reverse());

                if (possiblePal.Equals(string.Concat(possiblePal.Reverse())))
                    return (possiblePal);
            }

            return (st);
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
        /// A media access control address (MAC address) is a unique identifier assigned to network interfaces for communications on the physical network segment.
        /// 
        /// The standard(IEEE 802) format for printing MAC-48 addresses in human-friendly form is six groups of two hexadecimal digits(0 to 9 or A to F), separated by hyphens(e.g. 01-23-45-67-89-AB).
        /// 
        /// Your task is to check by given string inputString whether it corresponds to MAC-48 address or not.
        /// 
        /// Example
        /// 
        /// For inputString = "00-1B-63-84-45-E6", the output should be
        /// isMAC48Address(inputString) = true;
        /// For inputString = "Z1-1B-63-84-45-E6", the output should be
        /// isMAC48Address(inputString) = false;
        /// For inputString = "not a MAC-48 address", the output should be
        /// isMAC48Address(inputString) = false.
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         string inputString
        /// 
        /// Guaranteed constraints:
        /// 15 ≤ inputString.length ≤ 20.
        /// 
        /// [output] boolean
        /// 
        /// true if inputString corresponds to MAC-48 address naming rules, false otherwise.
        /// </remarks>
        public static bool isMAC48Address(string inputString)
        {
            return (Regex.IsMatch(inputString, "^([0-9A-F]{2}[:-]){5}([0-9A-F]{2})$"));
        }


    }
}
