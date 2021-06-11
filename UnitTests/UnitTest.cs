using System;
using CodeSignal.InterviewPratice.Arrays;
using Xunit;

namespace UnitTests
{
    public class UnitTest
    {
        /// <summary>
        /// 
        /// </summary>
        [Theory]
        [InlineData(new int[] { 2, 1, 3, 5, 3, 2 }, 3)]
        [InlineData(new int[] { 2, 2 }, 2)]
        [InlineData(new int[] { 2, 4, 3, 5, 1 }, -1)]
        public void FirstDuplicateTest(int [] input, int expected)
        {
            int result = FirstDuplicate.Solve(input);

            Assert.True(result == expected);
        }

        /// <summary>
        /// 
        /// </summary>
        [Theory]
        [InlineData("abacabad", 'c')]
        [InlineData("abacabaabacaba", '_')]
        public void FirstNotRepeatingCharacterTest(string input, char expected)
        {
            //abacabad
            char result = FirstNotRepeatingCharacter.Solve(input);

            Assert.True(result == expected);
        }


        [Fact]
        public void RotateImageTest()
        {
            int[][] a = RotateImage.Solve(new int[][]
            {
                new int[]{1, 2, 3 },
                new int[]{4, 5, 6 },
                new int[]{7, 8, 9 }
            });

            //check top corner
            Assert.True(a[0][0] == 7 && a[0][2] == 1);
        }
    }
}

