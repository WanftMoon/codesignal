using System;
namespace CodeSignal.Arcade.TheCore
{
    public class AtTheCrossroads
    {
        /// <remarks>
        /// You are playing an RPG game. Currently your experience points (XP) total is equal to experience. To reach the next level your XP should be at least at threshold. If you kill the monster in front of you, you will gain more experience points in the amount of the reward.
        /// 
        ///  Given values experience, threshold and reward, check if you reach the next level after killing the monster.
        /// 
        ///  Example
        /// 
        ///  For experience = 10, threshold = 15, and reward = 5, the output should be
        ///  reachNextLevel(experience, threshold, reward) = true;
        /// For experience = 10, threshold = 15, and reward = 4, the output should be
        /// reachNextLevel(experience, threshold, reward) = false.
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// integer experience
        /// 
        /// Guaranteed constraints:
        /// 3 ≤ experience ≤ 250.
        /// 
        /// [input]
        /// integer threshold
        /// 
        /// Guaranteed constraints:
        /// 5 ≤ threshold ≤ 300.
        /// 
        /// [input]
        /// integer reward
        /// 
        /// Guaranteed constraints:
        /// 2 ≤ reward ≤ 65.
        /// 
        /// [output] boolean
        /// 
        /// true if you reach the next level, false otherwise.
        /// </remarks>
        public static bool ReachNextLevel(int experience, int threshold, int reward)
        {
            return (experience + reward >= threshold);
        }

        /// <remarks>
        /// You found two items in a treasure chest! The first item weighs weight1 and is worth value1, and the second item weighs weight2 and is worth value2. What is the total maximum value of the items you can take with you, assuming that your max weight capacity is maxW and you can't come back for the items later?
        /// 
        /// Note that there are only two items and you can't bring more than one item of each type, i.e. you can't take two first items or two second items.
        /// 
        /// Example
        /// 
        /// For value1 = 10, weight1 = 5, value2 = 6, weight2 = 4, and maxW = 8, the output should be
        /// knapsackLight(value1, weight1, value2, weight2, maxW) = 10.
        /// 
        /// You can only carry the first item.
        /// 
        /// For value1 = 10, weight1 = 5, value2 = 6, weight2 = 4, and maxW = 9, the output should be
        /// knapsackLight(value1, weight1, value2, weight2, maxW) = 16.
        /// 
        /// You're strong enough to take both of the items with you.
        /// 
        /// For value1 = 5, weight1 = 3, value2 = 7, weight2 = 4, and maxW = 6, the output should be
        /// knapsackLight(value1, weight1, value2, weight2, maxW) = 7.
        /// 
        /// You can't take both items, but you can take any of them.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// integer value1
        /// 
        /// Guaranteed constraints:
        /// 2 ≤ value1 ≤ 20.
        /// 
        /// [input]
        /// integer weight1
        /// 
        /// Guaranteed constraints:
        /// 2 ≤ weight1 ≤ 10.
        /// 
        /// [input]
        /// integer value2
        /// 
        /// Guaranteed constraints:
        /// 2 ≤ value2 ≤ 20.
        /// 
        /// [input]
        /// integer weight2
        /// 
        /// Guaranteed constraints:
        /// 2 ≤ weight2 ≤ 10.
        /// 
        /// [input]
        /// integer maxW
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ maxW ≤ 20.
        /// 
        /// [output] integer
        ///
        /// 
        /// </remarks>
        public static int KnapsackLight(int value1, int weight1, int value2, int weight2, int maxW)
        {
            if (weight1 > maxW && weight2 > maxW)
                return (0);
            else if (weight1 + weight2 <= maxW)
                return (value1 + value2);
            else if (weight1 > maxW)
                return (value2);
            else if (weight2 > maxW)
                return (value1);

            return (Math.Max(value1, value2));
        }


        /// <remarks>
        /// You're given three integers, a, b and c. It is guaranteed that two of these integers are equal to each other. What is the value of the third integer?
        /// 
        /// Example
        /// 
        /// For a = 2, b = 7, and c = 2, the output should be
        /// extraNumber(a, b, c) = 7.
        /// 
        /// The two equal numbers are a and c.The third number (b) equals 7, which is the answer.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] integer a
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ a ≤ 109.
        /// 
        /// [input] integer b
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ b ≤ 109.
        /// 
        /// [input] integer c
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ c ≤ 109.
        /// 
        /// [output] integer
        ///
        /// a ^ b ^ c
        /// </remarks>
        public static int ExtraNumber(int a, int b, int c)
        {
            if (a == b)
                return (c);
            else if (b == c)
                return (a);

            return (b);
        }

