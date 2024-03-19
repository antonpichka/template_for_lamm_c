using System.Windows;

namespace template_for_lamm_c_sharp;

public sealed class AppView : Application
{
    private MainWindowView? mainWindowView;
    private readonly bool isBuildRelease = false;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        if(isBuildRelease) 
        {
            var mainWindowView = new MainWindowView();
            mainWindowView.Show();
            return;
        }
        var consoleWindowView = new ConsoleWindowView();
        consoleWindowView.Show();
        return;
    }

    protected override void OnActivated(EventArgs e)
    {
        base.OnActivated(e);
        if(isBuildRelease) 
        {
            return;
        }
        if(mainWindowView != null) 
        {
            return;
        }
        mainWindowView = new MainWindowView();
        mainWindowView.Show();
    }
}