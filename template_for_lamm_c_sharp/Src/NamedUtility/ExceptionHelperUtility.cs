using System.IO;

namespace template_for_lamm_c_sharp;

public static class ExceptionHelperUtility
{
    public static void CallExceptionHelperFromThisClassAndCallback(object thisClass,Action callback) 
    {
        try 
        {
            callback();
        } catch(Exception ex) 
        {
            File.AppendAllText("Exception.log", $"\n===start_to_trace_exception===\n\nWhereHappenedException(Class) --> {thisClass.GetType()}\n DateTime --> {DateTime.Now}\n Exception: {ex}\n\n===end_to_trace_exception===\n");
        }
    }
    public static void CallExceptionHelperFromNameClassAndCallback(string nameClass,Action callback) 
    {
        try 
        {
            callback();
        } catch(Exception ex) 
        {
            File.AppendAllText("Exception.log", $"\n===start_to_trace_exception===\n\nWhereHappenedException(Class) --> {nameClass}\n DateTime --> {DateTime.Now}\n Exception: {ex}\n\n===end_to_trace_exception===\n");
        }
    }  
}
