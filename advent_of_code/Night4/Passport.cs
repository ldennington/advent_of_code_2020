using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Night4
{
    internal class Passport
    {
        private int birthYear = 0;

        private int issueYear = 0;

        private int expirationYear = 0;

        private string height = "0";

        private string hairColor = "0";

        private string eyeColor = "0";

        private string passportId = "0";

        public Passport()
        { }

        public Passport(Dictionary<string, string> passport)
        {
            foreach (KeyValuePair<string, string> entry in passport)
            {
                ParseInput(entry);
            }
        }

        internal void ParseInput(KeyValuePair<string, string> entry)
        {
            switch (entry.Key)
            {
                case "byr":
                    birthYear = int.Parse(entry.Value);
                    break;
                case "eyr":
                    expirationYear = int.Parse(entry.Value);
                    break;
                case "iyr":
                    issueYear = int.Parse(entry.Value);
                    break;
                case "hgt":
                    height = entry.Value;
                    break;
                case "hcl":
                    hairColor = entry.Value;
                    break;
                case "ecl":
                    eyeColor = entry.Value;
                    break;
                case "pid":
                    passportId = entry.Value;
                    break;
            }
        }

        internal bool IsValid()
        {
            return ValidateBirthYear() &&
            ValidateIssueYear() &&
            ValidateExpirationYear() &&
            ValidateHeight() &&
            ValidateHairColor() &&
            ValidateEyeColor() &&
            ValidatePassportNumber();
        }

        internal bool ValidateBirthYear()
        {
            if (birthYear >= 1920 && birthYear <= 2002)
            {
                return true;
            }

            return false;
        }

        internal bool ValidateIssueYear()
        {
            if (issueYear >= 2010 && issueYear <= 2020)
            {
                return true;
            }

            return false;
        }

        internal bool ValidateExpirationYear()
        {
            if (expirationYear >= 2020 && expirationYear <= 2030)
            {
                return true;
            }

            return false;
        }

        internal bool ValidateHeight()
        {
            int height = ParseHeight(this.height, out string units);

            if (units == "cm" && (height >= 150 && height <= 193))
            {
                return true;
            }
            else if (units == "in" && (height >= 59 && height <= 76))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal static int ParseHeight(string rawheight, out string units)
        {
            if (rawheight == "0")
            {
                units = "none";
                return 0;
            }

            int unitStartIndex = rawheight.Length - 2;
            units = rawheight.Substring(unitStartIndex);
            return int.Parse(rawheight.Remove(unitStartIndex));
        }

        internal bool ValidateHairColor()
        {
            char[] characters = hairColor.ToCharArray();
            char[] acceptableCharacters = new char[] { '#', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
            int acceptableCharacterCount = 0;

            foreach (char character in characters)
            {
                if (acceptableCharacters.Contains(character))
                {
                    acceptableCharacterCount++;
                }
            }

            if (acceptableCharacterCount == 7)
            {
                return true;
            }

            return false;
        }

        internal bool ValidateEyeColor()
        {
            List<string> acceptableEyeColors = new List<string>()
            {
                "amb",
                "blu",
                "brn",
                "gry",
                "grn",
                "hzl",
                "oth"
            };

            if (acceptableEyeColors.Contains(this.eyeColor))
            {
                return true;
            }

            return false;
        }

        internal bool ValidatePassportNumber()
        {
            char[] pidCharacters = this.passportId.ToCharArray();
            if (pidCharacters.Length == 9)
            {
                return true;
            }

            return false;
        }
    }
}
