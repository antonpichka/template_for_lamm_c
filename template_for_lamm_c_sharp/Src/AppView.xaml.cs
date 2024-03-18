using System.Windows;

namespace template_for_lamm_c_sharp;

public sealed partial class AppView : Application
{
    private MainWindowView? mainWindowView;
    private readonly bool isRelease = false;
    
    public AppView()
    {
        InitializeComponent();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        if(isRelease) 
        {
            StartupUri = new Uri("MainWindowView.xaml",UriKind.Relative);
            return;
        }
        StartupUri = new Uri("ConsoleWindowView.xaml",UriKind.Relative);
        return;
    }

    protected override void OnActivated(EventArgs e)
    {
        base.OnActivated(e);
        if(isRelease) 
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