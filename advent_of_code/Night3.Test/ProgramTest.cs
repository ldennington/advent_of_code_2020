using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Night3.Test
{
    [TestClass]
    public class ProgramTest
    {

        [TestMethod]
        public void Verify_Parse_Input()
        {
            string input = "....#.#,..##..#,";

            List<List<string>> expected = new List<List<string>>()
            { 
                new List<string>() { ".", ".", ".", ".", "#", ".", "#" }, 
                new List<string>() { ".", ".", "#", "#", ".", ".", "#" } 
            };
            
            Program.ParseInput(input).Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Verify_Convert_To_Array()
        {
            List<List<string>> input = new List<List<string>>()
            {
                new List<string>() { ".", ".", ".", ".", "#", ".", "#" },
                new List<string>() { ".", ".", "#", "#", ".", ".", "#" }
            };

            string[,] expected = new string[,]
            {
                { ".", ".", ".", ".", "#", ".", "#" },
                { ".", ".", "#", "#", ".", ".", "#" }
            };

            Program.ConvertToArray(input).Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Verify_Extend_Row()
        {
            List<string> input = new List<string>()
            {
                 ".", ".", ".", ".", "#", ".", "#" 
            };

            List<string> expected = new List<string>()
            {
                 ".", ".", ".", ".", "#", ".", "#", ".", ".", ".", ".", "#", ".", "#"
            };

            Program.ExtendRow(input).Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Verify_Convert_To_List()
        {
            string[,] input = new string[,]
            {
                { ".", ".", ".", ".", "#", ".", "#" },
                { ".", ".", "#", "#", ".", ".", "#" }
            };

            List<List<string>> expected = new List<List<string>>()
            {
                new List<string>() { ".", ".", ".", ".", "#", ".", "#" },
                new List<string>() { ".", ".", "#", "#", ".", ".", "#" }
            };

            Program.ConvertToList(input).Should().BeEquivalentTo(expected);
        }

        // ...#.
        // ..##.
        // #.#..
        [TestMethod]
        public void Verify_Trees_Hit()
        {
            string[,] map = new string[,] { { ".", ".", ".", "#", "." }, { ".", ".", "#", "#", "." }, { "#", ".", "#", ".", "."} };
            int expected = 1;
            List<int> slope = new List<int>() { 3, 1 };
            Program.GetTreesHit(map, slope).Should().Be(expected);
        }
    }
}
