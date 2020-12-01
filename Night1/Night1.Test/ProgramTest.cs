using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Night1.Test
{
    [TestClass]
    public class ProgramTest
    {
        [DataTestMethod]
        [DataRow(2019, new int[] { 2019, 4, 5, 1 })]
        public void Verify_Compare(int compareNum, int[] input)
        {
            Program.Compare(compareNum, input).Should().Be(2019);
        }

        [DataTestMethod]
        [DataRow(2019, 1)]
        [DataRow(1570, 450)]
        public void Verify_Sum_Is_2020(int num1, int num2)
        {
            Program.SumIs2020(num1, num2).Should().BeTrue();
        }
    }
}
