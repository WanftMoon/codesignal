using System;
using System.Linq;

namespace CodeSignal.Arcade.Intro
{
    public class DarkWilderness
    {

        /// <remarks>
        /// Caring for a plant can be hard work, but since you tend to it regularly, you have a plant that grows consistently. Each day, its height increases by a fixed amount represented by the integer upSpeed. But due to lack of sunlight, the plant decreases in height every night, by an amount represented by downSpeed.
        /// 
        /// Since you grew the plant from a seed, it started at height 0 initially.Given an integer desiredHeight, your task is to find how many days it'll take for the plant to reach this height.
        /// 
        /// xample
        /// 
        /// or upSpeed = 100, downSpeed = 10, and desiredHeight = 910, the output should be
        /// rowingPlant(upSpeed, downSpeed, desiredHeight) = 10.
        /// 
        /// 	Day	Night
        /// 	100	90
        /// 	190	180
        /// 	280	270
        /// 	370	360
        /// 	460	450
        /// 	550	540
        /// 	640	630
        /// 	730	720
        /// 	820	810
        /// 	910	900
        /// The plant first reaches a height of 910 on day 10.
        ///
        /// if(desiredHeight <= upSpeed)
        /// return 1;
        /// return (desiredHeight - upSpeed - 1) / (upSpeed - downSpeed) + 2;
        /// </remarks>
        public static int GrowingPlant(int upSpeed, int downSpeed, int desiredHeight)
        {
            int countDays = 0;
            int currentHeight = 0;

            while (currentHeight < desiredHeight)
            {
                countDays++;
                currentHeight += upSpeed;

                if (currentHeight >= desiredHeight)
                    break;

                currentHeight -= downSpeed;
            }

            return (countDays);
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
        public static int knapsackLight(int value1, int weight1, int value2, int weight2, int maxW)
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
        /// Given a string, output its longest prefix which contains only digits.
        /// 
        /// Example
        /// 
        /// For inputString = "123aa1", the output should be
        /// longestDigitsPrefix(inputString) = "123".
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// string inputString
        /// 
        /// Guaranteed constraints:
        /// 3 ≤ inputString.length ≤ 100.
        /// 
        /// [output] string
        ///
        /// Regex.Match(inputString, @"^\d+").Value
        /// </remarks>
        public static string LongestDigitsPrefix(string inputString)
        {
            return (string.Concat(inputString.TakeWhile(p => char.IsDigit(p))));
        }

        /// <remarks>
        /// Let's define digit degree of some positive integer as the number of times we need to replace this number with the sum of its digits until we get to a one digit number.
        /// 
        /// Given an integer, find its digit degree.
        /// 
        /// Example
        /// 
        /// 
        /// For n = 5, the output should be
        /// digitDegree(n) = 0;
        /// For n = 100, the output should be
        /// digitDegree(n) = 1.
        /// 1 + 0 + 0 = 1.
        /// For n = 91, the output should be
        /// digitDegree(n) = 2.
        /// 9 + 1 = 10 -> 1 + 0 = 1.
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// integer n
        /// 
        /// Guaranteed constraints:
        /// 5 ≤ n ≤ 109.
        /// 
        /// [output] integer
        /// </remarks>
        public static int DigitDegree(int n)
        {
            string val = $"{n}";
            int degree = 0;
            int sum = n;

            while (sum >= 10)
            {
                sum = val.Sum(p => int.Parse($"{p}"));

                degree++;
                val = $"{sum}";
            }

            return (degree);
        }

    }
}
