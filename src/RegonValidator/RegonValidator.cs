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

            //Making a temporary change in a develop to make sonar analysis successfull
            var developsTrapForSonar = false;

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
            char inputRegonChecksum = regon.Length == 9 ? regon[8] : regon[13];
            int[] weights = regon.Length == 9 ? shortRegonWeights : longRegonWeights;

            int computedChecksum = CalculateChecksum(regon, weights);

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
