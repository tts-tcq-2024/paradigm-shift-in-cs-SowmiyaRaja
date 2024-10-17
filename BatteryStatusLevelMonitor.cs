using System;

namespace ParadigmShiftCSharp
{
    class Checker
    {
        private const float SocMin = 20;
        private const float SocMax = 80;
        private const float TempMin = 0;
        private const float TempMax = 45;
        private const float ChargeRateMax = 0.8;
      
        public void ExpectTrue(bool expression)
        {
            if (!expression)
            {
                Console.WriteLine("Expected true, but got false");
                Environment.Exit(1);
            }
        }

        public void ExpectFalse(bool expression)
        {
            if (expression)
            {
                Console.WriteLine("Expected false, but got true");
                Environment.Exit(1);
            }
        }

        public static bool BatteryIsOk(float temperature, float soc, float chargeRate)
        {
            return RangeChecker(temperature, TempMin, TempMax, "Temperature", true) &&
                   RangeChecker(soc, SocMin, SocMax, "SoC", true) &&
                   ChargeRateChecker(chargeRate);
        }

        public static bool RangeChecker(float input, float minValue, float maxValue, string parameter, bool validate)
        {
            DischargeWarning(input, maxValue, parameter, validate);
            ChargePeakWarning(input, minValue, parameter, validate);
            if (input < minValue || input > maxValue)
            {
                Console.WriteLine($"{parameter} is out of range!");
                return false;
            }
            return true;
        }

        public static bool ChargeRateChecker(float chargeRate)
        {
            if (chargeRate > ChargeRateMax)
            {
                Console.WriteLine("Charge Rate is out of range!");
                return false;
            }
            ChargePeakWarning(chargeRate, ChargeRateMax, "Charge Rate", true);
            return true;
        }

        private static void ChargePeakWarning(float currentVal, float maxValue, string parameter, bool validate)
        {
            if (validate && currentVal > (maxValue - (maxValue * 0.05f)) && currentVal < maxValue)
            {
                Console.WriteLine($"{parameter} is near the maximum range!");
            }
        }

        private static void DischargeWarning(float currentVal, float minValue, string parameter, bool validate)
        {
            if (validate && currentVal > (minValue + (minValue * 0.05f)) && currentVal > minValue)
            {
                Console.WriteLine($"{parameter} is near the minimum range!");
            }
        }
    }
    }
    }
}
