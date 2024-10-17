using System;

namespace ParadigmShiftCSharp
{
    public partial class Checker
    {
        private const float _minSoC = 20;
        private const float _maxSoC = 80;
        private const float _minTemperature = 0;
        private const float _maxTemperature = 45;
        private const float _maxChargeRate = 0.8f;
      
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

        public bool BatteryIsOk(float temperature, float soc, float chargeRate)
        {
            return RangeChecker(temperature, _minTemperature, _maxTemperature, "Temperature", true) &&
                   RangeChecker(soc, _minSoC, _maxSoC, "State of Charge", true) &&
                   ChargeRateChecker(chargeRate, true);
        }

        public bool RangeChecker(float input, float lowerLimit, float upperLimit, string parameter, bool isEarlyWarningRequired)
        {
            if(isEarlyWarningRequired)
            {
                DischargeWarning(input, upperLimit, parameter);
                ChargePeakWarning(input, lowerLimit, parameter);    
            }

            CheckLimits(input, lowerLimit, upperLimit, parameter);
            return true;
        }

        public bool CheckLimits(float input, float lowerLimit, float upperLimit, string parameter)
        {
            if (input < lowerLimit || input > upperLimit)
            {
                Console.WriteLine(parameter + "is out of range!");
                return false;
            }
            return true;
        }

        public bool ChargeRateChecker(float chargeRate, , bool isEarlyWarningRequired)
        {
            if(isEarlyWarningRequired)
            {
                ChargePeakWarning(chargeRate, _maxChargeRate, "Charge Rate", true);
            }
            if (chargeRate > _maxChargeRate)
            {
                Console.WriteLine("Charge Rate is out of range!");
                return false;
            }
            return true;
        }

        private void ChargePeakWarning(float currentVal, float maxValue, string parameter)
        {
            if (currentVal >= (maxValue - (maxValue * 0.05)) && currentVal <= maxValue)
            {
                Console.WriteLine($"{parameter}: Warning: Approaching charge-peak!");
            }
        }

        private void DischargeWarning(float currentVal, float minValue, string parameter)
        {
            if (currentVal <= (minValue + (minValue * 0.05f)) && currentVal >= minValue)
            {
                Console.WriteLine($"{parameter} : Warning: Approaching discharge!");
            }
        }
    }    
}
