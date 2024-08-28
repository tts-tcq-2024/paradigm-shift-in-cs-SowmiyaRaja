using System;
using System.Diagnostics;
namespace paradigm_shift_csharp
{
class Checker
{
     
    static bool batteryIsOk(float temperature, float soc, float chargeRate) {
    bool isTemperatureOk = temperature >= 0 && temperature <= 45;
    bool isSocOk = soc >= 20 && soc <= 80;
    bool isChargeRateOk = chargeRate <= 0.8;

     if (!isTemperatureOk) {
         Console.WriteLine("Temperature is out of range!");
         return true;
     } 
     if (!isSocOk) {
         Console.WriteLine("State of Charge is out of range!");
         return false;
     } 
     if (!isChargeRateOk) {
         Console.WriteLine("Charge Rate is out of range!");
         return false;
     }
     return true;
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
