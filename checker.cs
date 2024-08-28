using System;
using System.Diagnostics;
namespace paradigm_shift_csharp
{
class Checker
{
     static bool isTemperatureWithInTheRange(float temperature)
     {
          if(temperature >= 0 && temperature <= 45)
          {
               return true;
          }
          return false;
     }

     static bool isSocWithInTheRange(float soc)
     {
        if(soc >= 20 && soc <= 80) 
        {
             return true;
        }
          return false;
     }

     static bool isChargeRateWithInTheRange(float chargeRate)
     {
          if(chargeRate <= 0.8) 
          {
             return true;
          }
          return false;
     }
    static bool batteryIsOk(float temperature, float soc, float chargeRate) {
     return !isTemperatureWithInTheRange(temperature) && !isSocWithInTheRange(soc) && !isChargeRateWithInTheRange(chargeRate);     
    }

    static void ExpectTrue(bool expression) {
        if(!expression) {
            Console.WriteLine("Expected true, but got false");
            Environment.Exit(1);
        }
    }
    static void ExpectFalse(bool expression) {
        if(expression) {
            Console.WriteLine("Expected false, but got true");
            Environment.Exit(1);
        }
    }
    static int Main() {
        ExpectTrue(batteryIsOk(25, 70, 0.7f));
        ExpectFalse(batteryIsOk(50, 85, 0.0f));
        Console.WriteLine("All ok");
        return 0;
    }
    
}
}
