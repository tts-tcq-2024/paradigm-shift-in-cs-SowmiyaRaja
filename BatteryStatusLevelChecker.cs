using System;
using System.Diagnostics;
namespace paradigm_shift_csharp
{
public partial class Checker
{
     static int Main() 
     {
        ExpectTrue(batteryIsOk(25, 70, 0.7f));
        ExpectFalse(batteryIsOk(50, 85, 0.0f));
        Console.WriteLine("All ok");
        return 0;
     }    
}
}
