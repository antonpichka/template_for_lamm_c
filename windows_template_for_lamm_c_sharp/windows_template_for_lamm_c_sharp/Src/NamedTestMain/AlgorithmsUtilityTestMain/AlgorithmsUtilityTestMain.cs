using System.Runtime.Versioning;
using library_architecture_mvvm_modify_c_sharp;
using windows_template_for_lamm_c_sharp;

namespace AlgorithmsUtilityTestMain;

public class AlgorithmsUtilityTestMain
{
    [SupportedOSPlatform("windows7.0")]
    public static void Main(string[] args) 
    {
        Utility.DebugPrint($"{AlgorithmsUtility.IsWhereEqualsStartExceptionFromStr(" \n===start_to_trace_exception===\n qwqwqwqwqwqwqwqwqwq")}");
    }
}
// EXPECTED OUTPUT:
//
// True