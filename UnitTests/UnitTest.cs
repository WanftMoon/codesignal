using System;
using CodeSignal.InterviewPratice.Arrays;
using Xunit;

namespace UnitTests
{
    public class UnitTest
    {
        [Fact]
        public void FirstDuplicateTest()
        {
            //2, 1, 3, 5, 3, 2 = 3
            int result = FirstDuplicate.Solve(new int[] { 2, 1, 3, 5, 3, 2 });

            Assert.True(result == 3);
        }

        [Fact]
        public void firstNotRepeatingCharacterTest()
        {
            //abacabad
            char result = FirstNotRepeatingCharacter.Solve("abacabad");

            Assert.True(result == 'c');
        }
    }
}

