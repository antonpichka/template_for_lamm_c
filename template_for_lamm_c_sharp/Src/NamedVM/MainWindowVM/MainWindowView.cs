using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Hardcodet.Wpf.TaskbarNotification;
using library_architecture_mvvm_modify_c_sharp;

namespace template_for_lamm_c_sharp;

public sealed class MainWindowView : Window
{
    /// RELEASE CODE
    // private readonly MainWindowViewModel viewModel;
    /// TEST CODE
    private readonly TestMainWindowViewModel viewModel;

    public MainWindowView()
    {
        InitBuildWhereWindow();
        /// RELEASE CODE
        // viewModel = new MainWindowViewModel();
        /// TEST CODE
        viewModel = new TestMainWindowViewModel();
        InitParameterViewModel();
        BuildParameterViewModel();
    }
    
    public void DisposeParameterViewModel() 
    {
        viewModel.Dispose();
    }

    protected override void OnStateChanged(EventArgs e)
    {
       if (WindowState == WindowState.Minimized)
        {
            Hide();
            base.OnStateChanged(e);
            return;
        }
        base.OnStateChanged(e);
    }

    private void InitBuildWhereWindow() 
    {
        Title = "Example";
        Height = 400;
        Width = 600;
        MinHeight = 400;
        MinWidth = 600;
        MaxHeight = 400;
        MaxWidth = 600;
        // ResizeMode = ResizeMode.NoResize;
        TaskbarIcon notifyIcon = new()
        {
            ToolTipText = "TemplateForLAMMCSharp",
        };
        /// BUGS
        BitmapImage bitmapImage = new();
        bitmapImage.BeginInit();
        bitmapImage.EndInit();
        /// BUGS
        // bitmapImage.UriSource = new Uri("coins_dollar_32.ico");
        // notifyIcon.IconSource = bitmapImage;
        notifyIcon.TrayMouseDoubleClick += TrayMouseDoubleClickParameterNotifyIcon;
    }

    private async void InitParameterViewModel() 
    {
        viewModel.ListenStreamDataForNamedFromCallbackParameterNamedStreamWState((data) =>
        {
            BuildParameterViewModel();
        });
        var result = await viewModel.Init();
        Utility.DebugPrint($"MainWindowView: {result}");
        viewModel.NotifyStreamDataForNamedParameterNamedStreamWState();
    }
    
    private void BuildParameterViewModel() 
    {
        var dataForNamedParameterNamedStreamWState = viewModel.GetDataForNamedParameterNamedStreamWState();
        switch(dataForNamedParameterNamedStreamWState.GetEnumDataForNamed()) 
        {
            case EnumDataForMainWindowView.isLoading:
                Grid gridWIsLoading = new();
                gridWIsLoading.Children.Add(new Ellipse() {
                    Width = 50,
                    Height = 50,
                    Fill = new SolidColorBrush(Colors.Black),
                    VerticalAlignment = VerticalAlignment.Center
                });
                Content = gridWIsLoading;
                break;
            case EnumDataForMainWindowView.exception:
                Grid gridWException = new();
                gridWException.Children.Add(new TextBlock() {
                    Text = dataForNamedParameterNamedStreamWState.exceptionController.GetKeyParameterException(),
                    FontSize = 16.0,
                    Foreground = new SolidColorBrush(Colors.Black)
                });
                Content = gridWException;
                break;
            case EnumDataForMainWindowView.success:
                Grid gridWSuccess = new();
                gridWSuccess.Children.Add(new TextBlock() {
                    Text = "Success",
                    FontSize = 16.0,
                    Foreground = new SolidColorBrush(Colors.Black)
                });
                Content = gridWSuccess;
                break;
            default:
                break;            
        }
    }

    private void TrayMouseDoubleClickParameterNotifyIcon(object sender, RoutedEventArgs e)
    {
        Show();
        WindowState = WindowState.Normal;
    }
}