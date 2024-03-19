using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
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

    private void InitBuildWhereWindow() 
    {
        Title = "ExampleBlyad";
        Height = 600;
        Width = 800;
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
}