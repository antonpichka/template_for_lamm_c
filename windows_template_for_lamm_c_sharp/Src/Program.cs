namespace windows_template_for_lamm_c_sharp;

public static class Program
{
    [STAThread]
    public static void Main()
    {
        AppView appView = new();
        appView.Run();
    }
}
