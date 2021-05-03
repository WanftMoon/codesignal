using System;
namespace CodeSignal.Arcade.Intro
{
    public class IslandOfKnowledge
    {
        /// <remarks>
        /// Call two arms equally strong if the heaviest weights they each are able to lift are equal.
        /// 
        /// Call two people equally strong if their strongest arms are equally strong(the strongest arm can be both the right and the left), and so are their weakest arms.
        /// 
        /// Given your and your friend's arms' lifting capabilities find out if you two are equally strong.
        /// 
        /// Example
        /// 
        /// For yourLeft = 10, yourRight = 15, friendsLeft = 15, and friendsRight = 10, the output should be
        /// areEquallyStrong(yourLeft, yourRight, friendsLeft, friendsRight) = true;
        /// For yourLeft = 15, yourRight = 10, friendsLeft = 15, and friendsRight = 10, the output should be
        /// areEquallyStrong(yourLeft, yourRight, friendsLeft, friendsRight) = true;
        /// For yourLeft = 15, yourRight = 10, friendsLeft = 15, and friendsRight = 9, the output should be
        /// areEquallyStrong(yourLeft, yourRight, friendsLeft, friendsRight) = false.
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// integer yourLeft
        /// 
        /// A non-negative integer representing the heaviest weight you can lift with your left arm.
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ yourLeft ≤ 20.
        /// 
        /// [input]
        /// integer yourRight
        /// 
        /// A non-negative integer representing the heaviest weight you can lift with your right arm.
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ yourRight ≤ 20.
        /// 
        /// [input]
        /// integer friendsLeft
        /// 
        /// A non-negative integer representing the heaviest weight your friend can lift with his or her left arm.
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ friendsLeft ≤ 20.
        /// 
        /// [input] integer friendsRight
        /// 
        /// A non-negative integer representing the heaviest weight your friend can lift with his or her right arm.
        /// 
        /// Guaranteed constraints:
        /// 0 ≤ friendsRight ≤ 20.
        /// 
        /// [output] boolean
        /// 
        /// true if you and your friend are equally strong, false otherwise.
        /// </remarks>
        public static bool AreEquallyStrong(int yourLeft, int yourRight, int friendsLeft, int friendsRight)
        {
            return ((yourLeft == friendsLeft && yourRight == friendsRight) || ((yourLeft == friendsRight && yourRight == friendsLeft)));
        }


        /// <remarks>
        /// Given an array of integers, find the maximal absolute difference between any two of its adjacent elements.
        /// 
        /// Example
        /// 
        /// For inputArray = [2, 4, 1, 0], the output should be
        /// arrayMaximalAdjacentDifference(inputArray) = 3.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// array.integer inputArray
        /// 
        /// Guaranteed constraints:
        /// 3 ≤ inputArray.length ≤ 10,
        /// -15 ≤ inputArray[i] ≤ 15.
        /// 
        /// [output]
        /// integer
        /// 
        /// The maximal absolute difference.
        /// </remarks>
        public int arrayMaximalAdjacentDifference(int[] inputArray)
        {
            int max = 0;

            for (int i = 0; i < inputArray.Length - 1; i++)
                max = Math.Max(max, Math.Abs(inputArray[i] - inputArray[i + 1]));

            return (max);
        }


    }
}
