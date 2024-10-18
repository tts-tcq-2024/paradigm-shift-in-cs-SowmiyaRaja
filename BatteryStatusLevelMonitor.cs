using System;

namespace paradigmShiftCsharp
{
    public partial class Checker
    {
        private const float _minSoC = 20f;
        private const float _maxSoC = 80f;
        private const float _minTemperature = 0f;
        private const float _maxTemperature = 45;
        private const float _maxChargeRate = 0.8f;
      
        private static void ExpectTrue(bool expression)
        {
            if (!expression)
            {
                Console.WriteLine("Expected true, but got false");
                Environment.Exit(1);
            }
        }

        private static void ExpectFalse(bool expression)
        {
            if (expression)
            {
                Console.WriteLine("Expected false, but got true");
                Environment.Exit(1);
            }
        }

        private static bool BatteryIsOk(float temperature, float soc, float chargeRate)
        {
            return RangeChecker(temperature, _minTemperature, _maxTemperature, "Temperature", true) &&
                   RangeChecker(soc, _minSoC, _maxSoC, "State of Charge", true) &&
                   ChargeRateChecker(chargeRate, true);
        }

        private static bool RangeChecker(float input, float lowerLimit, float upperLimit, string parameter, bool isEarlyWarningRequired)
        {
            if(isEarlyWarningRequired)
            {
                ChargePeakWarning(input, upperLimit, parameter);
                DischargeWarning(input, lowerLimit, parameter);    
            }

           return CheckLimits(input, lowerLimit, upperLimit, parameter);
        }

        private static bool CheckLimits(float input, float lowerLimit, float upperLimit, string parameter)
        {
            if (input < lowerLimit || input > upperLimit)
            {
                Console.WriteLine(parameter + " is out of range!");
                return false;
            }
            return true;
        }

        private static bool ChargeRateChecker(float chargeRate, bool isEarlyWarningRequired)
        {
            if(isEarlyWarningRequired)
            {
                ChargePeakWarning(chargeRate, _maxChargeRate, "Charge Rate");
            }
            if (chargeRate > _maxChargeRate)
            {
                Console.WriteLine("Charge Rate is out of range!");
                return false;
            }
            return true;
        }

        private static void ChargePeakWarning(float currentVal, float maxValue, string parameter)
        {
            if (currentVal >= (maxValue - (maxValue * 0.05)) && currentVal <= maxValue)
            {
                Console.WriteLine($"{parameter}: Warning: Approaching charge-peak!");
            }
        }

        private static void DischargeWarning(float currentVal, float minValue, string parameter)
        {
            if (currentVal <= (minValue + (minValue * 0.05f)) && currentVal >= minValue)
            {
                Console.WriteLine($"{parameter} : Warning: Approaching discharge!");
            }
        }
    }    
}
