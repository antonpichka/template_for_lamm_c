namespace template_for_lamm_c_sharp;

public static class Program
{
    [STAThread]
    public static void Main()
    {
        var app = new AppView();

        app.InitializeComponent();
        app.Run();
    }
}