        /// <remarks>
        /// Given integers a and b, determine whether the following pseudocode results in an infinite loop
        /// 
        /// while a is not equal to b do
        ///   increase a by 1
        ///   decrease b by 1
        /// Assume that the program is executed on a virtual machine which can store arbitrary long numbers and execute forever.
        /// 
        /// Example
        /// 
        /// For a = 2 and b = 6, the output should be
        /// isInfiniteProcess(a, b) = false;
        /// For a = 2 and b = 3, the output should be
        /// isInfiniteProcess(a, b) = true.
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         integer a
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ a ≤ 20.
        /// 
        /// [input]
        ///         integer b
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ b ≤ 20.
        /// 
        /// [output] boolean
        /// 
        /// true if the pseudocode will never stop, false otherwise.
        ///
        /// </remarks>
        public static bool IsInfiniteProcess(int a, int b)
        {
            return (a > b || (b - a) % 2 != 0);
        }


        /// <remarks>
        /// Consider an arithmetic expression of the form a#b=c. Check whether it is possible to replace # with one of the four signs: +, -, * or / to obtain a correct expression.
        /// 
        /// Example
        /// 
        /// For a = 2, b = 3, and c = 5, the output should be
        /// arithmeticExpression(a, b, c) = true.
        /// 
        /// We can replace # with a + to obtain 2 + 3 = 5, so the answer is true.
        /// 
        /// For a = 8, b = 2, and c = 4, the output should be
        /// arithmeticExpression(a, b, c) = true.
        /// 
        /// We can replace # with a / to obtain 8 / 2 = 4, so the answer is true.
        /// 
        /// For a = 8, b = 3, and c = 2, the output should be
        /// arithmeticExpression(a, b, c) = false.
        /// 
        /// 8 + 3 = 11 ≠ 2;
        /// 8 - 3 = 5 ≠ 2;
        /// 8 * 3 = 24 ≠ 2;
        /// 8 / 3 = 2.(6) ≠ 2.
        /// So the answer is false.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         integer a
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ a ≤ 20.
        /// 
        /// [input]
        ///         integer b
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ b ≤ 20.
        /// 
        /// [input]
        ///         integer c
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ c ≤ 20.
        /// 
        /// [output] boolean
        /// 
        /// true if the desired replacement is possible, false otherwise.
        ///         /// </remarks>
        public static bool ArithmeticExpression(int a, int b, int c)
        {

            if (a + b == c || a == b * c || a * b == c || a - b == c)
                return (true);

            return (false);
        }

        /// <remarks>
        /// In tennis, the winner of a set is based on how many games each player wins. The first player to win 6 games is declared the winner unless their opponent had already won 5 games, in which case the set continues until one of the players has won 7 games.
        /// 
        /// Given two integers score1 and score2, your task is to determine if it is possible for a tennis set to be finished with a final score of score1 : score2.
        /// 
        /// Example
        /// 
        /// For score1 = 3 and score2 = 6, the output should be
        /// tennisSet(score1, score2) = true.
        /// 
        /// Since player 1 hadn't reached 5 wins, the set ends once player 2 has won 6 games.
        /// 
        /// For score1 = 8 and score2 = 5, the output should be
        /// tennisSet(score1, score2) = false.
        /// 
        /// Since both players won at least 5 games, the set would've ended once one of them won the 7th one.
        /// 
        /// For score1 = 6 and score2 = 5, the output should be
        /// tennisSet(score1, score2) = false.
        /// 
        /// This set will continue until one of these players wins their 7th game, so this can't be the final score.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         integer score1
        /// 
        /// Number of games won by the 1st player, non-negative integer.
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ score1 ≤ 10.
        /// 
        /// [input] integer score2
        /// 
        /// Number of games won by the 2nd player, non-negative integer.
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ score2 ≤ 10.
        /// 
        /// [output] boolean
        /// 
        /// true if score1 : score2 represents a possible score for an ended set, false otherwise.
        ///
        ///     if ( Math.Min(score1, score2) >= 7 )
        ///     {
        ///         return false;
        ///     }
        ///     
        ///     if (Math.Min(score1, score2) >= 5 )
        ///     {
        ///         return Math.Max(score1, score2) == 7;
        ///     }
        /// 
        /// return Math.Max(score1, score2) == 6;
        /// </remarks>
        public static bool TennisSet(int score1, int score2)
        {
            return (score1 >= 5 && score2 >= 5) ?
            (score1 == 7 || score2 == 7) && (score1 <= 7 && score2 <= 7) && score1 != score2 :
            (score1 == 6 || score2 == 6) && (score1 <= 6 && score2 <= 6) && score1 != score2;
        }

