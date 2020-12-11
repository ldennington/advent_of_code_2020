using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Night4.Test
{
    [TestClass]
    public class PassportTest
    {
        private Dictionary<string, string> passportData = new Dictionary<string, string>();

        [TestInitialize()]
        public void Setup()
        {
            passportData.Add("byr", "0");
            passportData.Add("iyr", "0");
            passportData.Add("eyr", "0");
            passportData.Add("hgt", "0");
            passportData.Add("hcl", "0");
            passportData.Add("ecl", "0");
            passportData.Add("pid", "0");
        }

        [DataTestMethod]
        [DataRow(20, false)]
        [DataRow(2001, true)]
        [DataRow(1920, true)]
        [DataRow(1919, false)]
        public void Verify_Birth_Year(int inputYear, bool expectedValue)
        {
            passportData["byr"] = inputYear.ToString();
            Passport passport = new Passport(passportData);
            passport.ValidateBirthYear().Should().Be(expectedValue);
        }

        [DataTestMethod]
        [DataRow(2010, true)]
        [DataRow(2009, false)]
        [DataRow(2020, true)]
        [DataRow(2022, false)]
        public void Verify_Issue_Year(int inputYear, bool expectedValue)
        {
            passportData["iyr"] = inputYear.ToString();
            Passport passport = new Passport(passportData);
            passport.ValidateIssueYear().Should().Be(expectedValue);
        }

        [DataTestMethod]
        [DataRow(2020, true)]
        [DataRow(2019, false)]
        [DataRow(2030, true)]
        [DataRow(2032, false)]
        public void Verify_Expiration_Year(int inputYear, bool expectedValue)
        {
            passportData["eyr"] = inputYear.ToString();
            Passport passport = new Passport(passportData);
            passport.ValidateExpirationYear().Should().Be(expectedValue);
        }

        [DataTestMethod]
        [DataRow("150cm", true)]
        [DataRow("149cm", false)]
        [DataRow("193cm", true)]
        [DataRow("194cm", false)]
        [DataRow("59in", true)]
        [DataRow("77in", false)]
        public void Verify_Validate_Height(string height, bool expectedValue)
        {
            passportData["hgt"] = height;
            Passport passport = new Passport(passportData);
            passport.ValidateHeight().Should().Be(expectedValue);
        }

        [DataTestMethod]
        [DataRow("150cm", 150, "cm")]
        [DataRow("149cm", 149, "cm")]
        [DataRow("193cm", 193, "cm")]
        [DataRow("194cm", 194, "cm")]
        [DataRow("59in", 59, "in")]
        [DataRow("77in", 77, "in")]
        public void Verify_Parse_Height(string inputHeight, int expectedValue, string expectedUnits)
        {
            Passport.ParseHeight(inputHeight, out string units).Should().Be(expectedValue);
            units.Should().Be(expectedUnits);
        }

        [DataTestMethod]
        [DataRow("#123abc", true)]
        [DataRow("#5647", false)]
        [DataRow("#45678a", true)]
        public void Verify_Validate_Hair_Color(string input, bool expected)
        {
            passportData["hcl"] = input;
            Passport passport = new Passport(passportData);
            passport.ValidateHairColor().Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow("amb", true)]
        [DataRow("why", false)]
        [DataRow("oth", true)]
        public void Verify_Validate_Eye_Color(string input, bool expected)
        {
            passportData["ecl"] = input;
            Passport passport = new Passport(passportData);
            passport.ValidateEyeColor().Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow("012345678", true)]
        [DataRow("01924", false)]
        [DataRow("123456789", true)]
        public void Verify_Validate_Passport_Number(string input, bool expected)
        {
            passportData["pid"] = input;
            Passport passport = new Passport(passportData);
            passport.ValidatePassportNumber().Should().Be(expected);
        }
    }
}
