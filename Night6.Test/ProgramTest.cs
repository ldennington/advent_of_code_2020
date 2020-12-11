using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace Night6.Test
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void Verify_Calculate_Final_Total()
        {
            List<List<string>> input = new List<List<string>>()
            {
                new List<string>() { "abc", "ac", "adbc" }, // 2
                new List<string>() { "abcd", "abcd", "abcd" }, // 4
            };

            Program.CalculateFinalTotal(input).Should().Be(6);
        }

        [DataTestMethod]
        [DataRow(new string[] { "abcxyz", "ab", "acdb" }, 2)]
        [DataRow(new string[] { "abcde", "abcde", "abcde" }, 5)]
        public void Verify_Calculate_Group_Total(string[] input, int expected)
        {
            Program.CalculateGroupTotal(input.ToList()).Should().Be(expected);
        }

        [TestMethod]
        public void Verify_Add_Or_Count_Letters()
        {
            string inputString = "abcd";

            Dictionary<char, int> letterCount = new Dictionary<char, int>()
            {
                { 'a', 1 },
                { 'c', 2 },
                { 'd', 3 },
            };

            Dictionary<char, int> expected = new Dictionary<char, int>()
            {
                { 'a', 2 },
                { 'b', 1 },
                { 'c', 3 },
                { 'd', 4 },
            };

            Program.AddOrCountLetters(inputString, letterCount);
            letterCount.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Verify_Parse_Input()
        {
            string[] input = new string[] { "abc", "a", "xy", "", "c", "cd", "" };
            List<Dictionary<int, string>> expected = new List<Dictionary<int, string>>()
            {
                new Dictionary<int, string>()
                {
                    { 0, "abc" },
                    { 1, "a" },
                    { 2, "xy" }
                },
                new Dictionary<int, string>()
                {
                    { 3, "c" },
                    { 4, "cd" },
                }
            };
            Program.ParseInput(input).Should().BeEquivalentTo(expected);
        }
    }
}
