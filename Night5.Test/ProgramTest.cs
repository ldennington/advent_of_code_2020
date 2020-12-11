using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Night5.Test
{
    [TestClass]
    public class ProgramTest
    {
        [DataTestMethod]
        [DataRow("FBFBBFF", 128, 44)]
        [DataRow("RLR", 8, 5)]
        public void Verify_Get_Row_Or_Column(string input, int size, int expected)
        {
            Program.GetRowOrColumn(input, size).Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow(4, new int[] { 0, 1, 2, 3})]
        [DataRow(3, new int[] { 0, 1, 2 })]
        public void Verify_Create_Array(int size, int[] expected)
        {
            Program.CreateArray(size, 0).Should().BeEquivalentTo(expected);
        }

        [DataTestMethod]
        [DataRow(new int[] { 0, 1, 2, 3 }, 2, new int[] { 0, 1 }, new int[] { 2, 3 })]
        public void Verify_Split_Int(int[] input, int index, int[] expectedTop, int[] expectedBottom)
        {
            Program.Split(input, index, out int[] top, out int[] bottom);
            top.Should().BeEquivalentTo(expectedTop);
            bottom.Should().BeEquivalentTo(expectedBottom);
        }

        [DataTestMethod]
        [DataRow(new char[] { 'F', 'F', 'B', 'L', 'R' }, 3, new char[] { 'F', 'F', 'B' }, new char[] { 'L', 'R' })]
        public void Verify_Split_Char(char[] input, int index, char[] expectedTop, char[] expectedBottom)
        {
            Program.Split(input, index, out char[] top, out char[] bottom);
            top.Should().BeEquivalentTo(expectedTop);
            bottom.Should().BeEquivalentTo(expectedBottom);
        }

        [DataTestMethod]
        [DataRow(new int[] { 0, 1, 2, 3, 5 }, 4)]
        [DataRow(new int[] { 0, 1, 2, 3, 4 }, 0)]
        [DataRow(new int[] { 1, 2, 3, 5, 6 }, 4)]
        public void Verify_Find_Missing_Seat(int[] rawInput, int expected)
        {
            List<int> input = rawInput.ToList();
            Program.FindMissingSeat(input, input.Count).Should().Be(expected);
        }
    }
}
