using System;

namespace ParadigmShiftCSharp
{
    class Checker
    {
        private const float _minSoC = 20;
        private const float _maxSoC = 80;
        private const float _minTemperature = 0;
        private const float _minTemperature = 45;
        private const float _maxChargeRate = 0.8;
      
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
            return RangeChecker(temperature, _minTemperature, _minTemperature, "Temperature", true) &&
                   RangeChecker(soc, _minSoC, _maxSoC, "State of Charge", true) &&
                   ChargeRateChecker(chargeRate);
        }

        public static bool RangeChecker(float input, float lowerLimit, float upperLimit, string parameter, bool isEarlyWarningRequired)
        {
            if(isEarlyWarningRequired)
            {
                DischargeWarning(input, upperLimit, parameter);
                ChargePeakWarning(input, lowerLimit, parameter);    
            }
            
            if (input < lowerLimit || input > maxValue)
            {
                Console.WriteLine(parameter + "is out of range!");
                return false;
            }
            return true;
        }

        public static bool ChargeRateChecker(float chargeRate)
        {
            if (chargeRate > _maxChargeRate)
            {
                Console.WriteLine("Charge Rate is out of range!");
                return false;
            }
            ChargePeakWarning(chargeRate, _maxChargeRate, "Charge Rate", true);
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
    }
}
