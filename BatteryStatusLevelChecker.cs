using System;
using System.Diagnostics;
namespace paradigmShiftCsharp
{
public partial class Checker
{
     static int Main() 
     {
        ExpectTrue(BatteryIsOk(25, 70, 0.7f));
        ExpectFalse(BatteryIsOk(50, 85, 0.0f));
        Console.WriteLine("All ok");
        return 0;
     }    
}
}
