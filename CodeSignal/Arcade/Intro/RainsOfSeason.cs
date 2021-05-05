using System;
namespace CodeSignal.Arcade.Intro
{
    public class RainsOfSeason
    {

        /// <remarks>
        /// Given an array of integers, replace all the occurrences of elemToReplace with substitutionElem.
        /// 
        /// Example
        /// 
        /// For inputArray = [1, 2, 1], elemToReplace = 1, and substitutionElem = 3, the output should be
        /// arrayReplace(inputArray, elemToReplace, substitutionElem) = [3, 2, 3].
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// array.integer inputArray
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ inputArray.length ≤ 104,
        /// 0 ≤ inputArray[i] ≤ 109.
        /// 
        /// [input]
        /// integer elemToReplace
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ elemToReplace ≤ 109.
        /// 
        /// [input]
        /// integer substitutionElem
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ substitutionElem ≤ 109.
        /// 
        /// [output] array.integer
        ///
        /// inputArray.Select( x => x == elemToReplace? substitutionElem : x)
        /// </remarks>
        public static int[] ArrayReplace(int[] inputArray, int elemToReplace, int substitutionElem)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] == elemToReplace)
                    inputArray[i] = substitutionElem;
            }

            return (inputArray);
        }

        /// <remarks>
        /// Check if all digits of the given integer are even.
        /// 
        /// Example
        /// 
        /// For n = 248622, the output should be
        /// venDigitsOnly(n) = true;
        /// or n = 642386, the output should be
        /// venDigitsOnly(n) = false.
        /// nput/Output
        /// 
        /// execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// integer n
        /// 
        /// uaranteed constraints:
        ///  ≤ n ≤ 109.
        /// 
        /// [output] boolean
        /// 
        /// rue if all digits of n are even, false otherwise.
        /// n.ToString().All(_ => _ % 2 < 1)
        /// </remarks>
        public static bool EvenDigitsOnly(int n)
        {
            string num = $"{n}";

            for (int i = 0; i < num.Length; i++)
            {
                int val = 0;

                if (int.TryParse($"{num[i]}", out val))
                {
                    if (val % 2 == 1)
                        return (false);
                }
            }

            return (true);
        }

        /// <remarks>
        /// Correct variable names consist only of English letters, digits and underscores and they can't start with a digit.
        /// 
        /// Check if the given string is a correct variable name.
        /// 
        /// Example
        /// 
        /// 
        /// For name = "var_1__Int", the output should be
        /// variableName(name) = true;
        /// For name = "qq-q", the output should be
        /// variableName(name) = false;
        /// For name = "2w2", the output should be
        /// variableName(name) = false.
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// string name
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ name.length ≤ 10.
        /// 
        /// [output] boolean
        /// 
        /// true if name is a correct variable name, false otherwise.
        /// ^[a-zA-Z_][a-zA-Z\\d_]*$
        /// </remarks>
        public static bool VariableName(string name)
        {
            if (char.IsDigit(name[0]))
                return (false);

            for (int i = 0; i < name.Length; i++)
            {
                if (!char.IsLetterOrDigit(name[i]) && name[i] != '_')
                    return (false);
            }

            return (true);
        }


    }
}
