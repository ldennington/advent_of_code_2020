using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Night2.Test
{
    [TestClass]
    public class ProgramTest
    {
        [DataTestMethod]
        [DataRow("6-7 x: jxxwxpx", new int[] { 6, 7 })]
        [DataRow("11-20 m: dlmcggnmlwmghngcqpxm", new int[] { 11, 20 })]
        public void Verify_Get_Positions(string input, int[] expected)
        {
            Program.GetPositions(input).Should().BeEquivalentTo(expected);
        }

        [DataTestMethod]
        [DataRow(new string[] { "6-7", "x:", "jxxwxpx", ",", "11-20", "m:", "dlmcggnmlwmghngcqpxm", "," })]
        public void Verify_Normalize_Input(string[] input)
        {
            string[] expected = new string[] { "6-7 x: jxxwxpx", "11-20 m: dlmcggnmlwmghngcqpxm" };
            Program.NormalizeInput(input).Should().BeEquivalentTo(expected);
        }

        [DataTestMethod]
        [DataRow(true, false, true)]
        [DataRow(true, true, false)]
        [DataRow(false, false, false)]
        [DataRow(false, true, true)]
        public void Verify_Determine_Validity(bool isInPosition1, bool isInPosition2, bool expectedOutcome)
        {
            Program.DetermineValidity(isInPosition1, isInPosition2).Should().Be(expectedOutcome);
        }

        [DataTestMethod]
        [DataRow(new string[] { "x", "jxxwxpx" }, 7, 8, true)]
        public void Verify_Check_Position(string[] items, int position1, int position2, bool expectedOutcome)
        {
            Program.CheckPosition(items, position1, position2).Should().Be(expectedOutcome);
        }

        [DataTestMethod]
        [DataRow(7, new char[] { 'j', 'x', 'x', 'w', 'x', 'p', 'x' }, "x", true)]
        [DataRow(2, new char[] { 'j', 'x', 'x', 'w', 'x', 'p', 'x' }, "x", true)]
        [DataRow(3, new char[] { 'j', 'x', 'x', 'j', 'x', 'p', 'x' }, "j", false)]
        [DataRow(1, new char[] { 'j', 'x', 'x', 'j', 'x', 'p', 'x' }, "j", true)]
        [DataRow(9, new char[] { 'j', 'x', 'x', 'j', 'x', 'p', 'x', 'i', 'j', 'n' }, "n", false)]
        public void Verify_Determine_If_In_Position(int position, char[] characters, string item, bool expectedOutcome)
        {
            Program.DetermineIfInPosition(position, characters, item).Should().Be(expectedOutcome);
        }
    }
}
