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
        [Fact]
        public void FirstDuplicateTest()
        {
            //2, 1, 3, 5, 3, 2 = 3
            int result = FirstDuplicate.Solve(new int[] { 2, 1, 3, 5, 3, 2 });

            Assert.True(result == 3);
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void FirstNotRepeatingCharacterTest()
        {
            //abacabad
            char result = FirstNotRepeatingCharacter.Solve("abacabad");

            Assert.True(result == 'c');
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

