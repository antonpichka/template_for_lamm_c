namespace template_for_lamm_c_sharp;

public static class AlgorithmsUtility
{
    public static bool IsWhereEqualsStartExceptionFromStr(string str) 
    {
        string replace = str.Replace("\n","").Replace(" ","");
        string result = "";
        for(int i = 0; i < replace.Length; i++) 
        {
            if(i > 29)
            {
                break;
            }
            result += replace[i];
        }
        return result == "===start_to_trace_exception===";
    }
}