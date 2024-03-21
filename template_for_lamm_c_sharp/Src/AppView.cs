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
        ExceptionHelperUtility.CallExceptionHelperFromThisClassAndCallback(this,() => 
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
        });
    }

    protected override void OnActivated(EventArgs e)
    {
        ExceptionHelperUtility.CallExceptionHelperFromThisClassAndCallback(this,() => 
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
        });
    }
}