        /// <remarks>
        /// Once Mary heard a famous song, and a line from it stuck in her head. That line was "Will you still love me when I'm no longer young and beautiful?". Mary believes that a person is loved if and only if he/she is both young and beautiful, but this is quite a depressing thought, so she wants to put her belief to the test.
        /// 
        /// Knowing whether a person is young, beautiful and loved, find out if they contradict Mary's belief.
        /// 
        /// A person contradicts Mary's belief if one of the following statements is true:
        /// 
        /// they are young and beautiful but not loved;
        /// they are loved but not young or not beautiful.
        /// Example
        /// 
        /// For young = true, beautiful = true, and loved = true, the output should be
        /// willYou(young, beautiful, loved) = false.
        /// 
        /// Young and beautiful people are loved according to Mary's belief.
        /// 
        /// For young = true, beautiful = false, and loved = true, the output should be
        /// willYou(young, beautiful, loved) = true.
        /// 
        /// Mary doesn't believe that not beautiful people can be loved.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 0.5 seconds(cpp)
        /// 
        /// [input]
        ///  boolean young
        /// 
        /// [input] boolean beautiful
        /// 
        /// [input] boolean loved
        /// 
        /// [output] boolean
        /// 
        /// true if the person contradicts Mary's belief, false otherwise.
        ///  loved != young && beautiful
        /// </remarks>
        public static bool WillYou(bool young, bool beautiful, bool loved)
        {
            return ((young && beautiful && !loved) || (loved && !young) || (loved && !beautiful));
        }

        /// <remarks>
        /// You just bought a public transit card that allows you to ride the Metro for a certain number of days.
        /// 
        ///     Here is how it works: upon first receiving the card, the system allocates you a 31-day pass, which equals the number of days in January.The second time you pay for the card, your pass is extended by 28 days, i.e.the number of days in February(note that leap years are not considered), and so on.The 13th time you extend the pass, you get 31 days again.
        /// 
        ///     You just ran out of days on the card, and unfortunately you've forgotten how many times your pass has been extended so far. However, you do remember the number of days you were able to ride the Metro during this most recent month. Figure out the number of days by which your pass will now be extended, and return all the options as an array sorted in increasing order.
        /// 
        /// 
        ///     Example
        /// 
        ///     For lastNumberOfDays = 30, the output should be
        ///     metroCard(lastNumberOfDays) = [31].
        ///     
        /// 
        ///     There are 30 days in April, June, September and November, so the next months to consider are May, July, October or December.All of them have exactly 31 days, which means that you will definitely get a 31-days pass the next time you extend your card.
        /// 
        ///     Input/Output
        /// 
        ///     [execution time limit] 3 seconds (cs)
        /// 
        ///     [input] integer lastNumberOfDays
        /// 
        ///     A positive integer, the number of days for which the card was extended the last time.
        /// 
        /// 
        ///     Guaranteed constraints:
        /// lastNumberOfDays = 28 or lastNumberOfDays = 30 or lastNumberOfDays = 31.
        ///     
        /// 
        ///     [output] array.integer
        /// 
        ///     An array of positive integers, the possible number of days for which you will extend your pass. The elements of the array can only be equal to 28, 30 or 31 and must be sorted in increasing order.
        /// 
        /// 
        /// </remarks>
        public static int[] MetroCard(int lastNumberOfDays)
        {
            return (lastNumberOfDays == 28 || lastNumberOfDays == 30 ? new int[] { 31 } : new int[] { 28, 30, 31 });
        }
    }
}
