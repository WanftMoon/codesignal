using System;
using System.Collections.Generic;

namespace CodeSignal.InterviewPratice.Arrays
{
    /// <summary>
    /// question 2
    /// </summary>
    /// <remarks>
    /// Given a string s consisting of small English letters, find and return the first instance of a non-repeating character in it. If there is no such character, return '_'.
    /// Example
    /// For s = "abacabad", the output should be
    /// firstNotRepeatingCharacter(s) = 'c'.
    /// There are 2 non-repeating characters in the string: 'c' and 'd'. Return c since it appears in the string first.
    /// For s = "abacabaabacaba", the output should be
    /// firstNotRepeatingCharacter(s) = '_'.
    /// There are no characters in this string that do not repeat.
    /// Input/Output
    /// [execution time limit] 3 seconds (cs)
    /// [input] string s
    /// A string that contains only lowercase English letters.
    /// Guaranteed constraints:
    /// 1 ≤ s.length ≤ 105.
    /// [output] char
    /// The first non-repeating character in s, or '_' if there are no characters that do not repeat.
    /// </remarks>
    public class FirstNotRepeatingCharacter
    {
        public static char Solve(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    dict[s[i]] += 1;
                }
                else
                    dict[s[i]] = 1;
            }

            foreach (char key in dict.Keys)
            {
                if (dict[key] == 1)
                    return (key);
            }

            return ('_');
        }

    }
}
