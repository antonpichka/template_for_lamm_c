using System.Windows;

namespace template_for_lamm_c_sharp;

public sealed class AppView : Application
{
    /* ONLY EDIT THIS LINE IF YOU WILL MAKE A RELEASE */
    private readonly bool isBuildRelease = false;
    /* ONLY EDIT THIS LINE IF YOU WILL MAKE A RELEASE */
    private MainWindowView? mainWindowView;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        if(isBuildRelease) 
        {
            MainWindowView mainWindowView = new();
            mainWindowView.Show();
            return;
        }
        ConsoleWindowView consoleWindowView = new();
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