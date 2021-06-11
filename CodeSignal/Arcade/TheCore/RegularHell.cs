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


        /// <remarks>
        /// Implement the missing code, denoted by ellipses. You may not modify the pre-existing code.
        ///         As an avid user of CodeSignal, you find it frustrating that there are no debugging and recovery tasks in your favorite language, PHP.You decide to help the platform by translating solutions in JavaScript into PHP.
        /// 
        ///        You quickly discover that this approach is quite convenient: sometimes all you have to do is substitute the function arguments by adding the $ sign in front of them.At first you do this manually, but soon realize that it won't get you far enough.
        /// 
        /// Now you need to implement a function that, given a solution written in JavaScript and its args, adds a $ sign in front of each args[i] (unless there is already a dollar sign present).
        /// 
        /// Given a solution in JavaScript and its args, return the almost-PHP solution.
        /// 
        /// Example
        /// 
        /// For
        /// 
        /// solution =
        ///     "function add($n, m) {\t
        ///        return n + $m;\t
        ///     }"
        /// and args = ["n", "m"], the output should be
        /// 
        /// programTranslation(solution, args) =
        ///     "function add($n, $m) {\t
        ///        return $n + $m;\t
        /// }
        /// "
        /// Input / Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input] string solution
        /// 
        /// Solution written in JavaScript. It is guaranteed that the given code snippet:
        /// 
        /// is correct and can be executed in the CodeSignal environment with $ symbols removed;
        /// does not contain comments or string variables;
        /// does not start with one of the args.
        /// Due to system limitations, tabulation (\t) characters are used instead of newlines (\n).
        /// 
        /// Guaranteed constraints:
        /// 40 ≤ solution.length ≤ 200.
        /// 
        /// [input] array.string args
        /// 
        /// An array of distinct function arguments. It is guaranteed that each argument is valid, i.e. it consists only of uppercase and lowercase letters 'A' through 'Z', the underscore '_' and, except for the first character, the digits '0' through '9'. It is also guaranteed that no argument coincides with one of the reserved words.
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ args.length ≤ 10,
        /// 1 ≤ args[i].length ≤ 10.
        /// 
        /// [output] string
        /// 
        /// The given solution with args replaced to PHP-style.
        /// </remarks>
        public static string ProgramTranslation(string solution, string[] args)
        {
            string argumentVariants = String.Join("|", args);
            string pattern = "(?<=[^0-9a-zA-Z$_])(" + argumentVariants + ")(?=[^0-9a-zA-Z$_])";
            string sub = "$$$1";
            return Regex.Replace(solution, pattern, sub);
        }

        /// <remarks>
        /// Implement the missing code, denoted by ellipses. You may not modify the pre-existing code.
        /// Jane just got a letter from her friend and realized that something's wrong: some words in the letter are written twice in a row. The thing is, she and her friend devised an ingenious cypher, the key to which is the number of pairs of repeated words in the encoded text. The cases of the words don't matter.
        /// 
        /// Formally, a word is a substring of letter consisting of English letters, such that characters to the left of the leftmost letter and to the right of the rightmost letter are not letters.
        /// 
        /// For obvious reasons, Jane can't tell you how the encryption works, but she needs your help with calculating the number of pairs of consecutive equal words. Write a function that, given a letter, returns this number.
        /// 
        /// 
        /// Example
        /// 
        /// For letter = "Hi, hi Jane! I'm so. So glad to to finally be able to write - WRITE!! - to you!",
        /// the output should be
        /// repetitionEncryption(letter) = 4.
        /// 
        /// 
        /// There are 4 pairs of consecutive identical words in the text. They are shown in different colors below:
        /// "Hi, hi Jane! I'm so. So glad to to finally be able to write - WRITE!! - to you!"
        /// 
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] string letter
        /// 
        /// 
        /// The letter Jane's friend wrote to her. It is guaranteed that there are no more than two consecutive equal words in a row. It is also guaranteed that between two such pairs there are at least two symbols.
        /// 
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ letter.length ≤ 250.
        /// 
        /// 
        /// [output] integer
        /// 
        /// The number of pairs of consecutive equal words in the letter.
        /// </remarks>
        public static int RepetitionEncryption(string letter)
        {
            Regex regex = new Regex("([a-zA-Z]+)[^a-zA-Z]+\\1(?![a-zA-Z])", RegexOptions.IgnoreCase);
            return regex.Matches(letter).Count;
        }


        /// <remarks>
        /// Implement the missing code, denoted by ellipses. You may not modify the pre-existing code.
        ///   In most role-playing games, die rolls required by the system are given in the form AdX.A and X are positive integers, separated by the letter 'd', which stands for die or dice.
        /// 
        ///  A is the number of times the die should be rolled(usually omitted if 1).
        /// X is the number of faces on the die.
        /// To this basic notation, an additive modifier can be appended that yields expressions in the form AdX+B or AdX-B.B is a number added to the sum of the rolls (or subtracted from it). So, 1d20-10 would indicate a single roll of a 20-sided die with 10 being subtracted from the result.
        /// 
        /// You're reading the rules of a famous Bugs and Bugfixes role-playing game involving dice. What is the maximum number of points you can get, assuming that you roll the dice according to each formula present within rules?
        /// 
        /// It is guaranteed that all the formulas that appear in rules are correct (i.e.A and X are always positive in a formula-like substring), and any two substrings that may be formulas do not overlap.
        /// 
        /// Example
        /// 
        /// 
        /// For rules = "Roll d6-3 and 4d4+3 to pick a weapon, and finish the boss with 3d7!",
        /// the output should be
        /// bugsAndBugfixes(rules) = 43.
        /// 
        /// 
        /// There are three formulas in the rules.
        /// 
        /// 
        /// d6-3 indicates a single roll of a 6-sided die, with 3 subtracted from the result. The maximum number that is possible to get is thus 6 - 3 = 3.
        /// 4d4+3 stands for 4 rolls of a 4-sided die, with 3 added to the result. It is possible to get 4 * 4 + 3 = 19 points.
        /// 3d7 means 3 rolls of a 7-sided die. The maximum number to obtain with it is 3 * 7 = 21.
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] string rules
        /// 
        /// 
        /// Rules given as a string.
        /// 
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ rules.length ≤ 100.
        /// 
        /// 
        /// [output] integer
        /// 
        /// The maximum possible number of points.If there are no formulas in rules, the output should be 0.
        /// </remarks>
        public static int BugsAndBugfixes(string rules)
        {
            Regex regex = new Regex(@"(\d*)d(\d+)([-+]\d+)*");
            MatchCollection formulas = regex.Matches(rules);

            int res = 0;
            foreach (Match match in formulas)
            {
                GroupCollection formula = match.Groups;
                int rolls = String.IsNullOrEmpty(formula[1].Value) ?
                  1 : Int32.Parse(formula[1].Value);
                int dieType = Int32.Parse(formula[2].Value);
                int formulaMax = rolls * dieType;

                if (!String.IsNullOrEmpty(formula[3].Value))
                {
                    if (formula[3].Value[0] == '-')
                    {
                        formulaMax -= Int32.Parse(formula[3].Value.Substring(1));
                    }
                    else
                    {
                        formulaMax += Int32.Parse(formula[3].Value.Substring(1));
                    }
                }

                res += formulaMax;
            }

            return res;
        }


    }
}
