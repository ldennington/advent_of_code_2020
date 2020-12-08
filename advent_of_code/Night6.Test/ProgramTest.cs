using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Night6.Test
{
    [TestClass]
    public class ProgramTest
    {
        [DataTestMethod]
        [DataRow(new string[] {  "aba", "ac" }, 4)]
        [DataRow(new string[] { "abxz", "c" }, 5)]
        public void Verify_Calculate_Final_Total(string[] rawInput, int expected)
        {
            List<string> input = rawInput.ToList();
            Program.CalculateFinalTotal(input).Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow("abaxyz", 5)]
        [DataRow("abxxxyz", 5)]
        public void Verify_Calculate_Group_Total(string input, int expected)
        {
            Program.CalculateGroupTotal(input).Should().Be(expected);
        }

        [TestMethod]
        public void Verify_Parse_Input()
        {
            string[] input = new string[] { "abc", "a", "xy", "", "c", "cd", "" };
            List<string> expected = new List<string>() { "abcaxy", "ccd" };
            Program.ParseInput(input).Should().BeEquivalentTo(expected);
        }
    }
}
