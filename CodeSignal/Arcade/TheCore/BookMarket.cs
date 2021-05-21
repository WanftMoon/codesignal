using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeSignal.Arcade.TheCore
{
    public class BookMarket
    {
        /// <remarks>
        /// Given a string, enclose it in round brackets.
        /// 
        /// Example
        /// 
        /// For inputString = "abacaba", the output should be
        /// encloseInBrackets(inputString) = "(abacaba)".
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// string inputString
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ inputString.length ≤ 10.
        /// 
        /// [output] string
        /// </remarks>
        public static string EncloseInBrackets(string inputString)
        {
            return ($"({inputString})");
        }


        /// <remarks>
        /// Proper nouns always begin with a capital letter, followed by small letters.
        /// 
        /// Correct a given proper noun so that it fits this statement.
        /// 
        /// Example
        /// 
        /// For noun = "pARiS", the output should be
        /// properNounCorrection(noun) = "Paris";
        /// For noun = "John", the output should be
        /// properNounCorrection(noun) = "John".
        /// Input / Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] string noun
        /// 
        /// 
        /// A string representing a proper noun with a mix of capital and small English letters.
        /// 
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ noun.length ≤ 10.
        /// 
        /// 
        /// [output] string
        /// 
        /// Corrected (if needed) noun.
        /// </remarks>
        public static string ProperNounCorrection(string noun)
        {
            return string.Concat(noun.Select((c, i) => i == 0 ? char.ToUpper(c) : char.ToLower(c)));
        }


        /// <remarks>
        /// Determine whether the given string can be obtained by one concatenation of some string to itself.
        /// 
        /// Example
        /// 
        /// For inputString = "tandemtandem", the output should be
        /// isTandemRepeat(inputString) = true;
        /// For inputString = "qqq", the output should be
        /// isTandemRepeat(inputString) = false;
        /// For inputString = "2w2ww", the output should be
        /// isTandemRepeat(inputString) = false.
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// string inputString
        /// 
        /// Guaranteed constraints:
        /// 2 ≤ inputString.length ≤ 20.
        /// 
        /// [output] boolean
        /// 
        /// true if inputString represents a string concatenated to itself, false otherwise.
        /// (\\w+)\\1
        /// </remarks>
        public static bool IsTandemRepeat(string inputString)
        {
            return (Regex.IsMatch(inputString, "^(\\w+)\\1$"));
        }

        /// <remarks>
        /// Given a string, check if it can become a palindrome through a case change of some (possibly, none) letters.
        /// 
        /// Example
        /// 
        /// For inputString = "AaBaa", the output should be
        /// isCaseInsensitivePalindrome(inputString) = true.
        /// 
        /// "aabaa" is a palindrome as well as "AABAA", "aaBaa", etc.
        /// 
        /// For inputString = "abac", the output should be
        /// isCaseInsensitivePalindrome(inputString) = false.
        /// 
        /// All the strings which can be obtained via changing case of some group of letters, i.e. "abac", "Abac", "aBAc" and 13 more, are not palindromes.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// string inputString
        /// 
        /// Non-empty string consisting of English letters.
        /// 
        /// Guaranteed constraints:
        /// 4 ≤ inputString.length ≤ 10.
        /// 
        /// [output] boolean
        /// </remarks>
        public static bool IsCaseInsensitivePalindrome(string inputString)
        {
            return (inputString.ToLower().Equals(string.Concat(inputString.ToLower().Reverse())));
        }

        /// <remarks>
        /// An email address such as "John.Smith@example.com" is made up of a local part ("John.Smith"), an "@" symbol, then a domain part ("example.com").
        /// 
        ///  The domain name part of an email address may only consist of letters, digits, hyphens and dots.The local part, however, also allows a lot of different special characters.Here you can look at several examples of correct and incorrect email addresses.
        /// 
        /// 
        /// Given a valid email address, find its domain part.
        /// 
        /// 
        /// Example
        /// 
        /// For address = "prettyandsimple@example.com", the output should be
        /// findEmailDomain(address) = "example.com";
        ///  For address = "fully-qualified-domain@codesignal.com", the output should be
        ///  findEmailDomain(address) = "codesignal.com".
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
        /// </remarks>
        public static string FindEmailDomain(string address)
        {
            return address[(address.LastIndexOf('@') + 1)..];
        }

        /// <remarks>
        /// You are implementing your own HTML editor. To make it more comfortable for developers you would like to add an auto-completion feature to it.
        /// 
        /// Given the starting HTML tag, find the appropriate end tag which your editor should propose.
        /// 
        /// If you are not familiar with HTML, consult with this note.
        /// 
        /// Example
        /// 
        /// For startTag = "<button type='button' disabled>", the output should be
        /// htmlEndTagByStartTag(startTag) = "</button>";
        /// For startTag = "<i>", the output should be
        /// htmlEndTagByStartTag(startTag) = "</i>".
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// string startTag
        /// 
        /// Guaranteed constraints:
        /// 3 ≤ startTag.length ≤ 75.
        /// 
        /// [output] string
        ///  "</" + startTag.Split("< >".ToArray())[1] + ">";
        /// </remarks>
        public static string HtmlEndTagByStartTag(string startTag)
        {
            StringBuilder endTag = new StringBuilder();

            for (int i = 0; i < startTag.Length; i++)
            {
                if (startTag[i] == ' ' || startTag[i] == '>')
                    break;

                endTag.Append(startTag[i]);
            }

            endTag.Insert(1, '/');
            endTag.Append('>');

            return (endTag.ToString());
        }

        /// <remarks>
        /// Some file managers sort filenames taking into account case of the letters, others compare strings as if all of the letters are of the same case. That may lead to different ways of filename ordering.
        /// 
        /// Call two filenames an unstable pair if their ordering depends on the case.
        /// 
        /// To compare two filenames a and b, find the first position i at which a[i] ≠ b[i]. If a[i] < b[i], then a<b. Otherwise a > b.If such position doesn't exist, the shorter string goes first.
        /// 
        /// Given two filenames, check whether they form an unstable pair.
        /// 
        /// Example
        /// 
        /// For filename1 = "aa" and filename2 = "AAB", the output should be
        /// isUnstablePair(filename1, filename2) = true.
        /// 
        /// Because "AAB" < "aa", but "AAB" > "AA".
        /// 
        /// For filename1 = "A" and filename2 = "z", the output should be
        /// isUnstablePair(filename1, filename2) = false.
        /// 
        /// Both "A" < "z" and "a" < "z".
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] string filename1
        /// 
        /// A non-empty string of English letters and digits.
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ filename1.length ≤ 10.
        /// 
        /// [input] string filename2
        /// 
        /// A non-empty string of English letters and digits. It's guaranteed that there is no ambiguity, i.e. even being considered in the same case strings are never equal.
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ filename2.length ≤ 10.
        /// 
        /// [output] boolean
        /// 
        /// true if filename1 and filename2 form an unstable pair, false otherwise.
        ///         /// </remarks>
        public static bool isUnstablePair(string filename1, string filename2)
        {
            return String.CompareOrdinal(filename1, filename2) * String.Compare(filename1.ToUpper(), filename2.ToUpper()) < 0;
        }

    }
}
