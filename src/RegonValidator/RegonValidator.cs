using System;
using System.Linq;

namespace Rychusoft.Validators
{
    public static class RegonValidator
    {
        private static readonly int[] shortRegonWeights = { 8, 9, 2, 3, 4, 5, 6, 7 };
        private static readonly int[] longRegonWeights = { 2, 4, 8, 5, 0, 9, 7, 3, 6, 1, 2, 4, 8 };

        public static bool IsValid(string regon)
        {
            if (IsEmptyOrNotProperLength(regon))
                return false;

            if (!IsNumber(regon))
                return false;

            if (!IsChecksumValid(regon))
                return false;

            if (!HasAtLeastThreeUniqueDigits(regon))
                return false;

            return true;
        }

        private static bool IsEmptyOrNotProperLength(string regon)
        {
            return string.IsNullOrWhiteSpace(regon) || (regon.Length != 9 && regon.Length != 14);
        }

        private static bool IsNumber(string regon)
        {
            return regon.All(Char.IsDigit);
        }

        private static bool IsChecksumValid(string regon)
        {
            if (regon.Length == 9)
                return IsShortRegonChecksumValid(regon);
            else
                return IsLongRegonChecksumValid(regon);
        }

        private static bool IsShortRegonChecksumValid(string regon)
        {
            char inputRegonChecksum = regon[8];
            int computedChecksum = CalculateChecksum(regon, shortRegonWeights);

            return inputRegonChecksum.ToString() == computedChecksum.ToString();
        }

        private static bool IsLongRegonChecksumValid(string regon)
        {
            var shortSubregon = regon.Substring(0, 9);

            if (!IsShortRegonChecksumValid(shortSubregon))
                return false;

            char inputRegonChecksum = regon[13];
            int computedChecksum = CalculateChecksum(regon, longRegonWeights);

            return inputRegonChecksum.ToString() == computedChecksum.ToString();
        }

        private static int CalculateChecksum(string regon, int[] weights)
        {
            int sum = 0;

            for (int i = 0; i < weights.Length; i++)
                sum += weights[i] * int.Parse(regon[i].ToString());

            int checksum = sum % 11;

            if (checksum == 10)
                checksum = 0;

            return checksum;
        }

        private static bool HasAtLeastThreeUniqueDigits(string regon)
        {
            return regon.Distinct().Count() > 2;
        }
    }
}
