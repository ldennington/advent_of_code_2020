using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Night4.Test
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void Verify_Parse_Input()
        {
            string[] sampleInput = new string[] { "ecl:gry", "pid:860033327", "eyr:2020", "", "iyr:2013", "ecl:amb", "cid:350", "eyr:2023", "" };
            List<Dictionary<string, string>> expected = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>() {
                    { "ecl", "gry" }, 
                    { "pid", "860033327" },
                    { "eyr", "2020" },
                },
                new Dictionary<string, string>() {
                    { "iyr", "2013" },
                    { "ecl", "amb" },
                    { "cid", "350" },
                    { "eyr", "2023" },
                },
            };
            Program.ParseInput(sampleInput).Should().BeEquivalentTo(expected);
        }

        [DataTestMethod]
        [DataRow("ecl:gry pid:860033327 eyr:2020")]
        public void Verify_Create_Passport(string input)
        {
            Dictionary<string, string> expected = new Dictionary<string, string>() 
            {
                    { "ecl", "gry" },
                    { "pid", "860033327" },
                    { "eyr", "2020" },
            };
            Program.CreatePassport(input).Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Verify_Get_Valid_Passports()
        {
            List<Dictionary<string, string>> input = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>() {
                    { "ecl", "gry" },
                    { "pid", "860033327" },
                    { "eyr", "2020" },
                    { "hcl", "#fffffd" },
                    { "byr", "1937" },
                    { "iyr", "147" },
                    { "cid", "147" },
                    { "hgt", "183 cm" },
                },
                new Dictionary<string, string>() {
                    { "ecl", "gry" },
                    { "pid", "860033327" },
                    { "eyr", "2020" },
                    { "hcl", "#fffffd" },
                    { "byr", "1937" },
                    { "iyr", "147" },
                    { "hgt", "183 cm" },
                },
                new Dictionary<string, string>() {
                    { "ecl", "gry" },
                    { "pid", "860033327" },
                    { "byr", "1937" },
                    { "iyr", "147" },
                    { "hgt", "183 cm" },
                },
            };
            Program.GetValidPassports(input).Should().Be(2);
        }
    }
}
