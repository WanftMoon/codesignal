using System;
using System.Text.RegularExpressions;

namespace CodeSignal.Arcade.TheCore
{
    public class RegularHell
    {
        /// <remarks>
        /// Implement the missing code, denoted by ellipses. You may not modify the pre-existing code.
        /// A sentence is considered correct if:
        /// 
        /// it starts with a capital letter;
        ///         it ends with a full stop, question mark or exclamation point('.', '?' or '!');
        ///         full stops, question marks and exclamation points don't appear anywhere else in the sentence.
        /// Given a sentence, return true if it is correct and false otherwise.
        /// 
        /// Example
        /// 
        /// For sentence = "This is an example of *correct* sentence.",
        /// the output should be
        /// isSentenceCorrect(sentence) = true;
        /// 
        /// For sentence = "!this sentence is TOTALLY incorrecT",
        /// the output should be
        /// isSentenceCorrect(sentence) = false.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         string sentence
        /// 
        /// A string without newline characters.
        /// 
        /// Guaranteed constraints:
        /// 2 ≤ sentence.length ≤ 100.
        /// 
        /// [output] boolean
        /// 
        /// true if the given sentence is correct, false otherwise.
        /// </remarks>
        public static bool IsSentenceCorrect(string sentence)
        {
            Regex regex = new Regex("^[A-Z][^.?!]*[.?!]$");
            return regex.IsMatch(sentence);
        }


        /// <remarks>
        /// Implement the missing code, denoted by ellipses. You may not modify the pre-existing code.
        /// Implement a function that replaces each digit in the given string with a '#' character.
        /// 
        /// Example
        /// 
        /// For input = "There are 12 points", the output should be
        /// replaceAllDigitsRegExp(input) = "There are ## points".
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// string input
        /// 
        /// Guaranteed constraints:
        /// 5 ≤ input.length ≤ 20.
        /// 
        /// [output] string
        /// </remarks>
        public static string ReplaceAllDigitsRegExp(string input)
        {
            return Regex.Replace(input, "[0-9]", "#");
        }

        /// <remarks>
        /// Implement the missing code, denoted by ellipses. You may not modify the pre-existing code.
        ///  You are given a string consisting of words separated by whitespace characters, where the words consist only of English letters.Your task is to swap pairs of consecutive words and return the result.
        /// 
        /// Example
        /// 
        /// 
        /// For s = "CodeFight On", the output should be
        /// swapAdjacentWords(s) = "On CodeFight";
        ///  For s = "How are you today guys", the output should be
        ///  swapAdjacentWords(s) = "are How today you guys".
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         string s
        /// 
        /// A string consisting of whitespace characters(' ') and English letters.There is exactly one whitespace character between two consecutive words, and both the first and the last characters of s are not equal to ' '.
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ s.length ≤ 100.
        /// 
        /// [output]
        ///         string
        /// 
        /// String s with pairs of adjacent words swapped.
        /// </remarks>
        public static string SwapAdjacentWords(string s)
        {
            return Regex.Replace(s, "(\\w+) (\\w+)", "$2 $1");
        }

        /// <remarks>
        /// Implement the missing code, denoted by ellipses. You may not modify the pre-existing code.
        ///  You are given a string s of characters that contains at least n numbers(here, a number is defined as a consecutive series of digits, where any character immediately to the left and right of the series are not digits). The numbers may contain leading zeros, but it is guaranteed that each number has at least one non-zero digit in it.
        /// 
        /// Your task is to find the nth number and return it as a string without leading zeros.
        /// 
        /// Example
        /// 
        /// 
        /// For s = "8one 003number 201numbers li-000233le number444" and n = 4,
        /// the output should be
        /// nthNumber(s, n) = "233".
        /// 
        /// Input / Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] string s
        /// 
        /// 
        /// A string containing at least n numbers.
        /// 
        /// 
        /// Guaranteed constraints:
        /// 20 ≤ s.length ≤ 650.
        /// 
        /// 
        /// [input] integer n
        /// 
        /// 1-based index of the number to find.
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ n ≤ 15.
        /// 
        /// 
        /// [output] string
        /// 
        /// The nth number without leading zeros.
        /// </remarks>
        public static string NthNumber(string s, int n)
        {
            Regex regex = new Regex(
              @"(?:\D*0*(\d+)){" + n + "}"
            );
            return regex.Match(s).Groups[1].Value;
        }

        /// <remarks>
        /// Implement the missing code, denoted by ellipses. You may not modify the pre-existing code.
        /// Given a string s, determine if it is a subsequence of a given string t.
        /// 
        /// Example
        /// 
        /// 
        /// For t = "CodeSignal" and s = "CoSi", the output should be
        /// isSubsequence(t, s) = true;
        /// 
        /// For t = "CodeSignal" and s = "cosi", the output should be
        /// the output should be
        /// isSubsequence(t, s) = false.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         string t
        /// 
        /// A string consisting of English letters, whitespace characters(' '), digits and punctuation marks(".,?!=*+-").
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ t.length ≤ 500.
        /// 
        /// [input]
        ///         string s
        /// 
        /// A string consisting of English letters, whitespace characters(' '), digits and punctuation marks(".,?!=*+-").
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ s.length ≤ 50.
        /// 
        /// [output] boolean
        /// 
        /// true if the s is a subsequence of t, false otherwise.
        /// </remarks>
        public static bool IsSubsequence(string t, string s)
        {
            string pattern = "";
            foreach (char ch in s)
            {
                pattern += $"[{ch}]+.*";
            }
            Regex regex = new Regex(pattern);
            return regex.Match(t).Success;
        }

        /// <remarks>
        /// Implement the missing code, denoted by ellipses. You may not modify the pre-existing code.
        ///  An eye rhyme is a rhyme in which two words are spelled similarly but pronounced differently.An example is the pair cough and bough; although they look similar, when they are spoken there is no rhyming quality.
        /// 
        /// You are writing a thesis on the eye rhyme, and you thought it would be cool to make the text itself eye rhymed.This brilliant idea came to your mind a little too late: the text is already written. Now you want to check if a given pair of lines in your text have an eye rhyme. More specifically, you want to make sure that the last three characters of each pair of lines coincide.
        /// 
        /// 
        /// You have already split your text into pairs of lines. Now all that's left is to check that the last three characters of the lines in each pairOfLines coincide. Implement a function that will do this job.
        /// 
        /// 
        /// Example
        /// 
        /// For pairOfLines = "cough\tbough", the output should be
        /// eyeRhyme(pairOfLines) = true.
        /// 
        /// 
        /// Both lines end with ugh.
        /// 
        /// For pairOfLines = "CodeFig!ht\tWith all your might", the output should be
        /// eyeRhyme(pairOfLines) = false.
        /// 
        /// 
        /// The first line ends with !ht, and the second one ends with ght.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] string pairOfLines
        /// 
        /// 
        /// A string in the format "<line1>\t<line2>", where<linei> consists of at least 3 characters and may contain any character except '\t' (tabulation character). The lines are separated by '\t' (tabulation character).
        /// 
        /// 
        /// Guaranteed constraints:
        /// 7 ≤ pairOfLines.length ≤ 1000.
        /// 
        /// 
        /// [output] boolean
        /// 
        /// true if the lines in pairOfLines have an eye rhyme, false otherwise.
        /// </remarks>
        public static bool eyeRhyme(string pairOfLines)
        {
            Regex regex = new Regex("^.*(.{3})\\t.*(.{3})$");
            Match match = regex.Match(pairOfLines);
            return match.Groups[1].Value == match.Groups[2].Value;
        }


    }
}
