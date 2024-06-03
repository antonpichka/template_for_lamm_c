using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using library_architecture_mvvm_modify_c_sharp;

namespace windows_template_for_lamm_c_sharp;

public sealed class ExampleWindowVM : Window
{
    // OperationEEModel(EEWhereNamed)[EEFromNamed]EEParameterNamedService
    // NamedUtility
    
    // Main objects
    private BaseNamedStreamWState<DataForExampleWindowVM,EnumDataForExampleWindowVM>? namedStreamWState;
    private RWTMode? rwtMode;

    public ExampleWindowVM()
    {
        ExceptionHelperUtility.CallExceptionHelperFromThisClassAndCallback(this,() => 
        {
            namedStreamWState = new DefaultStreamWState<DataForExampleWindowVM,EnumDataForExampleWindowVM>(new DataForExampleWindowVM(true));
            Func<Task<string>> initReleaseCallback = async () =>
            {
                await Task.Delay(1000);
                namedStreamWState.GetDataForNamed().isLoading = false;
                return KeysSuccessUtility.sUCCESS;
            };
            Func<Task<string>> initTestCallback = async () =>
            {
                await Task.Delay(1000);
                namedStreamWState.GetDataForNamed().isLoading = false;
                return KeysSuccessUtility.sUCCESS;
            };
            rwtMode = new RWTMode(
                EnumRWTMode.test,
                [
                    new NamedCallback("init",initReleaseCallback),
                ],
                [
                    new NamedCallback("init",initTestCallback),
                ]);
            Init();
            Build();
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
        Title = "ExampleWindow";
        Height = 400;
        Width = 600;
        MinHeight = 400;
        MinWidth = 600;
        MaxHeight = 400;
        MaxWidth = 600;
        Icon = BitmapFrame.Create(new Uri(@"../build/Assets/Icon/CoinsDollar32.ico",UriKind.RelativeOrAbsolute));
        ResizeMode = ResizeMode.NoResize;
        WindowState = WindowState.Normal; 
        namedStreamWState?.ListenStreamDataForNamedFromCallback((_data) =>
        {
            Build();
        });
        var callback = await rwtMode?.GetNamedCallbackFromName("init").callback();
        Utility.DebugPrint($"ExampleWindowVM: {callback}");
        namedStreamWState?.NotifyStreamDataForNamed();
    }
    
    private void Build() 
    {
        var dataForNamed = namedStreamWState?.GetDataForNamed();
        switch(dataForNamed?.GetEnumDataForNamed()) 
        {
            case EnumDataForExampleWindowVM.isLoading:
                Grid gridWIsLoading = new();
                gridWIsLoading.Children.Add(new Ellipse() {
                    Width = 50,
                    Height = 50,
                    Fill = new SolidColorBrush(Colors.Black),
                    VerticalAlignment = VerticalAlignment.Center
                });
                Content = gridWIsLoading;
                break;
            case EnumDataForExampleWindowVM.exception:
                Grid gridWException = new();
                gridWException.Children.Add(new TextBlock() {
                    Text = dataForNamed.exceptionController.GetKeyParameterException(),
                    FontSize = 16.0,
                    Foreground = new SolidColorBrush(Colors.Black)
                });
                Content = gridWException;
                break;
            case EnumDataForExampleWindowVM.success:
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
}   