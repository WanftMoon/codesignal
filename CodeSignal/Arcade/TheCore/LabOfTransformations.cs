using System;
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
        public static string characterParity(char symbol)
        {
            return char.IsDigit(symbol) ? (symbol % 2 == 0 ? "even" : "odd") : "not a digit";
        }


    }
}
