using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Hardcodet.Wpf.TaskbarNotification;
using library_architecture_mvvm_modify_c_sharp;

namespace template_for_lamm_c_sharp;

public sealed class MainWindowVM : Window
{
    // OperationEEModel(EEWhereNamed)[EEFromNamed]EEParameterNamedService
    // NamedUtility
    
    // Main objects
    private BaseNamedStreamWState<DataForMainWindowVM,EnumDataForMainWindowVM>? namedStreamWState;
    private RWTMode? rwtMode;

    public MainWindowVM()
    {
        ExceptionHelperUtility.CallExceptionHelperFromThisClassAndCallback(this,() => 
        {
            namedStreamWState = new DefaultStreamWState<DataForMainWindowVM,EnumDataForMainWindowVM>(new DataForMainWindowVM(true));
            rwtMode = new RWTMode(
                EnumRWTMode.test,
                [
                    new NamedCallback("init",(Func<Task<string>>)(async () =>
                    {
                        await Task.Delay(1000);
                        namedStreamWState.GetDataForNamed().isLoading = false;
                        return KeysSuccessUtility.sUCCESS;
                    })),
                ],
                [
                    new NamedCallback("init",(Func<Task<string>>)(async () =>
                    {
                        await Task.Delay(1000);
                        namedStreamWState.GetDataForNamed().isLoading = false;
                        return KeysSuccessUtility.sUCCESS;
                    })),
                ]);
            Init();
            Build();
        });
    }

    protected override void OnStateChanged(EventArgs e)
    {
        ExceptionHelperUtility.CallExceptionHelperFromThisClassAndCallback(this,() => 
        {
            if(WindowState == WindowState.Minimized)
            {
                Hide();
                base.OnStateChanged(e);
                return;
            }
            Show();
            base.OnStateChanged(e);
        });
    }

    protected override void OnClosed(EventArgs e)
    {
        ExceptionHelperUtility.CallExceptionHelperFromThisClassAndCallback(this,() => 
        {
            namedStreamWState?.Dispose();
            base.OnClosed(e);
        });
    }

    private async void Init() 
    {
        Title = "Example";
        Height = 400;
        Width = 600;
        MinHeight = 400;
        MinWidth = 600;
        MaxHeight = 400;
        MaxWidth = 600;
        Icon = BitmapFrame.Create(new Uri(@"../build/Assets/Icon/CoinsDollar32.ico",UriKind.RelativeOrAbsolute));
        ResizeMode = ResizeMode.NoResize;
        WindowState = WindowState.Normal;
        Closing += ClosingFromSenderAndE;  
        TaskbarIcon taskbarIcon = new()
        {
            ToolTipText = "TemplateForLAMMCSharp",
            Icon = new System.Drawing.Icon(@"../build/Assets/Icon/CoinsDollar32.ico")
        };
        taskbarIcon.TrayLeftMouseUp += TrayLeftMouseClickFromSenderAndE;
        taskbarIcon.TrayLeftMouseDown += TrayLeftMouseClickFromSenderAndE;
        namedStreamWState?.ListenStreamDataForNamedFromCallback((data) =>
        {
            Build();
        });
        var result = await rwtMode?.GetNamedCallbackFromName("init").callback();
        Utility.DebugPrint($"MainWindowVM: {result}");
        namedStreamWState?.NotifyStreamDataForNamed();
    }
    
    private void Build() 
    {
        var dataForNamed = namedStreamWState?.GetDataForNamed();
        switch(dataForNamed?.GetEnumDataForNamed()) 
        {
            case EnumDataForMainWindowVM.isLoading:
                Grid gridWIsLoading = new();
                gridWIsLoading.Children.Add(new Ellipse() {
                    Width = 50,
                    Height = 50,
                    Fill = new SolidColorBrush(Colors.Black),
                    VerticalAlignment = VerticalAlignment.Center
                });
                Content = gridWIsLoading;
                break;
            case EnumDataForMainWindowVM.exception:
                Grid gridWException = new();
                gridWException.Children.Add(new TextBlock() {
                    Text = dataForNamed.exceptionController.GetKeyParameterException(),
                    FontSize = 16.0,
                    Foreground = new SolidColorBrush(Colors.Black)
                });
                Content = gridWException;
                break;
            case EnumDataForMainWindowVM.success:
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

    private void ClosingFromSenderAndE(object? sender, CancelEventArgs e)
    {
        ExceptionHelperUtility.CallExceptionHelperFromThisClassAndCallback(this,() => 
        {
            e.Cancel = true;
            WindowState = WindowState.Minimized;
            ShowInTaskbar = true;
        });
    }

    private void TrayLeftMouseClickFromSenderAndE(object sender, RoutedEventArgs e)
    {
        ExceptionHelperUtility.CallExceptionHelperFromThisClassAndCallback(this,() => 
        {
            Show();
            WindowState = WindowState.Normal;
        });
    }
}   