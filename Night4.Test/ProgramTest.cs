using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Night4.Test
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void Verify_Get_Valid_Passports()
        {
            List<Passport> input = new List<Passport>()
            {
                new Passport (new Dictionary<string, string>() {
                    { "ecl", "blu" },
                    { "pid", "860033327" },
                    { "eyr", "2020" },
                    { "hcl", "#fffffd" },
                    { "byr", "1937" },
                    { "iyr", "2010" },
                    { "cid", "147" },
                    { "hgt", "183 cm" },
                }),
                new Passport (new Dictionary<string, string>() {
                    { "ecl", "gry" },
                    { "pid", "860033327" },
                    { "eyr", "2020" },
                    { "hcl", "#fffffd" },
                    { "byr", "1937" },
                    { "iyr", "147" },
                    { "hgt", "183 cm" },
                }),
                new Passport (new Dictionary<string, string>() {
                    { "ecl", "gry" },
                    { "pid", "860033327" },
                    { "byr", "1937" },
                    { "iyr", "147" },
                    { "hgt", "183 cm" },
                }),
            };
            Program.GetValidPassports(input).Should().Be(1);
        }
    }
}
