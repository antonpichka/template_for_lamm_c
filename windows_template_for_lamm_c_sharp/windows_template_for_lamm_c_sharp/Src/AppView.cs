using System.Windows;

namespace windows_template_for_lamm_c_sharp;

public sealed class AppView : Application
{
    /* ONLY EDIT THIS LINE IF YOU WILL MAKE A RELEASE */
    private readonly bool isBuildRelease = false;
    /* ONLY EDIT THIS LINE IF YOU WILL MAKE A RELEASE */
    
    /* You can put any starting class if you need to test it */
    private MainWindowVM? namedWindowVM;
    /* You can put any starting class if you need to test it */

    protected override void OnStartup(StartupEventArgs e)
    {
        ExceptionHelperUtility.CallExceptionHelperFromThisClassAndCallback(this,() => 
        {
            base.OnStartup(e);
            if(isBuildRelease) 
            {
                MainWindowVM mainWindowVM = new();
                mainWindowVM.Show();
                return;
            }
            ConsoleWindowView consoleWindowView = new();
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
            if(namedWindowVM != null) 
            {
                return;
            }
            namedWindowVM = new();
            namedWindowVM.Show();
        });
    }
}