using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodeSignal.Arcade.TheCore
{
    public class LabOfTransformations
    {

        /// <remarks>
        /// Given a character, check if it represents an odd digit, an even digit or not a digit at all.
        /// 
        /// Example
        /// 
        /// For symbol = '5', the output should be
        /// characterParity(symbol) = "odd";
        /// For symbol = '8', the output should be
        /// characterParity(symbol) = "even";
        /// For symbol = 'q', the output should be
        /// characterParity(symbol) = "not a digit".
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         char symbol
        /// 
        /// A symbol to check.
        /// 
        /// Guaranteed constraints:
        /// symbol is guaranteed to be a UTF-8 symbol.
        /// 
        /// [output] string
        /// </remarks>
        public static string CharacterParity(char symbol)
        {
            return char.IsDigit(symbol) ? (symbol % 2 == 0 ? "even" : "odd") : "not a digit";
        }


        /// <remarks>
        /// Define an alphabet reflection as follows: a turns into z, b turns into y, c turns into x, ..., n turns into m, m turns into n, ..., z turns into a.
        /// 
        /// Define a string reflection as the result of applying the alphabet reflection to each of its characters.
        /// 
        /// Reflect the given string.
        /// 
        /// 
        /// Example
        /// 
        /// For inputString = "name", the output should be
        /// reflectString(inputString) = "mznv".
        /// 
        /// Input / Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] string inputString
        /// 
        /// 
        /// A string of lowercase characters.
        /// 
        /// 
        /// Guaranteed constraints:
        /// 3 ≤ inputString.length ≤ 1000.
        /// 
        /// 
        /// [output] string
        /// inputString.Select(c => (char)(('z'-c)+'a'))
        /// </remarks>
        public static string ReflectString(string inputString)
        {
            var str = inputString.ToArray();

            for (int i = 0; i < str.Length; i++)
            {
                int offset = str[i] - 'a';

                str[i] = (char)('z' - offset);
            }

            return string.Concat(str);
        }


        /// <remarks>
        /// Your Informatics teacher at school likes coming up with new ways to help you understand the material. When you started studying numeral systems, he introduced his own numeral system, which he's convinced will help clarify things. His numeral system has base 26, and its digits are represented by English capital letters - A for 0, B for 1, and so on.
        /// 
        /// The teacher assigned you the following numeral system exercise: given a one-digit number, you should find all unordered pairs of one-digit numbers whose values add up to the number.
        /// 
        /// Example
        /// 
        /// For number = 'G', the output should be
        /// newNumeralSystem(number) = ["A + G", "B + F", "C + E", "D + D"].
        /// 
        /// Translating this into the decimal numeral system we get: number = 6, so it is ["0 + 6", "1 + 5", "2 + 4", "3 + 3"].
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] char number
        /// 
        /// A character representing a correct one-digit number in the new numeral system.
        /// 
        /// Guaranteed constraints:
        /// 'A' ≤ number ≤ 'Z'.
        /// 
        /// [output] array.string
        /// 
        /// An array of strings in the format "letter1 + letter2", where "letter1" and "letter2" are correct one-digit numbers in the new numeral system.The strings should be sorted by "letter1".
        /// 
        /// Note that "letter1 + letter2" and "letter2 + letter1" are equal pairs and we don't consider them to be different.
        /// </remarks>
        public static string[] NewNumeralSystem(char number)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < (number - 'A') / 2 + 1; i++)
            {
                result.Add($"{(char)(i + 'A')} + {(char)(number - i)}");
            }

            return result.ToArray();
        }

        /// <remarks>
        /// You've intercepted an encrypted message, and you are really curious about its contents. You were able to find out that the message initially contained only lowercase English letters, and was encrypted with the following cipher:
        /// 
        /// Let all letters from 'a' to 'z' correspond to the numbers from 0 to 25, respectively.
        /// The number corresponding to the ith letter of the encrypted message is then equal to the sum of numbers corresponding to the first i letters of the initial unencrypted message modulo 26.
        /// Now that you know how the message was encrypted, implement the algorithm to decipher it.
        /// 
        /// Example
        /// 
        /// For message = "taiaiaertkixquxjnfxxdh", the output should be
        /// cipher26(message) = "thisisencryptedmessage".
        /// 
        /// The initial message "thisisencryptedmessage" was encrypted as follows:
        /// 
        /// letter 0: t -> 19 -> t;
        ///         letter 1: th -> (19 + 7) % 26 -> 0 -> a;
        /// letter 2: thi -> (19 + 7 + 8) % 26 -> 8 -> i;
        /// etc.
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         string message
        /// 
        /// An encrypted string containing only lowercase English letters.
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ message.length ≤ 200.
        /// 
        /// [output] string
        /// 
        /// A decrypted message.
        /// </remarks>
        public static string Cipher26(string message)
        {
            string decrypted = $"{message[0]}";

            for (int i = 1; i < message.Length; i++)
            {
                decrypted += (char)((message[i] - message[i - 1] + 26) % 26 + 'a');
            }

            return decrypted;
        }

        /// <remarks>
        /// When you recently visited your little nephew, he told you a sad story: there's a bully at school who steals his lunch every day, and locks it away in his locker. He also leaves a note with a strange, coded message. Your nephew gave you one of the notes in hope that you can decipher it for him. And you did: it looks like all the digits in it are replaced with letters and vice versa. Digit 0 is replaced with 'a', 1 is replaced with 'b' and so on, with digit 9 replaced by 'j'.
        /// 
        /// The note is different every day, so you decide to write a function that will decipher it for your nephew on an ongoing basis.
        /// 
        /// Example
        /// 
        /// 
        /// For note = "you'll n4v4r 6u4ss 8t: cdja", the output should be
        /// stolenLunch(note) = "you'll never guess it: 2390".
        /// 
        /// Input / Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] string note
        /// 
        /// 
        /// A string consisting of lowercase English letters, digits, punctuation marks and whitespace characters (' ').
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ note.length ≤ 500.
        /// 
        /// [output]
        /// string
        /// 
        /// The deciphered note.
        /// 
        /// </remarks>
        public static string StolenLunch(string note)
        {
            var str = note.ToArray();
            var numbers = "abcdefghij";

            for (int i = 0; i < str.Length; i++)
            {
                if (numbers.Contains(str[i]))
                    str[i] = (char)(str[i] - 'a' + '0');
                else
                    str[i] = char.IsDigit(str[i]) ? (char)(str[i] - '0' + 'a') : str[i];
            }

            return (string.Concat(str));
        }

        /// <remarks>
        /// Given two version strings composed of several non-negative decimal fields separated by periods ("."), both strings contain equal number of numeric fields. Return true if the first version is higher than the second version and false otherwise.
        /// 
        /// The syntax follows the regular semver ordering rules:
        /// 
        /// 1.0.5 < 1.1.0 < 1.1.5 < 1.1.10 < 1.2.0 < 1.2.2
        /// < 1.2.10 < 1.10.2 < 2.0.0 < 10.0.0
        /// There are no leading zeros in any of the numeric fields, i.e.you do not have to handle inputs like 100.020.003 (it would instead be given as 100.20.3).
        /// 
        /// Example
        /// 
        /// For ver1 = "1.2.2" and ver2 = "1.2.0", the output should be
        /// higherVersion(ver1, ver2) = true;
        /// For ver1 = "1.0.5" and ver2 = "1.1.0", the output should be
        /// higherVersion(ver1, ver2) = false.
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         string ver1
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ ver1.length ≤ 15.
        /// 
        /// [input]
        ///         string ver2
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ ver2.length ≤ 15.
        /// 
        /// [output] boolean
        /// </remarks>
        public static bool HigherVersion(string ver1, string ver2)
        {
            var str1Parts = ver1.Split(".");
            var str2Parts = ver2.Split(".");

            if (str1Parts.Length == 0)
                return (int.Parse(ver1) > int.Parse(ver2));

            for (int i = 0; i < str1Parts.Length; i++)
            {
                if (int.Parse(str1Parts[i]) > int.Parse(str2Parts[i]))
                    return (true);
                else if (int.Parse(str1Parts[i]) < int.Parse(str2Parts[i]))
                    return (false);
            }

            return (false);
        }

        /// <remarks>
        /// Consider the following ciphering algorithm:
        /// 
        /// For each character replace it with its code.
        /// Concatenate all of the obtained numbers.
        /// Given a ciphered string, return the initial one if it is known that it consists only of lowercase letters.
        /// 
        /// 
        /// Note: here the character's code means its decimal ASCII code, the numerical representation of a character used by most modern programming languages.
        /// 
        /// 
        /// Example
        /// 
        /// For cipher = "10197115121", the output should be
        /// decipher(cipher) = "easy".
        /// 
        /// Explanation: charCode('e') = 101, charCode('a') = 97, charCode('s') = 115 and charCode('y') = 121.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// string cipher
        /// 
        /// A non-empty string which is guaranteed to be a cipher for some other string of lowercase letters.
        /// 
        /// Guaranteed constraints:
        /// 2 ≤ cipher.length ≤ 100.
        /// 
        /// [output] string
        /// 
        /// </remarks>
        public static string Decipher(string cipher)
        {
            string dec = "";
            string letter = "";

            for (int i = 0; i < cipher.Length; i++)
            {
                letter += cipher[i];

                int candidate = int.Parse(letter);

                if (candidate >= 'a' && candidate <= 'z')
                {
                    dec += (char)candidate;
                    letter = "";
                }
            }

            return (dec);
        }


        /// <remarks>
        /// An alphanumeric ordering of strings is defined as follows: each string is considered as a sequence of tokens, where each token is a letter or a number (as opposed to an isolated digit, as is the case in lexicographic ordering). For example, the tokens of the string "ab01c004" are [a, b, 01, c, 004]. In order to compare two strings, we'll first break them down into tokens and then compare the corresponding pairs of tokens with each other (i.e. compare the first token of the first string with the first token of the second string, etc).
        /// 
        /// Here is how tokens are compared:
        /// 
        /// If a letter is compared with another letter, the usual alphabetical order applies.
        /// A number is always considered less than a letter.
        /// When two numbers are compared, their values are compared. Leading zeros, if any, are ignored.
        /// If at some point one string has no more tokens left while the other one still does, the one with fewer tokens is considered smaller.
        /// 
        /// If the two strings s1 and s2 appear to be equal, consider the smallest index i such that tokens(s1)[i] and tokens(s2)[i] (where tokens(s)[i] is the ith token of string s) differ only by the number of leading zeros.If no such i exists, the strings are indeed equal.Otherwise, the string whose ith token has more leading zeros is considered smaller.
        /// 
        /// Here are some examples of comparing strings using alphanumeric ordering.
        /// 
        /// "a" < "a1" < "ab"
        /// "ab42" < "ab000144" < "ab00144" < "ab144" < "ab000144x"
        /// "x11y012" < "x011y13"
        /// Your task is to return true if s1 is strictly less than s2, and false otherwise.
        /// 
        /// Example
        /// 
        /// For s1 = "a" and s2 = "a1", the output should be alphanumericLess(s1, s2) = true;
        /// 
        /// These strings have equal first tokens, but since s1 has fewer tokens than s2, it's considered smaller.
        /// 
        /// For s1 = "ab" and s2 = "a1", the output should be alphanumericLess(s1, s2) = false;
        /// 
        /// These strings also have equal first tokens, but since numbers are considered less than letters, s1 is larger.
        /// 
        /// For s1 = "b" and s2 = "a1", the output should be alphanumericLess(s1, s2) = false.
        /// 
        /// Since b is greater than a, s1 is larger.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///     string s1
        /// 
        /// A string consisting of English letters and digits.
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ s1.length ≤ 20.
        /// 
        /// [input]
        ///     string s2
        /// 
        /// A string consisting of English letters and digits.
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ s2.length ≤ 20.
        /// 
        /// [output] boolean
        /// 
        /// true if s1 is alphanumerically strictly less than s2, false otherwise.
        /// </remarks>
        bool alphanumericLess(string s1, string s2)
        {
            var tokensS1 = Regex.Matches(s1, "[a-z]|[0-9]+").Select(m => m.ToString()).ToList();
            var tokensS2 = Regex.Matches(s2, "[a-z]|[0-9]+").Select(m => m.ToString()).ToList();
            int zeroIndex = -1;

            for (int i = 0; i < tokensS1.Count; i++)
            {
                if (i >= tokensS2.Count)
                    return (false);

                decimal resultS1 = 0;
                decimal resultS2 = 0;
                bool isTokenS1Number = decimal.TryParse(tokensS1[i], out resultS1);
                bool isTokenS2Number = decimal.TryParse(tokensS2[i], out resultS2);

                Console.WriteLine($"{resultS1} {resultS2} {tokensS1[i]} {tokensS2[i]} {tokensS2[i].TakeWhile(c => c == '0').Count()}");

                //both Numbers
                if ((isTokenS1Number && isTokenS2Number) && resultS1 < resultS2)
                    return (true);
                else if ((isTokenS1Number && isTokenS2Number) && resultS1 > resultS2)
                    return (false);
                else if (isTokenS1Number && !isTokenS2Number)
                    return (true);
                else if (!isTokenS1Number && isTokenS2Number)
                    return (false);
                else if ((!isTokenS1Number && !isTokenS2Number) && tokensS1[i][0] < tokensS2[i][0])
                    return (true);
                else if ((!isTokenS1Number && !isTokenS2Number) && tokensS1[i][0] > tokensS2[i][0])
                    return (false);

                //both numbers, check if s2 has more leading zeros
                if ((isTokenS1Number && isTokenS2Number) && zeroIndex == -1 && tokensS2[i].TakeWhile(c => c == '0').Count() > tokensS1[i].TakeWhile(c => c == '0').Count())
                    zeroIndex = 2;
                else if ((isTokenS1Number && isTokenS2Number) && zeroIndex == -1 && tokensS2[i].TakeWhile(c => c == '0').Count() < tokensS1[i].TakeWhile(c => c == '0').Count())
                    zeroIndex = 1;
            }
            Console.WriteLine($"zero index {zeroIndex}");

            //zero index == 2, s2 is smaller, index == -1, no zero index whas found
            if (tokensS1.Count == tokensS2.Count && (zeroIndex == 2 || zeroIndex == -1))
                return (false);

            return (true);
        }



    }
}
